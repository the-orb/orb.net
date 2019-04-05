FROM microsoft/dotnet:2.2-aspnetcore-runtime-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk-stretch AS build
WORKDIR /src
COPY ["Core.Web.Server/Core.Web.Server.csproj", "Core.Web.Server/"]
RUN dotnet restore "Core.Web.Server/Core.Web.Server.csproj"
COPY . .
WORKDIR "/src/Core.Web.Server"
RUN dotnet build "Core.Web.Server.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Core.Web.Server.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Core.Web.Server.dll"]