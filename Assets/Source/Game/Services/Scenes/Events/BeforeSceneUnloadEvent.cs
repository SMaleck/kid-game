namespace Game.Services.Scenes
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
