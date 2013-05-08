for /r %%x in (release\*.nupkg) do .nuget\NuGet.exe push %%x -ApiKey %1
