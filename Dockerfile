FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:10.0-alpine AS build
WORKDIR /source

COPY . /source
ARG TARGETARCH

RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages dotnet publish -a ${TARGETARCH/amd64/x64} --use-current-runtime --self-contained false -o /app

################################################################################

FROM mcr.microsoft.com/dotnet/aspnet:10.0-alpine AS final
WORKDIR /app

# Copy everything needed to run the app from the "build" stage.
COPY --from=build /app .

USER $APP_UID

ENTRYPOINT ["dotnet", "PingPong.dll"]
