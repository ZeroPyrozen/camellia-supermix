using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Subtitles;

namespace StorybrewScripts
{
    public class CamelliaSupermix : StoryboardObjectGenerator
    {
        private FontGenerator mapperFontGenerator;
        private FontGenerator titleFontGenerator;

        public override void Generate()
        {
            Initialization();
            SlideShow("Blackmagik Blazing.jpg", 377, 30965, "Lúin Øf CeltchaЯ", "Capu");
            SlideShow("60+3+10k.jpg", 30965, 56548, "Newspapers for Magicians", "Dusk");
            SlideShow("U.U.F.O..jpg", 56548, 87413, "We Magicians Still Alive in 2021", "Capu");
            SlideShow("U.U.F.O..jpg", 87348, 118510, "CICADA3302", "JarvisGaming");
            SlideShow("heart of android.jpg", 118510, 131283, "Alone Intelligence", "Ph0eNiiXZ");
            SlideShow("Blackmagik Blazing.jpg", 131283, 155333, "We Could Get More Machinegun\nPsystyle! (And More Genre Switches)", "Hivie");
            SlideShow("Blackmagik Blazing.jpg", 155333, 179333, "KillerBeast", "rubies87");
            SlideShow("crystallized.jpg", 179333, 201789, "First Town Of This Journey", "rubies87");
            SlideShow("crystallized.jpg", 201789, 223878, "Crystallized", "Hivie");
            SlideShow("U.U.F.O..jpg", 223792, 246445, "KillerToy", "JarvisGaming");
            SlideShow("U.U.F.O..jpg", 246357, 257231, "WYSI (When You See It)", "Ph0eNiiXZ");
            SlideShow("Blackmagik Blazing.jpg", 257149, 276490, "Arche", "Dusk");
            SlideShow("heart of android.jpg", 276415, 295676, "Tojita Sekai", "rubies87");
            SlideShow("OmegaParts.jpg", 295676, 333139, "ΩΩPARTS", "Axer");
            SlideShow("Blackmagik Blazing.jpg", 333139, 350604, "Secret Boss", "Ph0eNiiXZ");
            SlideShow("OmegaParts.jpg", 350604, 412956, "ΩΩPARTS", "Axer");
        }

        void Initialization()
        {
            double beatDuration = GetBeatDuration(0);

            var playfieldBar = GetLayer("Playfield").CreateSprite("sb/p.png", OsbOrigin.TopLeft, new Vector2(-107, 139));
            playfieldBar.Fade(0, 1);
            playfieldBar.Fade(417086, 0);
            playfieldBar.ScaleVec(OsbEasing.OutExpo, 0, beatDuration * 3, 0, 116, 854, 116);
            playfieldBar.Color(0, Color4.Black);

            var backgroundOverlay = GetLayer("BackgroundOverlay").CreateSprite("sb/p.png", OsbOrigin.Centre, new Vector2(320, 240));
            backgroundOverlay.Fade(0, 0.45);
            backgroundOverlay.Fade(417086, 0);
            backgroundOverlay.ScaleVec(0, 854, 480);
            backgroundOverlay.Color(0, Color4.Black);

            var timeBar = GetLayer("Playfield").CreateSprite("sb/p.png", OsbOrigin.BottomLeft, new Vector2(-107, 139));
            timeBar.Fade(0, 0.4);
            timeBar.Fade(412956, 0);
            timeBar.Additive(0, 412956);
            timeBar.ScaleVec(377, 417086, 0, 5, 854, 5);

            OsbSprite gradient = GetLayer("Gradient").CreateSprite("sb/grad.png", OsbOrigin.CentreRight, new Vector2(210, 328));
            gradient.ScaleVec(OsbEasing.OutExpo, beatDuration * 0.75, beatDuration * 2.75, 0, 0.6, 0.05, 0.6);
            gradient.Fade(0, 0.25);
            gradient.Fade(412956, 0);
            gradient.Additive(0, 412956);
            gradient.FlipH(0, 412956);

            OsbSprite verticalLine = GetLayer("Gradient").CreateSprite("sb/p.png", OsbOrigin.CentreLeft, new Vector2(210, 328));
            verticalLine.ScaleVec(OsbEasing.OutExpo, 0, beatDuration * 2, 2, 0, 2, 60);
            verticalLine.Fade(0, 1);
            verticalLine.Fade(412956, 0);

            OsbSprite solid = GetLayer("Solid").CreateSprite("sb/p.png");
            solid.ScaleVec(-4705, 854, 480);
            solid.Fade(-4705, 1);
            solid.Fade(377, 0);
            solid.Fade(412956, 1);
            solid.Fade(435044, 0);
            solid.Color(412956, Color4.Black);

            mapperFontGenerator = LoadFont("sb/f/m", new FontDescription
            {
                Color = Color4.White,
                Debug = false,
                EffectsOnly = false,
                FontPath = "fonts/Monorale-Regular.otf",
                FontSize = 60,
                FontStyle = System.Drawing.FontStyle.Regular,
                Padding = Vector2.Zero,
                TrimTransparency = true
            });

            titleFontGenerator = LoadFont("sb/f/t", new FontDescription
            {
                Color = Color4.White,
                Debug = false,
                EffectsOnly = false,
                FontPath = "fonts/#9Slide03 Montserrat SemiBold.ttf",
                FontSize = 60,
                FontStyle = System.Drawing.FontStyle.Regular,
                Padding = Vector2.Zero,
                TrimTransparency = true
            });
        }

