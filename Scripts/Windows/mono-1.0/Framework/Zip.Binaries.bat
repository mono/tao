@ECHO OFF
mono ..\..\..\..\Other\Nant\NAnt.exe -buildfile:..\..\..\..\Tao.build set-mono-1.0-runtime-configuration set-platform-win32 set-release zip.binaries
