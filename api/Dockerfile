FROM mcr.microsoft.com/dotnet/aspnet
WORKDIR /app
COPY bin\Debug\netcoreapp5.0 .
COPY ./src/UI/wwwroot ./wwwroot
ENTRYPOINT ["dotnet", "devops-calculator-api.dll"]