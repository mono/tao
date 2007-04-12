#!/bin/sh
./other/Prebuild/prebuild /target nant /file prebuild.xml 
nant mono-2.0 package-debug
