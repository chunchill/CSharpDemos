using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication12
{
   class Program
   {
      static void Main(string[] args)
      {
         var nameList = new NameList();
         nameList.CollectionChanged += NameListCollectionChanged;
         var p = new PersonName("Jasper", "Qiu");
         nameList.Add(p);
         nameList.Remove(nameList.FirstOrDefault(item => item.FirstName.Equals("Willa")));
         Console.Read();
      }

      static void NameListCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
      {

         Console.WriteLine("Changed");
         
      }
   }

   public class NameList : ObservableCollection<PersonName>
   {
      public NameList()
         : base()
      {
         Add(new PersonName("Willa", "Cather"));
         Add(new PersonName("Isak", "Dinesen"));
         Add(new PersonName("Victor", "Hugo"));
         Add(new PersonName("Jules", "Verne"));
      }

      protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
      {
         base.OnCollectionChanged(e);
         //if (CollectionChanged != null)
         //{
         //   using (BlockReentrancy())
         //   {
         //      CollectionChanged(this, e);
         //   }
         //}
         //Console.WriteLine("Changed");
         //Console.Read();
      }

      //public override event NotifyCollectionChangedEventHandler CollectionChanged;

      //// Summary:
      ////     Occurs when the collection changes.
      //public override event NotifyCollectionChangedEventHandler CollectionChanged
      //{
        
      //}
   }

   public class PersonName
   {
      private string firstName;
      private string lastName;

      public PersonName(string first, string last)
      {
         this.firstName = first;
         this.lastName = last;
      }

      public string FirstName
      {
         get { return firstName; }
         set { firstName = value; }
      }

      public string LastName
      {
         get { return lastName; }
         set { lastName = value; }
      }
   }

}
