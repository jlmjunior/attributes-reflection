using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Attributes
{
    class Program
    {
        static void Main(string[] args)
        {
            var types = from t in Assembly.GetExecutingAssembly().GetTypes()
                        where t.GetCustomAttributes<Test>().Count() > 0
                        select t;

            foreach (var t in types)
            {
                Console.WriteLine(t.Name);

                foreach (var p in t.GetProperties())
                {
                    Console.WriteLine(p.Name);
                }
            }

            Console.ReadLine();
        }
        
        [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
        public class Test : Attribute
        {
            public string Name { get; set; }

            public Test(string name)
            {
                this.Name = name;
            }
        }

        [Test("Testing")]
        public class Result
        {
            public int Number { get; set; }
        }
    }
}
