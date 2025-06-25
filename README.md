All terminal command should be done from TechnicalTest.Api folder.

To init the DB(by default the db is already initialized):
dotnet tool install --global dotnet-ef
dotnet ef migrations add InitialCreate
dotnet ef database update

To start the project from terminal:
dotnet run
then go to https://localhost:7185/swagger

Or simply from Visual studio using launchSetting.json use the "swagger" or "docker" profile, it should open swagger in your browser.
