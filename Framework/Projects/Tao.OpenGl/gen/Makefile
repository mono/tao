##
## Makefile
##
## Tao OpenGL binding generation
##

all: Gl.cs

Gl.cs: Gl-pre.cs Gl-enums.cs Gl-mid.cs Gl-funcs.cs Gl-post.cs
	cat Gl-pre.cs Gl-enums.cs Gl-mid.cs Gl-funcs.cs Gl-post.cs > Gl.cs

Gl-enums.cs: enum.spec sharp-genenums.py
	python sharp-genenums.py < enum.spec > Gl-enums.cs

Gl-funcs.cs: gl.xml typemap.xml gencore.exe
	mono gencore.exe gl.xml typemap.xml Gl-funcs.cs

gl.xml: gl.spec sharp-genfuncs.py
	python sharp-genfuncs.py < gl.spec > gl.xml

gencore.exe: gencore.cs
	mcs /out:gencore.exe gencore.cs

clean:
	rm -f gl.xml Gl-enums.cs Gl-funcs.cs gencore.exe Gl.cs

