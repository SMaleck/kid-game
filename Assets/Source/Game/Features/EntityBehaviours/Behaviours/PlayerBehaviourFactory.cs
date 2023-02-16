namespace Game.Features.EntityBehaviours.Behaviours
{
    public class PlayerBehaviourFactory : BehaviourFactory
    {
        protected override BehaviourTree.Builder.BehaviourTree CreateTree()
        {
            // @formatter:off
            return Builder()
                    .Sequence()
                        .Do(AssertIsRunning())
                    .End()
                .Build();
            // @formatter:on
        }
    }
}
