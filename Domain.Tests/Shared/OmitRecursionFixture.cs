using AutoFixture;

namespace Domain.Tests.Shared
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