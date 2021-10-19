# Query / Command Testing in C#

### Query Message: 
* Return/change something.
* No side-effects.
* These are Idempotent.

### Command Message: 
* Do not return anything, but change something.
* Has side-effects.
* Returns 'nil' in the case of ruby.
* Returns 'void' in the case of C#
* Not Idempotent.

**You can have both a command and a query in one method.**

*Goal:* changing a method's implementation will not cause our tests to break.

*From the sender's perspective, if a method is called and has no side effects - do not test it.*

---

#### Incoming Query:
* Test by asserting on the *return* value.
* If we test for internal logic, we are testing the implementation details.
* Test the outer interface not how it is implemented.
  * Now we can change how the method is implemented without breaking our test.
    * Only thing that cannot change is the actual return value.
* By testing only the interface, changing our method's implementation will not break our test.

#### Incoming Command:
* Here I test for side-effects.
* These side-effects should be public.
* They should be direct (the last class involved).

#### Sent-to-Self
* These a private methods.
* Do not test private *query* or *command* messages at all.
* Private methods should be free to change their implementation.

#### Outgoing Query:
* Also, do not test.
* Because this is just an incoming query for another object, that should already be tested elsewhere. 
* Do not test that they were sent.

#### Outgoing Command:
* Test that the message was sent.
* In this case, we have to use a mock.

---

#### Message Types
|  | Query      | Command |
|------ | ----------- | ----------- |
| Incoming  | Assert Return Value      | Assert Direct Public Side Effect       |
| Sent-to-Self* | Don't Test   | Don't Test        |
| Outgoing | Don't Test   | Assert Message Sent        |

\* *private methods*

#### Examples (see repo for better examples)
```csharp
// Test that this returns 3
public int IncomingQuery()
{
  return 1 + 2;
}

// Test the side effect
// In this case, that 'ClassValue' has the value of 'value'.
public void IncomingCommand(int value)
{
  ClassValue = value;
}

// Private, do not test
private IncomingQueryPrivate() {
  return 2 + 2;
}

// Private, do not test
private void IncomingCommandPrivate(int value)
{
  AnotherValue = value;
}

// Do not test
public OutgoingQuery()
{
  var localValue = OtherClass.value;

  // There would be further message types, 
  // but will not add for the sake of example.
}

// Test that this method has been called.
// This would need to be mocked.
public void OutgoingCommand(OtherClassMock otherClassMock) 
{
  otherClassMock.DoSomething();
}
```

##### Resources:
* [Command Query Separation](https://martinfowler.com/bliki/CommandQuerySeparation.html)
* [Katrina Owen - 467 tests, 0 failures, 0 confidence](https://vimeo.com/68730418)
* [The Magic Tricks of Testing by Sandi Metz](https://www.youtube.com/watch?v=URSWYvyc42M)
* [Writing Specs like Sandi Metz](https://medium.com/@christiancarey1/writing-specs-like-sandi-metz-9f2acf5026cb)
* [Testing Objects with a Functional Mindset](https://thoughtbot.com/blog/functional-viewpoints-on-testing-objectoriented-code)
* [Simplifying Tests by Extracting Side-Effects](https://thoughtbot.com/blog/simplify-tests-by-extracting-side-effects)
* [About Command & Query Separation and Object-Oriented-Design](https://medium.com/swlh/about-command-query-separation-and-object-oriented-design-c5dd4a5e03fb)
* [How to Mock Singletons and Static Methods in Unit Tests](https://medium.com/@martinrybak/how-to-mock-singletons-and-static-methods-in-unit-tests-cbe915933c7d)
* [Mocking Static Methods for Unit Testing](http://adventuresdotnet.blogspot.com/2011/03/mocking-static-methods-for-unit-testing.html)
