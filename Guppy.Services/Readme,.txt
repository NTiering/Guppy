------------------------------------------------------
------------------------------------------------------
Services Readme
------------------------------------------------------

The Services projects design goals are

1)	To encapsulated business logic (such as validation) 
2)	To provide extension points for workflows (E.G when a new order is received, send an email)

To this end the Services project  should only expose endpoints to achieve this. 

Components used only internally (E.G. encryption) should still be provided by dependency injection, but the interfaces defining these should not be exposed outside of the services project, thereby ensuring they are not misused. 

Adding workflow actions
------------------------------------------------------

It is common for external systems to be updated after an action has occurred. This can be done with service interceptors. 
A service interceptor is a class that can wrap a service and has extra method called before and after a service method (E.G before Get , after get.) New workflow items can be added here , and as the Service interceptors are also Services, they can be stacked upon each other.

Encapsulating business logic 
------------------------------------------------------

Basic business logic is encapsulated (when a model can be returned, when a model is valid etc) however if further encapsulation is required there are a few options


Extending the IService<T> definition. 

You may need to add new methods to the IService <T>  definition this can be one of 2 reasons. 

The extra functionality is needed in one project only (DAL,Services etc)
------------------------------------------------------

In this case , extend the IService <T> interface (this is defined as a partial) within the project and support it with an extension method targeting the IService <T> interface

The extra functionality is needed in more than one project (DAL,Services etc)
------------------------------------------------------

In this case , extend the IService <T> interface (this is defined as a partial) and add the new functionality in the Service project. You may be able to re use your new code by adding it in the Base Service class.


The extra functionality is captures in the filter passed to a get function
------------------------------------------------------

You can create a class that takes parameters needed in its constructor, and exposes a method conforming to Func<T> , or alternatively a method that returns a variable of type Func<T> . Be aware that this may force some ORM’s to return large datasets.


