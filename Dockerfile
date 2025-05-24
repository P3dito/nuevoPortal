# Imagen para compilar la app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar archivos de proyecto y restaurar dependencias
COPY *.csproj ./
RUN dotnet restore

# Copiar todo el resto del código y publicar en modo Release
COPY . ./
RUN dotnet publish -c Release -o out

# Imagen para ejecución
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Nombre del archivo .dll principal (ajústalo si no es correcto)
ENV APP_NET_CORE practica3.dll

# Render inyecta automáticamente la variable $PORT
CMD ASPNETCORE_URLS=http://*:$PORT dotnet $APP_NET_CORE
