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
        public override void Generate()
        {
            Initialization();
            SlideShow("Blackmagik Blazing.jpg", 0, 30965, "Lúin Øf CeltchaЯ", "Capu");
            SlideShow("60+3+10k.jpg", 30965, 56548, "Newspapers for Magicians", "Dusk");
            SlideShow("U.U.F.O..jpg", 56548, 87413, "We Magicians Still Alive in 2021", "Capu");
            SlideShow("U.U.F.O..jpg", 87348, 118510, "CICADA3302", "JarvisGaming");
            SlideShow("heart of android.jpg", 118510, 131283, "Alone Intelligence", "Ph0eNiiXZ");
            SlideShow("Blackmagik Blazing.jpg", 131283, 155333, "We Could Get More Machinegun      \nPsystyle! (And More Genre Switches)", "Hivie");
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
        }
    }
}
