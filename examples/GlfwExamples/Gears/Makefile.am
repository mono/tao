PROGRAM_WIN = GlfwExamples.Gears

include $(top_builddir)/am-config.mk

FILES = \
	AssemblyInfo.cs \
	Gears.cs

REFERENCES = \
	-r:../../../src/Tao.Glfw/Tao.Glfw.dll,../../../src/Tao.OpenGl/Tao.OpenGl.dll,../../../src/Tao.OpenGl.ExtensionLoader/Tao.OpenGl.ExtensionLoader.dll

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
