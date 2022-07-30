# Required Library Dependency

This program requires an additional libray to be added into the program solution to run.

## Steps to add library

- Download the code from [BigInt-Cpp-Library](https://github.com/eslutz/BigInt-Cpp-Library)
- Open the CollatzSequence solution
- Add a new Static Library project to the solution
- Copy the BigInt header and class definition into the new Static Library project
- Add the BigInt Static Library you created to the other three projects
  - Add the library as a reference
  - In the project go to `Properties > Configuration Properties > C/C++ > General`
    - Under `Additional Include Directories` add the path to the BigInt Library
