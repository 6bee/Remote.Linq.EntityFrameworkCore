@echo off
set configuration=Debug
set version-suffix="001"
clean ^
  && dotnet restore ^
  && dotnet build src\Remote.Linq.EntityFrameworkCore --configuration %configuration% ^
  && dotnet build test\Remote.Linq.EntityFrameworkCore.Tests --configuration %configuration% ^
  && dotnet test test\Remote.Linq.EntityFrameworkCore.Tests\Remote.Linq.EntityFrameworkCore.Tests.csproj --configuration %configuration% ^
  && dotnet pack src\Remote.Linq.EntityFrameworkCore\Remote.Linq.EntityFrameworkCore.csproj --output "..\..\artifacts" --configuration %configuration% --include-symbols --version-suffix %version-suffix%