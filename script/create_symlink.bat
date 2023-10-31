@echo off
cd /d %~dp0

echo シンボリック作るよ
cd "..\My Project"
mklink /D Assets "G:\マイドライブ\ailover\Assets

echo 何かキーを打って終了...

pause
exit