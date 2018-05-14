using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace KatlaSport.Services.Tests
{
    /// <summary>
    /// Represents a data attribute for theory-based tests that uses Moq for creating fake objects.
    /// </summary>
    public sealed class AutoMoqDataAttribute : AutoDataAttribute
    {
        public AutoMoqDataAttribute()
            : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}
