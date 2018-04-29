# CSharpStuff
Learn Stuff, Tests and Libs (Created with Visual Studio)

## GUISynchronisationSingleton
Shows a Progressbar, which is filled by a non-GUI Timer (asynchronous event). 3 slightly different ways are used (can be uncommented at end of CHelper.cs). Singleton-Pattern is implemented there, too.

## RLEexperiment
Simple Run-Length-Encoding implementation for byte-arrays, with configurable escape-character and threshold (minimum number of same byte before encoding).
Default: 0x254 -> 0x254 0x254; 8x 0xff -> 0x254 0xff 0x08

## Custom Controls
### Block diagram
If you plan to make a defrag program or show used memory or you're searching for a virtual LED matrix..  
![](blockdiagram.png?raw=true)