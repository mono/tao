@REM Builds the Tao Framework using both Prebuild and NAnt 

@ECHO OFF 

@REM Create NAnt Project Files 
other\Prebuild\Prebuild.exe /target nant /file prebuild.xml 

@REM Build Solutions Using NAnt 
NAnt.exe -t:net-2.0 -buildfile:src/Tao.Cg/Tao.Cg.build 
NAnt.exe -t:net-2.0 -buildfile:src/Tao.DevIl/Tao.DevIl.build 
NAnt.exe -t:net-2.0 -buildfile:src/Tao.Ode/Tao.Ode.build 
NAnt.exe -t:net-2.0 -buildfile:src/Tao.OpenGl/Tao.OpenGl.build 
NAnt.exe -t:net-2.0 -buildfile:src/Tao.PhysFs/Tao.PhysFs.build 
NAnt.exe -t:net-2.0 -buildfile:src/Tao.Sdl/Tao.Sdl.build 
NAnt.exe -t:net-2.0 -buildfile:src/Tao.Lua/Tao.Lua.build

@REM Copy Builds to Bin Directory 
@REM ..... Todo 

pause 
