
DEPTH = ../..

include $(DEPTH)/config.mk

LIBRARY = Tao.FreeGlut
DOCS = 1
POSTPROCESS_LIBRARY = 1

SRCS = \
	AssemblyInfo.cs \
	Glut.cs \
	DelegateCallingConventionCdeclAttribute.cs \
	$(NULL)
REFS = \
	Tao.OpenGl.dll \
	$(NULL)

CSFLAGS += /unsafe /doc:$(DOC_DEST)/$(LIBRARY).xml

include $(DEPTH)/rules.mk
