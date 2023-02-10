using EntiCS;
using EntiCS.Ticking;
using EntiCS.Utility;
using Game.Services.Scenes.Events;
using Game.Static.Events;
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
        /// Manipulate this Ticker to affect gameplay, i.e. pausing and timescale.
        /// By virtue of setup, there is only ever one logic-laden scene active at a time.
        /// If this ever changes, we need to keep track of all active scene tickers.
        /// </summary>
        public ITicker SceneTicker { get; private set; }

        /// <summary>
        /// This Ticker should never be paused or scaled
        /// </summary>
        public ITicker EngineTicker { get; }

        private readonly List<NextFrameAction> _nextFrameActions = new();

        public TickerFeature()
        {
            EngineTicker = EntiCSFactory.CreateTicker();
            EngineTicker.AddUpdate(new UpdateableProxy(Update));

            EventBus.OnEvent<EndSceneEvent>(_ => SetupSceneTicker());
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

        private void SetupSceneTicker()
        {
            SceneTicker?.Dispose();
            SceneTicker = null;

            SceneTicker = EntiCSFactory.CreateTicker();
        }
    }
}
