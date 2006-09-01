RUN_WITH_MONO	= 1
STRONG = 1

DESTDIR		= $(top_builddir)/dist
DOC_DEST	= .
LIBRARY_DEST	= $(DESTDIR)/lib
BINDIR		= $(DESTDIR)/bin
SYMBOLS		= 
CSFLAGS		= 
BUILD_DIR	= bin
CONFIG		= Release

# Add the unsafe command line argument if the unsafe variable is set
ifdef UNSAFE
  CSFLAGS	+= /unsafe
endif

ifdef DOCS
  CSFLAGS	+= /doc:$(DOC_DEST)/$(ASSEMBLY_NAME).xml
endif

# If ASSEMBLY_DLL has been set, and thus, is not ".dll", assume we're a 
# library, and not an executable
ifneq (library,$(TARGET))
  ASSEMBLY_EXT	= exe
else
# If ASSEMBLY_WINEXE has been set, and thus, is not ".exe", assume we're a 
# winexe, and not a command-line exe
  ASSEMBLY_EXT = dll
endif

GACUTIL_FLAGS = 

ifdef RUN_WITH_MONO
  RUN_EXE = mono
else
  RUN_EXE =
endif

