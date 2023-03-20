# Connecting to docker compose created Active MQ

This project aims to solve a problem I had trying to connect C# app to Active MQ instace created via docker compose.

## To run

First run the docker compose command in the project root folder:

```cmd
docker-compose -f .\compose.yml up -d
```

Next run the app, via command line:

```cmd
dotnet run
```

or via Visual Studio 22.