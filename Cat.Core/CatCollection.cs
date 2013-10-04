using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Cat.Core
{
    public class CatCollection : List<ICanMeow>
    {
        public CatCollection()
        {
            BuildCollection(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
        }

        public CatCollection(string catLocation)
        {
            BuildCollection(catLocation);
        }

        private void BuildCollection(string location)
        {
            var path = Path.GetDirectoryName(location);
            var allAssemblies = new List<Assembly>();

            foreach (string dll in Directory.GetFiles(path, "*.dll"))
                allAssemblies.Add(Assembly.LoadFile(dll));

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
                    this.Add(cat as ICanMeow);
                }
            }
        }


    }
}
