@REM Builds the Tao Framework for Mono using both Prebuild and NAnt 

@ECHO OFF 
rmdir /s /q dist

ECHO -------------------------
ECHO Create NAnt Project Files 
ECHO -------------------------
other\Prebuild\Prebuild.exe /target nant /file prebuild.xml 

ECHO --------------------------
ECHO Build Solutions Using NAnt
ECHO --------------------------
NAnt.exe -t:mono-2.0 -buildfile:src/Tao.DevIl/Tao.DevIl.build package
NAnt.exe -t:mono-2.0 -buildfile:src/Tao.Ode/Tao.Ode.build package
NAnt.exe -t:mono-2.0 -buildfile:src/Tao.OpenGl/Tao.OpenGl.build package
NAnt.exe -t:mono-2.0 -buildfile:src/Tao.PhysFs/Tao.PhysFs.build package
NAnt.exe -t:mono-2.0 -buildfile:src/Tao.Sdl/Tao.Sdl.build package
NAnt.exe -t:mono-2.0 -buildfile:src/Tao.Lua/Tao.Lua.build package

ECHO -----------------------------
ECHO Copy Builds to Dist Directory
ECHO -----------------------------
xcopy src\Tao.Cg\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.DevIl\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.FreeGlut\bin\Release\Tao.FreeGlut.dll dist\bin\*.* /Q /Y
xcopy src\Tao.Glfw\bin\Release\Tao.Glfw.dll dist\bin\*.* /Q /Y
xcopy src\Tao.Lua\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.Ode\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.OpenAl\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.OpenGl\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.PhysFs\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.Platform.Windows\bin\Release\Tao.Platform.Windows.dll dist\bin\*.* /Q /Y
xcopy src\Tao.Sdl\bin\Release\*.dll dist\bin\*.* /Q /Y

ECHO -------------------------------
ECHO Copy Examples to Dist Directory
ECHO -------------------------------
xcopy dist\bin\*.dll dist\examples\*.* /Q /Y

ECHO.
ECHO Cg Examples
xcopy examples\CgExamples\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\CgExamples\Data\*.* dist\examples\Data\*.* /Q /Y

ECHO.
ECHO DevIl Examples
xcopy examples\DevIlExamples\SimpleExample\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\DevIlExamples\SimpleExample\Data\*.* dist\examples\Data\*.* /Q /Y

ECHO.
ECHO FreeGlut Examples
xcopy examples\FreeGlutExamples\One\bin\Release\*.exe dist\examples\*.* /Q /Y

ECHO.
ECHO GeWang Examples
xcopy examples\GeWangExamples\bin\Release\*.exe dist\examples\*.* /Q /Y

ECHO.
ECHO GlfwExamples Examples
xcopy examples\GlfwExamples\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\GlfwExamples\Data\*.* dist\examples\Data\*.* /Q /Y

ECHO.
ECHO Lua Examples
xcopy examples\LuaExamples\Functions\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\LuaExamples\Functions\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\LuaExamples\Simple\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\LuaExamples\Simple\Data\*.* dist\examples\Data\*.* /Q /Y

ECHO.
ECHO NateRobins Examples
xcopy examples\NateRobins\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NateRobins\Data\*.* dist\examples\Data\*.* /Q /Y

ECHO.
ECHO NeHe Examples
xcopy examples\NeHe\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Data\*.* dist\examples\Data\*.* /Q /Y

ECHO.
ECHO Ode Examples
xcopy examples\OdeExamples\Basic\bin\Release\*.exe dist\examples\*.* /Q /Y

ECHO.
ECHO OpenAl Examples
xcopy examples\OpenAlExamples\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\OpenAlExamples\Data\*.* dist\examples\Data\*.* /Q /Y

ECHO.
ECHO PhysFs Examples
xcopy examples\PhysFsExamples\Simple\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\PhysFsExamples\Simple\Data\*.* dist\examples\Data\*.* /Q /Y

ECHO.
ECHO Redbook Examples
xcopy examples\Redbook\bin\Release\*.exe dist\examples\*.* /Q /Y

ECHO.
ECHO Sdl Examples
xcopy examples\SdlExamples\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\SdlExamples\Data\*.* dist\examples\Data\*.* /Q /Y

ECHO --------------------------
ECHO Move Documentation To Dist
ECHO --------------------------
xcopy src\Tao.Cg\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.DevIl\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.FreeGlut\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.Glfw\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.Lua\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.Ode\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.OpenAl\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.OpenGl\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.PhysFs\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.Platform.Windows\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.Sdl\bin\Release\*.xml dist\doc\*.* /Q /Y

xcopy src\Tao.Cg\bin\Release\doc\*.chm dist\doc\*.* /Q /Y
xcopy src\Tao.DevIl\bin\Release\doc\*.chm dist\doc\*.* /Q /Y
xcopy src\Tao.FreeGlut\bin\Release\doc\*.chm dist\doc\*.* /Q /Y
xcopy src\Tao.Glfw\bin\Release\doc\*.chm dist\doc\*.* /Q /Y
xcopy src\Tao.Lua\bin\Release\doc\*.chm dist\doc\*.* /Q /Y
xcopy src\Tao.Ode\bin\Release\doc\*.chm dist\doc\*.* /Q /Y
xcopy src\Tao.OpenAl\bin\Release\doc\*.chm dist\doc\*.* /Q /Y
xcopy src\Tao.OpenGl\bin\Release\doc\*.chm dist\doc\*.* /Q /Y
xcopy src\Tao.PhysFs\bin\Release\doc\*.chm dist\doc\*.* /Q /Y
xcopy src\Tao.Platform.Windows\bin\Release\doc\*.chm dist\doc\*.* /Q /Y
xcopy src\Tao.Sdl\bin\Release\doc\*.chm dist\doc\*.* /Q /Y

pause 
