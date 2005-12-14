SRCS = Lesson02.cs

CLEANFILES = Lesson02.exe

all: Lesson02.exe

Lesson02.exe: $(SRCS)
	mcs \
		-pkg:gtk-sharp-2.0 \
		-pkg:gtkgl-sharp-2.0 \
		-pkg:tao \
		$(SRCS) \
		-out:Lesson02.exe


