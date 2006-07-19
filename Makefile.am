SUBDIRS = src \
	  examples

pkgconfig_in_files = \
	tao-cg.pc.in \
	tao-devil.pc.in \
	tao-freeglut.pc.in \
	tao-glfw.pc.in \
	tao-ode.pc.in \
	tao-openal.pc.in \
	tao-opengl.pc.in \
	tao-opengl-glu.pc.in \
	tao-sdl.pc.in \
	tao-physfs.pc.in \
	tao-platform-windows.pc.in


pkgconfigdir=$(prefix)/lib/pkgconfig
pkgconfig_DATA=$(pkgconfig_in_files:.pc.in=.pc)

EXTRA_DIST = \
	$(pkgconfig_in_files) \
	am-config.mk

DISTCLEANFILES = \
	configure \
	config.guess \
	config.sub   \
	Makefile.in  \
	install-sh   \
	aclocal.m4   \
	missing
