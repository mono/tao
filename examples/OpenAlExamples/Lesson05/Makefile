
DEPTH = ../../..

include $(DEPTH)/config.mk

EXAMPLE = Lesson05
EXAMPLE_CATEGORY = OpenAlExamples

SRCS = \
	AssemblyInfo.cs \
	Lesson05.cs \
	$(NULL)

EXAMPLE_DATA = \
	Data/OpenAlExamples.Lesson05.Chimes.wav \
	Data/OpenAlExamples.Lesson05.Ocean.wav \
	Data/OpenAlExamples.Lesson05.Rain.wav \
	Data/OpenAlExamples.Lesson05.Stream.wav \
	Data/OpenAlExamples.Lesson05.Thunder.wav \
	Data/OpenAlExamples.Lesson05.Waterdrop.wav \
	$(NULL)

CSFLAGS += /target:exe

REFS = \
	Tao.OpenAl.dll \
	Tao.OpenGl.dll \
	Tao.OpenGl.Glu.dll \
	Tao.FreeGlut.dll \
	$(NULL)

include $(DEPTH)/rules.mk
