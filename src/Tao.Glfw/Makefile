
DEPTH = ../..

include $(DEPTH)/config.mk

LIBRARY = Tao.Glfw
DOCS = 1

SRCS = \
	AssemblyInfo.cs \
	Glfw.cs \
	$(NULL)

REFS = \
	Tao.OpenGl.dll \
	$(NULL)

CSFLAGS += /doc:$(DOC_DEST)/$(LIBRARY).xml

include $(DEPTH)/rules.mk
