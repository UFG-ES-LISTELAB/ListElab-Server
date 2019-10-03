FROM mcr.microsoft.com/dotnet/core/aspnet:2.2 AS base
WORKDIR /app
EXPOSE 5001
EXPOSE 5000
EXPOSE 80
EXPOSE 443
EXPOSE 81

FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build
WORKDIR /src
COPY listelab.sln ./
COPY listelab-contrato/*.csproj ./listelab-contrato/
COPY listelab-servico/*.csproj ./listelab-servico/
COPY listelab-data/*.csproj ./listelab-data/
COPY listelab-dominio/*.csproj ./listelab-dominio/
COPY listaelab-testes/*.csproj ./listaelab-testes/

RUN dotnet restore
COPY . .
WORKDIR /src/listelab-servico
RUN dotnet build -c Release -f netcoreapp2.2 -o /app

WORKDIR /src/listelab-contrato
RUN dotnet build -c Release -f netcoreapp2.2 -o /app

WORKDIR /src/listelab-data
RUN dotnet build -c Release -f netcoreapp2.2 -o /app

WORKDIR /src/listelab-dominio
RUN dotnet build -c Release -f netcoreapp2.2 -o /app

WORKDIR /src/listaelab-testes
RUN dotnet build -c Release -f netcoreapp2.2 -o /app

WORKDIR /src
FROM build AS publish
RUN dotnet publish -c Release -f netcoreapp2.2 -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "listelab-contrato.dll"]
