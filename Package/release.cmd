"..\..\oqtane.framework\oqtane.package\nuget.exe" pack Tres.Stripes.Module.nuspec 
XCOPY "*.nupkg" "..\..\oqtane.framework\Oqtane.Server\wwwroot\Modules\" /Y
