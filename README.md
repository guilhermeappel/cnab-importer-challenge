# Code Challenge - CNAB File Importer

Solution for the code challenge ["CNAB File Importer"](https://github.com/ByCodersTec/desafio-dev). Developed with React.js, C# .NET Core and PostgreSQL.

## Run application | Local environment

Run command: `docker-compose up -d --build`

The application was developed using Docker Compose, so you can simply run the command above, inside the "docker" folder. It will compile the application with all the necessary files and make it accessible at the link: http://localhost:3000/

The API documentation was created using Swagger Docs and will be made available through the link: http://localhost:7702/

PS: It runs a Docker PostgreSQL Database using the port `5432`, so be sure to not be running any other database application at this port.

## Live example

The front-end application is deployed at: https://cnab-importer.herokuapp.com/

The back-end application is deployed at: https://cnab-importer-api.herokuapp.com/api/

- PS¹: Swagger Docs available through https://cnab-importer-api.herokuapp.com/swagger/

- PS²: It runs a Heroku PostgreSQL Database deployed on Heroku.
