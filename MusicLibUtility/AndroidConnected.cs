using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RegawMOD.Android;
using PortableDeviceApiLib;
using System.Management;
using System.Text.RegularExpressions;
using System.Diagnostics;


namespace MusicLibUtility
{
    public class Devices
    {
        
        AndroidController android;
        Device device;

        public event EventHandler TableDataChanged;

        private List<Device> tableData;
        public List<Device> TableData
        {
            get { return tableData; }
            set
            {
                tableData = value;
                if (TableDataChanged != null)
                {
                    TableDataChanged(this, EventArgs.Empty);
                }
            }
        }
        public Devices()
        {
                   
        }
    }
    public class GetDevices
    {
        public static Devices GetDeviceData()
        {           
            AndroidController android;
            RegawMOD.Android.Device device;
            android = AndroidController.Instance;
            Devices table = new Devices();
            if (android.HasConnectedDevices)
            {

                int num = android.ConnectedDevices.Count;
                for(int i = 0; i < android.ConnectedDevices.Count; i++)
                {
                    string exp = @"\s+";
                    string serial = android.ConnectedDevices[i];
                    device = android.GetConnectedDevice(serial);
                    string devserial = device.SerialNumber;
                    DeviceState state = device.State;
                    table.TableData = new List<Device>();
                    Device item = new Device();
                    item.State = state.ToString();
                    item.model = model(device);
                    item.Brand = brand(device);
                    item.language = language(device);
                    item.version = version(device);
                    item.country = country(device);
                    Card1(device, exp, item);
                    Card2(device, exp);
                    item.SerialNumber = serial;
                    table.TableData.Add(item);
                }
            }
            return table;
        }

        private static void Card2(RegawMOD.Android.Device device, string exp)
        {
            AdbCommand adbCmdcard = Adb.FormAdbCommand(device, "shell df /storage/*card*");
            string card = Adb.ExecuteAdbCommand(adbCmdcard);
            string[] Card2 = Regex.Split(card, exp);
        }

        private static void Card1(RegawMOD.Android.Device device, string exp, Device item)
        {
            AdbCommand adbCmdCard = Adb.FormAdbCommand(device, "shell df /storage/*Card*");
            string Card = Adb.ExecuteAdbCommand(adbCmdCard);
            string[] Card1 = Regex.Split(Card, exp);
            item.free = Card1[8];
        }

        private static string country(RegawMOD.Android.Device device)
        {
            string getcountry = "shell getprop ro.product.locale.region";
            AdbCommand adbCmdgetcountry = Adb.FormAdbCommand(device, getcountry);
            return Adb.ExecuteAdbCommand(adbCmdgetcountry);
        }

        private static string version(RegawMOD.Android.Device device)
        {
            string getver = "shell getprop ro.product.version";
            AdbCommand adbCmdgetver = Adb.FormAdbCommand(device, getver);
            return Adb.ExecuteAdbCommand(adbCmdgetver);
        }

        private static string language(RegawMOD.Android.Device device)
        {
            string getlang = "shell getprop ro.product.locale.language";
            AdbCommand adbCmdgetlang = Adb.FormAdbCommand(device, getlang);
            return Adb.ExecuteAdbCommand(adbCmdgetlang);
        }

        private static string brand(RegawMOD.Android.Device device)
        {
            string getbrand = "shell getprop ro.product.brand";
            AdbCommand adbCmdgetBrand = Adb.FormAdbCommand(device, getbrand);
            return Adb.ExecuteAdbCommand(adbCmdgetBrand);
        }

        private static string model(RegawMOD.Android.Device device)
        {
            string getmodel = "shell getprop ro.product.model";
            AdbCommand adbCmdgetModel = Adb.FormAdbCommand(device, getmodel);
            return Adb.ExecuteAdbCommand(adbCmdgetModel);
        }
    }
}
