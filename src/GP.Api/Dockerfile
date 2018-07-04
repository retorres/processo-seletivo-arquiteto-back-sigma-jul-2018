FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 5000

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ./src/GP.Api/GP.Api.csproj src/GP.Api/
COPY ./src/GP.CommandSide/GP.CommandSide.csproj src/GP.CommandSide/
COPY ./src/GP.QuerySide/GP.QuerySide.csproj src/GP.QuerySide/

RUN dotnet restore src/GP.Api/GP.Api.csproj && \
    dotnet restore src/GP.CommandSide/GP.CommandSide.csproj && \
    dotnet restore src/GP.QuerySide/GP.QuerySide.csproj

COPY . .

WORKDIR /src/src/GP.Api
RUN dotnet build GP.Api.csproj -c Release -o /app


FROM build AS publish
RUN dotnet publish GP.Api.csproj -c Release -o /app
COPY ./src/GP.Api/bin/Debug/netcoreapp2.1/GP.Api.xml /app
COPY ./src/GP.Api/bin/Debug/netcoreapp2.1/GP.QuerySide.xml /app
COPY ./src/GP.Api/bin/Debug/netcoreapp2.1/GP.CommandSide.xml /app


FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GP.Api.dll"]
