FROM mcr.microsoft.com/dotnet/core/sdk:3.1
VOLUME /app

WORKDIR /app
COPY . ./
RUN dotnet build

ENV ASPNETCORE_URLS=http://+:5000
EXPOSE 5000
CMD dotnet run --urls http://0.0.0.0:5000