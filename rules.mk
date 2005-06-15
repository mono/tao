##
## rules.mk
##

EXIT_ON_ERROR := set -e; # Shell loops continue past errors without this.

ifdef DIRS
LOOP_OVER_DIRS = \
	@$(EXIT_ON_ERROR) \
	for d in $(DIRS); do \
		$(MAKE) -C $$d $@; \
	done
endif

REFFLAGS := $(REFS:%=$(REFFLAG):%)

PROGRAM_DEST = $(DESTDIR)/bin
LIBRARY_DEST = $(DESTDIR)/bin
EXAMPLE_DEST = $(DESTDIR)/examples

ifdef RUN_WITH_MONO
 RUN_EXE = mono
else
 RUN_EXE = 
endif

ifdef STRONG
 CSFLAGS += /d:STRONG
endif

all::
	$(MAKE) build

clean::
	$(LOOP_OVER_DIRS)

build: $(LIBRARY) $(PROGRAM) $(EXAMPLE) $(EXTRA_LIB_DIST) $(EXAMPLE_DATA) $(LIBRARY_DEST) $(EXAMPLE_DEST) $(EXAMPLE_DEST)/Data
	@for f in $(EXTRA_LIB_DIST); do \
		cp $$f $(LIBRARY_DEST); \
	done
	@for f in $(EXAMPLE_DATA); do \
		cp $$f $(EXAMPLE_DEST)/Data; \
	done
	$(LOOP_OVER_DIRS)

##
## Rules for Libraries; two kinds:
##
## 1) Normal, non-postprocessed libraries.  Just go straight to bindir.
##
## 2) Postprocessed libraries.  Multi-step process that does an IL round-trip.
##
## A .config file is required for each library.
##

ifneq (,$(LIBRARY))
$(LIBRARY): $(LIBRARY_DEST) $(LIBRARY_DEST)/$(LIBRARY).dll $(LIBRARY_DEST)/$(LIBRARY).dll.config

ifeq (,$(WIN32_BUILD))

# We only postprocess on win32, so just do a normal dll if we're not on win32
$(LIBRARY_DEST)/$(LIBRARY).dll: $(SRCS)
	$(CSC) /target:library $(CSFLAGS) /out:$@ $^ /lib:$(LIBRARY_DEST) $(REFFLAGS)

else

# And on win32, we only postprocess libs that request it
ifeq (,$(POSTPROCESS_LIBRARY))

# No preprocessing required
$(LIBRARY_DEST)/$(LIBRARY).dll: $(SRCS)
	$(CSC) /target:library $(CSFLAGS) /out:$@ $^ /lib:$(LIBRARY_DEST) $(REFFLAGS)

else

# Postprocess; note that the initially-compiled library must have the same
# name as the resulting library -- ilasm doesn't change the .assembly name
# embedded in the assembly.
ifneq (,$(STRONG))
 STRONGFLAG = /key:$(LIBRARY).snk
else
 STRONGFLAG =
endif

$(LIBRARY_DEST)/$(LIBRARY).dll: $(LIBRARY)-pre.dll.pp.il
	$(ILASM) $(STRONGFLAG) /dll $< /out:$@

$(LIBRARY)-pre.dll.pp.il: $(PROGRAM_DEST)/Tao.PostProcess.exe $(LIBRARY)-pre.dll.il
	$(RUN_EXE) $(PROGRAM_DEST)/Tao.PostProcess.exe $(LIBRARY)-pre.dll.il $(LIBRARY)-pre.dll.pp.il /R /Y

$(LIBRARY)-pre.dll.il: $(LIBRARY)-pre.dll
	$(ILDASM) /OUT=$@ $<

$(LIBRARY)-pre.dll: $(SRCS)
	$(CSC) /target:library $(CSFLAGS) /out:$@ $^ /lib:$(LIBRARY_DEST) $(REFFLAGS)

clean::
	rm -f $(LIBRARY)-pre*

endif # POSTPROCESS_LIBRARY
endif # !WIN32

$(LIBRARY_DEST)/$(LIBRARY).dll.config: $(LIBRARY).dll.config
	cp -f $^ $@

clean::
	rm -f $(LIBRARY_DEST)/$(LIBRARY).dll $(LIBRARY_DEST)/$(LIBRARY).dll.config
endif

##
## Rules for creating programs (to go into the bindir)
##

ifneq (,$(PROGRAM))
$(PROGRAM): $(PROGRAM_DEST) $(PROGRAM_DEST)/$(PROGRAM).exe

$(PROGRAM_DEST)/$(PROGRAM).exe: $(SRCS)
	$(CSC) /target:exe $(CSFLAGS) /out:$@ $^ /lib:$(LIBRARY_DEST) $(REFFLAGS)

clean::
	rm -f $(PROGRAM_DEST)/$(PROGRAM).exe
endif

##
## Rules for handling examples, with an optional category,
## and with optional data.  Examples go into the example dir.
##

ifneq (,$(EXAMPLE))
ifneq (,$(EXAMPLE_CATEGORY))
EXAMPLE_TARGET=$(EXAMPLE_CATEGORY).$(EXAMPLE)
else
EXAMPLE_TARGET=$(EXAMPLE)
endif

$(EXAMPLE): $(EXAMPLE_DEST) $(EXAMPLE_DEST)/$(EXAMPLE_TARGET).exe

$(EXAMPLE_DEST)/$(EXAMPLE_TARGET).exe: $(SRCS)
	$(CSC) $(CSFLAGS) /out:$@ $^ /lib:$(LIBRARY_DEST) $(REFFLAGS)

clean::
	rm -f $(EXAMPLE_DEST)/$(EXAMPLE_TARGET).exe
endif

ifneq (,$(EXAMPLE_DATA))
EXAMPLE_DATA_FILES = $(notdir $(EXAMPLE_DATA))
clean::
	rm -f $(EXAMPLE_DATA_FILES:%=$(EXAMPLE_DEST)/Data/%)
endif


##
## Rules for creating output dirs
##

$(PROGRAM_DEST):
	mkdir -p $(PROGRAM_DEST)

ifneq ($(PROGRAM_DEST),$(LIBRARY_DEST))
$(LIBRARY_DEST):
	mkdir -p $(LIBRARY_DEST)
endif

$(EXAMPLE_DEST):
	mkdir -p $(EXAMPLE_DEST)

$(EXAMPLE_DEST)/Data:
	mkdir -p $(EXAMPLE_DEST)/Data

