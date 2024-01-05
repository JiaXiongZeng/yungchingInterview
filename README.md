# yungchingInterview
This is a interview quiz project

1. Build up a solution with 2 separte projects
   a. PseudoEstate (MVC web site)
   b. PseudoEstateAPI (Web API)
   
2. Build up the entity framework with scafflod tool
   > cd .\PseudoEstateAPI
   > dotnet ef dbcontext scaffold "Data Source=..\yungchingInterview.db" Microsoft.EntityFrameworkCore.Sqlite -o Entities --force