using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using System;
using System.Drawing;

namespace StorybrewScripts
{
    public class Particles : StoryboardObjectGenerator
    {
        private double beatDuration;

        public override void Generate()
        {
            Initialize();

            GenerateMovingUpParticles("sb/d.png", -beatDuration * 12, 413021);
            GenerateHorizontalMovingParticles("sb/d.png", 0, 413021);
            GenerateSpectrumParticles("sb/d.png", 0, 413021);
        }

        private void Initialize()
        {
            beatDuration = Beatmap.GetTimingPointAt(0).BeatDuration;
        }

        private void GenerateMovingUpParticles(string texturePath, double startTime, double endTime, double particleDuration = 2000, int particleAmount = 24)
        {
            Bitmap bitmap = GetMapsetBitmap(texturePath);
            double timestep = particleDuration / particleAmount;

            using (OsbSpritePool pool = new OsbSpritePool(GetLayer(""), texturePath, OsbOrigin.Centre,
                       (sprite, spriteStartTime, spriteEndTime) => { sprite.Scale(spriteStartTime, Random(0.02f, 0.05f)); }))
            {
                pool.MaxPoolDuration = 72727;

                for (double spriteStartTime = startTime; spriteStartTime < endTime; spriteStartTime += timestep)
                {
                    float moveSpeed = Random(40f, 120f);
                    double spriteEndTime = spriteStartTime + Math.Ceiling(480f / moveSpeed) * particleDuration;
                    OsbSprite sprite = pool.Get(spriteStartTime, spriteEndTime);

                    float startX = Random(-107f, 747f);
                    sprite.MoveX(spriteStartTime, spriteEndTime, startX, startX + Random(-50, 50f));
                    sprite.MoveY(spriteStartTime, spriteEndTime, 480 + bitmap.Height * 0.05f, bitmap.Height * 0.05f);

                    sprite.Fade(spriteStartTime, spriteStartTime + 100, 0, 1);
                    sprite.Fade(OsbEasing.InSine, spriteStartTime + 100, spriteEndTime, 1, 0);
                    sprite.Additive(spriteStartTime, spriteEndTime);
                }
            }
        }

        private void GenerateHorizontalMovingParticles(string texturePath, double startTime, double endTime, double particleDuration = 2200, int particleAmount = 16)
        {
            double timestep = particleDuration / particleAmount;

            using (OsbSpritePool pool = new OsbSpritePool(GetLayer(""), texturePath, OsbOrigin.Centre,
                       (sprite, spriteStartTime, spriteEndTime) => { sprite.Scale(spriteStartTime, Random(0.01f, 0.03f)); }))
            {
                pool.MaxPoolDuration = 72727;

                for (double spriteStartTime = startTime; spriteStartTime < endTime; spriteStartTime += timestep)
                {
                    float moveSpeed = Random(40f, 120f);
                    double spriteEndTime = spriteStartTime + Math.Ceiling(40f / moveSpeed) * particleDuration;
                    OsbSprite sprite = pool.Get(spriteStartTime, spriteEndTime);

                    float startY = Random(300f, 358f);
                    sprite.MoveX(spriteStartTime, spriteEndTime, 210, 210 - Random(10f, 40f));
                    sprite.MoveY(OsbEasing.InSine, spriteStartTime, spriteEndTime, startY, startY + Random(-5f, 5f));

                    sprite.Fade(spriteStartTime, spriteStartTime + 200, 0, 1);
                    sprite.Fade(OsbEasing.InSine, spriteStartTime + 200, spriteEndTime, 1, 0);
                    sprite.Additive(spriteStartTime, spriteEndTime);
                }
            }
        }

        private void GenerateSpectrumParticles(string texturePath, double startTime, double endTime, double particleDuration = 3200, int particleAmount = 12)
        {
            double timestep = particleDuration / particleAmount;

            using (OsbSpritePool pool = new OsbSpritePool(GetLayer(""), texturePath, OsbOrigin.Centre,
                       (sprite, spriteStartTime, spriteEndTime) => { sprite.Scale(spriteStartTime, Random(0.01f, 0.04f)); }))
            {
                pool.MaxPoolDuration = 72727;

                for (double spriteStartTime = startTime; spriteStartTime < endTime; spriteStartTime += timestep)
                {
                    float moveSpeed = Random(40f, 120f);
                    double spriteEndTime = spriteStartTime + Math.Ceiling(80f / moveSpeed) * particleDuration;
                    OsbSprite sprite = pool.Get(spriteStartTime, spriteEndTime);

                    float startX = Random(194f, 602f);
                    sprite.MoveX(spriteStartTime, spriteEndTime, startX, startX + Random(-50, 50f));
                    sprite.MoveY(OsbEasing.InSine, spriteStartTime, spriteEndTime, 364, 470);

                    sprite.Fade(spriteStartTime, spriteStartTime + 200, 0, 1);
                    sprite.Fade(OsbEasing.InSine, spriteStartTime + 200, spriteEndTime, 1, 0);
                    sprite.Additive(spriteStartTime, spriteEndTime);
                }
            }
        }
    }
}
