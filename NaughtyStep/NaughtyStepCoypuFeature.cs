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
    public abstract class NaughtyStepCoypuFeature<T> : NaughtyStepFeatureBase where T : NaughtyStepCoypuContext, new()
    {
        protected readonly T Context;

        public NaughtyStepCoypuFeature()
            : base()
        {
            Context = new T();
        }

        /// <summary>
        /// Initialises the browser in the context. Usually it's best to call this either in a SetUp or TestFixtureSetUp.
        /// </summary>
        public virtual void Init()
        {
            Context.Init();
        }

        /// <summary>
        /// Disposes of the browser in the context. You should do this in a TearDown or TestFixtureTearDown.
        /// </summary>
        public virtual void Dispose()
        {
            Context.Dispose();
        }
    }
}