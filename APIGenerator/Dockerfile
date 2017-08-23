
# FROM microsoft/aspnetcore-build
# # Create directory for the app source code
# WORKDIR /app
# # Copy the source and restore dependencies
# COPY . /app
# RUN ["dotnet", "restore"]
# RUN ["dotnet", "build"]
# EXPOSE 5000
# ENTRYPOINT ["dotnet", "run"]

FROM microsoft/aspnetcore:1.1.2
ARG source
WORKDIR /app
EXPOSE 80
COPY ${source:-obj/Docker/publish} .
ENTRYPOINT ["dotnet", "APIGenerator.dll"]