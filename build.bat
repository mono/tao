@echo off
REM built from make using fixbat.pl, see other/fixbat.pl
mkdir dist
mkdir dist\bin
mkdir dist\examples
mkdir obj
echo src
chdir "src"
echo src/Tao.OpenGl.ExtensionLoader
chdir "Tao.OpenGl.ExtensionLoader"
csc /nologo /target:library /D:WIN32 /doc:..\..\dist\bin\Tao.OpenGl.ExtensionLoader.xml /out:..\..\dist\bin\Tao.OpenGl.ExtensionLoader.dll AssemblyInfo.cs GlExtensionLoader.cs /lib:..\..\dist\bin 
copy /y Tao.OpenGl.ExtensionLoader.dll.config ..\..\dist\bin\Tao.OpenGl.ExtensionLoader.dll.config
chdir ..
echo src/Tao.GlPostProcess
chdir "Tao.GlPostProcess"
csc /nologo /target:exe /D:WIN32 /out:..\..\dist\bin\Tao.GlPostProcess.exe AssemblyInfo.cs GlPostProcess.cs /lib:..\..\dist\bin /r:Tao.OpenGl.ExtensionLoader.dll
chdir ..
echo src/Tao.OpenGl
chdir "Tao.OpenGl"
csc /nologo /target:library /D:WIN32 /out:..\..\obj\Tao.OpenGl-pre.dll AssemblyInfo.cs Gl.cs ContextGl.cs /lib:..\..\dist\bin /r:Tao.OpenGl.ExtensionLoader.dll
..\..\dist\bin\Tao.GlPostProcess.exe ..\..\obj\Tao.OpenGl-pre.dll ..\..\dist\bin\Tao.OpenGl.dll "" Tao.OpenGl.Gl Tao.OpenGl.ContextGl
copy /y Tao.OpenGl.dll.config ..\..\dist\bin\Tao.OpenGl.dll.config
chdir ..
echo src/Tao.OpenGl.Glu
chdir "Tao.OpenGl.Glu"
csc /nologo /target:library /D:WIN32 /unsafe /doc:..\..\dist\bin\Tao.OpenGl.Glu.xml /out:..\..\dist\bin\Tao.OpenGl.Glu.dll AssemblyInfo.cs Glu.cs /lib:..\..\dist\bin /r:Tao.OpenGl.dll
copy /y Tao.OpenGl.Glu.dll.config ..\..\dist\bin\Tao.OpenGl.Glu.dll.config
chdir ..
echo src/Tao.Cg
chdir "Tao.Cg"
csc /nologo /target:library /D:WIN32 /unsafe /doc:..\..\dist\bin\Tao.Cg.xml /out:..\..\dist\bin\Tao.Cg.dll AssemblyInfo.cs Cg.cs /lib:..\..\dist\bin 
copy /y Tao.Cg.dll.config ..\..\dist\bin\Tao.Cg.dll.config
chdir ..
echo src/Tao.DevIl
chdir "Tao.DevIl"
csc /nologo /target:library /D:WIN32 /doc:..\..\dist\bin\Tao.DevIl.xml /out:..\..\dist\bin\Tao.DevIl.dll AssemblyInfo.cs Il.cs Ilu.cs Ilut.cs /lib:..\..\dist\bin 
copy /y Tao.DevIl.dll.config ..\..\dist\bin\Tao.DevIl.dll.config
chdir ..
echo src/Tao.PostProcess
chdir "Tao.PostProcess"
csc /nologo /target:exe /D:WIN32 /out:..\..\dist\bin\Tao.PostProcess.exe AssemblyInfo.cs AppMain.cs BuildProcessor.cs Options.cs ReleaseBuildProcessor.cs UsageHelp.cs /lib:..\..\dist\bin 
chdir ..
echo src/Tao.FreeGlut
chdir "Tao.FreeGlut"
csc /nologo /target:library /D:WIN32 /unsafe /doc:..\..\dist\bin\Tao.FreeGlut.xml /out:..\..\obj\Tao.FreeGlut-pre.dll AssemblyInfo.cs Glut.cs DelegateCallingConventionCdeclAttribute.cs /lib:..\..\dist\bin /r:Tao.OpenGl.dll
ildasm /text /OUT=..\..\obj\Tao.FreeGlut-pre.dll.il ..\..\obj\Tao.FreeGlut-pre.dll
..\..\dist\bin\Tao.PostProcess.exe ..\..\obj\Tao.FreeGlut-pre.dll.il ..\..\obj\Tao.FreeGlut-pre.dll.pp.il /R /Y
ilasm  /dll ..\..\obj\Tao.FreeGlut-pre.dll.pp.il /out:..\..\dist\bin\Tao.FreeGlut.dll
copy /y Tao.FreeGlut.dll.config ..\..\dist\bin\Tao.FreeGlut.dll.config
chdir ..
echo src/Tao.Glfw
chdir "Tao.Glfw"
csc /nologo /target:library /D:WIN32 /doc:..\..\dist\bin\Tao.Glfw.xml /out:..\..\dist\bin\Tao.Glfw.dll AssemblyInfo.cs Glfw.cs /lib:..\..\dist\bin /r:Tao.OpenGl.dll
copy /y Tao.Glfw.dll.config ..\..\dist\bin\Tao.Glfw.dll.config
chdir ..
echo src/Tao.Ode
chdir "Tao.Ode"
csc /nologo /target:library /D:WIN32 /unsafe /doc:..\..\dist\bin\Tao.Ode.xml /out:..\..\obj\Tao.Ode-pre.dll AssemblyInfo.cs Ode.cs DelegateCallingConventionCdeclAttribute.cs /lib:..\..\dist\bin 
ildasm /text /OUT=..\..\obj\Tao.Ode-pre.dll.il ..\..\obj\Tao.Ode-pre.dll
..\..\dist\bin\Tao.PostProcess.exe ..\..\obj\Tao.Ode-pre.dll.il ..\..\obj\Tao.Ode-pre.dll.pp.il /R /Y
ilasm  /dll ..\..\obj\Tao.Ode-pre.dll.pp.il /out:..\..\dist\bin\Tao.Ode.dll
copy /y Tao.Ode.dll.config ..\..\dist\bin\Tao.Ode.dll.config
pause
chdir ..
echo src/Tao.OpenAl
chdir "Tao.OpenAl"
csc /nologo /target:library /D:WIN32 /unsafe /doc:..\..\dist\bin\Tao.OpenAl.xml /out:..\..\dist\bin\Tao.OpenAl.dll AssemblyInfo.cs Al.cs Alc.cs Alut.cs /lib:..\..\dist\bin 
copy /y Tao.OpenAl.dll.config ..\..\dist\bin\Tao.OpenAl.dll.config
chdir ..
echo src/Tao.Sdl
chdir "Tao.Sdl"
csc /nologo /target:library /D:WIN32 /unsafe /doc:..\..\dist\bin\Tao.Sdl.xml /out:..\..\obj\Tao.Sdl-pre.dll AssemblyInfo.cs Sdl.cs SdlImage.cs SdlMixer.cs SdlTtf.cs SdlGfx.cs Smpeg.cs DelegateCallingConventionCdeclAttribute.cs /lib:..\..\dist\bin 
ildasm /text /OUT=..\..\obj\Tao.Sdl-pre.dll.il ..\..\obj\Tao.Sdl-pre.dll
..\..\dist\bin\Tao.PostProcess.exe ..\..\obj\Tao.Sdl-pre.dll.il ..\..\obj\Tao.Sdl-pre.dll.pp.il /R /Y
ilasm  /dll ..\..\obj\Tao.Sdl-pre.dll.pp.il /out:..\..\dist\bin\Tao.Sdl.dll
copy /y Tao.Sdl.dll.config ..\..\dist\bin\Tao.Sdl.dll.config
chdir ..
echo src/Tao.Platform.Windows
chdir "Tao.Platform.Windows"
csc /nologo /target:library /D:WIN32 /unsafe /doc:..\..\dist\bin\Tao.Platform.Windows.xml /out:..\..\obj\Tao.Platform.Windows-pre.dll AssemblyInfo.cs Gdi.cs IlasmAttribute.cs Kernel.cs SimpleOpenGlControl.cs User.cs Wgl.cs WinNt.cs Winmm.cs /lib:..\..\dist\bin /r:System.Drawing.dll /r:System.Windows.Forms.dll /r:Tao.OpenGl.dll
ildasm /text /OUT=..\..\obj\Tao.Platform.Windows-pre.dll.il ..\..\obj\Tao.Platform.Windows-pre.dll
..\..\dist\bin\Tao.PostProcess.exe ..\..\obj\Tao.Platform.Windows-pre.dll.il ..\..\obj\Tao.Platform.Windows-pre.dll.pp.il /R /Y
ilasm  /dll ..\..\obj\Tao.Platform.Windows-pre.dll.pp.il /out:..\..\dist\bin\Tao.Platform.Windows.dll
copy /y Tao.Platform.Windows.dll.config ..\..\dist\bin\Tao.Platform.Windows.dll.config
chdir ..
chdir ..
echo examples
chdir "examples"
echo examples/DevIlExamples
chdir "DevIlExamples"
echo examples/DevIlExamples/SimpleExample
chdir "SimpleExample"
csc /nologo /D:WIN32 /target:exe /out:..\..\..\dist\examples\DevIlExamples.SimpleExample.exe AssemblyInfo.cs SimpleExample.cs /lib:..\..\..\dist\bin /r:Tao.DevIl.dll
chdir ..
chdir ..
echo examples/GeWang
chdir "GeWang"
echo examples/GeWang/ClippingPlanes
chdir "ClippingPlanes"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\GeWang.ClippingPlanes.exe AssemblyInfo.cs ClippingPlanes.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/GeWang/Lorenz3d
chdir "Lorenz3d"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\GeWang.Lorenz3d.exe AssemblyInfo.cs Lorenz3d.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/GeWang/Mirror
chdir "Mirror"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\GeWang.Mirror.exe AssemblyInfo.cs Mirror.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/GeWang/Shadow
chdir "Shadow"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\GeWang.Shadow.exe AssemblyInfo.cs Shadow.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/GeWang/Starfield
chdir "Starfield"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\GeWang.Starfield.exe AssemblyInfo.cs Starfield.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/GeWang/Xform
chdir "Xform"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\GeWang.Xform.exe AssemblyInfo.cs Xform.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
chdir ..
echo examples/GlfwExamples
chdir "GlfwExamples"
echo examples/GlfwExamples/Boing
chdir "Boing"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\GlfwExamples.Boing.exe AssemblyInfo.cs Boing.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Glfw.dll
chdir ..
echo examples/GlfwExamples/Gears
chdir "Gears"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\GlfwExamples.Gears.exe AssemblyInfo.cs Gears.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.Glfw.dll
chdir ..
echo examples/GlfwExamples/KeyTest
chdir "KeyTest"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\GlfwExamples.KeyTest.exe AssemblyInfo.cs KeyTest.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.Glfw.dll
chdir ..
echo examples/GlfwExamples/ListModes
chdir "ListModes"
csc /nologo /D:WIN32 /target:exe /out:..\..\..\dist\examples\GlfwExamples.ListModes.exe AssemblyInfo.cs ListModes.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.Glfw.dll
chdir ..
echo examples/GlfwExamples/Triangle
chdir "Triangle"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\GlfwExamples.Triangle.exe AssemblyInfo.cs Triangle.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Glfw.dll
chdir ..
chdir ..
echo examples/NateRobins
chdir "NateRobins"
echo examples/NateRobins/Area
chdir "Area"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NateRobbins.Area.exe AssemblyInfo.cs Area.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/NateRobins/Maiden
chdir "Maiden"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NateRobbins.Maiden.exe AssemblyInfo.cs Maiden.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/NateRobins/MultiView
chdir "MultiView"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NateRobbins.MultiView.exe AssemblyInfo.cs MultiView.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/NateRobins/Nii
chdir "Nii"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NateRobbins.Nii.exe AssemblyInfo.cs Nii.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/NateRobins/Null
chdir "Null"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NateRobbins.Null.exe AssemblyInfo.cs Null.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/NateRobins/Qix
chdir "Qix"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NateRobbins.Qix.exe AssemblyInfo.cs Qix.cs Point.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/NateRobins/Rotate
chdir "Rotate"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NateRobbins.Rotate.exe AssemblyInfo.cs Rotate.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/NateRobins/Starfield
chdir "Starfield"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NateRobbins.Starfield.exe AssemblyInfo.cs Starfield.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/NateRobins/Strip
chdir "Strip"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NateRobbins.Strip.exe AssemblyInfo.cs Strip.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/NateRobins/Texture
chdir "Texture"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NateRobbins.Texture.exe AssemblyInfo.cs Texture.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/NateRobins/Voronoi
chdir "Voronoi"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NateRobbins.Voronoi.exe AssemblyInfo.cs Voronoi.cs Node.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
chdir ..
echo examples/NeHe
chdir "NeHe"
echo examples/NeHe/Lesson01
chdir "Lesson01"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson01.exe AssemblyInfo.cs Lesson01.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson02
chdir "Lesson02"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson02.exe AssemblyInfo.cs Lesson02.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson03
chdir "Lesson03"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson03.exe AssemblyInfo.cs Lesson03.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson04
chdir "Lesson04"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson04.exe AssemblyInfo.cs Lesson04.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson05
chdir "Lesson05"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson05.exe AssemblyInfo.cs Lesson05.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson06
chdir "Lesson06"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson06.exe AssemblyInfo.cs Lesson06.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson07
chdir "Lesson07"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson07.exe AssemblyInfo.cs Lesson07.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson08
chdir "Lesson08"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson08.exe AssemblyInfo.cs Lesson08.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson09
chdir "Lesson09"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson09.exe AssemblyInfo.cs Lesson09.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson10
chdir "Lesson10"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson10.exe AssemblyInfo.cs Lesson10.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson11
chdir "Lesson11"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson11.exe AssemblyInfo.cs Lesson11.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson12
chdir "Lesson12"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson12.exe AssemblyInfo.cs Lesson12.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson13
chdir "Lesson13"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson13.exe AssemblyInfo.cs Lesson13.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson14
chdir "Lesson14"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson14.exe AssemblyInfo.cs Lesson14.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson15
chdir "Lesson15"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson15.exe AssemblyInfo.cs Lesson15.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson16
chdir "Lesson16"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson16.exe AssemblyInfo.cs Lesson16.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson17
chdir "Lesson17"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson17.exe AssemblyInfo.cs Lesson17.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson18
chdir "Lesson18"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson18.exe AssemblyInfo.cs Lesson18.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson19
chdir "Lesson19"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson19.exe AssemblyInfo.cs Lesson19.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson20
chdir "Lesson20"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson20.exe AssemblyInfo.cs Lesson20.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson21
chdir "Lesson21"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson21.exe AssemblyInfo.cs Lesson21.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson23
chdir "Lesson23"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson23.exe AssemblyInfo.cs Lesson23.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson25
chdir "Lesson25"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson25.exe AssemblyInfo.cs Lesson25.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson26
chdir "Lesson26"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson26.exe AssemblyInfo.cs Lesson26.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
echo examples/NeHe/Lesson34
chdir "Lesson34"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\NeHe.Lesson34.exe AssemblyInfo.cs Lesson34.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.Platform.Windows.dll /r:System.Windows.Forms.dll /r:System.Drawing.dll
chdir ..
chdir ..
echo examples/OdeExamples
chdir "OdeExamples"
echo examples/OdeExamples/Basic
chdir "Basic"
csc /nologo /D:WIN32 /unsafe /out:..\..\..\dist\examples\OdeExamples.Basic.exe AssemblyInfo.cs Basic.cs /lib:..\..\..\dist\bin /r:Tao.Ode.dll
chdir ..
chdir ..
echo examples/OpenAlExamples
chdir "OpenAlExamples"
echo examples/OpenAlExamples/Boxes
chdir "Boxes"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\OpenAlExamples.Boxes.exe AssemblyInfo.cs Boxes.cs /lib:..\..\..\dist\bin /r:Tao.OpenAl.dll /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/OpenAlExamples/Lesson01
chdir "Lesson01"
csc /nologo /D:WIN32 /target:exe /out:..\..\..\dist\examples\OpenAlExamples.Lesson01.exe AssemblyInfo.cs Lesson01.cs /lib:..\..\..\dist\bin /r:Tao.OpenAl.dll /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/OpenAlExamples/Lesson02
chdir "Lesson02"
csc /nologo /D:WIN32 /target:exe /out:..\..\..\dist\examples\OpenAlExamples.Lesson02.exe AssemblyInfo.cs Lesson02.cs /lib:..\..\..\dist\bin /r:Tao.OpenAl.dll /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/OpenAlExamples/Lesson03
chdir "Lesson03"
csc /nologo /D:WIN32 /target:exe /out:..\..\..\dist\examples\OpenAlExamples.Lesson03.exe AssemblyInfo.cs Lesson03.cs /lib:..\..\..\dist\bin /r:Tao.OpenAl.dll /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/OpenAlExamples/Lesson05
chdir "Lesson05"
csc /nologo /D:WIN32 /target:exe /out:..\..\..\dist\examples\OpenAlExamples.Lesson05.exe AssemblyInfo.cs Lesson05.cs /lib:..\..\..\dist\bin /r:Tao.OpenAl.dll /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/OpenAlExamples/Waterfall
chdir "Waterfall"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\OpenAlExamples.Waterfall.exe AssemblyInfo.cs Waterfall.cs Sound.cs /lib:..\..\..\dist\bin /r:Tao.OpenAl.dll /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll /r:System.Drawing.dll
chdir ..
chdir ..
echo examples/Redbook
chdir "Redbook"
echo examples/Redbook/Aaindex
chdir "Aaindex"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Aaindex.exe AssemblyInfo.cs Aaindex.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Aapoly
chdir "Aapoly"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Aapoly.exe AssemblyInfo.cs Aapoly.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Aargb
chdir "Aargb"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Aargb.exe AssemblyInfo.cs Aargb.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Accanti
chdir "Accanti"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Accanti.exe AssemblyInfo.cs Accanti.cs Jitter.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Accpersp
chdir "Accpersp"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Accpersp.exe AssemblyInfo.cs Accpersp.cs Jitter.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Alpha
chdir "Alpha"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Alpha.exe AssemblyInfo.cs Alpha.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Alpha3d
chdir "Alpha3d"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Alpha3d.exe AssemblyInfo.cs Alpha3d.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Anti
chdir "Anti"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Anti.exe AssemblyInfo.cs Anti.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Bezcurve
chdir "Bezcurve"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Bezcurve.exe AssemblyInfo.cs Bezcurve.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Bezmesh
chdir "Bezmesh"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Bezmesh.exe AssemblyInfo.cs Bezmesh.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Bezsurf
chdir "Bezsurf"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Bezsurf.exe AssemblyInfo.cs Bezsurf.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Checker
chdir "Checker"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Checker.exe AssemblyInfo.cs Checker.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/CheckerOld
chdir "CheckerOld"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.CheckerOld.exe AssemblyInfo.cs CheckerOld.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Clip
chdir "Clip"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Clip.exe AssemblyInfo.cs Clip.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Colormat
chdir "Colormat"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Colormat.exe AssemblyInfo.cs Colormat.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Cube
chdir "Cube"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Cube.exe AssemblyInfo.cs Cube.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/DepthCue
chdir "DepthCue"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.DepthCue.exe AssemblyInfo.cs DepthCue.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Dof
chdir "Dof"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Dof.exe AssemblyInfo.cs Dof.cs Jitter.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Double
chdir "Double"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Double.exe AssemblyInfo.cs Double.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Drawf
chdir "Drawf"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Drawf.exe AssemblyInfo.cs Drawf.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Feedback
chdir "Feedback"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Feedback.exe AssemblyInfo.cs Feedback.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Fog
chdir "Fog"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Fog.exe AssemblyInfo.cs Fog.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/FogIndex
chdir "FogIndex"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.FogIndex.exe AssemblyInfo.cs FogIndex.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/FogIndexOld
chdir "FogIndexOld"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.FogIndexOld.exe AssemblyInfo.cs FogIndexOld.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/FogOld
chdir "FogOld"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.FogOld.exe AssemblyInfo.cs FogOld.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Font
chdir "Font"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Font.exe AssemblyInfo.cs Font.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Hello
chdir "Hello"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Hello.exe AssemblyInfo.cs Hello.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Image
chdir "Image"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Image.exe AssemblyInfo.cs Image.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Light
chdir "Light"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Light.exe AssemblyInfo.cs Light.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Lines
chdir "Lines"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Lines.exe AssemblyInfo.cs Lines.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/List
chdir "List"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.List.exe AssemblyInfo.cs List.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Material
chdir "Material"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Material.exe AssemblyInfo.cs Material.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Mipmap
chdir "Mipmap"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Mipmap.exe AssemblyInfo.cs Mipmap.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Model
chdir "Model"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Model.exe AssemblyInfo.cs Model.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/MoveLight
chdir "MoveLight"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.MoveLight.exe AssemblyInfo.cs MoveLight.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Nurbs
chdir "Nurbs"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Nurbs.exe AssemblyInfo.cs Nurbs.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/PickDepth
chdir "PickDepth"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.PickDepth.exe AssemblyInfo.cs PickDepth.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/PickSquare
chdir "PickSquare"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.PickSquare.exe AssemblyInfo.cs PickSquare.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Plane
chdir "Plane"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Plane.exe AssemblyInfo.cs Plane.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Planet
chdir "Planet"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Planet.exe AssemblyInfo.cs Planet.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/PolyOff
chdir "PolyOff"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.PolyOff.exe AssemblyInfo.cs PolyOff.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Polys
chdir "Polys"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Polys.exe AssemblyInfo.cs Polys.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Quadric
chdir "Quadric"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Quadric.exe AssemblyInfo.cs Quadric.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Robot
chdir "Robot"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Robot.exe AssemblyInfo.cs Robot.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Scene
chdir "Scene"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Scene.exe AssemblyInfo.cs Scene.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/SceneBlueAmbient
chdir "SceneBlueAmbient"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.SceneBlueAmbient.exe AssemblyInfo.cs SceneBlueAmbient.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/SceneColorLight
chdir "SceneColorLight"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.SceneColorLight.exe AssemblyInfo.cs SceneColorLight.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/SceneFlat
chdir "SceneFlat"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.SceneFlat.exe AssemblyInfo.cs SceneFlat.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Select
chdir "Select"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Select.exe AssemblyInfo.cs Select.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Smooth
chdir "Smooth"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Smooth.exe AssemblyInfo.cs Smooth.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Stencil
chdir "Stencil"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Stencil.exe AssemblyInfo.cs Stencil.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Stroke
chdir "Stroke"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Stroke.exe AssemblyInfo.cs Stroke.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Surface
chdir "Surface"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Surface.exe AssemblyInfo.cs Surface.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/SurfaceOld
chdir "SurfaceOld"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.SurfaceOld.exe AssemblyInfo.cs SurfaceOld.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/TeaAmbient
chdir "TeaAmbient"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.TeaAmbient.exe AssemblyInfo.cs TeaAmbient.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Teapots
chdir "Teapots"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Teapots.exe AssemblyInfo.cs Teapots.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Tess
chdir "Tess"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Tess.exe AssemblyInfo.cs Tess.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/TessWind
chdir "TessWind"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.TessWind.exe AssemblyInfo.cs TessWind.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/TexBind
chdir "TexBind"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.TexBind.exe AssemblyInfo.cs TexBind.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/TexGen
chdir "TexGen"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.TexGen.exe AssemblyInfo.cs TexGen.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/TexProx
chdir "TexProx"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.TexProx.exe AssemblyInfo.cs TexProx.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/TexSub
chdir "TexSub"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.TexSub.exe AssemblyInfo.cs TexSub.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/TextureSurf
chdir "TextureSurf"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.TextureSurf.exe AssemblyInfo.cs TextureSurf.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Torus
chdir "Torus"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Torus.exe AssemblyInfo.cs Torus.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Trim
chdir "Trim"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Trim.exe AssemblyInfo.cs Trim.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/UnProject
chdir "UnProject"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.UnProject.exe AssemblyInfo.cs UnProject.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Varray
chdir "Varray"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Varray.exe AssemblyInfo.cs Varray.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
echo examples/Redbook/Wrap
chdir "Wrap"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\Redbook.Wrap.exe AssemblyInfo.cs Wrap.cs /lib:..\..\..\dist\bin /r:Tao.OpenGl.dll /r:Tao.OpenGl.Glu.dll /r:Tao.FreeGlut.dll
chdir ..
chdir ..
echo examples/SdlExamples
chdir "SdlExamples"
echo examples/SdlExamples/GfxPrimitives
chdir "GfxPrimitives"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\SdlExamples.GfxPrimitives.exe AssemblyInfo.cs GfxPrimitives.cs /lib:..\..\..\dist\bin /r:Tao.Sdl.dll
chdir ..
echo examples/SdlExamples/Rectangles
chdir "Rectangles"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\SdlExamples.Rectangles.exe AssemblyInfo.cs Rectangles.cs /lib:..\..\..\dist\bin /r:Tao.Sdl.dll
chdir ..
echo examples/SdlExamples/SmpegPlayer
chdir "SmpegPlayer"
csc /nologo /D:WIN32 /target:winexe /out:..\..\..\dist\examples\SdlExamples.SmpegPlayer.exe AssemblyInfo.cs SmpegPlayer.cs /lib:..\..\..\dist\bin /r:Tao.Sdl.dll
chdir ..
chdir ..
chdir ..
