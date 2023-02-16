using EntiCS.Entities;
using EntiCS.Ticking;
using EntiCS.Utility;

namespace Game.Features.EntityBehaviours.Behaviours
{
    public class EntityBehaviour : IEntityBehaviour
    {
        private IEntity _entity;
        private BehaviourTree.Builder.BehaviourTree _tree;
        private ITicker _ticker;

        private IUpdateable _updateableProxy;
        private bool _isRunning = false;

        public EntityBehaviour(IEntity entity, BehaviourTree.Builder.BehaviourTree tree, ITicker ticker)
        {
            _entity = entity;
            _tree = tree;
            _ticker = ticker;

            _updateableProxy = new UpdateableProxy(OnUpdate);
        }

        public void Start()
        {
            _isRunning = true;
            _ticker.AddUpdate(_updateableProxy);
        }

        public void Stop()
        {
            _isRunning = false;
            _ticker.AddUpdate(_updateableProxy);
        }

        public void Dispose()
        {
            if (_isRunning)
            {
                Stop();
            }

            _entity = null;
            _tree = null;
            _ticker = null;
            _updateableProxy = null;
        }

        private void OnUpdate(float elapsedSeconds)
        {
            _tree.Tick(elapsedSeconds);
        }
    }
}
