AC_INIT(tao-opengl.pc.in)
AC_PREREQ(2.53)
AC_CANONICAL_SYSTEM
AM_INIT_AUTOMAKE([tao],[0.0.8],[tao-list@lists.ximian.com])

AM_MAINTAINER_MODE

dnl AC_PROG_INTLTOOL([0.25])

AC_PROG_INSTALL

MONO_REQUIRED_VERSION=1.1

AC_MSG_CHECKING([whether we're compiling from CVS])
if test -f "$srcdir/.cvs_version" ; then
        from_cvs=yes
else
  if test -f "$srcdir/.svn" ; then
        from_cvs=yes
  else
        from_cvs=no
  fi
fi

AC_MSG_RESULT($from_cvs)

AC_PATH_PROG(MONO, mono)
AC_PATH_PROG(MCS, mcs)
AC_PATH_PROG(GACUTIL, gacutil)

AC_MSG_CHECKING([for mono])
dnl if test "x$MONO" = "x" ; then
dnl  AC_MSG_ERROR([Can't find "mono" in your PATH])
dnl else
  AC_MSG_RESULT([found])
dnl fi

AC_MSG_CHECKING([for mcs])
dnl if test "x$MCS" = "x" ; then
dnl  AC_MSG_ERROR([Can't find "mcs" in your PATH])
dnl else
  AC_MSG_RESULT([found])
dnl fi

AC_MSG_CHECKING([for gacutil])
if test "x$GACUTIL" = "x" ; then
  AC_MSG_ERROR([Can't find "gacutil" in your PATH])
else
  AC_MSG_RESULT([found])
fi

AC_SUBST(PATH)
AC_SUBST(LD_LIBRARY_PATH)

CSFLAGS="-debug -nowarn:1574"
AC_SUBST(CSFLAGS)

dnl Find pkg-config
AC_PATH_PROG(PKGCONFIG, pkg-config, no)
if test "x$PKG_CONFIG" = "xno"; then
        AC_MSG_ERROR([You need to install pkg-config])
fi

PKG_CHECK_MODULES(MONO_DEPENDENCY, mono >= $MONO_REQUIRED_VERSION, has_mono=true, has_mono=false)

if test "x$has_mono" = "xtrue"; then
  AC_PATH_PROG(RUNTIME, mono, no)
  AC_PATH_PROG(CSC, mcs, no)
  if test `uname -s` = "Darwin"; then
        LIB_PREFIX=
        LIB_SUFFIX=.dylib
  else
        LIB_PREFIX=.so
        LIB_SUFFIX=
  fi
else
  AC_PATH_PROG(CSC, csc.exe, no)
  if test x$CSC = "xno"; then
        AC_MSG_ERROR([You need to install either mono or .Net])
  else
    RUNTIME=
    LIB_PREFIX=
    LIB_SUFFIX=.dylib
  fi
fi

AC_SUBST(LIB_PREFIX)
AC_SUBST(LIB_SUFFIX)

AC_SUBST(BASE_DEPENDENCIES_CFLAGS)
AC_SUBST(BASE_DEPENDENCIES_LIBS)

dnl Find monodoc
MONODOC_REQUIRED_VERSION=1.0
AC_SUBST(MONODOC_REQUIRED_VERSION)
PKG_CHECK_MODULES(MONODOC_DEPENDENCY, monodoc >= $MONODOC_REQUIRED_VERSION, enable_monodoc=yes, enable_monodoc=no)

if test "x$enable_monodoc" = "xyes"; then
        AC_PATH_PROG(MONODOC, monodoc, no)
        if test x$MONODOC = xno; then
           enable_monodoc=no
        fi
else
        MONODOC=
fi

AC_SUBST(MONODOC)
AM_CONDITIONAL(ENABLE_MONODOC, test "x$enable_monodoc" = "xyes")

AC_PATH_PROG(GACUTIL, gacutil, no)
if test "x$GACUTIL" = "xno" ; then
        AC_MSG_ERROR([No gacutil tool found])
fi

GACUTIL_FLAGS='/package Tao /gacdir $(DESTDIR)$(prefix)/lib'
AC_SUBST(GACUTIL_FLAGS)

winbuild=no
case "$host" in
       *-*-mingw*|*-*-cygwin*)
               winbuild=yes
               ;;
esac
AM_CONDITIONAL(WINBUILD, test x$winbuild = xyes)


dnl Check for OpenGL and friends

AX_CHECK_GL
AC_SUBST([GL_CFLAGS])
AC_SUBST([GL_LIBS])


AX_CHECK_GLU
AC_SUBST([GLU_CFLAGS])
AC_SUBST([GLU_LIBS])

AX_CHECK_GLUT
AC_SUBST([GLUT_CFLAGS])
AC_SUBST([GLUT_LIBS])

dnl Check for SDL

AC_PATH_PROG([SDL_CONFIG], [sdl-config])
have_sdl=no
if test -n "${SDL_CONFIG}"; then
    have_sdl=yes
    SDL_CFLAGS=`$SDL_CONFIG --cflags`
    SDL_LIBS=`$SDL_CONFIG --libs`
    #
    # sdl-config sometimes emits an rpath flag pointing at its library
    # installation directory.  We don't want this, as it prevents users from
    # linking sdl-viewer against, for example, a locally compiled libGL when a
    # version of the library also exists in SDL's library installation
    # directory, typically /usr/lib.
    #
    SDL_LIBS=`echo $SDL_LIBS | sed 's/-Wl,-rpath,[[^ ]]* //'`
fi
AC_SUBST([SDL_CFLAGS])
AC_SUBST([SDL_LIBS])


AC_OUTPUT([
tao-cg.pc
tao-devil.pc
tao-freeglut.pc
tao-glfw.pc
tao-ode.pc
tao-openal.pc
tao-opengl.pc
tao-opengl-glu.pc
tao-sdl.pc
tao-physfs.pc
tao-platform-windows.pc
Makefile
src/Makefile
src/Tao.OpenGl.ExtensionLoader/Makefile
src/Tao.GlPostProcess/Makefile
src/Tao.OpenGl/Makefile
src/Tao.Cg/Makefile
src/Tao.DevIl/Makefile
src/Tao.FreeGlut/Makefile
src/Tao.Glfw/Makefile
src/Tao.Ode/Makefile
src/Tao.OpenAl/Makefile
src/Tao.OpenGl.Glu/Makefile
src/Tao.Sdl/Makefile
src/Tao.PhysFs/Makefile
src/Tao.Platform.Windows/Makefile
examples/Makefile
examples/SdlExamples/Makefile
examples/SdlExamples/Rectangles/Makefile
examples/SdlExamples/GfxPrimitives/Makefile
examples/SdlExamples/SmpegPlayer/Makefile
examples/DevIlExamples/Makefile
examples/DevIlExamples/SimpleExample/Makefile
examples/PhysFsExamples/Makefile
examples/PhysFsExamples/Simple/Makefile
examples/GeWang/Makefile
examples/GeWang/ClippingPlanes/Makefile
examples/GeWang/Lorenz3d/Makefile
examples/GeWang/Mirror/Makefile
examples/GeWang/Shadow/Makefile
examples/GeWang/Starfield/Makefile
examples/GeWang/Xform/Makefile
examples/GlfwExamples/Makefile
examples/GlfwExamples/Boing/Makefile
examples/GlfwExamples/Gears/Makefile
examples/GlfwExamples/KeyTest/Makefile
examples/GlfwExamples/ListModes/Makefile
examples/GlfwExamples/Pong/Makefile
examples/GlfwExamples/Triangle/Makefile
examples/NateRobins/Makefile
examples/NateRobins/Area/Makefile
examples/NateRobins/Maiden/Makefile
examples/NateRobins/MultiView/Makefile
examples/NateRobins/Nii/Makefile
examples/NateRobins/Null/Makefile
examples/NateRobins/Qix/Makefile
examples/NateRobins/Rotate/Makefile
examples/NateRobins/Starfield/Makefile
examples/NateRobins/Strip/Makefile
examples/NateRobins/Texture/Makefile
examples/NateRobins/Voronoi/Makefile
examples/NeHe/Makefile
examples/NeHe/Lesson01/Makefile
examples/NeHe/Lesson02/Makefile
examples/NeHe/Lesson03/Makefile
examples/NeHe/Lesson04/Makefile
examples/NeHe/Lesson05/Makefile
examples/NeHe/Lesson06/Makefile
examples/NeHe/Lesson07/Makefile
examples/NeHe/Lesson08/Makefile
examples/NeHe/Lesson09/Makefile
examples/NeHe/Lesson10/Makefile
examples/NeHe/Lesson11/Makefile
examples/NeHe/Lesson12/Makefile
examples/NeHe/Lesson13/Makefile
examples/NeHe/Lesson14/Makefile
examples/NeHe/Lesson15/Makefile
examples/NeHe/Lesson16/Makefile
examples/NeHe/Lesson17/Makefile
examples/NeHe/Lesson18/Makefile
examples/NeHe/Lesson19/Makefile
examples/NeHe/Lesson20/Makefile
examples/NeHe/Lesson21/Makefile
examples/NeHe/Lesson23/Makefile
examples/NeHe/Lesson25/Makefile
examples/NeHe/Lesson26/Makefile
examples/NeHe/Lesson34/Makefile
examples/OpenAlExamples/Makefile
examples/OpenAlExamples/Boxes/Makefile
examples/OpenAlExamples/Lesson01/Makefile
examples/OpenAlExamples/Lesson02/Makefile
examples/OpenAlExamples/Lesson03/Makefile
examples/OpenAlExamples/Lesson05/Makefile
examples/OpenAlExamples/Waterfall/Makefile
examples/OdeExamples/Makefile
examples/OdeExamples/Basic/Makefile
examples/Redbook/Makefile
examples/Redbook/Aaindex/Makefile
examples/Redbook/Aapoly/Makefile
examples/Redbook/Aargb/Makefile
examples/Redbook/Accanti/Makefile
examples/Redbook/Accpersp/Makefile
examples/Redbook/Alpha/Makefile
examples/Redbook/Alpha3d/Makefile
examples/Redbook/Anti/Makefile
examples/Redbook/Bezcurve/Makefile
examples/Redbook/Bezmesh/Makefile
examples/Redbook/Bezsurf/Makefile
examples/Redbook/Checker/Makefile
examples/Redbook/CheckerOld/Makefile
examples/Redbook/Clip/Makefile
examples/Redbook/Colormat/Makefile
examples/Redbook/Cube/Makefile
examples/Redbook/DepthCue/Makefile
examples/Redbook/Dof/Makefile
examples/Redbook/Double/Makefile
examples/Redbook/Drawf/Makefile
examples/Redbook/Feedback/Makefile
examples/Redbook/Fog/Makefile
examples/Redbook/FogIndex/Makefile
examples/Redbook/FogIndexOld/Makefile
examples/Redbook/FogOld/Makefile
examples/Redbook/Font/Makefile
examples/Redbook/Hello/Makefile
examples/Redbook/Image/Makefile
examples/Redbook/Light/Makefile
examples/Redbook/Lines/Makefile
examples/Redbook/List/Makefile
examples/Redbook/Material/Makefile
examples/Redbook/Mipmap/Makefile
examples/Redbook/Model/Makefile
examples/Redbook/MoveLight/Makefile
examples/Redbook/Nurbs/Makefile
examples/Redbook/PickDepth/Makefile
examples/Redbook/PickSquare/Makefile
examples/Redbook/Plane/Makefile
examples/Redbook/Planet/Makefile
examples/Redbook/PolyOff/Makefile
examples/Redbook/Polys/Makefile
examples/Redbook/Quadric/Makefile
examples/Redbook/Robot/Makefile
examples/Redbook/Scene/Makefile
examples/Redbook/SceneBlueAmbient/Makefile
examples/Redbook/SceneColorLight/Makefile
examples/Redbook/SceneFlat/Makefile
examples/Redbook/Select/Makefile
examples/Redbook/Smooth/Makefile
examples/Redbook/Stencil/Makefile
examples/Redbook/Stroke/Makefile
examples/Redbook/Surface/Makefile
examples/Redbook/SurfaceOld/Makefile
examples/Redbook/TeaAmbient/Makefile
examples/Redbook/Teapots/Makefile
examples/Redbook/Tess/Makefile
examples/Redbook/TessWind/Makefile
examples/Redbook/TexBind/Makefile
examples/Redbook/TexGen/Makefile
examples/Redbook/TexProx/Makefile
examples/Redbook/TexSub/Makefile
examples/Redbook/TextureSurf/Makefile
examples/Redbook/Torus/Makefile
examples/Redbook/Trim/Makefile
examples/Redbook/UnProject/Makefile
examples/Redbook/Varray/Makefile
examples/Redbook/Wrap/Makefile
checkbuild.sh
])

#po/Makefile.in

echo "---"
echo "Configuration summary"
echo ""
echo "   * Installation prefix: $prefix"
echo "   * compiler: $CSC"
echo "   * Documentation: $enable_monodoc ($MONODOC)"
echo ""
echo "---"

