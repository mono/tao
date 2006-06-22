
DEPTH = ../..

include $(DEPTH)/config.mk

LIBRARY = Tao.OpenAl
DOCS = 1
POSTPROCESS_LIBRARY = 1

SRCS = \
	AssemblyInfo.cs \
	Al.cs \
	Alc.cs \
	Alut.cs \
	DelegateCallingConventionCdeclAttribute.cs \
	$(NULL)

CSFLAGS += /unsafe /doc:$(DOC_DEST)/$(LIBRARY).xml

include $(DEPTH)/rules.mk
