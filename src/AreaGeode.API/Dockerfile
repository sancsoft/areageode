FROM  microsoft/dotnet:2.2.1-runtime-bionic

WORKDIR /app

COPY dist /app

ENV ASPNETCORE_URLS http://*:5000

EXPOSE 5000

ENTRYPOINT ["dotnet", "AreaGeode.API.dll"]