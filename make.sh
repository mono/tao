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
    popd
  fi
done

# Copy Builds to Bin Directory
find ./ -name "Tao.*.dll" -exec cp \{\} ../dist/bin/ \;

cd $ROOTDIR

# Copy Examples to Dist Directory
mkdir -p dist/examples/Data
cp -f dist/bin/*.dll dist/examples

cp -f examples/CgExamples/Gl_01_vertex_program/bin/Release/*.exe dist/examples
cp -f examples/CgExamples/Gl_01_vertex_program/Data/*.* dist/examples/Data
cp -f examples/CgExamples/Gl_02_vertex_and_fragment_program/bin/Release/*.exe dist/examples
cp -f examples/CgExamples/Gl_02_vertex_and_fragment_program/Data/*.* dist/examples/Data

cp -f examples/DevIlExamples/SimpleExample/bin/Release/*.exe dist/examples
cp -f examples/DevIlExamples/SimpleExample/Data/*.* dist/examples/Data

cp -f examples/FreeGlutExamples/One/bin/Release/*.exe dist/examples

cp -f examples/GeWang/ClippingPlanes/bin/Release/*.exe dist/examples
cp -f examples/GeWang/Lorenz3d/bin/Release/*.exe dist/examples
cp -f examples/GeWang/Mirror/bin/Release/*.exe dist/examples
cp -f examples/GeWang/Shadow/bin/Release/*.exe dist/examples
cp -f examples/GeWang/Starfield/bin/Release/*.exe dist/examples
cp -f examples/GeWang/Xform/bin/Release/*.exe dist/examples

cp -f examples/GlfwExamples/Boing/bin/Release/*.exe dist/examples
cp -f examples/GlfwExamples/Gears/bin/Release/*.exe dist/examples
cp -f examples/GlfwExamples/KeyTest/bin/Release/*.exe dist/examples
cp -f examples/GlfwExamples/ListModes/bin/Release/*.exe dist/examples
cp -f examples/GlfwExamples/Pong/bin/Release/*.exe dist/examples
cp -f examples/GlfwExamples/Pong/Data/*.* dist/examples/Data
cp -f examples/GlfwExamples/Triangle/bin/Release/*.exe dist/examples

cp -f examples/LuaExamples/Functions/bin/Release/*.exe dist/examples
cp -f examples/LuaExamples/Functions/Data/*.* dist/examples/Data
cp -f examples/LuaExamples/Simple/bin/Release/*.exe dist/examples
cp -f examples/LuaExamples/Simple/Data/*.* dist/examples/Data

cp -f examples/NateRobins/Area/bin/Release/*.exe dist/examples
cp -f examples/NateRobins/Maiden/bin/Release/*.exe dist/examples
cp -f examples/NateRobins/Maiden/Data/*.* dist/examples/Data
cp -f examples/NateRobins/MultiView/bin/Release/*.exe dist/examples
cp -f examples/NateRobins/Nii/bin/Release/*.exe dist/examples
cp -f examples/NateRobins/Null/bin/Release/*.exe dist/examples
cp -f examples/NateRobins/Qix/bin/Release/*.exe dist/examples
cp -f examples/NateRobins/Rotate/bin/Release/*.exe dist/examples
cp -f examples/NateRobins/Starfield/bin/Release/*.exe dist/examples
cp -f examples/NateRobins/Strip/bin/Release/*.exe dist/examples
cp -f examples/NateRobins/Texture/bin/Release/*.exe dist/examples
cp -f examples/NateRobins/Voronoi/bin/Release/*.exe dist/examples

cp -f examples/NeHe/Lesson01/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson02/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson03/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson04/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson05/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson06/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson06/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson07/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson07/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson08/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson08/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson09/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson09/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson10/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson10/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson11/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson11/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson12/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson12/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson13/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson14/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson15/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson15/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson16/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson16/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson17/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson17/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson18/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson18/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson19/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson19/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson20/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson20/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson21/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson21/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson23/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson23/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson25/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson25/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson26/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson26/Data/*.* dist/examples/Data
cp -f examples/NeHe/Lesson34/bin/Release/*.exe dist/examples
cp -f examples/NeHe/Lesson34/Data/*.* dist/examples/Data

cp -f examples/OdeExamples/Basic/bin/Release/*.exe dist/examples

cp -f examples/OpenAlExamples/Boxes/bin/Release/*.exe dist/examples
cp -f examples/OpenAlExamples/Boxes/Data/*.* dist/examples/Data
cp -f examples/OpenAlExamples/Lesson01/bin/Release/*.exe dist/examples
cp -f examples/OpenAlExamples/Lesson01/Data/*.* dist/examples/Data
cp -f examples/OpenAlExamples/Lesson02/bin/Release/*.exe dist/examples
cp -f examples/OpenAlExamples/Lesson02/Data/*.* dist/examples/Data
cp -f examples/OpenAlExamples/Lesson03/bin/Release/*.exe dist/examples
cp -f examples/OpenAlExamples/Lesson03/Data/*.* dist/examples/Data
cp -f examples/OpenAlExamples/Lesson05/bin/Release/*.exe dist/examples
cp -f examples/OpenAlExamples/Lesson05/Data/*.* dist/examples/Data
cp -f examples/OpenAlExamples/Waterfall/bin/Release/*.exe dist/examples
cp -f examples/OpenAlExamples/Waterfall/Data/*.* dist/examples/Data

cp -f examples/PhysFsExamples/Simple/bin/Release/*.exe dist/examples
cp -f examples/PhysFsExamples/Simple/Data/*.* dist/examples/Data

cp -f examples/Redbook/Aaindex/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Aapoly/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Aargb/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Accanti/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Accpersp/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Alpha/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Alpha3d/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Anti/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Bezcurve/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Bezmesh/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Bezsurf/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Checker/bin/Release/*.exe dist/examples
cp -f examples/Redbook/CheckerOld/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Clip/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Colormat/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Cube/bin/Release/*.exe dist/examples
cp -f examples/Redbook/DepthCue/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Dof/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Double/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Drawf/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Feedback/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Fog/bin/Release/*.exe dist/examples
cp -f examples/Redbook/FogIndex/bin/Release/*.exe dist/examples
cp -f examples/Redbook/FogIndexOld/bin/Release/*.exe dist/examples
cp -f examples/Redbook/FogOld/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Font/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Hello/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Image/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Light/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Lines/bin/Release/*.exe dist/examples
cp -f examples/Redbook/List/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Material/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Mipmap/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Model/bin/Release/*.exe dist/examples
cp -f examples/Redbook/MoveLight/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Nurbs/bin/Release/*.exe dist/examples
cp -f examples/Redbook/PickDepth/bin/Release/*.exe dist/examples
cp -f examples/Redbook/PickSquare/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Plane/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Planet/bin/Release/*.exe dist/examples
cp -f examples/Redbook/PolyOff/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Polys/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Quadric/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Robot/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Scene/bin/Release/*.exe dist/examples
cp -f examples/Redbook/SceneBlueAmbient/bin/Release/*.exe dist/examples
cp -f examples/Redbook/SceneColorLight/bin/Release/*.exe dist/examples
cp -f examples/Redbook/SceneFlat/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Select/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Smooth/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Stencil/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Stroke/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Surface/bin/Release/*.exe dist/examples
cp -f examples/Redbook/SurfaceOld/bin/Release/*.exe dist/examples
cp -f examples/Redbook/TeaAmbient/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Teapots/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Tess/bin/Release/*.exe dist/examples
cp -f examples/Redbook/TessWind/bin/Release/*.exe dist/examples
cp -f examples/Redbook/TexBind/bin/Release/*.exe dist/examples
cp -f examples/Redbook/TexGen/bin/Release/*.exe dist/examples
cp -f examples/Redbook/TexProx/bin/Release/*.exe dist/examples
cp -f examples/Redbook/TexSub/bin/Release/*.exe dist/examples
cp -f examples/Redbook/TextureSurf/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Torus/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Trim/bin/Release/*.exe dist/examples
cp -f examples/Redbook/UnProject/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Varray/bin/Release/*.exe dist/examples
cp -f examples/Redbook/Wrap/bin/Release/*.exe dist/examples

cp -f examples/SdlExamples/GfxPrimitives/bin/Release/*.exe dist/examples
cp -f examples/SdlExamples/Rectangles/bin/Release/*.exe dist/examples
cp -f examples/SdlExamples/Rectangles/Data/*.* dist/examples/Data
cp -f examples/SdlExamples/SmpegPlayer/bin/Release/*.exe dist/examples
cp -f examples/SdlExamples/SmpegPlayer/Data/*.* dist/examples/Data

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

