Cat
=========

Lightweight modular diagnostics reporting for .NET

How To Use
----------

1. Create a Cat or two:

```
public class AvailableMemory : ICanMeow
{
	public Meow Meow()
	{
		var availableRam = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes").NextValue().ToString();
		return new Meow()
		{
			DateStamp = DateTime.Now,
			MeowCode = "AVAILABLE_MEMORY",
			Origin = "Chris' Cpmpiter",
			Message = "Available RAM is " + availableRam + "MB"
		};
	}
}
```

2. Pop the Cat DLLs in a folder, then run the Cat engine on the folder

```
var cats = new CatCollection(@"path\to\my\cats");
foreach (var cat in cats)
{
	var meow = cat.Meow();
	Console.WriteLine("Your Cat says " + meow.Message);
}
```

3. Do whatever you want with the output! Try serving the messsages as JSON through Nancy, via the command line, or write to a log. 


