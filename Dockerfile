FROM mcr.microsoft.com/dotnet/core/sdk:3.1
VOLUME /app

WORKDIR /app
COPY *.fsproj ./
RUN dotnet restore

COPY . ./
ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
RUN dotnet publish -c Release -o out