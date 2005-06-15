
DEPTH = ../../..

include $(DEPTH)/config.mk

EXAMPLE = Lesson21
EXAMPLE_CATEGORY = NeHe

SRCS = \
	AssemblyInfo.cs \
	Lesson21.cs \
	$(NULL)

EXAMPLE_DATA = \
	Data/NeHe.Lesson21.Complete.wav \
	Data/NeHe.Lesson21.Die.wav \
	Data/NeHe.Lesson21.Font.bmp \
	Data/NeHe.Lesson21.Freeze.wav \
	Data/NeHe.Lesson21.Hourglass.wav \
	Data/NeHe.Lesson21.Image.bmp \
	$(NULL)

CSFLAGS += /target:winexe

REFS = \
	Tao.OpenGl.dll \
	Tao.OpenGl.Glu.dll \
	Tao.Platform.Windows.dll \
	System.Windows.Forms.dll \
	System.Drawing.dll \
	$(NULL)

include $(DEPTH)/rules.mk
