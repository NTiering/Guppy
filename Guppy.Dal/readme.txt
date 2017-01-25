--------------------------------------------------
--------------------------------------------------
DAL Readme
--------------------------------------------------

The DAL projects design goals are

1)	To insulate the application from changes in the persistence layer. 
2)	To provide caching transparently

To this end the DAL should only expose endpoints to achieve this. 

Components used only internally (E.G. caching) should still be provided by dependency injection, but the interfaces defining these should not be exposed outside of the DAL project, thereby ensuring they are not misused. 

--------------------------------------------------
Extending the IDal<T> definition. 
--------------------------------------------------

You may need to add new methods to the IDal<T>  definition this can be one of 2 reasons. 

The extra functionality is needed in one project only (DAL,Services etc)
--------------------------------------------------

In this case , extend the DAL<T> interface (this is defined as a partial) within the project and support it with an extension method targeting the IDal<T> interface

The extra functionality is needed in more than one project (DAL,Services etc)
--------------------------------------------------

In this case , extend the DAL<T> interface (this is defined as a partial) and add the new functionality in the DAL project. You may be able to re use your new code by adding it in the Base Dal class.

Adding stored procedures. 

---------------------------
Some consideration should be given before using stored procedures, as although they are closer to the data, their functionality cannot  be as easily maintained. Also they must run on the server, which makes distributed computing more complex. 

Imagine adding a stored procedure to find all “blue widgets with the type of ‘widgety ’ ”. Stored procedure encapsulate all business logic, as we will effectively pass through both service and dal layers 

1)	Create a new Interface in Contracts (IWidgetDal : IDal<Widget>) 
2)	Add a new method to IWidgetDal IEnumerable<Widget> GetBlueWidgetsByType(string type = ‘widgety’)
3)	Create a new Interface in Services (IWidgetService : IService<Widget>) 
4)	Add a new method IWidgetService  IEnumerable<Widget> GetBlueWidgetsByType(string type = ‘widgety’)
5)	Implement IWidgetDal in the DAL project (by extending BaseDal) and add this to Register.cs 
6)	Implement IWidgetService in the Service project (by extending BaseService) and add this to Register.cs 
7)	Your front end can now use IWidgetService, and IWidgetService will still honour IService<Widget> and inherit any changes made globally to all services in future

