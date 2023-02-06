using EntiCS;
using EntiCS.Ticking;

namespace Game.Features.Ticking
{
    public class TickerFeature : Feature
    {
        public ITicker Ticker { get; }

        public TickerFeature()
        {
            Ticker = EntiCSFactory.CreateTicker();
        }
    }
}
