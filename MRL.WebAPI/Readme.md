Benodigde nuget pakketten:
- Install-Package Microsoft.Data.SqlClient;
- Install-Package Microsoft.EntityFrameworkCore.SqlServer
- Install-Package Microsoft.EntityFrameworkCore.Tools


To scaffold EntityFramework execute the following in the package manager console:
Scaffold-DbContext "Name=ConnectionStrings:MotorcycleReviewListDb" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context MotorcyclesContext -DataAnnotations

To use Swagger:
1. Set Build to IIS Express
1. Add /swagger to the page that opens so: https://localhost:44324/swagger
