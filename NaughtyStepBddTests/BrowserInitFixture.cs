using NaughtyStep;
using NSubstitute;
using NUnit.Framework;

namespace NaughtyStepTests
{
    [TestFixture]
    public class BrowserInitFixture
    {
        [Test]
        public void Init_IsCalledWithSingletonLifestyle_ShouldCallReturnSingletonOnProvider()
        {
            //Arrange
            var provider = Substitute.For<IBrowserProvider>();
            var context = new DerivedSingletonCoypuContext(provider);

            //Act
            context.Init();

            //Assert
            provider.Received().GetSingletonSession();
        }

        [Test]
        public void Init_IsCalledWithTransientLifestyle_ShouldCallReturnTransientOnProvider()
        {
            //Arrange
            var provider = Substitute.For<IBrowserProvider>();
            var context = new DerivedCoypuContext(provider);

            //Act
            context.Init();

            //Assert
            provider.Received().GetTransientSession();
        }

        private class DerivedCoypuContext : NaughtyStepCoypuContext
        {
            public DerivedCoypuContext(IBrowserProvider provider)
                : base(provider)
            {

            }
        }

        [ContextSessionLifestyle(Lifestyle = SessionLifestyle.Singleton)]
        private class DerivedSingletonCoypuContext : NaughtyStepCoypuContext
        {
            public DerivedSingletonCoypuContext(IBrowserProvider provider)
                : base(provider)
            {

            }
        }
    }
}