FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY Template.sln ./
COPY Template.WebApi/Template.WebApi.csproj Template.WebApi/
COPY Template.Core/Template.Core.csproj Template.Core/
RUN dotnet restore 
COPY . .
WORKDIR /src/Template.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Template.WebApi.dll"]
