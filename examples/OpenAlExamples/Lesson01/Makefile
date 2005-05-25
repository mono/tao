
DEPTH = ../../..

include $(DEPTH)/config.mk

EXAMPLE = Lesson01
EXAMPLE_CATEGORY = OpenAlExamples

SRCS = \
	AssemblyInfo.cs \
	Lesson01.cs \
	$(NULL)

EXAMPLE_DATA = \
	Data/OpenAlExamples.Lesson01.FancyPants.wav \
	$(NULL)

CSFLAGS += /unsafe

REFS = \
	Tao.OpenAl.dll \
	Tao.OpenGl.dll \
	Tao.OpenGl.Glu.dll \
	Tao.FreeGlut.dll \
	$(NULL)

include $(DEPTH)/rules.mk
