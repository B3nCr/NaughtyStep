// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

using System;
using System.Configuration;
using System.Threading;

namespace NaughtyStep
{
    /// <summary>
    /// Derive from this class to enable 'Given, When, Then' 
    /// functionality for test files or test harness programs.
    /// </summary>
    public abstract class NaughtyStepFeatureBase
    {
        protected int StepIntervalMilliseconds = 0;

        protected NaughtyStepFeatureBase()
        {
            try
            {
                var milliseconds = ConfigurationManager.AppSettings["StepIntervalMilliseconds"];
                if (String.IsNullOrEmpty(milliseconds)) return;
                if (int.Parse(milliseconds) > 0)
                {
                    StepIntervalMilliseconds = int.Parse(milliseconds);
                }
            }
            catch(Exception ex)
            { throw new Exception("You need to set the StepIntervalMilliseconds to an integer value", ex); }
        }

        public void Feature(string message, Action step)
        {
            Console.WriteLine(message);
            step.Invoke();
            Console.WriteLine("--> Feature passed");
        }

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
                Console.WriteLine(message.StartsWith("Feature") ? "--> Feature passed" : message.StartsWith("Scenario") ? "--> Scenario passed" : "--> Passed");
                Thread.Sleep(StepIntervalMilliseconds);
            }
            catch (Exception ex)
            {
                if (ex.Message.StartsWith("Scenario") || ex.Message.StartsWith("Feature")) return;
                if (ex.GetType().Name.Contains("SuccessException"))return;
                if(ex.GetType().Name.Contains("InconclusiveException"))
                {
                    Console.WriteLine("--> Inconclusive");
                    throw;
                }
                
                Console.WriteLine("--> Failure:");
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }
}