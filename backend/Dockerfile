FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
COPY . /app
WORKDIR /app
RUN dotnet restore
RUN dotnet publish ./gamesforfriends.api/gamesforfriends.api.csproj -c Release -o ./gamesforfriends.api/out

FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS runtime
WORKDIR /app
COPY --from=build /app/gamesforfriends.api/out/ .
EXPOSE 80
ENTRYPOINT ["dotnet", "gamesforfriends.api.dll"]
