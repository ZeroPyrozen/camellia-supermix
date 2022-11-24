using OpenTK;
using OpenTK.Graphics;
using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;

namespace StorybrewScripts
{
    public class SwipeTransition : StoryboardObjectGenerator
    {
        [Configurable]
        public Color4 Colour1;
        [Configurable]
        public Color4 Colour2;
        [Configurable]
        public Color4 Colour3;
        [Configurable]
        public Color4 Colour4;
        [Configurable]
        public Color4 Colour5;
        [Configurable]
        public Color4 Colour6;
        public override void Generate()
        {
            /*
            Colour Assignment
            Colour 1 = Blackmagik Blazing
            Colour 2 = 60+3+10k
            Colour 3 = U.U.F.O.
            Colour 4 = heart of android
            Colour 5 = crystallized
            Colour 6 = OmegaParts
            */
            SpawnSwipeTransition(30965, Colour2);
            SpawnSwipeTransition(56548, Colour3);
            SpawnSwipeTransition(87348, Colour3);
            SpawnSwipeTransition(118510, Colour4);
            SpawnSwipeTransition(131283, Colour1);
            SpawnSwipeTransition(155333, Colour1);
            SpawnSwipeTransition(179333, Colour5);
            SpawnSwipeTransition(201789, Colour5);
            SpawnSwipeTransition(223878, Colour3);
            SpawnSwipeTransition(246445, Colour3);
            SpawnSwipeTransition(257149, Colour1);
            SpawnSwipeTransition(276415, Colour4);
            SpawnSwipeTransition(295676, Colour6);
            SpawnSwipeTransition(333139, Colour1);
            SpawnSwipeTransition(350604, Colour6);
            SpawnSwipeTransition(412956, Color4.Black);
        }

        void SpawnSwipeTransition(int time, Color4 customColor)
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
