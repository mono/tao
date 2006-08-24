@REM Builds the Tao Framework using both Prebuild and NAnt 

@ECHO OFF 

@REM Create NAnt Project Files 
other\Prebuild\Prebuild.exe /target nant /file prebuild.xml 

@REM Build Solutions Using NAnt 
NAnt.exe -t:net-2.0 -buildfile:src/Tao.DevIl/Tao.DevIl.build build-release
NAnt.exe -t:net-2.0 -buildfile:src/Tao.Ode/Tao.Ode.build build-release
NAnt.exe -t:net-2.0 -buildfile:src/Tao.OpenGl/Tao.OpenGl.build build-release
NAnt.exe -t:net-2.0 -buildfile:src/Tao.PhysFs/Tao.PhysFs.build build-release
NAnt.exe -t:net-2.0 -buildfile:src/Tao.Sdl/Tao.Sdl.build build-release
NAnt.exe -t:net-2.0 -buildfile:src/Tao.Lua/Tao.Lua.build build-release

@REM Copy Builds to Dist Directory 
xcopy src\Tao.Cg\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.DevIl\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.FreeGlut\bin\Release\Tao.FreeGlut.dll dist\bin\*.* /Q /Y
xcopy src\Tao.Glfw\bin\Release\Tao.Glfw.dll dist\bin\*.* /Q /Y
xcopy src\Tao.Lua\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.Ode\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.OpenAl\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.OpenGl\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.OpenGl.ExtensionLoader\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.OpenGl.Glu\bin\Release\Tao.OpenGl.Glu.dll dist\bin\*.* /Q /Y
xcopy src\Tao.PhysFs\bin\Release\*.dll dist\bin\*.* /Q /Y
xcopy src\Tao.Platform.Windows\bin\Release\Tao.Platform.Windows.dll dist\bin\*.* /Q /Y
xcopy src\Tao.Sdl\bin\Release\*.dll dist\bin\*.* /Q /Y

@REM Copy Examples to Dist Directory
xcopy dist\bin\*.dll dist\examples\*.* /Q /Y

xcopy examples\CgExamples\Gl_01_vertex_program\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\CgExamples\Gl_01_vertex_program\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\CgExamples\Gl_02_vertex_and_fragment_program\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\CgExamples\Gl_02_vertex_and_fragment_program\Data\*.* dist\examples\Data\*.* /Q /Y

xcopy examples\DevIlExamples\SimpleExample\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\DevIlExamples\SimpleExample\Data\*.* dist\examples\Data\*.* /Q /Y

xcopy examples\FreeGlutExamples\One\bin\Release\*.exe dist\examples\*.* /Q /Y

xcopy examples\GeWang\ClippingPlanes\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\GeWang\Lorenz3d\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\GeWang\Mirror\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\GeWang\Shadow\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\GeWang\Starfield\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\GeWang\Xform\bin\Release\*.exe dist\examples\*.* /Q /Y

xcopy examples\GlfwExamples\Boing\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\GlfwExamples\Gears\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\GlfwExamples\KeyTest\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\GlfwExamples\ListModes\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\GlfwExamples\Pong\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\GlfwExamples\Pong\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\GlfwExamples\Triangle\bin\Release\*.exe dist\examples\*.* /Q /Y

xcopy examples\LuaExamples\Functions\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\LuaExamples\Functions\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\LuaExamples\Simple\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\LuaExamples\Simple\Data\*.* dist\examples\Data\*.* /Q /Y

xcopy examples\NateRobins\Area\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NateRobins\Maiden\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NateRobins\Maiden\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NateRobins\MultiView\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NateRobins\Nii\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NateRobins\Null\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NateRobins\Qix\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NateRobins\Rotate\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NateRobins\Starfield\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NateRobins\Strip\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NateRobins\Texture\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NateRobins\Voronoi\bin\Release\*.exe dist\examples\*.* /Q /Y

xcopy examples\NeHe\Lesson01\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson02\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson03\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson04\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson05\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson06\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson06\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson07\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson07\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson08\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson08\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson09\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson09\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson10\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson10\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson11\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson11\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson12\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson12\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson13\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson14\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson15\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson15\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson16\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson16\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson17\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson17\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson18\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson18\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson19\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson19\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson20\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson20\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson21\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson21\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson23\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson23\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson25\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson25\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson26\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson26\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\NeHe\Lesson34\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\NeHe\Lesson34\Data\*.* dist\examples\Data\*.* /Q /Y

xcopy examples\OdeExamples\Basic\bin\Release\*.exe dist\examples\*.* /Q /Y

xcopy examples\OpenAlExamples\Boxes\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\OpenAlExamples\Boxes\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\OpenAlExamples\Lesson01\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\OpenAlExamples\Lesson01\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\OpenAlExamples\Lesson02\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\OpenAlExamples\Lesson02\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\OpenAlExamples\Lesson03\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\OpenAlExamples\Lesson03\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\OpenAlExamples\Lesson05\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\OpenAlExamples\Lesson05\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\OpenAlExamples\Waterfall\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\OpenAlExamples\Waterfall\Data\*.* dist\examples\Data\*.* /Q /Y

xcopy examples\PhysFsExamples\Simple\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\PhysFsExamples\Simple\Data\*.* dist\examples\Data\*.* /Q /Y

xcopy examples\Redbook\Aaindex\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Aapoly\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Aargb\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Accanti\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Accpersp\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Alpha\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Alpha3d\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Anti\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Bezcurve\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Bezmesh\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Bezsurf\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Checker\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\CheckerOld\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Clip\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Colormat\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Cube\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\DepthCue\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Dof\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Double\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Drawf\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Feedback\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Fog\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\FogIndex\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\FogIndexOld\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\FogOld\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Font\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Hello\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Image\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Light\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Lines\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\List\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Material\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Mipmap\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Model\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\MoveLight\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Nurbs\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\PickDepth\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\PickSquare\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Plane\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Planet\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\PolyOff\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Polys\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Quadric\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Robot\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Scene\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\SceneBlueAmbient\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\SceneColorLight\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\SceneFlat\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Select\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Smooth\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Stencil\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Stroke\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Surface\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Surfaceold\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\TeaAmbient\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Teapots\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Tess\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\TessWind\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\TexBind\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\TexGen\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\TexProx\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\TexSub\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\TextureSurf\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Torus\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Trim\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\UnProject\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Varray\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\Redbook\Wrap\bin\Release\*.exe dist\examples\*.* /Q /Y

xcopy examples\SdlExamples\GfxPrimitives\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\SdlExamples\Rectangles\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\SdlExamples\Rectangles\Data\*.* dist\examples\Data\*.* /Q /Y
xcopy examples\SdlExamples\SmpegPlayer\bin\Release\*.exe dist\examples\*.* /Q /Y
xcopy examples\SdlExamples\SmpegPlayer\Data\*.* dist\examples\Data\*.* /Q /Y

@REM Copy XML Documentation to Dist Directory
xcopy src\Tao.Cg\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.DevIl\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.FreeGlut\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.Glfw\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.Lua\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.Ode\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.OpenAl\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.OpenGl.Glu\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.PhysFs\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.Platform.Windows\bin\Release\*.xml dist\doc\*.* /Q /Y
xcopy src\Tao.Sdl\bin\Release\*.xml dist\doc\*.* /Q /Y

pause 
