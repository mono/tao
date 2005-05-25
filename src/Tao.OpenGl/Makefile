
DEPTH = ../..

include $(DEPTH)/config.mk

LIBRARY = Tao.OpenGl

SRCS = \
	AssemblyInfo.cs \
	Gl.cs \
	ContextGl.cs \
	$(NULL)

REFS = \
	Tao.OpenGl.ExtensionLoader.dll \
	$(NULL)

# We have to manually munge our stuff here, so we don't use the default rules

build: gl_build

include $(DEPTH)/rules.mk

gl_build: $(LIBRARY_DEST)/Tao.OpenGl.dll

$(LIBRARY_DEST)/Tao.OpenGl.dll: Tao.OpenGl-pre.dll
	$(RUN_EXE) $(PROGRAM_DEST)/Tao.GlPostProcess.exe $< $@ Tao.OpenGl.Gl Tao.OpenGl.ContextGl

Tao.OpenGl-pre.dll: $(SRCS)
	$(CSC) /target:library $(CSFLAGS) /out:$@ $^ /lib:$(LIBRARY_DEST) $(REFFLAGS)

clean::
	rm -f Tao.OpenGl-pre.dll
