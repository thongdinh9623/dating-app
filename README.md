# dating-app
Dating app built with Postgres, ASP.NET Core, Angular.

# Features
- Register, login
- Update personal profile
- Find matches
- Messages

# Run Back-end
`dotnet watch run`

# Run front-end
`npm i`
`ng serve`

# Dockerize app
`docker run --name postgres -e POSTGRES_PASSWORD=Postgres@123 -p 5432:5432 -d postgres:lastest`
`docker build -t thongdinh96/datingapp .`
`docker run --rm -it -p 8080:80 thongdinh96/datingapp:latest`
`docker push thongdinh96/datingapp:latest`
`docker login`

# Entity framework core
`dotnet ef database drop`

# Fly.io
`fly launch --image thongdinh96/datingapp:latest`
`fly secrets list`
`fly secrets set`
