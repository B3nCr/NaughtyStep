// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using System;

namespace NaughtyStep
{
    /// <summary>
    /// Derive from this class to enable 'Given, When, Then' 
    /// functionality for test files or test harness programs.
    /// </summary>
    public abstract class NaughtyStepFeatureBase
    {
        public void Scenario(string message, Action step)
        {
            Console.WriteLine(message);
            step.Invoke();
            Console.WriteLine("--> Scenario passed");
        }

        public void Given(string message, Action step)
        {
            Step("Given " + message, step);
        }

        public void When(string message, Action step)
        {
            Step("When " + message, step);
        }

        public void Then(string message, Action step)
        {
            Step("Then " + message, step);
        }

        public void And(string message, Action step)
        {
            Step("And " + message, step);
        }

        private void Step(string message, Action step)
        {
            try
            {
                Console.WriteLine(message);
                step.Invoke();
                Console.WriteLine(message.StartsWith("Scenario") ? "--> Scenario passed" : "--> Passed");
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Scenario")) return;
                Console.WriteLine("--> Failure:");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}