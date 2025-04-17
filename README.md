# Store-Project-System-Back-End

Project with focus in .NET / ASP.NET / MySQL / Entity / Identity / Token / JWT

structure MVC with AutoMapper
  Project
    ⨽ Controllers  (Controllers with a Functions at Services)
       ⨽ Data
          ⨽Dtos ( Mask profiles for connection Models with only info required and yours functions)
       ⨽ Enums (Makes it easier a maintenance and addition a new classification products)
    ⨽ Migrations
    ⨽ Models ( Models required at system ) 
    ⨽ Profiles (configure profiles in AutoMapper between Models with Dtos)
    ⨽ Services (Create a second layer at security connection DB)

it`s a informative package with a frameworks in a project:

    "AutoMapper.Extensions.Microsoft.DependencyInjection" Version="12.0.0"
    "Microsoft.AspNetCore.Authentication.JwtBearer" Version="8.0.13"
    "Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="8.0.13"
    "Microsoft.AspNetCore.JsonPatch" Version="9.0.2
    "Microsoft.AspNetCore.Mvc.NewtonsoftJson" Version="8.0.13"
    "Microsoft.EntityFrameworkCore.Tools" Version="8.0.13
    "Microsoft.Extensions.Identity.Stores" Version="8.0.13"
    "Newtonsoft.Json" Version="13.0.3"
    "Pomelo.EntityFrameworkCore.MySql" Version="8.0.2"
    "Swashbuckle.AspNetCore" Version="6.6.2"
    "System.IdentityModel.Tokens.Jwt" Version="8.6.0"
