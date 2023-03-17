namespace Game.Features.GameWorld.PlayerInput
{
    public class PlayerInputFeature : Feature
    {
        public void Add(IPlayerInputSource source)
        {
            source.OnJump += OnJump;
            source.OnRoll += OnRoll;
            source.OnPauseGame += OnPauseGame;
        }

        public void Remove(IPlayerInputSource source)
        {
            source.OnJump -= OnJump;
            source.OnRoll -= OnRoll;
            source.OnPauseGame -= OnPauseGame;
        }

        private void OnJump()
        {

        }

        private void OnRoll()
        {

        }

        private void OnPauseGame()
        {

        }
    }
}
