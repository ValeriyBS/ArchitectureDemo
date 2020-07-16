
using System.Collections.Generic;
using AutoFixture;
using Domain.Customers;
using Xunit;

namespace Domain.Tests.Customers
{
    public class CustomerTests
    {
        private readonly Customer _customer;
        private readonly Customer _customerLeft;
        private readonly Customer _customerRight;
        private const int Id = 1;
        private const string UserId = "testUserId";

        public CustomerTests()
        {
            var fixture = new Fixture();
            fixture.Freeze<Customer>();

            _customerLeft = fixture.Create<Customer>();
            _customerRight = fixture.Create<Customer>();

            _customer = new Customer();

           
        }

        [Fact]
        public void TestSetGetId()
        {
            //Arrange
            //Act
            _customer.Id = Id;

            //Assert
            Assert.Equal(Id,_customer.Id);
        }

        [Fact]
        public void TestSetGetUserId()
        {
            //Arrange
            //Act
            _customer.UserId = UserId;

            //Assert
            Assert.Equal(UserId, _customer.UserId);
        }

        [Fact]
        public void TestOperatorEqualTo()
        {
            //Arrange
            //Act
            var result = _customerLeft == _customerRight;

            //Assert
            Assert.True(result);

        }

        [Fact]
        public void TestOperatorNotEqualTo()
        {
            //Arrange
            //Act
            var result = _customerLeft != _customerRight;

            //Assert
            Assert.False(result);

        }

        [Fact]
        public void TestGetHashCode()
        {
            //Arrange
            var customerSet = new HashSet<Customer>(){_customerLeft};

            //Act
            var result = customerSet.Contains(_customerLeft);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestEqualsSameReferenceObject()
        {
            //Arrange
            var categoryWrapper = (object)_customerRight;
            //Act
            var result = _customerRight.Equals(categoryWrapper);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestEqualsObject()
        {
            //Arrange
            //Act
            var result = _customerRight.Equals(new object());

            //Assert
            Assert.False(result);
        }


    }
}
