using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Data.Entity;
using System.Net;
using LIS.v10.Models;
using LIS.v10.Areas.HIS10.Models;
using LIS.v10.Areas.Core.Models;

using Microsoft.AspNet.Identity;

namespace LIS.v10.Controllers
{
    public class HomeController : Controller
    {
        private LisDBContainer db = new LisDBContainer();
        private His10DBContainer Hisdb = new His10DBContainer();
        private CoreDBContainer Coredb = new CoreDBContainer();

        public ActionResult Index()
        {
            Models.AppInformation appInfo_app = db.AppInformations.Where(d=> d.Key == "APP").FirstOrDefault();
            Models.AppInformation appInfo_desc = db.AppInformations.Where(d => d.Key == "DESC").FirstOrDefault();
            Models.AppInformation appInfo_ver = db.AppInformations.Where(d => d.Key == "VER").FirstOrDefault();
            Models.AppInformation appInfo_rem = db.AppInformations.Where(d => d.Key == "REMARKS").FirstOrDefault();
            Models.AppInformation appInfo_appcode = db.AppInformations.Where(d => d.Key == "APPCODE").FirstOrDefault();

            ViewBag.AppName = "Default App";
            ViewBag.AppDescription = "Laboratory Information System";
            ViewBag.AppVersion = "Prototype 1.0";

            if (appInfo_app != null) ViewBag.AppName = appInfo_app.Data;
            if (appInfo_desc != null) ViewBag.AppDescription = appInfo_desc.Data;
            if (appInfo_ver != null) ViewBag.AppVersion = appInfo_ver.Data;
            if (appInfo_rem != null) ViewBag.AppRemarks = appInfo_rem.Data;
            if (appInfo_appcode != null) ViewBag.AppCode = appInfo_appcode.Data;

            // check for the user type (doctor, patient, medtech )
            ViewBag.PageLabel = "Laboratory List";

            if (User.Identity.IsAuthenticated)
            {
                string userAccntId = User.Identity.GetUserId();

                //check if physician account
                int iPhysician = 0;
                var physician = Hisdb.HisPhysicians.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (physician != null) iPhysician = (int)physician.Id;
                if (iPhysician != 0)
                {
                    ViewBag.PageType = "DOCTOR";
                }

                //check if Patient account
                int iPatient = 0;
                var patient = Hisdb.HisProfiles.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (patient != null) iPatient = (int)patient.Id;
                if (iPatient != 0)
                {
                    ViewBag.PageType = "PATIENT";
                }

                //check if MedTech account
                var oper = Hisdb.HisOperators.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (oper != null) ViewBag.PageType = "MEDTECH";

                //check if Theraphy Account
                var theraphy = Hisdb.HisIncharges.Where(d => d.AccntUserId == userAccntId).FirstOrDefault();
                if (theraphy != null)
                {
                    ViewBag.PageType = "THERAPHY";
                    return RedirectToAction("TheraphyTasks", "HisProfileReqs", new { area = "HIS10", RptType = 1, status = 0 });
                }

                //check if Admin
                var gAdmin = Coredb.userGroupAdmins.Where(d => d.UserId == userAccntId ).FirstOrDefault();
                if (gAdmin != null) ViewBag.PageType = "ADMIN";
            }


            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}


/****** SMS Notification *****/

/*
    https://www.codeproject.com/Articles/19023/Sending-SMS-using-NET  
    https://www.codeguru.com/columns/dotnet/accessing-.net-serial-ports-from-c.html

*/

/* sample code
  
using System;
using System.Threading;
using System.ComponentModel;
using System.IO.Ports;   

public class SMSCOMMS
{
    private SerialPort SMSPort;
    private Thread SMSThread;
    private Thread ReadThread;
    public static bool _Continue = false;
    public static bool _ContSMS = false;
    private bool _Wait = false;
    public static bool _ReadPort = false;
    public delegate void SendingEventHandler(bool Done);
    public event SendingEventHandler Sending;
    public delegate void DataReceivedEventHandler(string Message);
    public event DataReceivedEventHandler DataReceived;    

    public SMSCOMMS(ref string COMMPORT)
    {
        SMSPort = new SerialPort();
        SMSPort.PortName = COMMPORT;
        SMSPort.BaudRate = 9600;
        SMSPort.Parity = Parity.None;
        SMSPort.DataBits = 8;
        SMSPort.StopBits = StopBits.One;
        SMSPort.Handshake = Handshake.RequestToSend;
        SMSPort.DtrEnable = true;
        SMSPort.RtsEnable = true;
        SMSPort.NewLine = System.Environment.NewLine;
        ReadThread = new Thread(
            new System.Threading.ThreadStart(ReadPort));
    }    

    public bool SendSMS(string CellNumber, string SMSMessage)
    {
        string MyMessage = null;
        //Check if Message Length <= 160
        if (SMSMessage.Length <= 160)
            MyMessage = SMSMessage;
        else
            MyMessage = SMSMessage.Substring(0, 160);
        if (IsOpen == true)
        {
            SMSPort.WriteLine("AT+CMGS=" + CellNumber + "r");
            _ContSMS = false;
                SMSPort.WriteLine(
                MyMessage + System.Environment.NewLine + (char)(26));
              _Continue = false;
            if (Sending != null)
                Sending(false);
        }
        return false;
    }    

    private void ReadPort()
    {
        string SerialIn = null;
        byte[] RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
        string SMSMessage = null;
        int Strpos = 0;
        string TmpStr = null;
        while (SMSPort.IsOpen == true)
        {
            if ((SMSPort.BytesToRead != 0) & (SMSPort.IsOpen == true))
            {
                while (SMSPort.BytesToRead != 0)
                {
                    SMSPort.Read(RXBuffer, 0, SMSPort.ReadBufferSize);
                    SerialIn = 
                        SerialIn + System.Text.Encoding.ASCII.GetString(
                        RXBuffer);
                            if (SerialIn.Contains(">") == true)
                    {
                        _ContSMS = true;
                    }
                    if (SerialIn.Contains("+CMGS:") == true)
                    {
                        _Continue = true;
                        if (Sending != null)
                            Sending(true);
                        _Wait = false;
                        SerialIn = string.Empty;
                        RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
                    }
                }
                if (DataReceived != null)
                    DataReceived(SerialIn);
                SerialIn = string.Empty;
                RXBuffer = new byte[SMSPort.ReadBufferSize + 1];
            }
        }
    }    

    public bool SendSMS(string CellNumber, string SMSMessage)
    {
        string MyMessage = null;
        if (SMSMessage.Length <= 160)
        {
            MyMessage = SMSMessage;
        }
        else
        {
            MyMessage = SMSMessage.Substring(0, 160);
        }
        if (IsOpen == true)
        {
            SMSPort.WriteLine("AT+CMGS=" + CellNumber + "r");
            _ContSMS = false;
                SMSPort.WriteLine(
                    MyMessage + System.Environment.NewLine + (char)(26));
              _Continue = false;
            if (Sending != null)
                Sending(false);
        }
        return false;
    }    

    public void Open()
    {
        if (IsOpen == false)
        {
            SMSPort.Open();
                ReadThread.Start();
        }
    }    

    public void Close()
    {
        if (IsOpen == true)
        {
            SMSPort.Close();
        }
    }    

}

Then use the code as below:

Hide   Copy Code
SMSEngine = new SMSCOMMS("COM1");
SMSEngine.Open();
SMSEngine.SendSMS("919888888888","THIS IS YOUR MESSAGE");
SMSEngine.Close();



 */



/* ANOTHER SAMPLE CODE
 

using System;
using System.IO.Ports;
using System.Linq;
 
namespace GSMSMSsend
{
   class Program
   {
      // NOTE: Change this to the actual name of the port
      // where your modem is
      private const string SERIAL_PORT_NAME = "COM41";
 
      private static SerialPort _modemConnection;
 
      static void SendSms(string destination, string text)
      {
         // Turn off echo, we don't need it for this
         _modemConnection.WriteLine("ATE0");
         var response = _modemConnection.ReadExisting();
 
         // Set text mode
         _modemConnection.WriteLine("AT+CMGF=1");
         response = _modemConnection.ReadExisting();
 
         // Send the SMS
         _modemConnection.WriteLine(String.Format
            ("AT+CMGS=\"{0}\"", destination));
         response = _modemConnection.ReadExisting();
 
         _modemConnection.Write(text);
         _modemConnection.Write(new byte[]{26}, 0, 1);
 
         response = _modemConnection.ReadExisting();
 
         if(response.Contains("ERROR"))
         {
            Console.WriteLine("SMS Failed to send");
         }
         else
         {
            Console.WriteLine("SMS Sent");
            Console.WriteLine("Response: {0}", response);
          }
      }
 
      static void HelpText()
      {
         Console.WriteLine("ERROR: ");
         Console.WriteLine("\tUSage is GSMSMSSend <number>
            \"<message>\"");
         Console.WriteLine("");
         Console.WriteLine("Where <number> should be
            the phone number you wish to send to in
            international format");
         Console.WriteLine("and \"<message>\" is the text
            you wish to send (NOTE: you MUST surround it
            with quote marks)");
      }
 
      static void Main(string[] args)
      {
         if(args.Count() != 2)
         {
            HelpText();
            return;
         }
 
         var destinationNumber = args[0];
         var message = args[1];
 
         Console.WriteLine("About to send message to {0}",
            destinationNumber);
 
         _modemConnection = new SerialPort(SERIAL_PORT_NAME)
         {
            // 19200 baud, most modems will accept everything
            // from 9600 up to 115200
            BaudRate = 19200,
            // 99% of the time the port connection will be
            //8 Data bits
            DataBits = 8,
            // NO partiy
            Parity = Parity.None,
            // and 1 stop bit. Check your modem manual if
            // this doesn't work
            StopBits = StopBits.One
         };
         _modemConnection.Open();
 
         SendSms(destinationNumber, message);
 
         _modemConnection.Close();
 
      }
 
   }
}
    
    
     
 */
