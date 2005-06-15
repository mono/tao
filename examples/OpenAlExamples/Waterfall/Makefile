
DEPTH = ../../..

include $(DEPTH)/config.mk

EXAMPLE = Waterfall
EXAMPLE_CATEGORY = OpenAlExamples

SRCS = \
	AssemblyInfo.cs \
	Waterfall.cs \
	Sound.cs \
	$(NULL)

EXAMPLE_DATA = \
	Data/OpenAlExamples.Waterfall.Collision.txt \
	Data/OpenAlExamples.Waterfall.Dirt.bmp \
	Data/OpenAlExamples.Waterfall.Evergreen.bmp \
	Data/OpenAlExamples.Waterfall.Grass.bmp \
	Data/OpenAlExamples.Waterfall.Level.txt \
	Data/OpenAlExamples.Waterfall.Rocks.bmp \
	Data/OpenAlExamples.Waterfall.Water.bmp \
	Data/OpenAlExamples.Waterfall.Water.txt \
	Data/OpenAlExamples.Waterfall.Water.wav \
	Data/OpenAlExamples.Waterfall.Wood.bmp \
	$(NULL)

CSFLAGS += /target:winexe

REFS = \
	Tao.OpenAl.dll \
	Tao.OpenGl.dll \
	Tao.OpenGl.Glu.dll \
	Tao.FreeGlut.dll \
	System.Drawing.dll \
	$(NULL)

include $(DEPTH)/rules.mk
