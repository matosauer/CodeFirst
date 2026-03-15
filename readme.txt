*** an environment variable
ConnectionStrings__CodeFirstConnection

the double underscore (__) — it represents : in configuration paths.

*** Windows CMD, for that CMD session:
set ConnectionStrings__CodeFirstConnection="Data Source=.\SQLEXPRESS;.....

*** To make it permanent:
setx ConnectionStrings__CodeFirstConnection "Data Source=.\SQLEXPRESS;.....

*** To show specific stored environment variable is Filter variables
set | find "ConnectionStrings"

*** Run migrations from the Console project
From the solution folder:

dotnet ef migrations add InitialCreate --project CodeFirst.Domain --startup-project CodeFirst.Console
dotnet ef database update --project CodeFirst.Domain --startup-project CodeFirst.Console

Explanation:
    --project → where migrations are stored (CodeFirst.Domain)
    --startup-project → where configuration lives (CodeFirst.Console)

