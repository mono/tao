PROGRAM_WIN = NeHe.Lesson23

include $(top_builddir)/am-config.mk

FILES = \
	AssemblyInfo.cs \
	Lesson23.cs

REFERENCES = \
	-r:../../../src/Tao.OpenGl/Tao.OpenGl.dll,../../../src/Tao.OpenGl.ExtensionLoader/Tao.OpenGl.ExtensionLoader.dll,../../../src/Tao.OpenGl.Glu/Tao.OpenGl.Glu.dll,../../../src/Tao.Platform.Windows/Tao.Platform.Windows.dll,System.Windows.Forms.dll,System.Drawing.dll

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
