FROM mcr.microsoft.com/dotnet/aspnet:5.0
COPY bin/Debug/netcoreapp3.1/ /App
WORKDIR /App
ENTRYPOINT ["dotnet", "api.dll"]