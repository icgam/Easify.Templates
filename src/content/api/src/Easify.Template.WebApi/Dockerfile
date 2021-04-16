FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR  /src
COPY *.sln ./
COPY Easify.Template.WebApi/*.csproj ./Easify.Template.WebApi/
COPY Easify.Template.WebApi.IntegrationTests/*.csproj ./Easify.Template.WebApi.IntegrationTests/
COPY Easify.Template.Core/*.csproj ./Easify.Template.Core/
COPY Easify.Template.Core.UnitTests/*.csproj ./Easify.Template.Core.UnitTests/
COPY Easify.Template.Common/*.csproj ./Easify.Template.Common/
COPY Easify.Template.Client/*.csproj ./Easify.Template.Client/
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
