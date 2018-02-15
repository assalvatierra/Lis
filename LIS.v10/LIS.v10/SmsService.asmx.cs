using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;

namespace LIS.v10
{
    /// <summary>
    /// Summary description for SmsService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class SmsService1 : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }
        // -- GET METHODS --//        
        //get all list of messages from 'HisNotifications' Table
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getList()
        {
            string sql = "SELECT [Id],[RecType],[Recipient],[Message],[DtSending],[RefId],[RefTable] FROM dbo.HisNotifications";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();
            da.Fill(ds);
            
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));

        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getAdminMessage()
        {
            string sql = "SELECT * FROM dbo.HisNotifications WHERE [RecType]='admin'";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();
            da.Fill(ds);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void getClientMessage()
        {
            string sql = "SELECT * FROM dbo.HisNotifications WHERE [RecType]='client'";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());
            DataSet ds = new DataSet();
            da.Fill(ds);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(ds, Newtonsoft.Json.Formatting.Indented));
        }

        // --END OF GET METHODS --//        

        //update notificationlog for sent and failed to send messages
        public void updateLog()
        {
            string sql = "SELECT * FROM dbo.HisNotifications WHERE [RecType]='client'";
            SqlDataAdapter da = new SqlDataAdapter(sql, ConfigurationManager.ConnectionStrings["SmsConnection"].ToString());

            //DataSet ds = new DataSet();
            // da.Fill(ds);

            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject("SUCCESS", Newtonsoft.Json.Formatting.Indented));
        }

        // POST METHOND Controller
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public void jsoninputdata(int NotificationID,string rData,string status,string remarks)
        {
            string response;
            string json = JsonConvert.SerializeObject(rData);
            try
            {

                string conString = ConfigurationManager.ConnectionStrings["SmsConnection"].ConnectionString;
                var con = new SqlConnection(conString);
                con.Open();

                var cmd = new SqlCommand("INSERT INTO [dbo].[HisNotificationLogs] ([HisNotificationId],[DtSending],[Status],[Remarks]) VALUES"+
                    " ("+NotificationID+", '" + rData + "', '"+ status +"', '"+ remarks +"') ", con);

                int row = cmd.ExecuteNonQuery();
                con.Close();
                response = "success";
            }
            catch (Exception ex)
            {
                rData = ex.ToString();
            }
            
            Context.Response.Clear();
            Context.Response.ContentType = "application/json";
            Context.Response.Write(JsonConvert.SerializeObject(rData, Newtonsoft.Json.Formatting.Indented));
            //Do my stuff here....
        }

    }
}
