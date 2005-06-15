
DEPTH = ../../..

include $(DEPTH)/config.mk

EXAMPLE = Boxes
EXAMPLE_CATEGORY = OpenAlExamples

SRCS = \
	AssemblyInfo.cs \
	Boxes.cs \
	$(NULL)

EXAMPLE_DATA = \
	Data/OpenAlExamples.Boxes.A.wav \
	Data/OpenAlExamples.Boxes.B.wav \
	Data/OpenAlExamples.Boxes.C.wav \
	$(NULL)

CSFLAGS += /target:winexe

REFS = \
	Tao.OpenAl.dll \
	Tao.OpenGl.dll \
	Tao.OpenGl.Glu.dll \
	Tao.FreeGlut.dll \
	$(NULL)

include $(DEPTH)/rules.mk
