DOTNET := dotnet
publish:
	$(DOTNET) publish --runtime win-x64 --configuration Release -p:PublishSingleFile=true -p:PublishTrimmed=true --self-contained true
