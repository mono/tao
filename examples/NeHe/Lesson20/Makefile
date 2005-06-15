
DEPTH = ../../..

include $(DEPTH)/config.mk

EXAMPLE = Lesson20
EXAMPLE_CATEGORY = NeHe

SRCS = \
	AssemblyInfo.cs \
	Lesson20.cs \
	$(NULL)

EXAMPLE_DATA = \
	Data/NeHe.Lesson20.Image1.bmp \
	Data/NeHe.Lesson20.Image2.bmp \
	Data/NeHe.Lesson20.Logo.bmp \
	Data/NeHe.Lesson20.Mask1.bmp \
	Data/NeHe.Lesson20.Mask2.bmp \
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
