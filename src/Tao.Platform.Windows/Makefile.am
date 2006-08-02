LIBRARY		= Tao.Platform.Windows

DOCS = 1
UNSAFE = 1

include $(top_builddir)/am-config.mk

FILES = \
AssemblyInfo.cs \
	Gdi.cs \
	IlasmAttribute.cs \
	Kernel.cs \
	SimpleOpenGlControl.cs \
	User.cs \
	Wgl.cs \
	WinNt.cs \
	Winmm.cs

REFERENCES = \
	-r:../Tao.OpenGl/Tao.OpenGl.dll,../Tao.OpenGl.ExtensionLoader/Tao.OpenGl.ExtensionLoader.dll,System.Drawing.dll,System.Windows.Forms.dll

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
	$(FILES) \
	Tao.Platform.Windows.snk \
	Tao.Platform.Windows.dll.config
