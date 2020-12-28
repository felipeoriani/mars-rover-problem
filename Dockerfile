FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS dev
WORKDIR /src
COPY /src .
RUN dotnet restore "Mars.Tests.csproj"
RUN dotnet build "Mars.Tests.csproj"
ENTRYPOINT ["dotnet", "test", "Mars.Tests.csproj"]

# docker build -t mars:latest .
# docker run -it --name rover mars
# docker start -i rover