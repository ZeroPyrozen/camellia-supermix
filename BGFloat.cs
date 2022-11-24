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
using System.Drawing;
using System.IO;

namespace StorybrewScripts
{
    public class BGFloat : StoryboardObjectGenerator
    {
        [Configurable]
        public string FilePath = "bg.jpg";

        [Configurable]
        public int StartTime = 0;
        
        [Configurable]
        public int EndTime = 1000;

        [Configurable]
        public double Distance = 10;

        [Configurable]
        public double Scale = 0.5;

        [Configurable]
        public double BeatDivisor = 4;

        [Configurable]
        public bool ReturnToNormal = true;
        public override void Generate()
        {
            var time_lag = Beatmap.GetTimingPointAt(StartTime).BeatDuration / BeatDivisor;
		    var BG = GetLayer("").CreateSprite(FilePath, OsbOrigin.Centre);
            BG.Fade(StartTime, 1);
            BG.Scale(StartTime, Scale);
            double x = 320;
            double y = 240;
            double rad = 0;
            double x1 = x + Random(-Distance, Distance);
            double y1 = y + Random(-Distance, Distance);
            double rad1 = rad + Random(-0.020, 0.020);
            int a = 1;
            for(double i = StartTime; i <= EndTime - (double)time_lag; i += (double)time_lag)
            {
                BG.Move(OsbEasing.InOutSine, i, i + time_lag, x, y, x1, y1);
                BG.Rotate(OsbEasing.InOutSine, i, i + time_lag, rad, rad1);
                x = x1;
                y = y1;
                rad = rad1;
                a++;
                x1 = x + Random(-10, 10);
                y1 = y + Random(-10, 10);
                rad1 = rad + Random(0, 0.020) * Math.Pow(-1, a);
            }
                
            if(ReturnToNormal)
            {
                BG.Scale(EndTime - (double)time_lag / 2, EndTime, 0.6, 0.444791655);
                BG.Move(EndTime - (double)time_lag / 2, EndTime, x, y, 320, 240);
                BG.Rotate(EndTime - (double)time_lag / 2, EndTime, rad, 0);
            }
        }
    }
}
