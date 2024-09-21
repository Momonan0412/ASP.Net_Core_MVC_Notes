# ASP.Net_Core_MVC_Notes
## Models:
Models represent entities, which are mapped to database tables in Entity Framework. They contain the properties (fields) that define the structure of the database table.
Data Annotations: Use proper data annotations (e.g., [Required], [StringLength], [Key]) to enforce validation rules or database constraints.
## Views:
Views are templates in Razor syntax that render HTML and display data to the user. They are typically .cshtml files.
If you scaffold identity (e.g., for user authentication), it generates views and may include a .cs (code-behind) file for handling logic related to user authentication.
Controller-Generated Views: Views generated using a controller (e.g., CRUD operations) usually don't have separate .cs files but use the controller itself for logic.
A scaffolded identity view (e.g., login page) might have a .cs file for identity logic, while CRUD views (like Edit.cshtml) rely on controller methods.
## Controllers:
Controllers handle the logic for processing requests and returning responses. They typically contain GET and POST methods for handling CRUD operations.
Create and Edit: It is common to combine Create and Edit functionality into one method or view for better code reuse. You distinguish between them using conditions (e.g., checking if an entity Id is 0).
Delete Method:
Avoid using the GET method for delete actions because it's unsafe (URLs can be manipulated). Instead, use POST action method.
## Routing:
Routing defines how URLs map to controller actions. It determines how requests are directed to the correct controller and method.
Routing Rules can be defined in the Program.cs
Routing can handle both GET and POST requests, depending on which controller method is specified.
## DbContext:
A DbContext is necessary to interact with the database. It uses DbSet properties to represent tables in the database.
When extending from DbContext, you need to pass DbContextOptions to the base constructor.
## ASP.NET Identity:
ASP.NET Identity provides a full solution for managing user authentication, registration, and roles. It can be imported and customized as needed.
UserManager: Manages CRUD operations for users like creating, deleting, and updating user data.
## Addition:
You can extend the IdentityUser class by editing the custom user model in the Data folder (usually named ApplicationUser) to add additional fields or attributes. These new fields are typically added in the input model in the .cs file of Razor pages. Then, update the corresponding .cshtml view to display or manipulate the fields on the frontend. Additionally, the controller's backend .cs file can be updated to handle the new fields during form submission or other operations


## References
https://www.youtube.com/watch?v=wzaoQiS_9dI
https://www.youtube.com/watch?v=hZ1DASYd9rk
https://www.youtube.com/watch?v=VYmsoCWjvM4&t=2399s
https://learn.microsoft.com/en-us/aspnet/core/security/authentication/scaffold-identity?view=aspnetcore-8.0&tabs=visual-studio
https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.dataannotations?view=net-8.0
https://learn.microsoft.com/en-us/aspnet/mvc/overview/older-versions/mvc-music-store/mvc-music-store-part-6
https://learn.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-8.0
