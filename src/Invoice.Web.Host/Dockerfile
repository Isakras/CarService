FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /src
COPY ["src/Invoice.Web.Host/Invoice.Web.Host.csproj", "src/Invoice.Web.Host/"]
COPY ["src/Invoice.Web.Core/Invoice.Web.Core.csproj", "src/Invoice.Web.Core/"]
COPY ["src/Invoice.Application/Invoice.Application.csproj", "src/Invoice.Application/"]
COPY ["src/Invoice.Core/Invoice.Core.csproj", "src/Invoice.Core/"]
COPY ["src/Invoice.EntityFrameworkCore/Invoice.EntityFrameworkCore.csproj", "src/Invoice.EntityFrameworkCore/"]
WORKDIR "/src/src/Invoice.Web.Host"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Invoice.Web.Host", "src/Invoice.Web.Host"]
COPY ["src/Invoice.Web.Core", "src/Invoice.Web.Core"]
COPY ["src/Invoice.Application", "src/Invoice.Application"]
COPY ["src/Invoice.Core", "src/Invoice.Core"]
COPY ["src/Invoice.EntityFrameworkCore", "src/Invoice.EntityFrameworkCore"]
WORKDIR "/src/src/Invoice.Web.Host"
RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:8.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Invoice.Web.Host.dll"]
