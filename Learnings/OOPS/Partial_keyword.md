##### There are several situations when splitting a class definition is desirable:



* Declaring a class over separate files enables multiple programmers to work on it at the same time.
* You can add code to the class without having to recreate the source file that includes automatically generated source. Visual Studio uses this approach when it creates Windows Forms, Web service wrapper code, and so on. You can create code that uses these classes without having to modify the file created by Visual Studio.
* Source generators can generate extra functionality in a class.



##### sealed

* When you apply the sealed modifier to a class, it prevents other classes from inheriting from that class. In the following example, class B inherits from class A, but no class can inherit from class B.



* You can also use the sealed modifier on a method or property that overrides a virtual method or property in a base class. By using this approach, you enable developers to derive classes from your class while preventing them from overriding specific virtual methods or properties.



``` csharp

class X

{

&nbsp;   protected virtual void F() { Console.WriteLine("X.F"); }

&nbsp;   protected virtual void F2() { Console.WriteLine("X.F2"); }

}



class Y : X

{

&nbsp;   sealed protected override void F() { Console.WriteLine("Y.F"); }

&nbsp;   protected override void F2() { Console.WriteLine("Y.F2"); }

}



class Z : Y

{

&nbsp;   // Attempting to override F causes compiler error CS0239.

&nbsp;   // protected override void F() { Console.WriteLine("Z.F"); }



&nbsp;   // Overriding F2 is allowed.

&nbsp;   protected override void F2() { Console.WriteLine("Z.F2"); }

}

```





