The application is named "Login," but it has evolved into a complete project for managing students and other upcoming features.

.NET 8 Version


To connect to the database, you need to create a Docker Compose file and use Docker to initialize it. Here is the docker-compose file:
services:
  postgres_teacher:
    image: "postgres"
    container_name: postgres_db_teacher
    ports:
      - '5433:5432'
    environment:
        POSTGRES_USER: docker
      POSTGRES_PASSWORD: docker
      POSTGRES_DB: teacher
      PGDATA: /data/postgres-teacher
    volumes:
      - dbteacher:/data/postgres-teacher
    restart: unless-stopped

volumes:
  dbteacher:
    driver: local

After bringing up the Compose, the database must be updated using the following commands:

- Open package manager console and cd to data folder.
- set startup project LoginBackend.Api
- change the pattern project to LoginBackend.Data
- type: <dotnet ef migrations add initial-migration>
- type: <dotnet ef database update>
- connect the databse with any sgbd for postgresql that you prefer with connections data below:
  host: localhost
  port: 5433
  database: teacher
  user: docker
  password: docker
- after that you have to create a user to login the application: (patch the values with your preference)
  INSERT INTO public."User"
    ("Password", "Email")
  VALUES('', '');

If you encounter an error when using dotnet ef commands, install it with the following command and try again:
dotnet tool install --global dotnet-ef
