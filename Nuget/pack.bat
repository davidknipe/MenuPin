@Echo Setting up folder structure
md Package\lib\net40\

md Package\tools\


@Echo Removing old files
del /Q Package\lib\net40\*.*

@Echo Copying new files
copy ..\MenuPin\bin\Release\MenuPin.dll Package\lib\net40 

@Echo Packing files
"..\.nuget\nuget.exe" pack package\MenuPin.nuspec

@Echo Moving package
move /Y *.nupkg c:\project\nuget.local\