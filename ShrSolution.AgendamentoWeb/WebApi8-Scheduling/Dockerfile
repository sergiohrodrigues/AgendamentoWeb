# Etapa 1: Build com SDK e execução da migration
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copia tudo para a pasta de build
COPY . .

# Restaura os pacotes
RUN dotnet restore "./WebApi8-Scheduling.csproj"

# Instala o dotnet-ef globalmente e executa a migration
RUN dotnet tool install --global dotnet-ef && \
    export PATH="$PATH:/root/.dotnet/tools" && \
    dotnet ef database update --project ./WebApi8-Scheduling.csproj

# Publica o app
RUN dotnet publish "./WebApi8-Scheduling.csproj" -c Release -o /app/publish

# Etapa 2: Imagem de runtime (mais leve)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copia os arquivos publicados
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "WebApi8-Scheduling.dll"]
