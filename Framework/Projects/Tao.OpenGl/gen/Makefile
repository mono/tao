##
## Makefile
##
## Tao OpenGL binding generation
##

#MONO=mono
#MCS=mcs

MONO=
MCS=csc

all: Gl.cs ContextGl.cs
	cp -f Gl.cs ContextGl.cs ..

Gl.cs: Gl-pre.cs Gl-enums.cs Gl-mid.cs Gl-funcs.cs Gl-post.cs
	cat Gl-pre.cs Gl-enums.cs Gl-mid.cs Gl-funcs.cs Gl-post.cs > Gl.cs

ContextGl.cs: ContextGl-pre.cs ContextGl-funcs.cs Gl-post.cs
	cat ContextGl-pre.cs ContextGl-funcs.cs Gl-post.cs > ContextGl.cs

Gl-enums.cs: enum.spec sharp-genenums.py
	python sharp-genenums.py < enum.spec > Gl-enums.cs

ContextGl-funcs.cs: gl.xml typemap.xml gencore.exe
	$(MONO) gencore.exe gl.xml typemap.xml ContextGl-funcs.cs instance

Gl-funcs.cs: gl.xml typemap.xml gencore.exe
	$(MONO) gencore.exe gl.xml typemap.xml Gl-funcs.cs

gl.xml: gl.spec sharp-genfuncs.py
	python sharp-genfuncs.py < gl.spec > gl.xml

gencore.exe: gencore.cs
	$(MCS) /out:gencore.exe gencore.cs

clean:
	rm -f gl.xml Gl-enums.cs Gl-funcs.cs gencore.exe Gl.cs ContextGl.cs ContextGl-funcs.cs

