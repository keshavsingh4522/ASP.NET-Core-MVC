- file name should start with *uppercase charater*.
```
if razor page name start with lowercase char then it wil not render pages to display
```
- file extension should be *.razor*
- Split Component Html and C# Code
```
two methods
- Partial Files (shared folder)
  - click on pages and add class with same name and extension should be .razor.cs
  - make this class partial with partial keyword
- Base class
  - add a clas with same name+Base for example CounterBase
  - inherit from ComponentBase class
  -  and write below code in razor page
@inherits CounterBase
  - make all member or method protected or public
```
