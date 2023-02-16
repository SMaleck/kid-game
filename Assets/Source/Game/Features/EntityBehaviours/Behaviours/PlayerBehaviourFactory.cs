namespace Game.Features.EntityBehaviours.Behaviours
{
    public class PlayerBehaviourFactory : BehaviourFactory
    {
        protected override BehaviourTree.Builder.BehaviourTree CreateTree()
        {
            // @formatter:off
            return Builder()
                    .SequenceIf(AssertIsRunning())
                        .Do(UserInput())
                    .End()
                .Build();
            // @formatter:on
        }
    }
}
