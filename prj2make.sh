#!/bin/sh
./other/Prebuild/prebuild /target vs2003 /file prebuild.xml

PROJECTS="
    Tao.OpenGl
    Tao.Glfw
    Tao.DevIl
    Tao.Ode
    Tao.PhysFs
    Tao.Platform.Windows
    Tao.FreeGlut
    Tao.OpenAl
    Tao.Lua
    Tao.Sdl
    Tao.GlBindGen
    Tao.Cg"

ROOTDIR=$PWD;

for i in $PROJECTS ; do
  cd $ROOTDIR/src/$i
  prj2make $i.csproj && \
  make || exit 1
done

cd $ROOTDIR


