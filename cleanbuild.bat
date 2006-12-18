@REM Builds the Tao Framework using both Prebuild and NAnt 

@ECHO OFF 

@REM Create NAnt Project Files 
other\Prebuild\Prebuild.exe /target nant /file prebuild.xml 

rmdir /s /q dist

@REM Build Solutions Using NAnt 
NAnt.exe -t:net-2.0 -buildfile:src/Tao.DevIl/Tao.DevIl.build clean
NAnt.exe -t:net-2.0 -buildfile:src/Tao.Ode/Tao.Ode.build clean
NAnt.exe -t:net-2.0 -buildfile:src/Tao.GlBindGen/Tao.GlBindGen.build clean
NAnt.exe -t:net-2.0 -buildfile:src/Tao.OpenGl/Tao.OpenGl.build clean
NAnt.exe -t:net-2.0 -buildfile:src/Tao.PhysFs/Tao.PhysFs.build clean
NAnt.exe -t:net-2.0 -buildfile:src/Tao.Sdl/Tao.Sdl.build clean
NAnt.exe -t:net-2.0 -buildfile:src/Tao.Lua/Tao.Lua.build clean
