
DEPTH = ../../..

include $(DEPTH)/config.mk

EXAMPLE = Maiden
EXAMPLE_CATEGORY = NateRobbins

SRCS = \
	AssemblyInfo.cs \
	Maiden.cs \
	$(NULL)

EXAMPLE_DATA = \
	Data/NateRobins.Maiden.Ace.ppm \
	Data/NateRobins.Maiden.DeadOne.ppm \
	Data/NateRobins.Maiden.Space.ppm \
	Data/NateRobins.Maiden.Virus.ppm \
	$(NULL)

CSFLAGS += /target:winexe

REFS = \
	Tao.OpenGl.dll \
	Tao.OpenGl.Glu.dll \
	Tao.FreeGlut.dll \
	$(NULL)

include $(DEPTH)/rules.mk
