FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

RUN dotnet tool install -g Microsoft.Web.LibraryManager.Cli
RUN ln -s ~/.dotnet/tools/libman /usr/local/bin/libman

WORKDIR /src
COPY src/ .


WORKDIR "/src/Invoice.Web.Mvc"
RUN dotnet restore 

WORKDIR /src
COPY ["src/Invoice.Web.Mvc", "src/Invoice.Web.Mvc"]
COPY ["src/Invoice.Web.Core", "src/Invoice.Web.Core"]
COPY ["src/Invoice.Application", "src/Invoice.Application"]
COPY ["src/Invoice.Core", "src/Invoice.Core"]
COPY ["src/Invoice.EntityFrameworkCore", "src/Invoice.EntityFrameworkCore"]

WORKDIR "/src/Invoice.Web.Mvc"
RUN libman restore
RUN dotnet publish -c Release -o /publish --no-restore

RUN dotnet run --project Invoice.Web.Mvc --bundling

RUN dotnet publish -c Release -o /publish --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:9.0
EXPOSE 80
WORKDIR /app
COPY --from=build /publish .
ENTRYPOINT ["dotnet", "Invoice.Web.Mvc.dll"]

