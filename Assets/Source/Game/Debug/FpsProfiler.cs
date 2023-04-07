using System;
using System.Linq;
using UnityEngine;

namespace Game.Debug
{
    public class FpsProfiler
    {
        private const float UpdateFrequencySeconds = 0.33f;
        private const int BufferSeconds = 60;

        private float _lastMeasuredTime;
        private int _framesRendered;

        private int _fpsBufferIndex = 0;
        private readonly int[] _fpsBuffer = new int[(int)(BufferSeconds / UpdateFrequencySeconds)];

        public int CurrentFps { get; private set; }
        public int MinFps { get; private set; }
        public int MaxFps { get; private set; }
        public int AverageFps { get; private set; }

        public void OnUpdate()
        {
            _framesRendered++;
            var timeDifference = Time.realtimeSinceStartup - _lastMeasuredTime;

            if (timeDifference >= UpdateFrequencySeconds)
            {
                var fps = Math.Round(_framesRendered / timeDifference);
                AddFpsCount((int)fps);

                _framesRendered = 0;
                _lastMeasuredTime = Time.realtimeSinceStartup;
            }
        }

        private void AddFpsCount(int fps)
        {
            _fpsBuffer[_fpsBufferIndex] = fps;
            OnFpsCountAdded(fps);

            _fpsBufferIndex = _fpsBufferIndex >= _fpsBuffer.Length - 1
                ? 0
                : _fpsBufferIndex + 1;
        }

        private void OnFpsCountAdded(int fps)
        {
            var min = 0;
            var max = 0;
            var total = 0f;

            for (var i = 0; i < _fpsBuffer.Length; i++)
            {
                var entry = _fpsBuffer[i];
                if (entry <= 0) continue;

                min = entry > min ? entry : min;
                max = entry > max ? entry : max;
                total += entry;
            }

            CurrentFps = fps;
            MinFps = min;
            MaxFps = max;
            AverageFps = (int)Math.Round(total / _fpsBuffer.Length);
        }

        private int[] GetCalculationSafeBuffer()
        {
            var buffer = _fpsBuffer.Where(e => e > 0).ToArray();
            return buffer.Length > 0 ? buffer : new[] { 0 };
        }
    }
}