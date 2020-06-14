FROM mcr.microsoft.com/dotnet/core/sdk:3.1
VOLUME /app

WORKDIR /app
COPY . ./
RUN dotnet build

ENV ASPNETCORE_URLS=http://+:$PORT
EXPOSE $PORT
CMD dotnet run --urls http://0.0.0.0:$PORT