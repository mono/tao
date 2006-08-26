PROGRAM_WIN = CgExamples.Gl_02_vertex_and_fragment_program

include $(top_builddir)/am-config.mk

SNKFILE = ../../../src/Tao.Cg/Tao.cg.snk

FILES = \
	AssemblyInfo.cs \
	Gl_02_vertex_and_fragment_program.cs

REFERENCES = \
		-r:../../../src/Tao.Cg/Tao.Cg.dll,../../../src/Tao.OpenGl/Tao.OpenGl.dll,../../../src/Tao.OpenGl.ExtensionLoader/Tao.OpenGl.ExtensionLoader.dll,../../../src/Tao.OpenGl.Glu/Tao.OpenGl.Glu.dll,../../../src/Tao.FreeGlut/Tao.FreeGlut.dll

BUILD_FILES = $(addprefix $(srcdir)/, $(FILES))

all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(top_builddir)/
	$(CSC) -debug -out:$@ \
		-target:$(TARGET) \
		$(REFERENCES) \
		$(CSFLAGS) \
		$(BUILD_FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb
EXTRA_DIST = \
	$(FILES) \
	../../../src/Tao.Cg/Tao.Cg.snk
