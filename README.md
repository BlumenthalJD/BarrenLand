# BarrenLand
This is a barren land analysis tool. Using a field of 399 X 599, it will calculate the usable areas given a list of coordinates for barren areas.

## Formatting of Barren Areas
Here are some examples of valid input and output:
```
Input: {"0 292 399 307"}
Output: 116800 116800

Input: {"48 192 351 207", "48 392 351 407", "120 52 135 547", "260 52 275 547"}
Output: 22816 192608
```

## Instructions to Run
* Windows *(Windows 10 or higher)*
	1. Download the "Windows" directory
	2. Run the BarrenLand.exe from the directory
* OS X *(OS X 10.11 or higher)*
	1. Download the "OS-X"  directory
	2. Run the BarrenLand executable from the directory
* Linux *(Most popular 64-bit distros should work)*
	1. Download the "Linux"  directory
	2. Run the BarrenLand executable from the directory

## Implementation Details
* I chose to use an iterative depth-first search to find the each area. Initially I was using a recursive implementation, but that was causing an internal stack overflow due to the depth that this solution requires.
* In order to validate the input string, I'm using regex to ensure the correct number of input coords, as well as proper input formatting. 