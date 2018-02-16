using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyCouch;

namespace DnD4e.Assets.Scripts.Controller.Data
{
    public class MyDB
    {

        public static void Main(string[] args)
        {
            using (var db = new MyCouchClient("http://localhost:5984/", "mydb"))
            {
                //var r = await client.Replicator.ReplicateAsync(id, source, target);
            };
        }
    }
}
