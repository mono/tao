PROGRAM = CgExamples.Gl_01_vertex_program

include $(top_builddir)/am-config.mk

SNKFILE = ../../../src/Tao.Cg/Tao.cg.snk

FILES = \
	AssemblyInfo.cs \
	Gl_01_vertex_program.cs

REFERENCES = \
	-r:../../../src/Tao.Cg/Tao.Cg.dll

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
