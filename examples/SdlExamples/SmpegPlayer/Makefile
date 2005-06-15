
DEPTH = ../../..

include $(DEPTH)/config.mk

EXAMPLE = SdlExamples
EXAMPLE_CATEGORY = SmpegPlayer

SRCS = \
	AssemblyInfo.cs \
	SmpegPlayer.cs \
	$(NULL)

EXAMPLE_DATA = \
	Data/SdlExamples.SmpegPlayer.mpg \
	$(NULL)

CSFLAGS += /target:winexe

REFS = \
	Tao.Sdl.dll \
	$(NULL)

include $(DEPTH)/rules.mk
