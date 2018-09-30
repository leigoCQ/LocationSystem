﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WCFClientLib;
using WCFServiceForWPF.LocationServices;

namespace LocationWCFClient
{
    public class AppContext
    {
        private static AppContext _instance ;
        public static AppContext Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance=new AppContext();
                }
                return _instance;
            }
        }

        private AppContext()
        {
            
        }

        public LocationClient Client { get; set; }

        public LoginInfo LoginInfo { get; set; }

        public bool Login(string port, string ip, string user, string pass)
        {
            LocationClient client = new LocationClient(ip, port);
            LoginInfo = client.InnerClient.Login(new LoginInfo() {UserName = user, Password = pass});
            Client = client;
            return LoginInfo != null && !string.IsNullOrEmpty(LoginInfo.Session);
        }
    }
}