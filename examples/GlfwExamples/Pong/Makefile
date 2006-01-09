
DEPTH = ../../..

include $(DEPTH)/config.mk

EXAMPLE = Pong
EXAMPLE_CATEGORY = GlfwExamples

SRCS = \
	AssemblyInfo.cs \
	Pong.cs \
	$(NULL)

EXAMPLE_DATA = \
	Data/pong3d_field.tga \
	Data/pong3d_instr.tga \
	Data/pong3d_menu.tga \
	Data/pong3d_title.tga \
	Data/pong3d_winner1.tga \
	Data/pong3d_winner2.tga \
	$(NULL)

CSFLAGS += /target:winexe

REFS = \
	Tao.OpenGl.dll \
	Tao.OpenGl.Glu.dll \
	Tao.Glfw.dll \
	$(NULL)

include $(DEPTH)/rules.mk
