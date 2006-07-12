RUN_WITH_MONO	= 1
STRONG = 1

DESTDIR		= $(top_builddir)/dist
DOC_DEST	= .
LIBRARY_DEST	= $(DESTDIR)/lib
BINDIR		= $(DESTDIR)/bin
ASSEMBLY_DLL	= $(LIBRARY).dll
ASSEMBLY_EXE	= $(PROGRAM).exe
ASSEMBLY_WINEXE	= $(PROGRAM_WIN).exe
ASSEMBLY_NAME	= $(LIBRARY)
SYMBOLS		= 
CSFLAGS		= 

# Add the unsafe command line argument if the unsafe variable is set
ifdef UNSAFE
  CSFLAGS	+= /unsafe
endif

# Add the /d:STRONG command line argument (which defines a compile-time value to be set for use in pre-processing)
ifdef STRONG
  CSFLAGS += /d:STRONG
endif

# If ASSEMBLY_DLL has been set, and thus, is not ".dll", assume we're a 
# library, and not an executable
ifneq (.dll,$(ASSEMBLY_DLL))
  TARGET	= library
  ASSEMBLY	= $(ASSEMBLY_DLL)
  
  ifdef DOCS
    CSFLAGS	+= /doc:$(DOC_DEST)/$(LIBRARY).xml
  endif

  ifdef STRONG
    SNKFILE = $(LIBRARY).snk
  else
    SNKFILE =
  endif
else
# If ASSEMBLY_WINEXE has been set, and thus, is not ".exe", assume we're a 
# winexe, and not a command-line exe
  ifneq (.exe,$(ASSEMBLY_WINEXE))
    TARGET	= winexe
    ASSEMBLY	= $(ASSEMBLY_WINEXE)
  else
# Otherwise, do command-line executable-type stuff
  TARGET	= exe
  ASSEMBLY	= $(ASSEMBLY_EXE)
  endif
endif


GACUTIL_FLAGS = 

ifdef RUN_WITH_MONO
  RUN_EXE = mono
else
  RUN_EXE =
endif

