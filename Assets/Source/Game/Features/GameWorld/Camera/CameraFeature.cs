using System.Collections.Generic;

namespace Game.Features.GameWorld.Camera
{
    public class CameraFeature : Feature
    {
        private List<UCamera> _cameras = new List<UCamera>();

        public void Push(UCamera uCamera)
        {
            if (_cameras.Contains(uCamera))
            {
                return;
            }

            foreach (var camera in _cameras)
            {
                camera.IsActive = false;
            }

            uCamera.IsActive = true;
            _cameras.Add(uCamera);
        }

        public void Remove(UCamera uCamera)
        {
            if (!_cameras.Contains(uCamera))
            {
                return;
            }

            uCamera.IsActive = false;
            _cameras.Remove(uCamera);

            if (_cameras.Count > 0)
            {
                _cameras[^1].IsActive = true;
            }
        }
    }
}
