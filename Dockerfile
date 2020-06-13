FROM mcr.microsoft.com/dotnet/core/sdk:3.1
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.fsproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out


CMD dotnet out/Laranjo.dll
