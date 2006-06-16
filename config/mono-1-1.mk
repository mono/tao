
##
## Config file for Mono 1.1
##

ifneq (,$(MONODIR))
 CSC = $(MONODIR)/mcs
else
 CSC = mcs
endif
CSFLAGS =
ILDASM = monodis
ILASM = ilasm

RUN_WITH_MONO = 1
WIN32_BUILD =

# flag to compiler to build a library
LIBFLAG = /target:library

# flag to compiler to have the result go to the output; will be used like
# $(OUTFLAG):foo.dll.  Same with ref.
OUTFLAG = /out
REFFLAG = /r

DESTDIR = $(DEPTH)/dist

