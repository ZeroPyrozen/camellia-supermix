using StorybrewCommon.Scripting;

namespace StorybrewScripts
{
    public class RemoveBackground : StoryboardObjectGenerator
    {
        public override void Generate()
        {
            GetLayer("").CreateSprite(Beatmap.BackgroundPath).Fade(0,0);
        }
    }
}
