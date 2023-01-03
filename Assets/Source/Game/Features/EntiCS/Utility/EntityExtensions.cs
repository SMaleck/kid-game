using EntiCS.Entities;

namespace Game.Features.EntiCS.Utility
{
    public static class EntityExtensions
    {
        public static void Reset(this IEntity entity)
        {
            foreach (var component in entity.Components)
            {
                if (component is IResettable resettable)
                {
                    resettable.ResetState();
                }
            }
        }
    }
}
