using System;
using System.Collections.Generic;
using System.Linq;
using Cat.Core;

namespace Cat.Testing.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var meows = new List<Meow>();

            


            var type = typeof(ICanMeow);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p));

            foreach (var catType in types)
            {
                if (catType.IsInterface) continue;

                var cat = Activator.CreateInstance(catType);
                if (cat != null)
                {
                    meows.Add(((ICanMeow)cat).Meow());
                }
            }
        }
    }
}
