FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
ENV ASPNETCORE_URLS=http://+:8080/
EXPOSE 8080
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Service/Serverless/Service.Cadastro/Service.Cadastro.csproj", "Service/Serverless/Service.Cadastro/"]
COPY ["Application/Application.Cadastro/Application.Cadastro.csproj", "Application/Application.Cadastro/"]
COPY ["Domain/Domain/Domain.csproj", "Domain/Domain/"]
COPY ["Infra/CrossCutting/Domain/Cadastro/Infra.CrossCutting.IoC.Domain.Cadastro/Infra.CrossCutting.IoC.Domain.Cadastro.csproj", "Infra/CrossCutting/Domain/Cadastro/Infra.CrossCutting.IoC.Domain.Cadastro/"]
COPY ["Infra/Data/Domain/Cadastro/Infra.Data.Cadastro/Infra.Data.Cadastro.csproj", "Infra/Data/Domain/Cadastro/Infra.Data.Cadastro/"]
COPY ["Util/Util.ExpressionExtension/Util.ExpressionExtension.csproj", "Util/Util.ExpressionExtension/"]

RUN dotnet restore "Service/Serverless/Service.Cadastro/Service.Cadastro.csproj"
COPY . .
WORKDIR "/src/Service/Serverless/Service.Cadastro"

RUN dotnet build "Service.Cadastro.csproj" -c Release -o /app/build
FROM build AS publish
RUN dotnet publish "Service.Cadastro.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Service.Cadastro.dll"]