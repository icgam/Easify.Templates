FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ICG.Template.sln ./
COPY ICG.Template.WebApi/ICG.Template.WebApi.csproj ICG.Template.WebApi/
COPY ICG.Template.Core/ICG.Template.Core.csproj ICG.Template.Core/
RUN dotnet restore -nowarn:msb3202,nu1503 -s "https://api.nuget.org/v3/index.json" -s "http://buildserver.icgplc.com/guestAuth/app/nuget/v1/FeedService.svc/"
COPY . .
WORKDIR /src/ICG.Template.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ICG.Template.WebApi.dll"]
