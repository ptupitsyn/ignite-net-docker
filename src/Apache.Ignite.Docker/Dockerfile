FROM microsoft/dotnet:sdk AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM microsoft/dotnet:runtime
RUN apt update && apt install default-jdk -y --no-install-recommends
WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=build-env /root/.nuget/packages/apache.ignite/2.7.0/libs .
ENTRYPOINT ["dotnet", "Apache.Ignite.Docker.dll"]
