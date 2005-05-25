
##
## Config file for .NET 1.1
##

CSC = csc /nologo
CSFLAGS = /D:WIN32
ILDASM = ildasm /text
ILASM = ilasm

RUN_WITH_MONO =
WIN32_BUILD = 1

# flag to $(CSC) to build a library
LIBFLAG = /target:library

# flag to $(MCS) to have the result go to the output; will be used like
# $(OUTFLAG):foo.dll
OUTFLAG = /out
REFFLAG = /r

DESTDIR = $(DEPTH)/dist
