The application is named "Login," but it has evolved into a complete project for managing students and other upcoming features.

.NET 8 Version

After bringing up the Compose, the database must be updated using the following commands:

- dotnet ef migrations add initial-migration
- dotnet ef UPDATE-DATABASE
- 
If you encounter an error when using dotnet ef commands, try installing it with the following command:
dotnet tool install --global dotnet-ef

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
