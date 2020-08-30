FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine
EXPOSE 5002

# Workaround for "Globalization Invariant Mode is not supported" error
RUN apk add icu-libs
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

WORKDIR /usr/src/vega
COPY ./bin/Debug/netcoreapp3.1 .

ENTRYPOINT ["dotnet", "Vega.Api.Root.dll"]
