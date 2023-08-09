dotnet sonarscanner begin /k:"unittestss" /d:sonar.host.url="http://localhost:9000" /d:sonar.coverageReportPaths=".\sonarqubecoverage\SonarQube.xml" /d:sonar.cs.vstest.reportsPaths="\**\*.trx" /d:sonar.token="sqp_84e91bebf68b91c5c3058d51f1a471a08d7c073b"
dotnet build
dotnet test --no-build --collect:"XPlat Code Coverage"
reportgenerator "-reports:*\TestResults\*\coverage.cobertura.xml" "-targetdir:sonarqubecoverage" "-reporttypes:SonarQube"
dotnet sonarscanner end /d:sonar.token="sqp_84e91bebf68b91c5c3058d51f1a471a08d7c073b"