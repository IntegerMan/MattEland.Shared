SonarScanner.MSBuild.exe begin /k:"IntegerMan_MattEland.Shared" /o:"integerman-github" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="1b2ae3684e2d4ff13207093bd2c11f9a6b8b872c" /d:sonar.cs.nunit.reportsPaths="%CD%\NUnitResults.xml" /d:sonar.cs.opencover.reportsPaths="%CD%\opencover.xml"
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MsBuild.exe" /t:Rebuild

echo nunit3-console.exe --result="%CD%\NUnitResults.xml" "MattEland.Shared.Tests.Framework\bin\Release\MattEland.Shared.Tests.Framework.dll" 

echo dotcover cover /TargetExecutable="C:\Users\Matt\.nuget\packages\nunit.consolerunner\3.10.0\tools\nunit3-console.exe" /TargetArguments="%CD%\MattEland.Shared.Tests.Framework\bin\Release\MattEland.Shared.Tests.Framework.dll" /Output="%CD%\dotCover.html" /ReportType="HTML"

OpenCover.Console.exe -output:"%CD%\opencover.xml" -register:user -target:"C:\Users\Matt\.nuget\packages\nunit.consolerunner\3.10.0\tools\nunit3-console.exe" -targetargs:"%CD%\MattEland.Shared.Tests.Framework\bin\Release\MattEland.Shared.Tests.Framework.dll --result=%CD%\NUnitResults.xml"
                    
SonarScanner.MSBuild.exe end /d:sonar.login="1b2ae3684e2d4ff13207093bd2c11f9a6b8b872c"
Pause