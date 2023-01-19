using StorybrewCommon.Scripting;
using StorybrewCommon.Storyboarding;

namespace StorybrewScripts
{
    public class RemoveBackground : StoryboardObjectGenerator
    {
        [Configurable]
        public string BackgroundPath = "bg.jpg";
        public override void Generate()
        {
            if(string.IsNullOrEmpty(BackgroundPath))
                BackgroundPath = Beatmap.BackgroundPath;
            GetLayer("").CreateSprite(BackgroundPath).Fade(0,0);
        }
    }
}
