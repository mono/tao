
DEPTH = ../..

include $(DEPTH)/config.mk

LIBRARY = Tao.OpenGl.Glu
DOCS = 1

SRCS = \
	AssemblyInfo.cs \
	Glu.cs \
	$(NULL)

REFS = \
	Tao.OpenGl.dll \
	$(NULL)

CSFLAGS += /unsafe /doc:$(DOC_DEST)/$(LIBRARY).xml

include $(DEPTH)/rules.mk
