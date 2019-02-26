FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY ["testTask/testTask.csproj", "testTask/"]
RUN dotnet restore "testTask/testTask.csproj"
COPY . .
WORKDIR "/src/testTask"
RUN dotnet build "testTask.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "testTask.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "testTask.dll"]