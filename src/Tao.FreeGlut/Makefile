
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

CSFLAGS += /unsafe

include $(DEPTH)/rules.mk
