// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************


using System;
using NaughtyStep;
using NSubstitute;
using NUnit.Framework;

namespace NaughtyStepTests
{
    [TestFixture]
    public class NaughtyStepFixture
    {
        private Action action = Substitute.For<Action>();
        private class DerivedNaughtyStep : NaughtyStepFeatureBase
        {
        }

        [Test]
        public void Feature_IsCalledWhenItContainsASingleAction_ShouldCallAction()
        {
            //Arrange
            var sut = new DerivedNaughtyStep();

            //Act
            sut.Feature("Testing", () => action());

            //Assert
            action.Received().Invoke();
        }

        [Test]
        public void Scenario_IsCalledWhenItContainsASingleAction_ShouldCallAction()
        {
            //Arrange
            var sut = new DerivedNaughtyStep();

            //Act
            sut.Scenario("Testing", () => action());

            //Assert
            action.Received().Invoke();
        }

        [Test]
        public void Given_IsCalledWhenItContainsASingleAction_ShouldCallAction()
        {
            //Arrange
            var sut = new DerivedNaughtyStep();

            //Act
            sut.Given("Testing", () => action());

            //Assert
            action.Received().Invoke();
        }

        [Test]
        public void When_IsCalledWhenItContainsASingleAction_ShouldCallAction()
        {
            //Arrange
            var sut = new DerivedNaughtyStep();

            //Act
            sut.When("Testing", () => action());

            //Assert
            action.Received().Invoke();
        }

        [Test]
        public void Then_IsCalledWhenItContainsASingleAction_ShouldCallAction()
        {
            //Arrange
            var sut = new DerivedNaughtyStep();

            //Act
            sut.Then("Testing", () => action());

            //Assert
            action.Received().Invoke();
        }

        [Test]
        public void And_IsCalledWhenItContainsASingleAction_ShouldCallAction()
        {
            //Arrange
            var sut = new DerivedNaughtyStep();

            //Act
            sut.And("Testing", () => action());

            //Assert
            action.Received().Invoke();
        }
    }
}
