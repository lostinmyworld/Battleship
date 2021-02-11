Startup project -- Web.Battleship

dotnet ef migrations remove

dotnet ef migrations add InitialCreate

dotnet ef database update

### UPDATE dotnet EF tool if necessary ###
dotnet tool update --global dotnet-ef --version 5.0.3
