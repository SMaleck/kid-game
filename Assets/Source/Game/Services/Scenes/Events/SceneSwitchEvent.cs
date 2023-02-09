namespace Game.Services.Scenes.Events
{
    public class SceneSwitchEvent
    {
        public SceneId From { get; }
        public SceneId To { get; }

        public SceneSwitchEvent(SceneId from, SceneId to)
        {
            From = from;
            To = to;
        }
    }
}
