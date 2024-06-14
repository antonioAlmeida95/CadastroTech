FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_URLS=http://+:8080/
EXPOSE 8080
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

RUN dotnet build ./Service/Serverless/Service.Cadastro/Service.Cadastro.csproj -c Release -o /app/build --runtime=linux-arm64
FROM build AS publish
RUN dotnet publish ./Service/Serverless/Service.Cadastro/Service.Cadastro.csproj -c Release -o /app/publish --runtime=linux-arm64

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service.Cadastro.dll"]