using System.Collections;
using System.Collections.Generic;
using Application.ShopItems.Queries;
using AutoFixture;

namespace Application.Tests.ShopItems.Queries
{
    partial class ShopItemModelTests
    {
        private sealed class ShopItemModelTestsData : IEnumerable<object[]>
        {
            private readonly ShopItemModel _shopItemModel1;
            private readonly ShopItemModel _shopItemModel2;
            private readonly ShopItemModel _shopItemModel3;

            public ShopItemModelTestsData()
            {
                var fixture = new Fixture();

                // client has a circular reference from AutoFixture point of view
                fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
                fixture.Behaviors.Add(new OmitOnRecursionBehavior());

                _shopItemModel1 = fixture.Create<ShopItemModel>();
                fixture.Freeze<ShopItemModel>();
                _shopItemModel2 = fixture.Create<ShopItemModel>();
                _shopItemModel3 = fixture.Create<ShopItemModel>();
            }

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    _shopItemModel1,
                    _shopItemModel2,
                    false
                };
                yield return new object[]
                {
                    _shopItemModel1,
                    _shopItemModel1,
                    true
                };
                yield return new object[]
                {
                    _shopItemModel2,
                    _shopItemModel3,
                    true
                };
                yield return new object[]
                {
                    _shopItemModel1,
                    null,
                    false
                };
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }
    }
}