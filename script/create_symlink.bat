@echo off
cd /d %~dp0

echo シンボリック消して作るよ
cd "..\My Project"
rmdir Assets
mklink /D Assets "%userprofile%\drive\マイドライブ\ailover\Assets

echo 何かキーを打って終了...

pause
exit