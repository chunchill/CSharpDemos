using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpDemos
{
   public class ObservableCollectionDemo
   {
      public static void Go()
      {
         var nameList = new NameList();
         nameList.CollectionChanged += ItemsCollectionChanged;

         var p = new PersonName("Jasper", "Qiu");
         nameList.Add(p);
         nameList.Remove(nameList.FirstOrDefault(item => item.FirstName.Equals("Willa")));
         Console.Read();
      }

      static void ItemsCollectionChanged(object sender,
                NotifyCollectionChangedEventArgs e)
      {
         foreach (INotifyPropertyChanged item in e.OldItems)
            item.PropertyChanged -= ItemPropertyChanged;

         foreach (INotifyPropertyChanged item in e.NewItems)
            item.PropertyChanged += ItemPropertyChanged;
      }

      static void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
      {
         Console.WriteLine("Something changed!");
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

   public class PersonName : INotifyPropertyChanged
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

      public event PropertyChangedEventHandler PropertyChanged;
   }

}
