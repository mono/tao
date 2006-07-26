dnl @synopsis AX_CHECK_GLU
dnl
dnl Check for GLU.  If GLU is found, the required preprocessor and linker flags
dnl are included in the output variables "GLU_CFLAGS" and "GLU_LIBS",
dnl respectively.  This macro adds the configure option
dnl "--with-apple-opengl-framework", which users can use to indicate that
dnl Apple's OpenGL framework should be used on Mac OS X.  If Apple's OpenGL
dnl framework is used, the symbol "HAVE_APPLE_OPENGL_FRAMEWORK" is defined.  If
dnl no GLU implementation is found, "no_glu" is set to "yes".
dnl
dnl @copyright (C) 2003 Braden McDaniel
dnl @license GNU GPL
dnl @version 1.0
dnl @author Braden McDaniel <address@hidden>
dnl
AC_DEFUN([AX_CHECK_GLU],
[AC_REQUIRE([AX_CHECK_GL])dnl
GLU_CFLAGS="${GL_CFLAGS}"
if test "X${with_apple_opengl_framework}" != "Xyes"; then
  AC_CACHE_CHECK([for OpenGL Utility library], [ax_cv_check_glu_libglu],
  [ax_cv_check_glu_libglu="no"
  ax_save_CPPFLAGS="${CPPFLAGS}"
  CPPFLAGS="${GL_CFLAGS} ${CPPFLAGS}"
  ax_save_LIBS="${LIBS}"
  LIBS=""
  ax_check_libs="-lglu32 -lGLU"
  for ax_lib in ${ax_check_libs}; do
    if test "X$CC" = "Xcl"; then
      ax_try_lib=`echo $ax_lib | sed -e 's/^-l//' -e 's/$/.lib/'`
    else
      ax_try_lib="${ax_lib}"
    fi
    LIBS="${ax_try_lib} ${GL_LIBS} ${ax_save_LIBS}"
    #
    # libGLU typically links with libstdc++ on POSIX platforms. However,
    # setting the language to C++ means that test program source is named
    # "conftest.cc"; and Microsoft cl doesn't know what to do with such a
    # file.
    #
    if test "X$CXX" != "Xcl"; then
      AC_LANG_PUSH([C++])
    fi
    AC_TRY_LINK([
# if HAVE_WINDOWS_H && defined(_WIN32)
#   include <windows.h>
# endif
# include <GL/glu.h>
],
    [gluBeginCurve(0)],
    [ax_cv_check_glu_libglu="${ax_try_lib}"; break])
    if test "X$CXX" != "Xcl"; then
      AC_LANG_POP([C++])
    fi
  done
  LIBS=${ax_save_LIBS}
  CPPFLAGS=${ax_save_CPPFLAGS}])
  if test "X${ax_cv_check_glu_libglu}" = "Xno"; then
    no_gl="yes"
    GLU_CFLAGS=""
    GLU_LIBS=""
  else
    GLU_LIBS="${ax_cv_check_glu_libglu} ${GL_LIBS}"
  fi
fi
AC_SUBST([GLU_CFLAGS])
AC_SUBST([GLU_LIBS])
])
