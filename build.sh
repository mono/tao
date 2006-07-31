#!/bin/sh
# Builds the Tao Framework using both Prebuild and NAnt 

# Create NAnt Project Files 
other/Prebuild/Prebuild.exe /target nant /file prebuild.xml 

# Build Solutions Using NAnt 
mnant -t:mono-2.0 -buildfile:src/Tao.Cg/Tao.Cg.build 
mnant -t:mono-2.0 -buildfile:src/Tao.DevIl/Tao.DevIl.build 
mnant -t:mono-2.0 -buildfile:src/Tao.Ode/Tao.Ode.build 
mnant -t:mono-2.0 -buildfile:src/Tao.OpenGl/Tao.OpenGl.build 
mnant -t:mono-2.0 -buildfile:src/Tao.PhysFs/Tao.PhysFs.build 
mnant -t:mono-2.0 -buildfile:src/Tao.Sdl/Tao.Sdl.build 
mnant -t:mono-2.0 -buildfile:src/Tao.Lua/Tao.Lua.build

# Copy Builds to Bin Directory 
# ..... Todo 

