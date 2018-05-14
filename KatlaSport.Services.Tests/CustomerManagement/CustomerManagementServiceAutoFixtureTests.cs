using System;
using System.Linq;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using KatlaSport.DataAccess.CustomerCatalogue;
using KatlaSport.Services.CustomerManagement;
using Moq;
using Xunit;

namespace KatlaSport.Services.Tests.CustomerManagement
{
    public class CustomerManagementServiceAutoFixtureTests
    {
        [Theory]
        [AutoMoqData]
        public void GetAmount_EmptySet_ZeroReturned([Frozen] Mock<ICustomerContext> context, CustomerManagementService service)
        {
            context.Setup(c => c.Customers).ReturnsEntitySet(new Customer[] { });

            var amount = service.GetAmount();

            amount.Should().Be(0);
        }

        [Theory]
        [AutoMoqData]
        public void GetAmount_SetWithTwoElements_TwoReturned([Frozen] Mock<ICustomerContext> context, CustomerManagementService service, IFixture fixture)
        {
            var customers = fixture.CreateMany<Customer>(10).ToArray();
            context.Setup(c => c.Customers).ReturnsEntitySet(customers);

            var amount = service.GetAmount();

            amount.Should().Be(customers.Length);
        }

        [Theory]
        [AutoMoqData]
        public void GetBriefInfo_EmptySet_EmptyListReturned([Frozen] Mock<ICustomerContext> context, CustomerManagementService service)
        {
            context.Setup(c => c.Customers).ReturnsEntitySet(new Customer[] { });

            var list = service.GetBriefInfo(0, 0);

            list.Should().BeEmpty();
        }

        [Theory]
        [AutoMoqData]
        public void GetBriefInfo_SetWithFourElements_TwoElementsListReturned([Frozen] Mock<ICustomerContext> context, CustomerManagementService service, IFixture fixture)
        {
            var customers = fixture.CreateMany<Customer>(4).ToArray();
            context.Setup(c => c.Customers).ReturnsEntitySet(customers);

            var list = service.GetBriefInfo(0, 2);

            list.Should().HaveCount(2);
            list.Should().Contain(i => i.Id == customers[0].Id);
            list.Should().Contain(i => i.Id == customers[1].Id);
        }

        [Theory]
        [AutoMoqData]
        public void GetBriefInfo_SetWithFourElementsGetLastTwo_LastTwoElementsListReturned([Frozen] Mock<ICustomerContext> context, CustomerManagementService service, IFixture fixture)
        {
            var customers = fixture.CreateMany<Customer>(4).ToArray();
            context.Setup(c => c.Customers).ReturnsEntitySet(customers);

            var list = service.GetBriefInfo(2, 2);

            list.Should().HaveCount(2);
            list.Should().Contain(i => i.Id == customers[2].Id);
            list.Should().Contain(i => i.Id == customers[3].Id);
        }

        [Theory]
        [AutoMoqData]
        public void GetFullInfo_NullAsParameter_ExceptionThrown(CustomerManagementService service)
        {
            Assert.Throws<ArgumentNullException>(() => service.GetFullInfo(null));
        }

        [Theory]
        [AutoMoqData]
        public void GetFullInfo_OneId_OneElementListReturned([Frozen] Mock<ICustomerContext> context, CustomerManagementService service, IFixture fixture)
        {
            var customers = fixture.CreateMany<Customer>(4).ToArray();
            context.Setup(c => c.Customers).ReturnsEntitySet(customers);

            var list = service.GetFullInfo(new[] { customers[1].Id });

            list.Should().HaveCount(1);
            list.Should().Contain(i => i.Id == customers[1].Id);
        }

        [Theory]
        [AutoMoqData]
        public void GetFullInfo_TwoIds_TwoElementsListReturned([Frozen] Mock<ICustomerContext> context, CustomerManagementService service, IFixture fixture)
        {
            var customers = fixture.CreateMany<Customer>(4).ToArray();
            context.Setup(c => c.Customers).ReturnsEntitySet(customers);

            var list = service.GetFullInfo(new[] { customers[1].Id, customers[3].Id });

            list.Should().HaveCount(2);
            list.Should().Contain(i => i.Id == customers[1].Id);
            list.Should().Contain(i => i.Id == customers[3].Id);
        }
    }
}
