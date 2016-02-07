# Welcome to the BinVis project #

**BinVis** is a C# based project to visualize binary-file structures in unique ways. - The visual way for reverse engineering and forensics.
(Currently I'm going to add some documentation regarding the used visualization algorithms.)

Specifically BinVis can help you to look for suspicious parts in packed or encrypted files like binaries, and to locate relevant offsets. It provides a visual overview for easier orientation and deeper insight.


## Features of BinVis ##

  * visual and active **structure viewer**
  * multiple plots for different focus points
  * focusing on portions of a sample

  * **seeing stings and ressources**, in PE or ELF executables e. g.
  * getting **patterns** for cryptanalysis on files
  * **spotting** packer or encoder algorithms
  * **identify** Steganography by patterns
  * **visual** binary-diffing

BinVis is a great **start-point to get familiar with an unknown target** in a black-boxing scenario.

## Installation procedures ##

1. Windows Binary Setup Instructions

Please refer to the [Downloads](http://code.google.com/p/binvis/downloads/list) tab, which contains a link to the "installer".

```
http://code.google.com/p/binvis/downloads/detail?name=setup.exe&can=2&q=
```

The code-repository is considered to be a developer access. The software is under GPL, whether you download a binary release or compile it from source.
**Third party binary distribution is unsupported and my violate license agreements:** Linked MS assemblies are excluded from GPL and are under MS specific licenses. Binary downloads from the SVN are not intended for public distribution and only project references as a developer's access.

2. Windows Source Compiling Instructions

**BinVis is looking for project members! Means: you!**

The source installation requires a .Net build environment. Please refer to the wiki page for [basic instructions](http://code.google.com/p/binvis/wiki/Installation_from_Source_on_Unices_or_Windows?ts=1253191667&updated=Installation_from_Source_on_Unices_or_Windows) at the growing application wiki.

**UPDATE:**

You currently have to download a (deprecated) .Net Assembly reference in order to re-build this project with **Visual Studio 2010**. Everything elese is a smooth and standard click & build.
```
http://www.microsoft.com/downloads/en/details.aspx?FamilyID=8a166cac-758d-45c8-b637-dd7726e61367&DisplayLang=en
```


3. Cross-platform Setup Instructions

For now: please try wine: [Wine](http://www.winehq.org/). The Microsoft.ReportViewer is not ported into the Mono framework jet. Therefore the code is not portable.




Further documentation is linked in the following.

## Backgrounds ##

  * research paper, filling the backgrounds: [download](http://www.rumint.org/gregconti/publications/2008_VizSEC_FileVisualization_v53_final.pdf) the PDF file.
  * Blackhat 2008 presentation: [download](http://crazylazy.info/cons/bh08/black-hat-usa-08-conti-visualforensics-hires.m4v) the m4v file.

## Samples ##

Very soon. Means tomorrow :)

## Authors ##

BinVis's original authors are mostly Gregory Conti and other researchers. Now it's released with the GPL license and it's getting extended by Marius Ciepluch (mail-to wishinet -at - gmail.com).

## Media ##

http://netsecpodcast.com/?p=322  - interview with Greg Conti on Network Security Podcast 27.08.2009

http://www.vimeo.com/5624781 - presentation at Blackhat 2008
http://vimeo.com/15633207 - presentation at Blackhat 2010

http://www.softpedia.com/get/System/File-Management/BinVis.shtml - just for fun. No pun intended.



## AWESOME?? ##

**If you want to join development** or even submit **visualized samples**, feel free to contact me at wishinet - at - gmail.com.


```
Have fun,
wishi
```