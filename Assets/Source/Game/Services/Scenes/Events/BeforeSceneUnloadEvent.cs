namespace Game.Services.Scenes.Events
{
    public class BeforeSceneUnloadEvent
    {
        public SceneId Scene { get; }

        public BeforeSceneUnloadEvent(SceneId scene)
        {
            Scene = scene;
        }
    }
}
