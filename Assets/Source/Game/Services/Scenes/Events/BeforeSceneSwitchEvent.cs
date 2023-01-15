namespace Game.Services.Scenes
{
    public class BeforeSceneSwitchEvent
    {
        public SceneId From { get; }
        public SceneId To { get; }

        public BeforeSceneSwitchEvent(SceneId from, SceneId to)
        {
            From = from;
            To = to;
        }
    }
}
