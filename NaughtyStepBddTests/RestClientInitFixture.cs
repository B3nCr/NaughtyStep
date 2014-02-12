// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using NaughtyStep;
using NSubstitute;
using NUnit.Framework;

namespace NaughtyStepTests
{
    [TestFixture]
    public class RestClientInitFixture
    {
        [Test]
        public void Init_IsCalledWithSingletonLifestyle_ShouldCallReturnSingletonOnProvider()
        {
            //Arrange
            var provider = Substitute.For<IRestClientProvider>();
            var context = new DerivedSingletonRestSharpContext(provider);

            //Act
            context.Init();

            //Assert
            provider.Received().GetSingletonClient();
        }

        [Test]
        public void Init_IsCalledWithTransientLifestyle_ShouldCallReturnTransientOnProvider()
        {
            //Arrange
            var provider = Substitute.For<IRestClientProvider>();
            var context = new DerivedRestSharpContext(provider);

            //Act
            context.Init();

            //Assert
            provider.Received().GetTransientClient();
        }

        private class DerivedRestSharpContext : NaughtyStepRestSharpContext
        {
            public DerivedRestSharpContext(IRestClientProvider provider)
                : base(provider)
            {

            }
        }

        [ContextSessionLifestyle(Lifestyle = SessionLifestyle.Singleton)]
        private class DerivedSingletonRestSharpContext : NaughtyStepRestSharpContext
        {
            public DerivedSingletonRestSharpContext(IRestClientProvider provider)
                : base(provider)
            {

            }
        }
    }
}