C#		|	var MyArray = new Object[] {1,2,3}
VB		|	Dim MyArray = new Object() {1,2,3}

Boxing >>> [ TValue | Object | Variant ]

Delphi	|	var MyArray : TArray<TValue> := [1,2,3]						// ValueSemantics | Boxing | record type dynamic
Delphi	|	var MyArray : Array [1..10] of TValue := [1,2,3]			// ValueSemantics | Boxing | record type dynamic
Delphi	|	var MyArray : TArray<Variant|Object> := [1,2,3]				// RefSemantics | Boxing | built-in record type
Delphi	|	var MyArray : Array [1..10] of Variant|Object := [1,2,3]	// RefSemantics | Boxing | built-in record type
Delphi	|	var MyArray : TArray<TObject> := [1,2,3]					// Late binding
Delphi  |   var MyArray : Array [1..10] of TObject := [1,2,3]			// Late binding

AutoIt	|	Dim $MyArray[10] = [1,2,3]



Imports System
Imports System.Diagnostics
Imports System.Threading
Imports System.Threading.Tasks
Imports System.Collections.Generic
Imports System.Collections.Specialized
Imports System.Linq

Namespace ParallelForEachExample
    Public Class Program
        Public Shared Sub Main()
		
			Dim MyStrCol as new StringCollection() 		:	MyStrCol.AddRange({"1", "2","4", "3"}) 
		Dim proTempRange as IEnumerable(Of Object) 	:	Dim BoxResult as new List(of Object)

			proTempRange = (From item In MyStrCol Select item) 
			proTempRange.ToList.ForEach( Sub(obj) BoxResult.Add( Convert.ToInt32(obj) )	)

				console.WriteLine( BoxResult.ElementAt(0).GetType.ToString + "|" + BoxResult.GetType.ToString )
				console.WriteLine( string.Join(" ", BoxResult) )
				
			Console.ReadLine()
        End Sub
    End Class
End Namespace



//===============================================================================================================


using System;
using System.Collections;
using System.IO;
using System.Linq;
using System.Collections.Generic;
					
public class Program	{
	static (int Id, string FirstName, string LastName) GetPerson() 	{  			 // Feature: record-like safe code | SampleName: Deconstruct ValueTuple # 2
		return (Id:1, FirstName: "Bill", LastName: "Gates");
	}	
	public static void Example1() {												// Feature: Tuple Spread | SampleName :
		var (destination, distance) = ("post office", 3.6);
		Console.WriteLine($"Distance to {destination} is {distance} kilometers.");
		// Output:
		// Distance to post office is 3.6 kilometers.	
		
		var t0 = ((double bla, int ka)) (4.5, 3);
		Console.WriteLine($"Tuple with elements {t0.bla} and {t0.ka}.");

		(double, int) t2 = (4.5, 3);
		Console.WriteLine($"Sum of {t2.Item2} elements is {t2.Item1}.");
		
		var t3 = (Field1: 4.5, Field2: 3);
		Console.WriteLine($"Sum of {t3.Field2} elements is {t3.Field1}.");	
	}
	public static void Example2() {
		var MyFSinfos = new ArrayList();	var myTuple = (Sum: 4.5, Count: 3);		MyFSinfos.Add( myTuple );
		var t = (Sum: 4.5, Count: 3);
		Console.WriteLine($"Sum of {t.Count} elements is {t.Sum}.");		
	}	
	public static void Example3()	{
		(int PersonId0, var FirstName, string LName0)  =  (1, "Bill", "Gates");
		(var PersonId, var FName, var LName) = GetPerson();   // Multiple-declaration assignment
		Console.WriteLine(LName0 + "_" + FName);	
	}
	public static void Example4() {
		var ToString = 9.5;
		var counta = 3;
		var td = (Alt: ToString, counta);
		Console.WriteLine($"Sum of {td.counta} elements is {td.Alt}.");
	}
	public static void Example5()	{
			var myTuple = (Sum: 4.5, Count: 3);
			Console.WriteLine(myTuple.GetType().ToString());
			Console.WriteLine(myTuple);
			//(double Sum, int Count) TupleCasted = MyFSinfos.ToArray();
			//Console.WriteLine(TupleCasted.GetType());
			//Console.WriteLine($"Sum of {MyFSinfos[0].Count} elements is {MyFSinfos[0].Sum}.");
	}	
	
public static void Main()	{
		Example1();
		Example2();
		Example3();
		Example4();
		Example5();
}
}


