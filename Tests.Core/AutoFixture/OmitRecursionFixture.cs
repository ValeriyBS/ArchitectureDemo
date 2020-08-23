using AutoFixture;

namespace Tests.Core.AutoFixture
{
    public class OmitRecursionFixture : Fixture
    {
        public OmitRecursionFixture()
        {
            Behaviors.Remove(new ThrowingRecursionBehavior());
            Behaviors.Add(new OmitOnRecursionBehavior());
        }
    }
}