        void SlideShow(string albumImage, double startTime, double endTime, string songTitle, string mapper)
        {
            var album = GetLayer("Metadata").CreateSprite("sb/a/" + albumImage, OsbOrigin.CentreLeft, new Vector2(12, 367.5f));
            album.Fade(startTime, 1);
            album.Fade(endTime, 0);
            album.Scale(startTime, 0.25);

            if (songTitle.Contains("\n"))
            {
                string[] songTitleSplit = songTitle.Split('\n');

                GenerateText("title", songTitleSplit[0], startTime, endTime, new Vector2(218, 288), 0.25f);
                GenerateText("title", songTitleSplit[1], startTime, endTime, new Vector2(218, 312), 0.15f);
            }
            else
            {
                GenerateText("title", songTitle, startTime, endTime, new Vector2(218, 288), 0.4f);
            }

            GenerateText("mapper", mapper, startTime, endTime, new Vector2(218, 330), 0.3f);
        }

        private void GenerateText(string type, string sentence, double startTime, double endTime, Vector2 startPosition, float fontScale = 0.35f)
        {
            FontGenerator fontGenerator = GetFontGenerator(type);
            float letterX = startPosition.X;
            double delay = 0;
            double beatDuration = GetBeatDuration(startTime);

            foreach (char letter in sentence)
            {
                FontTexture texture = fontGenerator.GetTexture(letter.ToString());
                if (!texture.IsEmpty)
                {
                    Vector2 position = new Vector2(letterX, startPosition.Y) + texture.OffsetFor(OsbOrigin.CentreLeft) * fontScale;
                    OsbSprite sprite = GetLayer("Metadata").CreateSprite(texture.Path, OsbOrigin.CentreLeft, position);

                    // In animation
                    sprite.MoveX(OsbEasing.OutExpo, startTime + delay, startTime + delay + beatDuration * 4, startPosition.X, position.X);
                    sprite.ScaleVec(OsbEasing.OutExpo, startTime + delay, startTime + delay + beatDuration * 3, 0, fontScale, fontScale, fontScale);
                    sprite.Fade(startTime + delay, startTime + delay + beatDuration * 2, 0, 1);

                    // Out animation
                    sprite.MoveX(OsbEasing.InExpo, endTime - delay - beatDuration * 4, endTime - delay, position.X, startPosition.X);
                    sprite.ScaleVec(OsbEasing.InExpo, endTime - delay - beatDuration * 3, endTime - delay, fontScale, fontScale, 0, fontScale);
                    sprite.Fade(endTime - delay - beatDuration * 2, endTime - delay, 1, 0);

                    delay += beatDuration / 24;
                }

                letterX += texture.BaseWidth * fontScale;
            }
        }

        private FontGenerator GetFontGenerator(string type)
        {
            switch (type)
            {
                case "title":
                    return titleFontGenerator;

                default:
                    return mapperFontGenerator;
            }
        }

        private double GetBeatDuration(double time)
            => Beatmap.GetTimingPointAt((int)time).BeatDuration;
    }
}
