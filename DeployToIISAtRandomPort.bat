@echo off

ECHO Source: https://blogs.msdn.microsoft.com/robert_mcmurray/2018/03/21/running-iis-express-on-a-random-port/

pushd "%~dp0"

setlocal enabledelayedexpansion

if exist "wwwroot" (
if exist "%ProgramFiles%\IIS Express\iisexpress.exe" (
  set /a RNDPORT=8000 + %random% %%1000
  "%ProgramFiles%\IIS Express\iisexpress.exe" /path:"%~dp0wwwroot" /port:!RNDPORT!
)
) 

popd