using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormDemos
{
   public partial class ResponseFlush2 : System.Web.UI.Page
   {
      protected void Page_Load(object sender, EventArgs e)
      {
         Response.BufferOutput = true;
         Response.Write(GetString("1"));
         Response.Flush();
         Response.Clear();
         Thread.Sleep(1000);
         Response.Write(GetString("2"));
         Response.Flush();
         Response.Clear();
         Thread.Sleep(1000);
         Response.Write(GetString("3"));
         Response.Flush();
         Response.Clear();
         Thread.Sleep(1000);
         Response.Write(GetString("4"));
         Response.Flush();
         Response.Clear();
         Thread.Sleep(1000);
         Response.Write(GetString("5"));
         Response.Flush();
         Response.Clear();
         Thread.Sleep(1000);
      }
      private string GetString(string val)
      {
         StringBuilder sb = new StringBuilder();
         for (int i = 0; i < 256; ++i)
         {
            sb.Append(val);
         }
         sb.Append("<br />");
         //确保sb里面的字符串大于256字节
         return sb.ToString();
      }
   }
}