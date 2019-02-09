# AreaGeode.API

The following developer notes are provided to support building and deploying the AreaGeode.API.  The notes are intended as guidelines for our standard deployment, management and consumption of the API, as opposed to directives or codified requirements.

## Database

The API requires access to the database of area code information. Update the connnection string in `appsettings.json` for  access to the database.  The `sample.appsettings.json` is included in the repository to support configuration.

## CORS

The API is configured with CORS, Allow Any Origin, to allow general consumption.

## Publishing

Publish the API project to the dist folder in order to generate a distributable, release build.

    dotnet publish --configuration=Release -o dist
 
## Docker

The Dockerfile uses the published output in the dist folder to build a container.  It is currently configured with the dotnet run-time and the API must be published before the container can be built.

### Building the Container

Build the container in the base of the AreaGeode.API project.

    docker build -t areageode .

### Running the Container

The container serves the website on port 5000. Port 5000 needs to be exposed adn likely reverse proxied by the web server.

    docker container run -p 5000:5000 --name areageode areageode

The container should be run disconnected with restart on failure for deployment. 

    docker container run -d -p 5000:5000 --restart on-failure --name areageode areageode
