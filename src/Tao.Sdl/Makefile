
DEPTH = ../..

include $(DEPTH)/config.mk

LIBRARY = Tao.Sdl
DOCS = 1
POSTPROCESS_LIBRARY = 1

SRCS = \
	AssemblyInfo.cs \
	Sdl.cs \
	SdlImage.cs \
	SdlMixer.cs \
	SdlTtf.cs \
	SdlGfx.cs \
	Smpeg.cs \
	DelegateCallingConventionCdeclAttribute.cs \
	$(NULL)

CSFLAGS += /unsafe /doc:$(DOC_DEST)/$(LIBRARY).xml
	

include $(DEPTH)/rules.mk

