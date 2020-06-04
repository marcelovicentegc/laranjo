FROM microsoft/dotnet-preview

RUN mkdir /app
WORKDIR /app

COPY Laranjo.fsproj .
RUN dotnet restore

COPY . .
RUN dotnet publish -c Release -o out

EXPOSE 5000/tcp
CMD ["dotnet", "out/Laranjo.dll"]
