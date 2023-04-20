using System.Collections.Generic;
using EntiCS.Entities;
using EntiCS.Systems;

namespace Game.Features.EntiCS.Systems.BaseSystems
{
    public abstract class PerEntitySystem : EntitySystem
    {
        public override void Update(float elapsedSeconds, HashSet<IEntity> entities)
        {
            foreach (var entity in entities)
            {
                UpdateEntity(elapsedSeconds, entity);
            }
        }

        protected abstract void UpdateEntity(float elapsedSeconds, IEntity entity);
    }
}
