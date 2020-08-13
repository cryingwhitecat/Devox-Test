### Devox API

This is a test project built on ASP.NET Core. It uses Visual Studio's **localdb**, which is intended only for development purposes, but you can setup this app on your machine using the **InitQuery.sql** script. If you are going to use different DB, change the connection string in **appsettings.json**. 

#### API Endpoints

All endpoints return `Content-Type: application/json`. 

##### Get Methods

```
/api/gettrackingtime
Method: GET
Requires an Employee ID and a Date encoded in request body as shown in this example:
{
    "ID": 1,
    "Date": "2019-01-03"
}
Returns a list of all activities of this employee on a specified date. 
```

```
/api/gettrackingtimebyweek
Method: GET
Parameters:
	year: int
	weekID: int (0 - 54)
Returns an array of activities during a specified week.
```

```
/api/getproject
Method: GET
Parameters: 
	id: int
Returns a project with a specified id if it exists. 
```

```
/api/getallprojects
Method: GET
Returns all available projects
```

```
/api/getallactivities
Method: GET
Returns all available activities
```

```
/api/getallprojects
Method: GET
Returns all available projects
```

##### Update Methods

```
/api/updateproject
Method: POST
Requires an updated project in request body encoded as shown in this example:
{
    "ProjectID" : 2,
    "StartDate" : "2003-03-03",
    "EndDate": "2003-04-03",
    "ProjectName" : "UpdatedProject"
}
Returns 200 OK and a request status in JSON.
```

##### Create Methods

```
/api/createactivitytype
Method: POST
Creates a new Activity Type.
Requires a new activity type in request body encoded as shown in this example:
{
    "ActivityTypeName" : "Normal Work" 
}
Returns 200 OK and a new activity type's id.
```

```
/api/createrole
Method: POST
Creates a new Employee Role.
Requires a new role in request body encoded as shown in this example:
{
    "RoleName" : "Software Developer"
}
Returns 200 OK,a new role's id and a status message.
```

```
/api/createemployee
Method: POST
Creates a new Employee.
Requires a new Employee object in request body encoded as shown in this example:
{
    "FirstName" : "John",
    "LastName" : "Johnson",
    "Sex" : "Male",
    "Dob" : "2001-01-01"
}
Returns 200 OK, a new employee's id and a status message.
```

```
/api/createproject
Method: POST
Creates a new Project.
Requires a new Project object in request body encoded as shown in this example:
{
    "StartDate" : "2003-03-03",
    "EndDate": "2003-04-03",
    "ProjectName" : "New Project"
}
Return 200 OK, a new project's id and a status message.
```

```
/api/createactivity
Method: POST
Creates a new Activity.
Requires a new Activity object in request body encoded as shown in this example:
{
    "ActivityDate" : "2019-01-10",
    "DurationInHours" : 4,
    "ActivityTypeID" : 1,
    "EmployeeRoleID" : 1,
    "EmployeeID" : 2
}
Return 200 OK, a new activity id and a status message.
```

##### Delete Methods

```
/api/deleteproject
Method: POST
Parameters: 
	id: int.
Deletes a project if it exists.
```

