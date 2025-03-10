Aplicação tem o nome de login, mas acabou sendo um projeto completo para gerenciar estudantes e outras coisas que estão por vir.

Versão do .NET 8

Para conexão com a base precisa ser criado um arquivo docker-compose e utilizar o docker para inicializar.

Após subida do compose, deve ser feita a atualização da base de dados com os seguintes comandos:
- dotnet ef migrations add initial-migration
- dotnet ef UPDATE-DATABASE

Utilização das seguintes ferramentas:
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
