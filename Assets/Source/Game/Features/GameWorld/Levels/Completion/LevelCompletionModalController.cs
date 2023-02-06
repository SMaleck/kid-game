using Game.Services.Gooey.Controllers;

namespace Game.Features.GameWorld.Levels.Completion
{
    public class LevelCompletionModalController : ModalController<LevelCompletionModalView>
    {
        public LevelCompletionModalController(LevelCompletionModalView view)
            : base(view)
        {
        }
    }
}
