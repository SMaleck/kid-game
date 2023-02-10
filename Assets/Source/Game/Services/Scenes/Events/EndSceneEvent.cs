namespace Game.Services.Scenes.Events
{
    public class EndSceneEvent
    {
        public SceneId Scene { get; }

        public EndSceneEvent(SceneId scene)
        {
            Scene = scene;
        }
    }
}
