FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

COPY . .

RUN dotnet restore
RUN dotnet build --no-restore -c Release

CMD ["dotnet", "test", "--settings:.runsettings"]