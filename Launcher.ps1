dotnet restore;

dotnet build --no-restore;

dotnet tool install -g dotnet-ef;

dotnet ef database update -p src\Blog.Api;

dotnet user-secrets -p src\Blog.Api set "Kestrel:Certificates:Development:Password" "test";

dotnet dev-certs https -ep $Env:USERPROFILE\.aspnet\https\Blog.Api.pfx -p test

dotnet dev-certs https --trust;

docker-compose up -d;