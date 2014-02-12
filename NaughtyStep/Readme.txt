NaughtyStep
===========

Visit the [NaughtyStep website](http://www.naughtystepbdd.org) for more information.

NaughtyStep allows you to develop behaviour tests that excercise your web based software
from the outside. It provides a base classes from which you can derive behaviour test features.
If your derived classes happen to be unit test fixtures as well, you have an easy way to run up
browser automation, or REST API tests.

### Examples

[Browser Test Example](http://www.naughtystepbdd.org/example.htm)

[REST API Test Example](http://www.naughtystepbdd.org/example2.htm)

### Basic use (NUnit)

Browser
=======

1. Create a new class to be your context (this class will work with your browser to test the site), and 
inherit NaughtyStepCoypuContext. 
2. Create a test fixture and inherit NaughtyStepCoypuContext<>, the generic argument should be the 
type of the context you created in step 1.
3. Create a new void for your test, add the Test attribute.
4. Inside the test add the steps you need like so:

   [Test]
   public void MyTest()
   {
      Scenario("Describe the scenario", () =>
	  {
	     Given("You are at a homepage for instance", () => Context.UserIsAtHomepage());
	     When("You click on something for instance", () => Context.ClickOnSomething());
		 Then("You should be somewhere else", () => Context.UserIsOnAnotherPage())
	  })
   } 

5. The Context you created in step 1 has been set for you my NaughtyStep, so you need to create a method 
for each delegate action that you have created in step 4. These methods have access to the Browser object.
A basic context method would look like:

   public void UserIsAtHomePage()
        {
            Browser.Visit("http://www.naughtystepbdd.org/index.html");
            Browser.Location.AbsoluteUri.ShouldEqual("http://www.naughtystepbdd.org/index.html");
        }

To get more info on the browser object go to [The Coypu Website](https://github.com/featurist/coypu). 
If you're happier adapting an existing example, the gists on the example pages linked to above
should get you off to a great start.