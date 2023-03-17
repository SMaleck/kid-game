using System;

namespace Game.Features.GameWorld.PlayerInput
{
    public interface IPlayerInputSource
    {
        Action OnJump { get; set; }
        Action OnRoll { get; set; }
        Action OnPauseGame { get; set; }
    }
}
