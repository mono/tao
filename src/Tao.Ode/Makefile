
DEPTH = ../..

include $(DEPTH)/config.mk

LIBRARY = Tao.Ode
DOCS = 1
POSTPROCESS_LIBRARY = 1

SRCS = \
	AssemblyInfo.cs \
	Ode.cs \
	$(NULL)

CSFLAGS += /unsafe /doc:$(DOC_DEST)/$(LIBRARY).xml

include $(DEPTH)/rules.mk
