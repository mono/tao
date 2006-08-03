PROGRAM_WIN = LuaExamples.Functions

include $(top_builddir)/am-config.mk

FILES = \
	AssemblyInfo.cs \
	Functions.cs

REFERENCES = \
	-r:../../../src/Tao.Lua/Tao.Lua.dll

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
	$(FILES) \
	../../../src/Tao.Lua/Tao.Lua.snk
