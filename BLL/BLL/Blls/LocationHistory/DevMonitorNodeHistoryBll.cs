﻿using DAL;
using DbModel.LocationHistory.AreaAndDev;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Blls.LocationHistory
{
    public class DevMonitorNodeHistoryBll : BaseBll<DevMonitorNodeHistory, LocationHistoryDb>
    {
        public DevMonitorNodeHistoryBll() : base()
        {

        }
        public DevMonitorNodeHistoryBll(LocationHistoryDb db) : base(db)
        {

        }

        protected override void InitDbSet()
        {
            DbSet = Db.DevMonitorNodeHistorys;
        }
    }
}
