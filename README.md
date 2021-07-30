# Query / Command Testing in C#

### Query Message: 
* Return/change something with no side-effects.

### Command Message: 
* Do not return anything, but change something with side-effects.

---

#### Incoming Query:
* Test by asserting on the *return* value.
* If we test for internal logic, we are testing the implementation details.
* Test the outer interface not how it is implemented.
  * Now we can change how the method is implemented without breaking our test.
    * Only thing that cannot change is the actual return value.

#### Incoming Command:
* Here I test for side-effects.
* These side-effects should be public.
* They should be direct (the last ruby class involved).

#### Sent-to-Self
* These a private methods.
* Do not test private *query* or *command* messages at all.
* Private methods should be free to change their implementation.

#### Outgoing Query:
* Also, do not test.
* Because this is just an incoming query for another object, that should already be tested elsewhere. 

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
