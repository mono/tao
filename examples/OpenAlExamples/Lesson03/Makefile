
DEPTH = ../../..

include $(DEPTH)/config.mk

EXAMPLE = Lesson03
EXAMPLE_CATEGORY = OpenAlExamples

SRCS = \
	AssemblyInfo.cs \
	Lesson03.cs \
	$(NULL)

EXAMPLE_DATA = \
	Data/OpenAlExamples.Lesson03.Battle.wav \
	Data/OpenAlExamples.Lesson03.Gun1.wav \
	Data/OpenAlExamples.Lesson03.Gun2.wav \
	$(NULL)

CSFLAGS += /target:exe

REFS = \
	Tao.OpenAl.dll \
	Tao.OpenGl.dll \
	Tao.OpenGl.Glu.dll \
	Tao.FreeGlut.dll \
	$(NULL)

include $(DEPTH)/rules.mk
