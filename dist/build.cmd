@echo off

echo Removing existing packages in current directory...
del *.nupkg

echo Packing packages...
"../.nuget/NuGet.exe" Pack "./NTH.Windows.Forms.nuspec"

echo Pushing packages to NuGet.org...
"../.nuget/NuGet.exe" Push *.nupkg
