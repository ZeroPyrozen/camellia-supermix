using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Mapset;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;
using StorybrewCommon.Storyboarding.Util;
using StorybrewCommon.Subtitles;
using StorybrewCommon.Util;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorybrewScripts
{
    public class CamelliaSupermix : StoryboardObjectGenerator
    {
        FontGenerator collabNameGenerator;
        FontGenerator songTitleGenerator;
        Color4 capu;
        Color4 dusk;
        Color4 jarvisGaming;
        Color4 ph0eniixz;
        Color4 hivie;
        Color4 rubies87;
        Color4 axer;
        public override void Generate()
        {
            Initialization();
            Timeline(0, 30965);
            SlideShow("Blackmagik Blazing.jpg", 0, 30965, "Lúin Øf CeltchaЯ", "Capu");
            SwipeTransition(30965, dusk);
            Timeline(30965, 56548);
            SlideShow("60+3+10k.jpg", 30965, 56548, "Newspapers for Magicians", "Dusk");
            SwipeTransition(56548, capu);
            Timeline(56548, 87413);
            SlideShow("U.U.F.O..jpg", 56548, 87413, "We Magicians Still Alive in 2021", "Capu");
            SwipeTransition(87348, jarvisGaming);
            Timeline(87348, 118510);
            SlideShow("U.U.F.O..jpg", 87348, 118510, "CICADA3302", "JarvisGaming");
            SwipeTransition(118510, ph0eniixz);
            Timeline(118510, 131283);
            SlideShow("heart of android.jpg", 118510, 131283, "Alone Intelligence", "Ph0eNiiXZ");
            SwipeTransition(131283, hivie);
            Timeline(131283, 155333);
            SlideShow("Blackmagik Blazing.jpg", 131283, 155333, "We Could Get More Machinegun      \nPsystyle! (And More Genre Switches)", "Hivie");
            SwipeTransition(155333, rubies87);
            Timeline(155333, 179333);
            SlideShow("Blackmagik Blazing.jpg", 155333, 179333, "KillerBeast", "rubies87");
            SwipeTransition(179333, rubies87);
            Timeline(179333, 201789);
            SlideShow("crystallized.jpg", 179333, 201789, "First Town Of This Journey", "rubies87");
            SwipeTransition(201789, hivie);
            Timeline(201789, 223878);
            SlideShow("crystallized.jpg", 201789, 223878, "Crystallized", "Hivie");
            SwipeTransition(223878, jarvisGaming);
            Timeline(223792, 246445);
            SlideShow("U.U.F.O..jpg", 223792, 246445, "KillerToy", "JarvisGaming");
            SwipeTransition(246445, ph0eniixz);
            Timeline(246357, 257231);
            SlideShow("U.U.F.O..jpg", 246357, 257231, "WYSI (When You See It)", "Ph0eNiiXZ");
            SwipeTransition(257149, dusk);
            Timeline(257149, 276490);
            SlideShow("Blackmagik Blazing.jpg", 257149, 276490, "Arche", "Dusk");
            SwipeTransition(276415, rubies87);
            Timeline(276415, 295676);
            SlideShow("heart of android.jpg", 276415, 295676, "Tojita Sekai", "rubies87");
            SwipeTransition(295676, axer);
            Timeline(295676, 333139);
            SlideShow("OmegaParts.jpg", 295676, 333139, "ΩΩPARTS", "Axer");
            SwipeTransition(333139, ph0eniixz);
            Timeline(333139, 350604);
            SlideShow("Blackmagik Blazing.jpg", 333139, 350604, "Secret Boss", "Ph0eNiiXZ");
            SwipeTransition(350604, axer);
            Timeline(350604, 412956);
            SlideShow("OmegaParts.jpg", 350604, 412956, "ΩΩPARTS", "Axer");
            SwipeTransition(412956, Color4.Black);
        }

        void Initialization()
        {
            var playfieldBar = GetLayer("Playfield").CreateSprite("sb/p.png", OsbOrigin.TopLeft, new Vector2(-107, 139));
            playfieldBar.Fade(0, 1);
            playfieldBar.Fade(417086, 0);
            playfieldBar.ScaleVec(OsbEasing.OutExpo, 0, 377, 0, 116, 854, 116);
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

            collabNameGenerator = LoadFont("sb/c", new FontDescription{
                Color = Color4.White,
                Debug = false,
                EffectsOnly = false,
                FontPath = "Plus Jakarta Sans",
                FontSize = 22,
                FontStyle = System.Drawing.FontStyle.Regular,
                Padding = Vector2.Zero,
                TrimTransparency = true
            });

            songTitleGenerator = LoadFont("sb/m", new FontDescription{
                Color = Color4.White,
                Debug = false,
                EffectsOnly = false,
                FontPath = "#9Slide03 Montserrat SemiBold",
                FontSize = 36,
                FontStyle = System.Drawing.FontStyle.Regular,
                Padding = Vector2.Zero,
                TrimTransparency = true
            });

            capu = new Color4(178, 24, 43, 1);
            dusk = new Color4(239, 138, 98, 1);
            jarvisGaming = new Color4(253, 219, 199, 1);
            ph0eniixz = new Color4(247, 247, 247, 1);
            hivie = new Color4(209, 229, 240, 1);
            rubies87 = new Color4(103, 169, 207, 1);
            axer = new Color4(33, 102, 172, 1);
        }

        void Timeline(int startTime, int endTime)
        {
            var beatDuration = Beatmap.GetTimingPointAt(startTime).BeatDuration / 4;
            double lineOpacity = 0.4;
            var upperLeftCornerPosition = new Vector2(2, 278);
            var bottomRightCornerPosition = new Vector2(182, 458);
            var lineThickness = 5;
            var lineLength = 180;
            var secondaryLeftCornerPosition = new Vector2(upperLeftCornerPosition.X, upperLeftCornerPosition.Y + lineThickness);
            var secondaryRightCornerPosition = new Vector2(bottomRightCornerPosition.X, bottomRightCornerPosition.Y - lineThickness);

            var upperLine2 = GetLayer("TimelineExp").CreateSprite("sb/p.png", OsbOrigin.TopLeft, upperLeftCornerPosition);
            var lowerLine2 = GetLayer("TimelineExp").CreateSprite("sb/p.png", OsbOrigin.BottomRight, bottomRightCornerPosition);
            var leftLine2 = GetLayer("TimelineExp").CreateSprite("sb/p.png", OsbOrigin.TopLeft, secondaryLeftCornerPosition);
            var rightLine2 = GetLayer("TimelineExp").CreateSprite("sb/p.png", OsbOrigin.BottomRight, secondaryRightCornerPosition);

            upperLine2.Fade(startTime, lineOpacity);
            upperLine2.Fade(endTime + beatDuration, 0);
            upperLine2.ScaleVec(OsbEasing.None, startTime, endTime, lineThickness, lineThickness, lineLength, lineThickness);
            upperLine2.ScaleVec(OsbEasing.In, endTime+10, endTime + beatDuration, lineLength, lineThickness, lineLength, 0);

            lowerLine2.Fade(startTime, lineOpacity);
            lowerLine2.Fade(endTime + beatDuration, 0);
            lowerLine2.ScaleVec(OsbEasing.None, startTime, endTime, lineThickness, lineThickness, lineLength, lineThickness);
            lowerLine2.ScaleVec(OsbEasing.In, endTime+10, endTime + beatDuration, lineLength, lineThickness, lineLength, 0);

            leftLine2.Fade(startTime, lineOpacity);
            leftLine2.Fade(endTime + beatDuration, 0);
            leftLine2.ScaleVec(OsbEasing.None, startTime, endTime, lineThickness, 0, lineThickness, lineLength - lineThickness*2);
            leftLine2.ScaleVec(OsbEasing.In, endTime+10, endTime + beatDuration, lineThickness, lineLength - lineThickness*2, 0, lineLength - lineThickness*2);

            rightLine2.Fade(startTime, lineOpacity);
            rightLine2.Fade(endTime + beatDuration, 0);
            rightLine2.ScaleVec(OsbEasing.None, startTime, endTime, lineThickness, 0, lineThickness, lineLength - lineThickness*2);
            rightLine2.ScaleVec(OsbEasing.In, endTime+10, endTime + beatDuration, lineThickness, lineLength - lineThickness*2, 0, lineLength - lineThickness*2);

            upperLine2.Additive(startTime, endTime);
            lowerLine2.Additive(startTime, endTime);
            leftLine2.Additive(startTime, endTime);
            rightLine2.Additive(startTime, endTime);
        }

        void SlideShow(string albumImage, int startTime, int endTime, string songTitle, string collaborator)
        {
            var time_lag = Beatmap.GetTimingPointAt(startTime).BeatDuration / 0.25;
            var album = GetLayer("Metadata").CreateSprite("sb/a/"+albumImage, OsbOrigin.CentreLeft, new Vector2(12, 367.5f));
            album.Fade(startTime, 1);
            album.Fade(endTime, 0);
            album.Scale(startTime, 0.25);

            var collabText = collabNameGenerator.GetTexture(collaborator);
            var collabSprite = GetLayer("Metadata").CreateSprite(collabText.Path, OsbOrigin.BottomLeft, new Vector2(192, 445));
            collabSprite.Fade(startTime, 1);
            collabSprite.Scale(startTime, 0.75);
            collabSprite.Fade(endTime, 0);


            var songText = songTitleGenerator.GetTexture(songTitle);
            var songSprite = GetLayer("Metadata").CreateSprite(songText.Path, OsbOrigin.TopLeft, new Vector2(192, 288));
            songSprite.Fade(startTime, 1);
            if(songTitle.Length < "We Could Get More Machinegun      \nPsystyle! (And More Genre Switches)".Length)
            {
                if(songTitle.Length < "We Magicians Still Alive in 2021".Length)
                {
                    songSprite.Scale(startTime, 0.65);
                    collabSprite.MoveY(startTime, 345);
                } 
                else
                {
                    songSprite.Scale(startTime, 0.55);
                    collabSprite.MoveY(startTime, 345);
                }
                    
            }
            else    
            {
                songSprite.Scale(startTime, 0.45);
                collabSprite.MoveY(startTime, 380);
            }
            songSprite.Fade(endTime, 0);

            var distance = 5;
		    var background = GetLayer("Background").CreateSprite("sb/b/"+albumImage, OsbOrigin.Centre);
            background.Fade(startTime, 1);
            background.Scale(startTime, Math.Max(854.0 / 640.0, 480.0 / 640.0) + 0.2);
            double x = 320;
            double y = 240;
            double rad = 0;
            double x1 = x + Random(-distance, distance);
            double y1 = y + Random(-distance, distance);
            double rad1 = rad + Random(-0.020, 0.020);
            int a = 1;
            for(double i = startTime; i <= endTime - (double)time_lag; i += (double)time_lag)
            {
                background.Move(OsbEasing.InOutSine, i, i + time_lag, x, y, x1, y1);
                background.Rotate(OsbEasing.InOutSine, i, i + time_lag, rad, rad1);
                x = x1;
                y = y1;
                rad = rad1;
                a++;
                x1 = x + Random(-distance, distance);
                y1 = y + Random(-distance, distance);
                rad1 = rad + Random(0, 0.020) * Math.Pow(-1, a);
            }
            background.Fade(endTime, 0);
        }

        

        void SwipeTransition(int time, Color4 customColor)
        {
            string SpritePath = "sb/p.png";
            Color4 Color = customColor;
            var sprite = GetLayer("Transition").CreateSprite(SpritePath, OsbOrigin.Centre, new Vector2(320, 240));
            sprite.ScaleVec(OsbEasing.None, time - 800, time, 900, 700, 900, 700);
            sprite.Rotate(OsbEasing.None, time - 800, time, 0.2, 0.2);
            sprite.Move(OsbEasing.InExpo, time - 800, time, 1270, 240, 320, 240);
            sprite.Color(time, Color); 
             

            var sprite2 = GetLayer("Transition").CreateSprite(SpritePath, OsbOrigin.Centre, new Vector2(320, 240));
            sprite2.ScaleVec(OsbEasing.None, time, time + 800, 900, 700, 900, 700);
            sprite2.Rotate(OsbEasing.None, time, time + 800, 0.2, 0.2);
            sprite2.Move(OsbEasing.OutExpo, time, time + 800, 320, 240, -630, 240);
            sprite2.Color(time, Color);
        }
    }
}
