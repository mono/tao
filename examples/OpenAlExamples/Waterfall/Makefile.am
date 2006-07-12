PROGRAM_WIN = OpenAlExamples.Waterfall

include $(top_builddir)/am-config.mk

FILES = \
	AssemblyInfo.cs \
	Sound.cs \
	Waterfall.cs

REFERENCES = \
	-r:../../../src/Tao.OpenAl/Tao.OpenAl.dll,../../../src/Tao.OpenGl/Tao.OpenGl.dll,../../../src/Tao.OpenGl.Glu/Tao.OpenGl.Glu.dll,../../../src/Tao.FreeGlut/Tao.FreeGlut.dll,System.Drawing.dll

BUILD_FILES = $(addprefix $(srcdir)/, $(FILES))

all: $(ASSEMBLY)

install-data-local:
	echo "$(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS)";  \
	$(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS) || exit 1;

uninstall-local:
	echo "$(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS)"; \
	$(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS) || exit 1;

$(ASSEMBLY): $(FILES)
	mkdir -p $(top_builddir)/
	$(CSC) -debug -out:$@ \
		-target:$(TARGET) \
		$(REFERENCES) \
		$(CSFLAGS) \
		$(BUILD_FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb
EXTRA_DIST = \
	$(FILES)
