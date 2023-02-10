namespace Game.Services.Scenes.Events
{
    public class StartSceneEvent
    {
        public SceneId Scene { get; }

        public StartSceneEvent(SceneId scene)
        {
            Scene = scene;
        }
    }
}
