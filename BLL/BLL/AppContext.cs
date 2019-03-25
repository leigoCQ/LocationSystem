﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Location.BLL.Tool;
using DAL;
using System.IO;
using System.Data.Entity;

namespace LocationServer
{
    public static class AppContext
    {
        /// <summary>
        /// 是否将定位引擎获取的数据写入日志
        /// </summary>
        public static bool WritePositionLog { get; set; }

        public static bool AutoStartServer { get; set; }

        public static double PositionMoveStateWaitTime { get; set; }

        public static Bll GetLocationBll()
        {
            return new Bll(false, true, true);
        }

        public static string DbSource = "SqlServer";

        public static void InitDbContext(string dbType)
        {
            DbSource = dbType;
            Log.Info("InitDbContext:" + dbType);
            if (dbType == "SQLite")
            {
                LocationDb.IsSqlite = false;
                LocationHistoryDb.IsSqlite = false;
            }
            LocationDb.Name = "Location_" + dbType;
            LocationHistoryDb.Name = "LocationHistory_" + dbType;
        }

        public static void InitDb(int mode, bool isForce = false)
        {
            Log.InfoStart("InitDb");
            Bll bll = new Bll();
            if (isForce)
            {
                bll.Db.Database.Create();
                bll.DbHistory.Database.Create();
            }
            bll.Init(mode);
            Log.InfoEnd("InitDb");
        }

        public static void InitDbAsync(int mode,Action<Bll> callBack,bool isForce=false)
        {
            Log.InfoStart("InitDb");
            Bll bll;
            if (isForce&& DbSource == "SQLite")
            {
                string dir = AppDomain.CurrentDomain.BaseDirectory;
                string file1 = dir + "location.db";
                if (File.Exists(file1))
                {
                    File.Delete(file1);
                }
                string file2 = dir + "locationHis.db";
                if (File.Exists(file2))
                {
                    File.Delete(file2);
                }

                bll = new Bll();
            }
            else
            {
                bll = new Bll();
                //if (isForce)
                //{
                //    //bll.Db.Database.Delete();
                //    //bll.Db.Database.Create();
                //    bll.DbHistory.Database.Delete();
                //    bll.DbHistory.Database.Create();
                //}
            }
            bll.InitAsync(mode,(b)=>
            {
                Log.InfoEnd("InitDb");
                if (callBack != null)
                {
                    callBack(b);
                }
            });
            
        }

        public static void InitDbAsync(string dbsource, int initMode,Action<Bll> callback)
        {
            InitDbContext(dbsource);
            InitDbAsync(initMode, callback,true);
        }

        public static void InitDb(string dbsource,int initMode)
        {
            InitDbContext(dbsource);
            InitDb(initMode);
        }

        public static void DeleteDb(int type)
        {
            if (type == 0)
            {
                var db1 = new DbContext("LocationConnection");
                var delResult1 = db1.Database.Delete();

                var db2 = new DbContext("LocationHistoryConnection");
                var delResult2 = db2.Database.Delete();
            }
            else if (type == 1)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory + "\\Data\\");
                FileInfo[] files = dirInfo.GetFiles("*.db");
                foreach (var file in files)
                {
                    file.Delete();
                }
            }
            else
            {
                LocationDb Ldb = new LocationDb();
                LocationHistoryDb Lhdb = new LocationHistoryDb();
               // Ldb.Database.ExecuteSqlCommand("drop database location");
               // Lhdb.Database.ExecuteSqlCommand("drop database locationhistory");
                Ldb.Database.Delete();
                Lhdb.Database.Delete();
            }
        }
    }
}
