#!/bin/sh
# Builds the Tao Framework using both Prebuild and NAnt 

# Create NAnt Project Files 
other/Prebuild/prebuild /target nant /file prebuild.xml 

rm -rf dist

# Build Solutions Using NAnt 
nant -t:mono-2.0 -buildfile:src/Tao.DevIl/Tao.DevIl.build clean
nant -t:mono-2.0 -buildfile:src/Tao.GlGenerator/Tao.GlGenerator.build clean 
nant -t:mono-2.0 -buildfile:src/Tao.Ode/Tao.Ode.build clean 
nant -t:mono-2.0 -buildfile:src/Tao.OpenGl/Tao.OpenGl.build clean 
nant -t:mono-2.0 -buildfile:src/Tao.PhysFs/Tao.PhysFs.build clean 
nant -t:mono-2.0 -buildfile:src/Tao.Sdl/Tao.Sdl.build clean 
nant -t:mono-2.0 -buildfile:src/Tao.Lua/Tao.Lua.build clean 
