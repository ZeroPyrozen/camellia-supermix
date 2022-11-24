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
    public class Timeline : StoryboardObjectGenerator
    {
        [Configurable]
        public string LinePath = "sb/p.png";
        [Configurable]
        public Vector2 TopLeftPosition = new Vector2(-107, 0);
        [Configurable]
        public Vector2 BottomRightPosition = new Vector2(747, 480);
        [Configurable]
        public double LineOpacity = 1;
        [Configurable]
        public int LineThickness = 5;
        [Configurable]
        public bool Additive = true;
        [Configurable]
        public int BeatDivisor = 4;
        public override void Generate()
        {
            /*
            var TopLeft = new Vector2(2, 278);
            var BottomRight = new Vector2(182, 458);
            */
            SpawnTimeline(0, 30965);
            SpawnTimeline(30965, 56548);
            SpawnTimeline(56548, 87413);
            SpawnTimeline(87348, 118510);
            SpawnTimeline(118510, 131283);
            SpawnTimeline(131283, 155333);
            SpawnTimeline(155333, 179333);
            SpawnTimeline(179333, 201789);
            SpawnTimeline(201789, 223878);
            SpawnTimeline(223792, 246445);
            SpawnTimeline(246357, 257231);
            SpawnTimeline(257149, 276490);
            SpawnTimeline(276415, 295676);
            SpawnTimeline(295676, 333139);
            SpawnTimeline(333139, 350604);
            SpawnTimeline(350604, 412956);
        }

        void SpawnTimeline(int startTime, int endTime)
        {
            var beatDuration = Beatmap.GetTimingPointAt(startTime).BeatDuration / BeatDivisor;
            var topLine = GetLayer("Timeline").CreateSprite(LinePath, OsbOrigin.TopLeft, TopLeftPosition);
            var bottomLine = GetLayer("Timeline").CreateSprite(LinePath, OsbOrigin.BottomRight, BottomRightPosition);
            var leftLine = GetLayer("Timeline").CreateSprite(LinePath, OsbOrigin.TopLeft, new Vector2(TopLeftPosition.X, TopLeftPosition.Y + LineThickness));
            var rightLine = GetLayer("Timeline").CreateSprite(LinePath, OsbOrigin.BottomRight, new Vector2(BottomRightPosition.X, BottomRightPosition.Y - LineThickness));

            var horizontalLength = BottomRightPosition.X - TopLeftPosition.X;
            var verticalLength = BottomRightPosition.Y - TopLeftPosition.Y;

            topLine.Fade(startTime, LineOpacity);
            topLine.Fade(endTime + beatDuration, 0);
            topLine.ScaleVec(OsbEasing.None, startTime, endTime, LineThickness, LineThickness, horizontalLength, LineThickness);
            topLine.ScaleVec(OsbEasing.In, endTime+10, endTime + beatDuration, horizontalLength, LineThickness, horizontalLength, 0);

            bottomLine.Fade(startTime, LineOpacity);
            bottomLine.Fade(endTime + beatDuration, 0);
            bottomLine.ScaleVec(OsbEasing.None, startTime, endTime, LineThickness, LineThickness, horizontalLength, LineThickness);
            bottomLine.ScaleVec(OsbEasing.In, endTime+10, endTime + beatDuration, horizontalLength, LineThickness, horizontalLength, 0);

            leftLine.Fade(startTime, LineOpacity);
            leftLine.Fade(endTime + beatDuration, 0);
            leftLine.ScaleVec(OsbEasing.None, startTime, endTime, LineThickness, 0, LineThickness, verticalLength - LineThickness*2);
            leftLine.ScaleVec(OsbEasing.In, endTime+10, endTime + beatDuration, LineThickness, verticalLength - LineThickness*2, 0, verticalLength - LineThickness*2);

            rightLine.Fade(startTime, LineOpacity);
            rightLine.Fade(endTime + beatDuration, 0);
            rightLine.ScaleVec(OsbEasing.None, startTime, endTime, LineThickness, 0, LineThickness, verticalLength - LineThickness*2);
            rightLine.ScaleVec(OsbEasing.In, endTime+10, endTime + beatDuration, LineThickness, verticalLength - LineThickness*2, 0, verticalLength - LineThickness*2);
        }
    }
}
