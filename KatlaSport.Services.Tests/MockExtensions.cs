using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using KatlaSport.DataAccess;
using Moq;
using Moq.Language.Flow;

namespace KatlaSport.Services.Tests
{
    /// <summary>
    /// Contains extentions for Moq.
    /// </summary>
    public static class MockExtensions
    {
        public static IReturnsResult<TMock> ReturnsEntitySet<TMock, TResult>(this ISetup<TMock, IEntitySet<TResult>> setup, IList<TResult> items)
            where TMock : class
            where TResult : class
        {
            return setup.Returns(new FakeEntitySet<TResult>(items));
        }

        public static IReturnsResult<TMock> SetupEntitySet<TMock, TResult>(this Mock<TMock> mock, Expression<Func<TMock, IEntitySet<TResult>>> expression, IList<TResult> items)
            where TMock : Mock<TMock>
            where TResult : class
        {
            return mock.Setup(expression).Returns(new FakeEntitySet<TResult>(items));
        }
    }
}
