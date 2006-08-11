PROGRAM_WIN = GlfwExamples.Boing

include $(top_builddir)/am-config.mk

SNKFILE = ../../../src/Tao.Glfw/Tao.Glfw.snk

FILES = \
	AssemblyInfo.cs \
	Boing.cs

REFERENCES = \
	-r:../../../src/Tao.Glfw/Tao.Glfw.dll,../../../src/Tao.OpenGl/Tao.OpenGl.dll,../../../src/Tao.OpenGl.ExtensionLoader/Tao.OpenGl.ExtensionLoader.dll,../../../src/Tao.OpenGl.Glu/Tao.OpenGl.Glu.dll

BUILD_FILES = $(addprefix $(srcdir)/, $(FILES))

all: $(ASSEMBLY)

$(ASSEMBLY): $(FILES)
	mkdir -p $(top_builddir)/
	$(CSC) -debug -out:$@ \
		-target:$(TARGET) \
		$(REFERENCES) \
		$(CSFLAGS) \
		$(BUILD_FILES)

CLEANFILES = $(ASSEMBLY) $(ASSEMBLY).mdb $(ASSEMBLY_NAME).pdb $(ASSEMBLY_NAME).xml
EXTRA_DIST = \
	$(FILES) \
	../../../src/Tao.Glfw/Tao.Glfw.snk
