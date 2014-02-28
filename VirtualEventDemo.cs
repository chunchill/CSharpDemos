using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemos
{
   class VirtualEventDemo
   {
      public static void Go()
      {
         Base x = new Derived();

         x.Foo += (sender, args) => { };
      }
   }

   class Base
   {
      public virtual event EventHandler Foo
      {
         add
         {
            Console.WriteLine("Base Foo.add called");
         }
         remove
         {
            Console.WriteLine("Base Foo.remove called");
         }
      }
   }

   class Derived : Base
   {
      public override event EventHandler Foo
      {
         add
         {
            Console.WriteLine("Derived Foo.add called");
         }
         remove
         {
            Console.WriteLine("Derived Foo.remove called");
         }
      }
   }


}
