PROGRAM = DevIlExamples.SimpleExample

include $(top_builddir)/am-config.mk

FILES = \
	AssemblyInfo.cs \
	SimpleExample.cs

REFERENCES = \
	-r:../../../src/Tao.DevIl/Tao.DevIl.dll

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
	../../../src/Tao.DevIl/Tao.DevIl.snk
