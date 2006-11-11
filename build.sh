#!/bin/sh
# Builds the Tao Framework using both Prebuild and NAnt 
rm -rf dist

# Create NAnt Project Files 
other/Prebuild/prebuild /target nant /file prebuild.xml 

# Build Solutions Using NAnt 
nant -t:mono-2.0 -buildfile:src/Tao.DevIl/Tao.DevIl.build package
nant -t:mono-2.0 -buildfile:src/Tao.Ode/Tao.Ode.build package 
nant -t:mono-2.0 -buildfile:src/Tao.OpenGl/Tao.OpenGl.build package 
nant -t:mono-2.0 -buildfile:src/Tao.PhysFs/Tao.PhysFs.build package 
nant -t:mono-2.0 -buildfile:src/Tao.Sdl/Tao.Sdl.build package 
nant -t:mono-2.0 -buildfile:src/Tao.Lua/Tao.Lua.build package 

# Copy Builds to Bin Directory 
mkdir -p dist/bin
cp -f src/Tao.Cg/bin/Release/*.dll dist/bin
cp -f src/Tao.DevIl/bin/Release/*.dll dist/bin
cp -f src/Tao.FreeGlut/bin/Release/*.dll dist/bin
cp -f src/Tao.Glfw/bin/Release/Tao.Glfw.dll dist/bin
cp -f src/Tao.Lua/bin/Release/*.dll dist/bin
cp -f src/Tao.Ode/bin/Release/*.dll dist/bin
cp -f src/Tao.OpenAl/bin/Release/*.dll dist/bin
cp -f src/Tao.OpenGl/bin/Release/*.dll dist/bin
cp -f src/Tao.PhysFs/bin/Release/*.dll dist/bin
cp -f src/Tao.Platform.Windows/bin/Release/Tao.Platform.Windows.dll dist/bin
cp -f src/Tao.Sdl/bin/Release/*.dll dist/bin

# Copy Examples to Dist Directory
mkdir -p dist/examples/Data
cp -f dist/bin/*.dll dist/examples

cp -f examples/CgExamples/bin/Release/*.exe dist/examples
cp -f examples/CgExamples/Data/*.* dist/examples/Data

cp -f examples/DevIlExamples/bin/Release/*.exe dist/examples
cp -f examples/DevIlExamples/Data/*.* dist/examples/Data

cp -f examples/FreeGlutExamples/One/bin/Release/*.exe dist/examples

cp -f examples/GeWangExamples/bin/Release/*.exe dist/examples

cp -f examples/GlfwExamples/bin/Release/*.exe dist/examples
cp -f examples/GlfwExamples/Data/*.exe dist/examples/Data

cp -f examples/LuaExamples/Functions/bin/Release/*.exe dist/examples
cp -f examples/LuaExamples/Functions/Data/*.* dist/examples/Data
cp -f examples/LuaExamples/Simple/bin/Release/*.exe dist/examples
cp -f examples/LuaExamples/Simple/Data/*.* dist/examples/Data

cp -f examples/NateRobins/bin/Release/*.exe dist/examples
cp -f examples/NateRobins/Data/*.* dist/examples/Data

cp -f examples/NeHe/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Data/*.* dist/examples/Data

cp -f examples/OdeExamples/Basic/bin/Release/*.exe dist/examples

cp -f examples/OpenAlExamples/bin/Release/*.exe dist/examples
cp -f examples/OpenAlExamples/Data/*.* dist/examples/Data

cp -f examples/PhysFsExamples/Simple/bin/Release/*.exe dist/examples
cp -f examples/PhysFsExamples/Simple/Data/*.* dist/examples/Data

cp -f examples/Redbook/bin/Release/*.exe dist/examples

cp -f examples/SdlExamples/bin/Release/*.exe dist/examples
cp -f examples/SdlExamples/Data/*.* dist/examples/Data

# Move Documentation to Dist Directory
mkdir -p dist/doc
cp -f src/Tao.Cg/bin/Release/*.xml dist/doc
cp -f src/Tao.DevIl/bin/Release/*.xml dist/doc
cp -f src/Tao.FreeGlut/bin/Release/*.xml dist/doc
cp -f src/Tao.Glfw/bin/Release/*.xml dist/doc
cp -f src/Tao.Lua/bin/Release/*.xml dist/doc
cp -f src/Tao.Ode/bin/Release/*.xml dist/doc
cp -f src/Tao.OpenAl/bin/Release/*.xml dist/doc
cp -f src/Tao.OpenGl/bin/Release/*.xml dist/doc
cp -f src/Tao.PhysFs/bin/Release/*.xml dist/doc
cp -f src/Tao.Platform.Windows/bin/Release/*.xml dist/doc
cp -f src/Tao.Sdl/bin/Release/*.xml dist/doc

#cp -f src/Tao.Cg/bin/Release/doc/*.chm dist/doc
#cp -f src/Tao.DevIl/bin/Release/doc/*.chm dist/doc
#cp -f src/Tao.FreeGlut/bin/Release/doc/*.chm dist/doc
#cp -f src/Tao.Glfw/bin/Release/doc/*.chm dist/doc
#cp -f src/Tao.Lua/bin/Release/doc/*.chm dist/doc
#cp -f src/Tao.Ode/bin/Release/doc/*.chm dist/doc
#cp -f src/Tao.OpenAl/bin/Release/doc/*.chm dist/doc
#cp -f src/Tao.OpenGl/bin/Release/doc/*.chm dist/doc
#cp -f src/Tao.PhysFs/bin/Release/doc/*.chm dist/doc
#cp -f src/Tao.Platform.Windows/bin/Release/doc/*.chm dist/doc
#cp -f src/Tao.Sdl/bin/Release/doc/*.chm dist/doc
