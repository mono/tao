PROGRAM_WIN = SdlExamples.GfxPrimitives

include $(top_builddir)/am-config.mk

SNKFILE = ../../../src/Tao.Sdl/Tao.Sdl.snk

FILES = \
	AssemblyInfo.cs \
	GfxPrimitives.cs

REFERENCES = \
	-r:../../../src/Tao.Sdl/Tao.Sdl.dll

BUILD_FILES = $(addprefix $(srcdir)/, $(FILES))

all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(top_builddir)/
	$(CSC) -debug -out:$@ \
		-target:$(TARGET) \
		$(REFERENCES) \
		$(CSFLAGS) \
		$(BUILD_FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb $(ASSEMBLY_NAME).pdb $(ASSEMBLY_NAME).xml
EXTRA_DIST = \
	$(FILES) \
	../../../src/Tao.Sdl/Tao.Sdl.snk
