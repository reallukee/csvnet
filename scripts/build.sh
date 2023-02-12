#/bin/bash

cd ..

# Build CSVNet Legacy.
dotnet build csvnet.legacy/csvnet.legacy.csproj -c Debug
dotnet build csvnet.legacy/csvnet.legacy.csproj -c Release
dotnet pack csvnet.legacy/csvnet.legacy.csproj

# Build CSVNet Legacy Test.
dotnet build csvnet.legacy.test/csvnet.legacy.test.csproj -c Debug
dotnet build csvnet.legacy.test/csvnet.legacy.test.csproj -c Release

# Build CSVNet.
dotnet build csvnet/csvnet.csproj -c Debug
dotnet build csvnet/csvnet.csproj -c Release
dotnet pack csvnet/csvnet.csproj

# Build CSVNet Test.
dotnet build csvnet.test/csvnet.test.csproj -c Debug
dotnet build csvnet.test/csvnet.test.csproj -c Release
