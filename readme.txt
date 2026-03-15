*** an environment variable
ConnectionStrings__CodeFirstConnection

the double underscore (__) — it represents : in configuration paths.

*** Windows CMD, for that CMD session:
set ConnectionStrings__CodeFirstConnection="Data Source=.\SQLEXPRESS;.....

*** To make it permanent:
setx ConnectionStrings__CodeFirstConnection "Data Source=.\SQLEXPRESS;.....

*** To show specific stored environment variable is Filter variables
set | find "ConnectionStrings"

