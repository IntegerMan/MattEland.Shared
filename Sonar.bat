SonarScanner.MSBuild.exe begin /k:"IntegerMan_MattEland.Shared" /o:"integerman-github" /d:sonar.host.url="https://sonarcloud.io" /d:sonar.login="1b2ae3684e2d4ff13207093bd2c11f9a6b8b872c"
"C:\Program Files (x86)\Microsoft Visual Studio\2019\Community\MSBuild\Current\Bin\MsBuild.exe" /t:Rebuild
SonarScanner.MSBuild.exe end /d:sonar.login="1b2ae3684e2d4ff13207093bd2c11f9a6b8b872c"