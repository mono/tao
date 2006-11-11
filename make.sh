#!/bin/sh
# Builds the Tao Framework using both Prebuild and autotools 

configure_args=$1

# Create autotools Project Files 
other/Prebuild/prebuild /target autotools /file prebuild.xml 

# Build Solutions Using autotools 
PACKAGES="Tao.DevIl
          Tao.GlBindGen
	  Tao.Ode
	  Tao.PhysFs
	  Tao.Sdl
	  Tao.Lua
	  Tao.OpenGl
	  Tao.OpenAl
	  "

mkdir -p dist/bin

ROOTDIR=$PWD

cd $ROOTDIR/src

for thedir in $PACKAGES ;
do
  # If the configure.ac file exists, build
  if [ -f $thedir/configure.ac ]
  then
    pushd $thedir &&
    autoreconf -i -s &&
    ./configure $configure_args &&
    make &&
    make install || exit -1
    make install-data-local
    popd
  fi
done

# Copy Builds to Bin Directory
find ./ -name "Tao.*.dll" -exec cp \{\} ../dist/bin/ \;

cd $ROOTDIR

# Copy Examples to Dist Directory
mkdir -p dist/examples/Data
cp -f dist/bin/*.dll dist/examples

cp -f examples/CgExamples/bin/Release/*.exe dist/examples
cp -f examples/CgExamples/Data/*.* dist/examples/Data

cp -f examples/DevIlExamples/SimpleExample/bin/Release/*.exe dist/examples
cp -f examples/DevIlExamples/SimpleExample/Data/*.* dist/examples/Data

cp -f examples/FreeGlutExamples/One/bin/Release/*.exe dist/examples

cp -f examples/GeWangExamples/bin/Release/*.exe dist/examples

cp -f examples/GlfwExamples/bin/Release/*.exe dist/examples
cp -f examples/GlfwExamples/Data/*.* dist/examples/Data

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

# Build Documentation Using autotools 
mkdir -p dist/doc
cp -f src/Tao.Cg/bin/Release/*.xml dist/doc
cp -f src/Tao.DevIl/bin/Release/*.xml dist/doc
cp -f src/Tao.FreeGlut/bin/Release/*.xml dist/doc
cp -f src/Tao.Glfw/bin/Release/*.xml dist/doc
cp -f src/Tao.Lua/bin/Release/*.xml dist/doc
cp -f src/Tao.Ode/bin/Release/*.xml dist/doc
cp -f src/Tao.OpenAl/bin/Release/*.xml dist/doc
cp -f src/Tao.PhysFs/bin/Release/*.xml dist/doc
cp -f src/Tao.Platform.Windows/bin/Release/*.xml dist/doc
cp -f src/Tao.Sdl/bin/Release/*.xml dist/doc

