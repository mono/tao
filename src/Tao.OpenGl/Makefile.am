LIBRARY		= Tao.OpenGl

include $(top_builddir)/am-config.mk

FILES = \
	AssemblyInfo.cs \
	Gl.cs \
	ContextGl.cs

REFERENCES = \
	-r:../Tao.OpenGl.ExtensionLoader/Tao.OpenGl.ExtensionLoader.dll

BUILD_FILES = $(addprefix $(srcdir)/, $(FILES))

build: gl_build

all: $(ASSEMBLY)

install-data-local:
	echo "$(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS)";  \
	$(GACUTIL) /i $(ASSEMBLY) /f $(GACUTIL_FLAGS) || exit 1;

uninstall-local:
	echo "$(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS)"; \
	$(GACUTIL) /u $(ASSEMBLY_NAME) $(GACUTIL_FLAGS) || exit 1;


$(ASSEMBLY): Tao.OpenGl-pre.dll
	MONO_PATH=$(MONO_PATH):../Tao.OpenGl.ExtensionLoader $(RUN_EXE) ../Tao.GlPostProcess/Tao.GlPostProcess.exe \
		$(srcdir)/$< $@ "$(SNKFILE)" \
		Tao.OpenGl.Gl Tao.OpenGl.ContextGl


Tao.OpenGl-pre.dll: $(FILES)
	mkdir -p $(top_builddir)/
	$(CSC) -debug -out:$@ \
		-target:$(TARGET) \
		$(REFERENCES) \
		$(CSFLAGS) \
		$(BUILD_FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb Tao.OpenGl-pre.dll
EXTRA_DIST = \
	$(FILES) \
	Tao.OpenGl.snk \
	Tao.OpenGl.dll.config
