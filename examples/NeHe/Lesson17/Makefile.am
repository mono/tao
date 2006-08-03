PROGRAM_WIN = NeHe.Lesson17

include $(top_builddir)/am-config.mk

FILES = \
	AssemblyInfo.cs \
	Lesson17.cs

REFERENCES = \
	-r:../../../src/Tao.OpenGl/Tao.OpenGl.dll,../../../src/Tao.OpenGl.ExtensionLoader/Tao.OpenGl.ExtensionLoader.dll,../../../src/Tao.OpenGl.Glu/Tao.OpenGl.Glu.dll,../../../src/Tao.Platform.Windows/Tao.Platform.Windows.dll,System.Windows.Forms.dll,System.Drawing.dll

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
	$(FILES)
