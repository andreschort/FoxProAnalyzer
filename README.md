FoxProAnalyzer
==============

A set of tools that I developed to gather information about a big Visual FoxPro application

##Projects:
FoxProAnalyzer: Its a command line tool which knows how to gather information from a Visual FoxPro application such as:
 - Track DO FORM statements
 - Track stored procedures usages with a name like u?sp_.* (This was the SP prefix the application I was dealing with used)
 - Track report usages with a name like r_(\d{3,4})(\.frx)?
 - Get statistics from each file like number of code lines, number of methods, etc.

VFPLOCCounter: A great tool developed by Mark Miller. This application is entirely NOT my work and is here only as reference since it was extremely helpfull in learning how to read the binary Visual FoxPro files.
You can find more about it in the following link:
http://www.codeproject.com/Articles/18990/Visual-FoxPro-Lines-of-Code-Analysis