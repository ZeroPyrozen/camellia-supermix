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
    public class Particles : StoryboardObjectGenerator
    {
        private double BeatDuration;

        public override void Generate()
        {
            BeatDuration = Beatmap.GetTimingPointAt(0).BeatDuration;

            GenerateMovingUpParticles(-BeatDuration * 12, AudioDuration);
        }

        private void GenerateMovingUpParticles(double startTime, double endTime, double particleDuration = 2000,
            int particleAmout = 16)
        {
            var timestep = particleDuration / particleAmout;
            using (var pool = new OsbSpritePool(GetLayer(""), "sb/d.png", OsbOrigin.Centre,
                       (sprite, spriteStartTime, spriteEndTime) => { sprite.Scale(startTime, Random(0.02f, 0.05f)); }))
            {
                for (double spriteStartTime = startTime; spriteStartTime < endTime; spriteStartTime += timestep)
                {
                    var moveSpeed = Random(40, 120);
                    var spriteEndTime = spriteStartTime + Math.Ceiling(480f / moveSpeed) * particleDuration;
                    var sprite = pool.Get(spriteStartTime, spriteEndTime);

                    var startX = Random(-107, 747f);
                    sprite.MoveX(spriteStartTime, spriteEndTime, startX, startX + Random(-50, 50f));
                    sprite.MoveY(spriteStartTime, spriteEndTime, 482, 240 - moveSpeed);

                    sprite.Fade(spriteStartTime, spriteStartTime + 100, 0, 1);
                    sprite.Fade(OsbEasing.InSine, spriteStartTime + 100, spriteEndTime, 1, 0);
                    sprite.Additive(spriteStartTime, spriteEndTime);
                }
            }
        }
    }
}