//=============================================================================================================================

Imports System
Imports System.Collections
Imports System.IO
Imports System.Linq
Imports System.Collections.Generic

Public Class Program
	Public Sub Main
		Const state As String = "MI"
		Const stateName As String = "Michigan"
		Const capital As String = "Lansing"
		Dim stateInfo = (state:=state, stateName:=stateName, capital:=capital)
		
		Dim MyTuple = ("post office", 3.6)
		Console.WriteLine($"{MyTuple.Item1}: 2-letter code: {MyTuple.Item2}")
		
		' Console.WriteLine(MyTuple1.GetType().ToString())
		Dim x = CType(("A", "B", 27) , (string, string, integer))
		Dim y as (string, string, integer) = ("A", "B", 27) 
		Dim t3 = (Field1:= 4.5, Field2:= 3)
		Dim aaa = ("hello", "world", 24) 		:		Dim  (Field:="", Field2:="", Field3:=0) = aaa
		
		Dim holiday As (EventDate As Date, Name As String, IsHoliday As Boolean) = _
			(#07/04/2017#, "Independence Day", True)
		
		
		Console.WriteLine($"{x}     {stateInfo.stateName}: 2-letter code: {stateInfo.state}, Capital {stateInfo.capital}")
		' The example displays the following output:
		'      Michigan: 2-letter code: MI, Capital Lansing		
	End Sub
End Class
        
//======================================================================================
using System;
using System.Collections.Generic;
					
public class Program	{

	
	public static void Main()
	{
        // anonymous types
        var anonType = new {Id = "123123123", Name = "Goku", Age = 30, DateAdded = new DateTime()};
        // notice we have a strongly typed anonymous class we can access the properties with
        Console.WriteLine(​$"Anonymous Type: {anonType.Id} {anonType.Name} {anonType.Age} {anonType.DateAdded}");
        // compile time error//
        anonType = 100;
        // dynamic types
        dynamic dynType = 100.01m;
        Console.WriteLine(​$"Dynamic type: {dynType}");
        // it's ok to change the type however you want
        dynType = new List<DateTime>();
        Console.WriteLine(​$"Dynamic type: {dynType}");

        // mix dynamic and anonymous
        dynamic dynamicAnonymousType = new {Id = 8000, FirstName = "Goku", Gender = "male", IsSuperSaiyan = true};
        // Wasn't sure this would work but it does! However, you lose intellisense on the FirstName so you have to type it manually.
        Console.WriteLine(​$"FirstName: {dynamicAnonymousType.FirstName}​"​);
        dynamicAnonymousType = 100;
        Console.WriteLine(dynamicAnonymousType);
        // runtime error
        Console.WriteLine($"Id: {dynamicAnonymousType.FirstName}​"​);


			Person teacher = new Teacher("Nancy", "Davolio", 3);
			Console.WriteLine(teacher);
			// output: Teacher { FirstName = Nancy, LastName = Davolio, Grade = 3 }
	
		Console.WriteLine("Hello World");
	}
}


Imports System
Imports System.Collections.Generic

Public Class Program
    Public Shared Sub Main()
        Dim anonType = New With {Key
            .Id = "123123123", Key
            .Name = "Goku", Key
            .Age = 30, Key
            .DateAdded = New DateTime()
        }
        Console.WriteLine($"Anonymous Type: {anonType.Id} {anonType.Name} {anonType.Age} {anonType.DateAdded}")
        anonType = 100
        Dim dynType As dynamic = 100.01D
        Console.WriteLine($"Dynamic type: {dynType}")
        dynType = New List(Of DateTime)()
        Console.WriteLine($"Dynamic type: {dynType}")
        Dim dynamicAnonymousType As dynamic = New With {Key
            .Id = 8000, Key
            .FirstName = "Goku", Key
            .Gender = "male", Key
            .IsSuperSaiyan = True
        }
        Console.WriteLine($"FirstName: {dynamicAnonymousType.FirstName}​")
        dynamicAnonymousType = 100
        Console.WriteLine(dynamicAnonymousType)
        Console.WriteLine($"Id: {dynamicAnonymousType.FirstName}​")
        Dim teacher As Person = New Teacher("Nancy", "Davolio", 3)
        Console.WriteLine(teacher)
        Console.WriteLine("Hello World")
    End Sub
End Class


//========================================================================================

Imports NamedRange = System.Collections.Generic.List(Of Object)

Dim Inferred = (Field6:=New NamedRange, Field7:=New NamedRange)

//===============================≠============≠==================


Nothing like a little code to clear things up:



Shallow immutability ( non-Value types are still settable! )

C# GRAMMAR SPECIFICATIONS
========================================
Object creation expressions
Object initializers     
anonymous types

===================================================================================================


using System;
					
public class Program	{
public readonly record struct RecStruct_00 {	public string Name { get; init;  }	public int CategoryId { get; init;  }  }  	
public readonly record struct RecStruct_01  {	public string Name { get; init; }	public int CategoryId { get;   }	}
public record struct RecStruct_02  			{	public string Name { get; init;  }  public int CategoryId { get; set;  }	} 		
public record struct RecStruct_03  			{	public string Name { get; init; }	public int CategoryId { get; init; }	}	
public record struct RecStruct_04  			{	public string Name { get; init; }	public int CategoryId { get;  }	}	

public record class RecStruct_20  			{	public string Name { get; init;  }  public int CategoryId { get; set;  }	}  // readonly not allowed
public record class RecStruct_21  			{	public string Name { get; init; }	public int CategoryId { get; init; }	}	
public record class RecStruct_22  			{	public string Name { get; init; }	public int CategoryId { get;  }	}	

public readonly struct RecStruct_30  {	public string Name { get; init;  }	public int CategoryId { get; init;  }	} 	
public readonly struct RecStruct_31  {	public string Name { get; init; }	public int CategoryId { get;   }	}
public struct RecStruct_32  			{	public string Name { get; init;  }  public int CategoryId { get; set;  }	} 		
public struct RecStruct_33  			{	public string Name { get; init; }	public int CategoryId { get; init; }	}	
public struct RecStruct_34  			{	public string Name { get; init; }	public int CategoryId { get;  }	}	    
	
	public static void Main()		{
            RecStruct_00    product01, product02, product03 ;
		product01 = new RecStruct_00  {  Name = "VideoGame", CategoryId = 1  };    
        product02 = new RecStruct_00  {  Name = "VideoGame" };
        product03 = new RecStruct_00  {  CategoryId = 1 };  
            RecStruct_01     product04, product05, product06 ;
        //product04 = new RecStruct_01 {  Name = "VideoGame", CategoryId = 1  };
        product05 = new RecStruct_01 {  Name = "VideoGame"  };
        //product06 = new RecStruct_01 {  CategoryId = 1  };
            RecStruct_02     product07, product08, product09 ;
		product07 = new RecStruct_02  {  Name = "VideoGame", CategoryId = 1  };    
        product08 = new RecStruct_02  {  Name = "VideoGame" };
        product09 = new RecStruct_02  {  CategoryId = 1 }; 
            RecStruct_03     product10, product11, product12 ;
		product10 = new RecStruct_03  {  Name = "VideoGame", CategoryId = 1  };    
        product11 = new RecStruct_03  {  Name = "VideoGame" };
        product12 = new RecStruct_03  {  CategoryId = 1 }; 		
            RecStruct_04     product13, product14, product15 ;
        product14 = new RecStruct_04  {  Name = "VideoGame" };

//========================================================================================		
            RecStruct_20     product16, product17, product18 ;
		product16 = new RecStruct_20  {  Name = "VideoGame", CategoryId = 1  };    
        product17 = new RecStruct_20  {  Name = "VideoGame" };
        product18 = new RecStruct_20  {  CategoryId = 1 }; 	 
            RecStruct_21     product19, product20, product21 ;
		product19 = new RecStruct_21  {  Name = "VideoGame", CategoryId = 1  };    
        product20 = new RecStruct_21  {  Name = "VideoGame" };
        product21 = new RecStruct_21  {  CategoryId = 1 }; 		
            RecStruct_22     product22, product23, product24 ;
        product23 = new RecStruct_22  {  Name = "VideoGame" };
//========================================================================================	
            RecStruct_30    product25, product26, product27 ;
		product25 = new RecStruct_30  {  Name = "VideoGame", CategoryId = 1  };    
        product26 = new RecStruct_30  {  Name = "VideoGame" };
            RecStruct_31     product28, product29, product30 ;
        //product28 = new RecStruct_31 {  Name = "VideoGame", CategoryId = 1  };
        product29 = new RecStruct_31 {  Name = "VideoGame"  };
            RecStruct_32     product31, product32, product33 ;
		product31 = new RecStruct_32  {  Name = "VideoGame", CategoryId = 1  };    
        product33 = new RecStruct_32  {  CategoryId = 1 }; 
            RecStruct_33     product34, product35, product36 ;
		product34 = new RecStruct_33  {  Name = "VideoGame", CategoryId = 1  };    
        product35 = new RecStruct_33  {  Name = "VideoGame" };
            RecStruct_34     product37, product38, product39 ;
        product38 = new RecStruct_34  {  Name = "VideoGame" };


		//product13 = new RecStruct_04  {  Name = "VideoGame", CategoryId = 1  };    //get  
        // product15 = new RecStruct_04  {  CategoryId = 1 }; 	  // get     
		//product22 = new RecStruct_22  {  Name = "VideoGame", CategoryId = 1  };    //get 
        //product24 = new RecStruct_22  {  CategoryId = 1 }; 			//get  
        //product30 = new RecStruct_31 {  CategoryId = 1  };    //get        
		//product37 = new RecStruct_34  {  Name = "VideoGame", CategoryId = 1  };    //get
        //product39 = new RecStruct_34  {  CategoryId = 1 }; 		//get
        
        product27 = new RecStruct_30  {  CategoryId = 1 };  // Null exception        
        product32 = new RecStruct_32  {  Name = "VideoGame" };    // Null exception        
        product36 = new RecStruct_33  {  CategoryId = 1 }; 		    // Null exception        
//========================================================================================	
        PrintInfo( product01, product02, product03 );
        PrintInfo( product05 );
		PrintInfo( product07, product08, product09 );
        PrintInfo( product10, product11, product12 );
        PrintInfo( product14 );
        
        PrintInfo( product16, product17, product18);
        PrintInfo( product19, product20, product21);
        PrintInfo( product23 );
        
        PrintInfo( product25 );    
		PrintInfo( product26 );    
		PrintInfo( product27 );    // Late binding error
        PrintInfo( product29 );
        PrintInfo( product31 );
        PrintInfo( product32 );    // Late binding error
        PrintInfo( product33 );    
        PrintInfo( product34 );  
        PrintInfo( product35 );
        PrintInfo(  product36 );    // Late binding error
        PrintInfo( product38 );
	}
    //===============================================
	public static void PrintInfo( dynamic product00, dynamic product01 = null, dynamic product02 = null, dynamic product03 = null ) {
		Console.Write( product00.Name + "\t" + product00.CategoryId );
		Console.Write("\t|\t");
		if (product01 != null ) Console.Write( product01.Name + "\t" + product01.CategoryId  );	
        if (product02 != null ) Console.Write( "\t|\t" + product02.Name + "\t" + product02.CategoryId  );	
        if (product03 != null) Console.Write( "\t|\t" + product03.Name + "\t" + product03.CategoryId  );	
		Console.WriteLine();
	}    
}
