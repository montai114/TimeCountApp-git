@echo off
rem �p�X�͎��M�̊��ɍ��킵�ĕύX���Ă��������B
C:\Windows\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe

if not %ERRORLEVEL%==0 (
	pause
	goto end
) 

echo �V���[�g�J�b�g���f�X�N�g�b�v�ɍ쐬���܂����H
choice 
if %ERRORLEVEL%==1 (
  goto createLink
)
if %ERRORLEVEL%==2 (
  echo %ERRORLEVEL%
  goto end
)


:createLink
mklink %USERPROFILE%\Desktop\���Ԍv���A�v�� %~dp0bin\Release\TimeCountApp.exe
echo �V���[�g�J�b�g���쐬���܂����B
pause

:end