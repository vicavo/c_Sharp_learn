@echo off

set projects="LTC Notify"

echo cleaning output folder...
del .\Bin\Debug\*.manifest
del .\Bin\Debug\*.pdb
del .\Bin\Debug\*.exe
del .\Bin\Debug\*.exe.config
del .\Bin\Debug\*.log

del .\Bin\Release\*.manifest
del .\Bin\Release\*.pdb
del .\Bin\Release\*.exe
del .\Bin\Release\*.exe.config
del .\Bin\Release\*.log

echo cleaning solution settings...
del *.DotSettings.user /s
rd "_ReSharper.LTC Notify" /s /q

del .\Bin\Fused\Dotfuscated /s /q

echo cleaning projects folder...
for %%i in (%projects%) Do rd .\%%i\bin /s /q 
for %%i in (%projects%) Do rd .\%%i\obj /s /q 
for %%i in (%projects%) Do rd .\%%i\_ReSharper.%%i /s /q 
for %%i in (%projects%) Do del .\%%i\*.DotSettings.user /s /q

@echo solution cleaned!
@pause