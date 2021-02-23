# Dotnet6Sqlite
Example Blazor Server project showing SQLite issue with M1 Macs and .Net 6 preview 1

This project is an example to demonstrate the [issue reported here](https://github.com/dotnet/efcore/issues/24198)
## Usage: 

1. Get yourself an Apple Silicon Mac. I'm using an M1 Macbook Pro 
2. Install dotnet 6 preview 1
3. Clone the repo
4. cd Dotnet6Sqlite
5. Execute `dotnet run --runtime osx-x64`
6. You'll see the app startup, and two log entries indicating that the SQLite DB has been created.
7. Execute `dotnet run --runtime osx-arm64`
8. You'll see the app throws a type initializer exception at startup.

## Notes: 
This project is using the preview version of the SQLite PCL Raw libraries which claim to support Apple Silicon.
