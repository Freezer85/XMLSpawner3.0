@ECHO OFF
@ECHO ###############################
@ECHO # SpawnEditor SETUP
@ECHO ###############################
@ECHO # NOTE:
@ECHO # This setup shall be launched with "ADMINISTRATOR" priviledges as it register the UOMap old OCX
@ECHO # To do this, right click the SETUP and select "Run as administrator".
@ECHO ###############################
cd /d %~dp0
@ECHO.

if exist "UOMap.ocx" (
    @ECHO 1) Trying to uninstall eventual old UOMap.ocx...
    REGSVR32 /U /S UOMap.ocx
    @ECHO 2) Installing UOMap.ocx...
    regsvr32.exe "%cd%\UOMap.ocx"
) else (
    @ECHO 1) UOMap.ocx not found - skipping
)

if exist "UOMAPLib.dll" (
    @ECHO 3) Registering UOMAPLib.dll...
    regsvr32.exe /s "%cd%\UOMAPLib.dll"
) else (
    @ECHO 3) UOMAPLib.dll not found - skipping
)

if exist "AxUOMAPLib.dll" (
    @ECHO 4) Registering AxUOMAPLib.dll...
    regsvr32.exe /s "%cd%\AxUOMAPLib.dll"
) else (
    @ECHO 4) AxUOMAPLib.dll not found - skipping
)

@ECHO.
@ECHO END OF SETUP
PAUSE
