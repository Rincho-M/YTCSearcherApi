FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["YTCSearcherApi/YTCSearcherApi.csproj", "YTCSearcherApi/"]
RUN dotnet restore "YTCSearcherApi/YTCSearcherApi.csproj"
COPY . .
WORKDIR "/src/YTCSearcherApi"
RUN dotnet build "YTCSearcherApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "YTCSearcherApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "YTCSearcherApi.dll"]