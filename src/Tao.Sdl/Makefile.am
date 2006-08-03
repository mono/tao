LIBRARY		= Tao.Sdl

DOCS = 1
UNSAFE = 1

include $(top_builddir)/am-config.mk

FILES = \
	AssemblyInfo.cs \
	Sdl.cs \
	SdlImage.cs \
	SdlMixer.cs \
	SdlTtf.cs \
	SdlNet.cs \
	SdlGfx.cs \
	Smpeg.cs

REFERENCES =

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

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb $(ASSEMBLY).xml $(ASSEMBLY).pdb
EXTRA_DIST = \
	$(FILES) \
	Tao.Sdl.snk \
	Tao.Sdl.dll.config
