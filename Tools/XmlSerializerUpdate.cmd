Sgen.exe /a:"..\ZScreen\bin\x86\Debug\ZScreenLib.dll" /f /t:"ZScreenLib.XMLSettings" /t:"ZScreenLib.AppSettings" /t:"ZScreenLib.Workflow" /t:"ZScreenLib.ZScreenOptions" /v
Sgen.exe /a:"..\ZScreen\bin\x86\Debug\ZScreenCoreLib.dll" /f /t:"ZScreenCoreLib.ActionsConfig" /t:"ZScreenCoreLib.Software" /t:"ZScreenCoreLib.FileNamingConfig" /t:"ZScreenCoreLib.ImageEffectsConfig" /v
Sgen.exe /a:"..\ZScreen\bin\x86\Debug\UploadersLib.dll" /f /t:"UploadersLib.UploadersConfig" /t:"UploadersLib.GoogleTranslatorConfig" /t:"UploadersLib.ProxyConfig" /v

Sgen.exe /a:"..\ZScreen\bin\x86\Release\ZScreenLib.dll" /f /t:"ZScreenLib.XMLSettings" /t:"ZScreenLib.AppSettings" /t:"ZScreenLib.Workflow" /t:"ZScreenLib.ZScreenOptions" /v
Sgen.exe /a:"..\ZScreen\bin\x86\Release\ZScreenCoreLib.dll" /f /t:"ZScreenCoreLib.ActionsConfig" /t:"ZScreenCoreLib.Software" /t:"ZScreenCoreLib.FileNamingConfig" /t:"ZScreenCoreLib.ImageEffectsConfig" /v
Sgen.exe /a:"..\ZScreen\bin\x86\Release\UploadersLib.dll" /f /t:"UploadersLib.UploadersConfig" /t:"UploadersLib.GoogleTranslatorConfig" /t:"UploadersLib.ProxyConfig" /v

Sgen.exe /a:"..\ZUploader\bin\Release\ZUploader.exe" /f /t:"ZUploader.Settings" /v
Sgen.exe /a:"..\ZUploader\bin\Release\UploadersLib.dll" /f /t:"UploadersLib.UploadersConfig" /v

pause
