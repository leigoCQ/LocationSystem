﻿using BLL;
using DbModel.Location.Alarm;
using Location.BLL.Tool;
using LocationServices.Locations.Services;
using Newtonsoft.Json;
using SignalRService.Hubs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiCommunication.ExtremeVision;

namespace LocationServer.Tools
{
    public class CameraAlarmListener
    {
        public string Url;

        public int SaveMode;

        public string SaveDir;

        public MyHttpListener httpListener;

        public CameraAlarmListener(string url,int saveMode,string saveDir)
        {
            this.Url = url;
            this.SaveMode = saveMode;
            this.SaveDir = saveDir;

            httpListener = new MyHttpListener(url);
            httpListener.OnReceived += (json) =>
            {
                return ParseCameraAlarm(url, json);
            };
        }

        public bool Start()
        {
            try
            {
                if (httpListener != null)
                {
                    return httpListener.Start();
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Log.Error(LogTags.ExtremeVision, "CameraAlarmListener.Start:" + e.Message);
                return false;
            }
        }

        public void Stop()
        {
            if (httpListener != null)
            {
                try
                {
                    httpListener.Stop();
                    httpListener = null;
                }
                catch (Exception e)
                {
                    Log.Error(LogTags.ExtremeVision, "CameraAlarmListener.Stop:"+e.Message);
                }
            }
        }

        private string ParseCameraAlarm(string url, string json)
        {
            try
            {
                Log.Info(LogTags.ExtremeVision, string.Format("收到消息({0})", url));

                CameraAlarmService service = new CameraAlarmService();
                string result=service.ParseJson(json, SaveMode);

                return result;
            }
            catch (Exception ex)
            {
                return "error:" + ex.Message;
            }

        }
    }
}
