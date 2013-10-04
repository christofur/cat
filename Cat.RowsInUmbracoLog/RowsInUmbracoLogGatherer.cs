using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cat.Core;

namespace Cat.RowsInUmbracoLog
{
    public class RowsInUmbracoLogGatherer : ICanMeow
    {
        public Meow Meow()
        {
            var db = new PetaPoco.Database("umbracoDbDSN");
            long count = db.ExecuteScalar<long>("SELECT Count(*) FROM umbracoLog");

            var meow = new Meow()
            {
                DateStamp = DateTime.Now,
                MeowCode = "ROWS_IN_UMBRACO_LOG",
                Origin = "Unknown",
                Message = count.ToString()
            };
            return meow;

        }
    }
}
