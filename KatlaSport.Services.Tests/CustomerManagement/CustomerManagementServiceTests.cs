using System;
using KatlaSport.DataAccess.CustomerCatalogue;
using KatlaSport.Services.CustomerManagement;
using Moq;
using Xunit;

namespace KatlaSport.Services.Tests.CustomerManagement
{
    public class CustomerManagementServiceTests
    {
        [Fact]
        public void Ctor_ContextIsNull_ExceptionThrown()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => new CustomerManagementService(null));

            Assert.Equal(typeof(ArgumentNullException), exception.GetType());
        }

        [Fact]
        public void GetAmount_EmptySet_ZeroReturned()
        {
            var context = new Mock<ICustomerContext>();
            context.Setup(c => c.Customers).ReturnsEntitySet(new Customer[0]);
            var service = new CustomerManagementService(context.Object);

            var amount = service.GetAmount();

            Assert.Equal(0, amount);
        }

        [Fact]
        public void GetAmount_SetWithTwoElements_TwoReturned()
        {
            var context = new Mock<ICustomerContext>();
            context.Setup(c => c.Customers).ReturnsEntitySet(new[] { new Customer(), new Customer() });
            var service = new CustomerManagementService(context.Object);

            var amount = service.GetAmount();

            Assert.Equal(2, amount);
        }

        [Fact]
        public void GetBriefInfo_EmptySet_EmptyListReturned()
        {
            var context = new Mock<ICustomerContext>();
            context.Setup(c => c.Customers).ReturnsEntitySet(new Customer[0]);
            var service = new CustomerManagementService(context.Object);

            var list = service.GetBriefInfo(0, 0);

            Assert.Empty(list);
        }

        [Fact]
        public void GetBriefInfo_SetWithFourElements_TwoElementsListReturned()
        {
            var firstCustomer = new Customer
            {
                Id = 1
            };
            var secondCustomer = new Customer
            {
                Id = 2
            };

            var context = new Mock<ICustomerContext>();
            context.Setup(c => c.Customers).ReturnsEntitySet(new[] { firstCustomer, secondCustomer, new Customer(), new Customer() });
            var service = new CustomerManagementService(context.Object);

            var list = service.GetBriefInfo(0, 2);

            Assert.Equal(2, list.Count);
            Assert.Contains(list, i => i.Id == 1);
            Assert.Contains(list, i => i.Id == 2);
        }

        [Fact]
        public void GetBriefInfo_SetWithFourElementsGetLastTwo_LastTwoElementsListReturned()
        {
            var thirdCustomer = new Customer
            {
                Id = 3
            };
            var fourthCustomer = new Customer
            {
                Id = 4
            };

            var context = new Mock<ICustomerContext>();
            context.Setup(c => c.Customers).ReturnsEntitySet(new[] { new Customer(), new Customer(), thirdCustomer, fourthCustomer });
            var service = new CustomerManagementService(context.Object);

            var list = service.GetBriefInfo(2, 2);

            Assert.Equal(2, list.Count);
            Assert.Contains(list, i => i.Id == 3);
            Assert.Contains(list, i => i.Id == 4);
        }

        [Fact]
        public void GetFullInfo_NullAsParameter_ExceptionThrown()
        {
            var context = new Mock<ICustomerContext>();
            var service = new CustomerManagementService(context.Object);

            Assert.Throws<ArgumentNullException>(() => service.GetFullInfo(null));
        }

        [Fact]
        public void GetFullInfo_OneId_OneElementListReturned()
        {
            var context = new Mock<ICustomerContext>();
            context.Setup(c => c.Customers).ReturnsEntitySet(new[]
            {
                new Customer
                {
                    Id = 1
                },
                new Customer
                {
                    Id = 2
                },
                new Customer
                {
                    Id = 3
                },
                new Customer
                {
                    Id = 4
                }
            });

            var service = new CustomerManagementService(context.Object);

            var list = service.GetFullInfo(new[] { 2 });

            Assert.Equal(1, list.Count);
            Assert.Contains(list, i => i.Id == 2);
        }

        [Fact]
        public void GetFullInfo_TwoIds_TwoElementsListReturned()
        {
            var context = new Mock<ICustomerContext>();
            context.Setup(c => c.Customers).ReturnsEntitySet(new[]
            {
                new Customer
                {
                    Id = 1
                },
                new Customer
                {
                    Id = 2
                },
                new Customer
                {
                    Id = 3
                },
                new Customer
                {
                    Id = 4
                }
            });

            var service = new CustomerManagementService(context.Object);

            var list = service.GetFullInfo(new[] { 2, 4 });

            Assert.Equal(2, list.Count);
            Assert.Contains(list, i => i.Id == 2);
            Assert.Contains(list, i => i.Id == 4);
        }
    }
}
