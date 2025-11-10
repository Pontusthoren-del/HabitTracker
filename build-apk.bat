@echo off
REM ----------------------------
REM Bygg APK för Android
REM ----------------------------
dotnet publish -f:net8.0-android -c:Release -o:publish/Android

echo.
echo ===============================
echo APK byggd!
echo Filen ligger i: publish/Android/
echo ===============================
pause