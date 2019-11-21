FROM mcr.microsoft.com/dotnet/core/aspnet:2.1 AS base

WORKDIR /app
EXPOSE 80
EXPOSE 81
EXPOSE 443
EXPOSE 5000
EXPOSE 5001

FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build
WORKDIR /src
COPY listelab.sln ./
COPY listelab-contrato/*.csproj ./listelab-contrato/
COPY listelab-servico/*.csproj ./listelab-servico/
COPY listelab-data/*.csproj ./listelab-data/
COPY listelab-dominio/*.csproj ./listelab-dominio/
COPY listaelab-testes/*.csproj ./listaelab-testes/

COPY . .
WORKDIR /src

RUN dotnet build -c Release -f netcoreapp2.1 -o /app
RUN dotnet test -c Release -f netcoreapp2.1

WORKDIR /src
FROM build AS publish
RUN dotnet publish -c Release -f netcoreapp2.1 -o /app

WORKDIR /src
COPY listelab-contrato/ListElab.Contrato.xml /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ListElab.Contrato.dll"]
