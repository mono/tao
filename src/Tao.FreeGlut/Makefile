
DEPTH = ../..

include $(DEPTH)/config.mk

LIBRARY = Tao.FreeGlut
POSTPROCESS_LIBRARY = 1

SRCS = \
	AssemblyInfo.cs \
	Glut.cs \
	DelegateCallingConventionCdeclAttribute.cs \
	$(NULL)
REFS = \
	Tao.OpenGl.dll \
	$(NULL)

CSFLAGS += /unsafe /doc:$(LIBRARY_DEST)/$(LIBRARY).xml

include $(DEPTH)/rules.mk
