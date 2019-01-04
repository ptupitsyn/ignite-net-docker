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

## Workaround for apt/jre issues
RUN mkdir -p /usr/share/man/man1
RUN apt update && apt install apt-utils -y --no-install-recommends

## Install JRE
RUN apt update && apt install default-jre -y --no-install-recommends

## Copy binaries
WORKDIR /app
COPY --from=build-env /app/out .
COPY --from=build-env /root/.nuget/packages/apache.ignite/2.7.0/libs ./libs

## Run
ENTRYPOINT ["dotnet", "Apache.Ignite.Docker.dll"]
