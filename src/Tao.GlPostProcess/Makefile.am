PROGRAM		= Tao.GlPostProcess

include $(top_builddir)/am-config.mk

SNKFILE = Tao.GlPostProcess.snk

FILES = \
	AssemblyInfo.cs \
	GlPostProcess.cs

REFERENCES = \
	-r:../Tao.OpenGl.ExtensionLoader/Tao.OpenGl.ExtensionLoader.dll

BUILD_FILES = $(addprefix $(srcdir)/, $(FILES))

all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(top_builddir)/
	cp ../Tao.OpenGl.ExtensionLoader/Tao.OpenGl.ExtensionLoader.dll .
	$(CSC) -debug -out:$@ \
		-target:$(TARGET) \
		$(REFERENCES) \
		$(CSFLAGS) \
		$(BUILD_FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb
EXTRA_DIST = \
	$(FILES) \
	Tao.GlPostProcess.snk
