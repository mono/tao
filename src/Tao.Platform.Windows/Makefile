
DEPTH = ../..

include $(DEPTH)/config.mk

LIBRARY = Tao.Platform.Windows
POSTPROCESS_LIBRARY = 1

SRCS = \
	AssemblyInfo.cs \
	Gdi.cs	\
	IlasmAttribute.cs \
	Kernel.cs \
	SimpleOpenGlControl.cs \
	User.cs \
	Wgl.cs \
	WinNt.cs \
	Winmm.cs \
	$(NULL)

CSFLAGS += /unsafe /doc:$(DOC_DEST)/$(LIBRARY).xml

REFS = \
	System.Drawing.dll \
	System.Windows.Forms.dll \
	Tao.OpenGl.dll \
	$(NULL)

include $(DEPTH)/rules.mk
