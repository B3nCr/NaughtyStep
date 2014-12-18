using Nancy;

namespace DummyRestApi
{
    public class SimpleService : NancyModule
    {
        public SimpleService()
        {
            Get["tuganet"] = parameters => new {TestOne = "One", TestTwo = "Two"};
        }
    }
}
