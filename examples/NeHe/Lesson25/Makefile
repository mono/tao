
DEPTH = ../../..

include $(DEPTH)/config.mk

EXAMPLE = Lesson25
EXAMPLE_CATEGORY = NeHe

SRCS = \
	AssemblyInfo.cs \
	Lesson25.cs \
	$(NULL)

EXAMPLE_DATA = \
	Data/NeHe.Lesson25.Sphere.txt \
	Data/NeHe.Lesson25.Torus.txt \
	Data/NeHe.Lesson25.Tube.txt \
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
