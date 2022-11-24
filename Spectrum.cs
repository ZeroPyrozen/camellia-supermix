using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Animations;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using System;
using System.Drawing;

namespace StorybrewScripts
{
    /// <summary>
    /// An example of a spectrum effect.
    /// </summary>
    public class Spectrum : StoryboardObjectGenerator
    {
        [Configurable]
        public int StartTime = 0;

        [Configurable]
        public int EndTime = 10000;

        [Configurable]
        public Vector2 Position = new Vector2(0, 400);

        [Configurable]
        public int Gap = 0;

        [Configurable]
        public float Width = 640;

        [Configurable]
        public int BeatDivisor = 16;

        [Configurable]
        public int BarCount = 96;

        [Configurable]
        public string SpritePath = "sb/bar.png";

        [Configurable]
        public OsbOrigin SpriteOrigin = OsbOrigin.BottomLeft;

        [Configurable]
        public Vector2 Scale = new Vector2(1, 100);

        [Configurable]
        public int LogScale = 600;

        [Configurable]
        public double Tolerance = 0.2;

        [Configurable]
        public int CommandDecimals = 1;

        [Configurable]
        public float MinimalHeight = 0.05f;

        [Configurable]
        public OsbEasing FftEasing = OsbEasing.InExpo;

        [Configurable]
        public int FrequencyCutOff = 16000;

        private Bitmap bitmap;

        public override void Generate()
        {
            Initialize();

            GenerateSpectrum(377, 30965);
            GenerateSpectrum(30965, 56548);
            GenerateSpectrum(56548, 118510);
            GenerateSpectrum(118510, 131283);
            GenerateSpectrum(131283, 179333);
            GenerateSpectrum(179333, 223878);
            GenerateSpectrum(223878, 257149);
            GenerateSpectrum(257149, 295676);
            GenerateSpectrum(295676, 333139);
            GenerateSpectrum(295676, 350604);
            GenerateSpectrum(350604, 412956);
        }

        private void Initialize()
        {
            bitmap = GetMapsetBitmap(SpritePath);

            AddSpectrumHorizontalLine();
            AddSpectrumGradientBackground();
        }

        private void AddSpectrumHorizontalLine()
        {
            double beatDuration = GetBeatDuration(0);
            float spriteWidth = Width + (BarCount - 1) * Gap;

            OsbSprite sprite = GetLayer("Horizontal Line").CreateSprite("sb/p.png", OsbOrigin.BottomLeft, new Vector2(Position.X, Position.Y));
            sprite.ScaleVec(OsbEasing.OutExpo, 0, beatDuration * 2, spriteWidth, 0, spriteWidth, 3);
            sprite.Fade(0, 1);
            sprite.Fade(412956, 0);
        }

        private void AddSpectrumGradientBackground()
        {
            double beatDuration = GetBeatDuration(0);
            float spriteWidth = (Width + (BarCount - 1) * Gap) / GetMapsetBitmap("sb/grad.png").Height;

            OsbSprite sprite = GetLayer("Gradient").CreateSprite("sb/grad.png", OsbOrigin.BottomLeft, new Vector2(Position.X, Position.Y));
            sprite.ScaleVec(OsbEasing.OutExpo, 0, beatDuration * 2, 0, spriteWidth, 0.15, spriteWidth);
            sprite.Fade(0, 0.25);
            sprite.Fade(412956, 0);
            sprite.Additive(0, 412956);
            sprite.Rotate(0, Math.PI / 2);
        }

        private void GenerateSpectrum(double startTime, double endTime)
        {
            KeyframedValue<float>[] heightKeyframes = GetKeyframedValues(startTime, endTime, BarCount);
            float barWidth = Width / BarCount;

            for (int i = 0; i < BarCount; i++)
            {
                KeyframedValue<float> keyframes = heightKeyframes[i];
                keyframes.Simplify1dKeyframes(Tolerance, h => h);

                OsbSprite bar = GetLayer("Spectrum").CreateSprite(SpritePath, SpriteOrigin, new Vector2(Position.X + i * (barWidth + Gap), Position.Y));
                bar.CommandSplitThreshold = 300;
                bar.Color(startTime, Color4.White);
                bar.Fade(startTime, 1);
                bar.Fade(endTime, 0);
                // bar.Additive(startTime, endTime);

                float scaleX = Scale.X * barWidth / bitmap.Width;
                scaleX = (float)Math.Floor(scaleX * 10) / 10.0f;

                bool hasScale = false;
                keyframes.ForEachPair(
                    (start, end) =>
                    {
                        hasScale = true;
                        bar.ScaleVec(start.Time, end.Time,
                            scaleX, start.Value,
                            scaleX, end.Value);
                    },
                    MinimalHeight,
                    s => (float)Math.Round(s, CommandDecimals)
                );

                if (!hasScale)
                {
                    bar.ScaleVec(StartTime, scaleX, MinimalHeight);
                }
            }
        }

        private KeyframedValue<float>[] GetKeyframedValues(double startTime, double endTime, int barCount)
        {
            KeyframedValue<float>[] keyframes = new KeyframedValue<float>[barCount];
            for (int i = 0; i < barCount; i++)
            {
                keyframes[i] = new KeyframedValue<float>(null);
            }

            double fftTimeStep = GetBeatDuration(startTime) / BeatDivisor;
            double fftOffset = fftTimeStep * 0.2;
            for (double time = startTime; time < endTime; time += fftTimeStep)
            {
                float[] fft = GetFft(time + fftOffset, barCount, null, FftEasing);
                for (int i = 0; i < barCount; i++)
                {
                    float height = (float)Math.Log10(1 + fft[i] * LogScale) * Scale.Y / bitmap.Height;
                    if (height < MinimalHeight)
                    {
                        height = MinimalHeight;
                    }

                    keyframes[i].Add(time, height);
                }
            }

            return keyframes;
        }

        private double GetBeatDuration(double time)
            => Beatmap.GetTimingPointAt((int)time).BeatDuration;
    }
}
