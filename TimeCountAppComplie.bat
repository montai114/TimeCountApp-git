@echo off
rem パスは自信の環境に合わして変更してください。
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe

if not %ERRORLEVEL%==0 (
	pause
	goto end
) 

echo ショートカットをデスクトップに作成しますか？
choice 
if %ERRORLEVEL%==1 (
  goto createLink
)
if %ERRORLEVEL%==2 (
  echo %ERRORLEVEL%
  goto end
)


:createLink
mklink %USERPROFILE%\Desktop\時間計測アプリ %~dp0bin\Release\TimeCountApp.exe
echo ショートカットを作成しました。
pause

:end