@ECHO OFF
mono ..\..\..\..\Other\Nant\NAnt.exe -buildfile:..\..\..\..\Tao.build set-release set-mono-1.0-runtime-configuration set-platform-win32 clean.sdl
