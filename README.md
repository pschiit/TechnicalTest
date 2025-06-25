# Technical Test
Blog API made for a recruitment test.

To launch the app:

From Visual Studio:

    Open and Start TechnicalTest.sln,  use the "swagger", "docker" profile from TechnicalTest.Api or "dockercompose" from the DockerCompose project, it should open swagger in your browser.
    
From Command line:

    Go to the directory of TechnicalTest.Api (<repository path>\TechnicalTest\TechnicalTest.Api) and run the command:
    
    dotnet run

    Go to http://localhost:7185/swagger and simply click on Author or Post to access the controller request, select the request you want and click on "Try it out" on the top right.

You will be able to enter parameters if required then simply click execute and your response will appear in the "Responses" section under "Server response".
