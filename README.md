Cat
=========

Lightweight modular diagnostics reporting for .NET

How To Use
----------

Create a Cat or two:

```
public class AvailableMemoryCat : ICanMeow
{
	public Meow Meow()
	{
		var availableRam = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes").NextValue().ToString();
		return new Meow()
		{
			DateStamp = DateTime.Now,
			MeowCode = "AVAILABLE_MEMORY",
			Origin = "Chris' Computer",
			Message = "Available RAM is " + availableRam + "MB"
		};
	}
}
```

Pop the Cat DLL(s) in a folder, then run the Cat engine on the folder

```
var cats = new CatCollection(@"path\to\my\cats");
foreach (var cat in cats)
{
	var meow = cat.Meow();
	Console.WriteLine("Your Cat says " + meow.Message);
}
```

Do whatever you want with the output! Try serving the messsages as JSON through Nancy, via the command line, or write to a log. 


![This is a Cat](http://ih3.redbubble.net/image.11748456.8987/sticker,375x360.png)
