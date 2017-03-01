@Echo Removing old files
del Package\lib /s /q
del Package\content /s /q

@Echo Setting up folder structure
md Package\lib\net45\
md Package\tools\
md Package\content\modules\_protected\MenuPin\ClientResources\Scripts\MenuPin\

@Echo Copying new files
copy ..\MenuPin\bin\Release\MenuPin.dll Package\lib\net45\
copy ..\MenuPin\ClientResources\Scripts\MenuPin\MenuPinInit.js Package\content\modules\_protected\MenuPin\ClientResources\Scripts\MenuPin\
copy ..\MenuPin\ClientResources\Scripts\MenuPin\MenuPinForFind.js Package\content\modules\_protected\MenuPin\ClientResources\Scripts\MenuPin\
copy ..\MenuPin\module.config Package\content\modules\_protected\MenuPin\

@Echo Packing files
"..\.nuget\nuget.exe" pack Package\MenuPin.nuspec

@Echo Moving package
move /Y *.nupkg c:\project\nuget.local\
