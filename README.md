# Dotnet6Sqlite
Example Blazor Server project showing SQLite issue with M1 Macs and .Net 6 preview 1

This project is an example to demonstrate the [issue reported here](https://github.com/dotnet/efcore/issues/24198)
## Usage: 

1. Get yourself an Apple Silicon Mac. I'm using an M1 Macbook Pro 
2. Install dotnet 6 preview 1
3. Clone the repo
4. cd Dotnet6Sqlite
5. Execute `dotnet run --runtime osx-x64`
6. You'll see the app startup, and two log entries indicating that the SQLite DB has been created. The ```TestDB.db``` file will be created in the current directory.
7. Next, delete the TestDB.db file.
8. Execute `dotnet run --runtime osx-arm64`
9. You'll see the app throws a type initializer exception at startup:

```
Unhandled exception. System.TypeInitializationException: The type initializer for 'Microsoft.Data.Sqlite.SqliteConnection' threw an exception.
 ---> System.Reflection.TargetInvocationException: Exception has been thrown by the target of an invocation.
 ---> System.DllNotFoundException: Unable to load shared library 'e_sqlite3' or one of its dependencies. In order to help diagnose loading problems, consider setting the DYLD_PRINT_LIBRARIES environment variable: dlopen(libe_sqlite3, 1): image not found
   at System.Runtime.InteropServices.NativeLibrary.LoadByName(String libraryName, QCallAssembly callingAssembly, Boolean hasDllImportSearchPathFlag, UInt32 dllImportSearchPathFlag, Boolean throwOnError)
   at System.Runtime.InteropServices.NativeLibrary.LoadLibraryByName(String libraryName, Assembly assembly, Nullable`1 searchPath, Boolean throwOnError)
   at System.Runtime.InteropServices.NativeLibrary.Load(String libraryName, Assembly assembly, Nullable`1 searchPath)
   at SQLitePCL.NativeLibrary.Load(String libraryName, Assembly assy, Int32 flags)
   at SQLitePCL.Batteries_V2.MakeDynamic(String name, Int32 flags)
   at SQLitePCL.Batteries_V2.DoDynamic_cdecl(String name, Int32 flags)
   at SQLitePCL.Batteries_V2.Init()
   --- End of inner exception stack trace ---
   at System.RuntimeMethodHandle.InvokeMethod(Object target, Object[] arguments, Signature sig, Boolean constructor, Boolean wrapExceptions)
   at System.Reflection.MethodBase.Invoke(Object obj, Object[] parameters)
   at Microsoft.Data.Sqlite.Utilities.BundleInitializer.Initialize()
   at Microsoft.Data.Sqlite.SqliteConnection..cctor()
   --- End of inner exception stack trace ---
   at Microsoft.Data.Sqlite.SqliteConnection..ctor(String connectionString)
   at Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal.SqliteRelationalConnection.CreateDbConnection()
   at Microsoft.EntityFrameworkCore.Storage.RelationalConnection.get_DbConnection()
   at Microsoft.EntityFrameworkCore.Storage.RelationalConnection.Open(Boolean errorsExpected)
   at Microsoft.EntityFrameworkCore.Sqlite.Storage.Internal.SqliteDatabaseCreator.Exists()
   at Microsoft.EntityFrameworkCore.Storage.RelationalDatabaseCreator.EnsureCreated()
   at Microsoft.EntityFrameworkCore.Infrastructure.DatabaseFacade.EnsureCreated()
   at Dotnet6Sqlite.Program.<>c.<CreateHostBuilder>b__1_0(IWebHostBuilder webBuilder) in /Users/markotway/LocalCloud/Development/Dotnet6Sqlite/Dotnet6Sqlite/Program.cs:line 30
   at Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.<>c__DisplayClass0_0.<ConfigureWebHostDefaults>b__0(IWebHostBuilder webHostBuilder)
   at Microsoft.Extensions.Hosting.GenericHostWebHostBuilderExtensions.ConfigureWebHost(IHostBuilder builder, Action`1 configure, Action`1 configureWebHostBuilder)
   at Microsoft.Extensions.Hosting.GenericHostWebHostBuilderExtensions.ConfigureWebHost(IHostBuilder builder, Action`1 configure)
   at Microsoft.Extensions.Hosting.GenericHostBuilderExtensions.ConfigureWebHostDefaults(IHostBuilder builder, Action`1 configure)
   at Dotnet6Sqlite.Program.CreateHostBuilder(String[] args) in /Users/markotway/LocalCloud/Development/Dotnet6Sqlite/Dotnet6Sqlite/Program.cs:line 20
   at Dotnet6Sqlite.Program.Main(String[] args) in /Users/markotway/LocalCloud/Development/Dotnet6Sqlite/Dotnet6Sqlite/Program.cs:line 16
```

## Notes: 
This project is using the preview version of the SQLite PCL Raw libraries which claim to support Apple Silicon:
```<PackageReference Include="sqlitepclraw.bundle_e_sqlite3" Version="2.0.5-pre20210119130047" />```
