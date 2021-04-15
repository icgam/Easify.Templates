FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR  /src
COPY Easify.Template.sln ./
COPY Easify.Template.WebApi/Easify.Template.WebApi.csproj Easify.Template.WebApi/
COPY Easify.Template.Core/Easify.Template.Core.csproj Easify.Template.Core/
RUN dotnet restore
COPY . .
WORKDIR /src/Easify.Template.WebApi
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Easify.Template.WebApi.dll"]
