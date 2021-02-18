SQL Server Express LocalDB

The connection string specifies SQL Server LocalDB. LocalDB is a lightweight version of the SQL Server Express Database Engine and is intended for app development, 
not production use. LocalDB starts on demand and runs in user mode, so there's no complex configuration. By default, 
LocalDB creates .mdf DB files in the C:/Users/<user> directory.



_____________________________________


In server project

dotnet ef database drop
dotnet ef migrations add InitialCreate
dotnet ef migrations remove
dotnet ef database update

Use migrations to update the schema without losing any data that you may have added to the database
dotnet ef migrations add MaxLengthOnNames
dotnet ef migrations add ColumnFirstName


_____________________________________



The Key attribute

There's a one-to-zero-or-one relationship between the Instructor and the OfficeAssignment entities. 
An office assignment only exists in relation to the instructor it's assigned to, and therefore its primary key is also its foreign key to the Instructor entity. 
But the Entity Framework can't automatically recognize InstructorID as the primary key of this entity because its name doesn't follow the ID or classnameID naming 
convention. Therefore, the Key attribute is used to identify it as the key:
C#

[Key]
public int InstructorID { get; set; }

You can also use the Key attribute if the entity does have its own primary key but you want to name the property something other than classnameID or ID.

By default, EF treats the key as non-database-generated because the column is for an identifying relationship.

______________________________________

Foreign key

The Entity Framework doesn't require you to add a foreign key property to your data model when you have a navigation property for a related entity. 
EF automatically creates foreign keys in the database wherever they're needed and creates shadow properties for them. But having the foreign key in 
the data model can make updates simpler and more efficient. For example, when you fetch a course entity to edit, 
the Department entity is null if you don't load it, so when you update the course entity, you would have to first fetch the Department entity. 
When the foreign key property DepartmentID is included in the data model, you don't need to fetch the Department entity before you update.
