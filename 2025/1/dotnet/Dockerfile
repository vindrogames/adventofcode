FROM mcr.microsoft.com/dotnet/sdk:10.0

RUN dotnet dev-certs https --clean && \
    dotnet dev-certs https --verbose && \
    dotnet --version