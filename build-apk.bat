@echo off
REM ----------------------------
REM Bygg APK för Android med .NET 9
REM ----------------------------

REM Publicera projekt i Release-läge
dotnet publish HabitTracker.csproj -f:net9.0-android35.0 -c:Release -p:RuntimeIdentifier=android-arm64 -o:publish/Android


echo.
echo ===============================
echo APK byggd!
echo Filen ligger i: publish/Android/
echo ===============================
pause
