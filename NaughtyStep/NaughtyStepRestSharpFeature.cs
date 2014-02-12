// ****************************************************************
// Copyright 2014, Mark Dickinson
// This is free software licensed under the MIT license. You may
// obtain a copy of the license at http://naughtystepbdd.org
// ****************************************************************

namespace NaughtyStep
{
    /// <summary>
    /// Derive from this class to get NaughtyStep functionality with
    /// a Coypu user context. You specify the derived NaughtyStepCoypuContext
    /// which will be instantiated when the tests run.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class NaughtyStepRestSharpFeature<T> : NaughtyStepFeatureBase where T : NaughtyStepRestSharpContext, new()
    {
        protected readonly T Context;

        public NaughtyStepRestSharpFeature()
        {
            Context = new T();
        }

        /// <summary>
        /// Initialises the RestClient in the context. Usually it's best to call this either in a SetUp or TestFixtureSetUp.
        /// </summary>
        public virtual void Init()
        {
            Context.Init();
        }

        public virtual void Dispose()
        {
            Context.Dispose();
        }
    }
}