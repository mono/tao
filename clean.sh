#!/bin/sh
# Builds the Tao Framework using both Prebuild and autotools 

configure_args=$1

# clean autotools Project Files 
#other/Prebuild/prebuild /target autotools /file prebuild.xml /clean
other/Prebuild/prebuild /file prebuild.xml /clean

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

# clean up dist files
rm -rf dist

ROOTDIR=$PWD

cd $ROOTDIR/src

for thedir in $PACKAGES ;
do
  # If the configure.ac file exists, clean
  if [ -f $thedir/configure.ac ]
  then
    pushd $thedir &&
    autoreconf -i -s &&
    ./configure $configure_args &&
    make distclean
    popd
  fi
done

cd $ROOTDIR

# Clean up the left-overs
for i in \
    Include.am \
    autom4te.cache \
    aclocal.m4 \
    config.log \
    config.status \
    config.guess \
    configure \
    config.sub \
    configure.ac \
    Makefile \
    Makefile.am \
    Makefile.in \
    install-sh \
    missing \
    '*.pc' \
    '*.pc.in' ; do
  find ./ -name $i -exec rm -rf \{\} \;
done


