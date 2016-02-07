# Howto install BinVis

# Introduction #

BinVis is written in C# and utilizes standard .Net components. Therefore it's possible to run BinVis on .Net compatible Windows platforms and [mono](http://mono-project.com/Main_Page) compatible operating systems:

  * Windows 2000 - Windows 7

For now the mono support is considered to be supported at alpha stage: please create a ticket and report any issues you encounter on

  * MacOS, OpenSuse, Debian, Ubuntu and other Linuxes or Solaris


# Howto install from source #

In binviz\_0.01/bin/ there's a release binary. However to source from within another environment you can compile within MonoDevelop or your current VisualStudio version. You have to convert the project file, which happens automatically.

## Mono ##

```
mono "./binviz_0.01.exe" "$@"
```

Should do start the program after compilation. Currently the window management is buggy and it doesn't scale with larger files.

## .Net ##

VisualStudio completely manages the build process and you should use it like that. After successful compilation you can run the executable like any other application you have. Please keep in mind that you need Microsoft's .Net runtime.

```
Have fun
wishi
```
