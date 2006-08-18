PROGRAM		= Tao.GlGenerator

include $(top_builddir)/am-config.mk

SNKFILE = Tao.GlGenerator.snk

FILES = \
	AssemblyInfo.cs \
	GlGenerator.cs

REFERENCES = 

BUILD_FILES = $(addprefix $(srcdir)/, $(FILES))

all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(top_builddir)/
	$(CSC) -debug -out:$@ \
		-target:$(TARGET) \
		$(REFERENCES) \
		$(CSFLAGS) \
		$(BUILD_FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb $(ASSEMBLY_NAME).pdb
EXTRA_DIST = \
	$(FILES) \
	Tao.GlGenerator.snk
