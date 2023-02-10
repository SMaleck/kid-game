using EntiCS;
using EntiCS.Ticking;
using EntiCS.Utility;
using System;
using System.Collections.Generic;

namespace Game.Features.Ticking
{
    public class TickerFeature : Feature
    {
        private class NextFrameAction
        {
            public int FrameCount = 0;
            public Action OnNext;
        }

        /// <summary>
        /// Manipulate this Ticker to affect gameplay, i.e. pausing and timescale
        /// </summary>
        public ITicker GameTicker { get; }
        
        /// <summary>
        /// This Ticker should never be paused or scaled
        /// </summary>
        public ITicker EngineTicker { get; }

        private readonly List<NextFrameAction> _nextFrameActions = new();

        public TickerFeature()
        {
            GameTicker = EntiCSFactory.CreateTicker();

            EngineTicker = EntiCSFactory.CreateTicker();
            EngineTicker.AddUpdate(new UpdateableProxy(Update));
        }

        public void OnNextFrame(Action onNext)
        {
            _nextFrameActions.Add(new NextFrameAction() { OnNext = onNext });
        }

        public void Update(float elapsedSeconds)
        {
            for (var i = _nextFrameActions.Count - 1; i >= 0; i--)
            {
                var nextFrameAction = _nextFrameActions[i];
                if (nextFrameAction.FrameCount >= 1)
                {
                    nextFrameAction.OnNext.Invoke();
                    _nextFrameActions.Remove(nextFrameAction);
                }
                else
                {
                    nextFrameAction.FrameCount++;
                }
            }
        }
    }
}
