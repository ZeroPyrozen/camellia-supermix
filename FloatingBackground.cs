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
    public class FloatingBackground : StoryboardObjectGenerator
    {
        public override void Generate()
        {
		    SpawnFloatingBackground("sb/b/Blackmagik Blazing.jpg", 0, 30965);
            SpawnFloatingBackground("sb/b/60+3+10k.jpg", 30965, 56548);
            SpawnFloatingBackground("sb/b/U.U.F.O..jpg", 56548, 87413);
            SpawnFloatingBackground("sb/b/U.U.F.O..jpg", 87348, 118510);
            SpawnFloatingBackground("sb/b/heart of android.jpg", 118510, 131283);
            SpawnFloatingBackground("sb/b/Blackmagik Blazing.jpg", 131283, 155333);
            SpawnFloatingBackground("sb/b/Blackmagik Blazing.jpg", 155333, 179333);
            SpawnFloatingBackground("sb/b/crystallized.jpg", 179333, 201789);
            SpawnFloatingBackground("sb/b/crystallized.jpg", 201789, 223878);
            SpawnFloatingBackground("sb/b/U.U.F.O..jpg", 223792, 246445);
            SpawnFloatingBackground("sb/b/U.U.F.O..jpg", 246357, 257231);
            SpawnFloatingBackground("sb/b/Blackmagik Blazing.jpg", 257149, 276490);
            SpawnFloatingBackground("sb/b/heart of android.jpg", 276415, 295676);
            SpawnFloatingBackground("sb/b/OmegaParts.jpg", 295676, 333139);
            SpawnFloatingBackground("sb/b/Blackmagik Blazing.jpg", 333139, 350604);
            SpawnFloatingBackground("sb/b/OmegaParts.jpg", 350604, 412956, floatingDistance:2);
        }

        void SpawnFloatingBackground(string imagePath, int startTime, int endTime, int floatingDistance=5, double beatDivisor=0.25, double customScale=0)
        {
            var duration = Beatmap.GetTimingPointAt(startTime).BeatDuration / beatDivisor;
		    var background = GetLayer("FloatingBackground").CreateSprite(imagePath, OsbOrigin.Centre);
            double x = 320;
            double y = 240;
            double rad = 0;
            double x1 = x + Random(-floatingDistance, floatingDistance);
            double y1 = y + Random(-floatingDistance, floatingDistance);
            double rad1 = rad + Random(-0.020, 0.020);
            int a = 1;

            background.Fade(startTime, 1);
            background.Scale(startTime, customScale==0?Math.Max(854.0 / 640.0, 480.0 / 640.0) + 0.2:customScale);

            for(double i = startTime; i <= endTime - (double)duration; i += (double)duration)
            {
                background.Move(OsbEasing.InOutSine, i, i + duration, x, y, x1, y1);
                background.Rotate(OsbEasing.InOutSine, i, i + duration, rad, rad1);
                x = x1;
                y = y1;
                rad = rad1;
                a++;
                x1 = x + Random(-floatingDistance, floatingDistance);
                y1 = y + Random(-floatingDistance, floatingDistance);
                rad1 = rad + Random(0, 0.020) * Math.Pow(-1, a);
            }

            background.Fade(endTime, 0);
        }
    }
}
