dnu restore && dnu build src\Remote.Linq.EntityFramework test\Remote.Linq.EntityFramework.Tests && dnx -p test\Remote.Linq.EntityFramework.Tests test && dotnet pack src\Remote.Linq.EntityFramework --output artifacts --configuration Debug --version-suffix 001