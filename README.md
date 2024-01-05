# yungchingInterview
This is an interview quiz project

1. Build up a solution with 2 separte projects
   a. PseudoEstate (MVC web site)
   b. PseudoEstateAPI (Web API)
   
2. Build up the entity framework with scafflod tool
   > cd .\PseudoEstateAPI
   > dotnet ef dbcontext scaffold "Data Source=..\yungchingInterview.db" Microsoft.EntityFrameworkCore.Sqlite -o Entities --force
   
3. For using the scafflod tool to generate controller/model/view automatically,
   I tried to buid up the entity framework at web site project (PseudoEstate)
   > cd .\PseudoEstate
   > dotnet ef dbcontext scaffold "Data Source=..\yungchingInterview.db" Microsoft.EntityFrameworkCore.Sqlite -o Entities --force
   
4. Generate the basic CRUD pages per table (under PseudoEstate)