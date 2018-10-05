﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using BLL;
using BLL.ServiceHelpers;
using DbModel.Location.AreaAndDev;
using DbModel.Tools;
using Location.BLL.ServiceHelpers;
using Location.Model.DataObjects.ObjectAddList;
using Location.TModel.FuncArgs;
using Location.TModel.Location;
using Location.TModel.Location.AreaAndDev;
using Location.TModel.Location.Data;
using Location.TModel.Location.Obsolete;
using Location.TModel.Location.Alarm;
using Location.TModel.Location.Person;
using Location.TModel.LocationHistory.Data;
using LocationServices.Converters;
using LocationServices.Tools;
using LocationWCFService;
using LocationWCFService.ServiceHelper;
using ConfigArg = Location.TModel.Location.AreaAndDev.ConfigArg;
using DevInfo = Location.TModel.Location.AreaAndDev.DevInfo;
using KKSCode = Location.TModel.Location.AreaAndDev.KKSCode;
using Post = Location.TModel.Location.AreaAndDev.Post;
using Dev_DoorAccess = Location.TModel.Location.AreaAndDev.Dev_DoorAccess;

namespace LocationServices.Locations
{
    //设备相关的接口
    public partial class LocationService : ILocationService, IDisposable
    {

        #region 设备信息、位置信息
        /// <summary>
        /// 获取所有设备位置信息
        /// </summary>
        /// <returns></returns>
        public IList<DevPos> GetDevPositions()
        {
            List<DevPos> posList = new List<DevPos>();
            var devs = db.DevInfos.ToList();
            foreach (DbModel.Location.AreaAndDev.DevInfo dev in devs)
            {
                posList.Add(dev.GetPos());
            }
            return posList.ToWCFList();
        }

        /// <summary>
        /// 添加一条设备位置信息
        /// </summary>
        /// <param name="pos"></param>
        public bool AddDevPosInfo(DevPos pos)
        {
            return ModifyPosInfo(pos);
        }
        /// <summary>
        /// 修改设备位置信息
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool ModifyPosInfo(DevPos pos)
        {
            var devInfo = db.DevInfos.DbSet.FirstOrDefault(i => i.Local_DevID == pos.DevID);
            if (devInfo != null)
            {
                devInfo.SetPos(pos);
                return db.DevInfos.Edit(devInfo);
            }
            return false;
        }
        /// <summary>
        /// 修改设备位置信息
        /// </summary>
        /// <param name="posList"></param>
        /// <returns></returns>
        public bool ModifyPosByList(List<DevPos> posList)
        {
            //return db.DevPos.EditRange(db.Db, posList);
            foreach (var devPose in posList)
            {
                ModifyPosInfo(devPose);
            }
            return true;
        }
        /// <summary>
        /// 删除设备位置信息
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public bool DeletePosInfo(DevPos pos)
        {
            //return db.DevPos.DeleteById(pos.DevID);
            return false;
        }
        /// <summary>
        /// 添加设备位置信息（列表形式）
        /// </summary>
        /// <param name="posList"></param>
        public bool AddDevPosByList(List<DevPos> posList)
        {
            //return db.DevPos.AddRange(posList.ToList());
            return ModifyPosByList(posList);
        }


        private void BindingDev(List<DevInfo> devInfoList)
        {
            DeviceInfoService service = new DeviceInfoService();
            //service.BindingDevPos(devInfoList, db.DevPos.ToList());
            service.BindingDevParent(devInfoList, db.Areas.ToList().ToTModel());
        }

        /// <summary>
        /// 获取所有的设备基本信息
        /// </summary>
        /// <returns></returns>
        public IList<DevInfo> GetAllDevInfos()
        {
            //List<DevInfo> devInfoList = db.DevInfos.ToList();
            //return devInfoList.ToWcfModelList(); 

            var devInfoList = db.DevInfos.DbSet.ToList().ToTModel();
            BindingDev(devInfoList);
            return devInfoList.ToWCFList();
        }

        /// <summary>
        /// 获取所有的设备基本信息
        /// </summary>
        /// <returns></returns>
        public IList<DevInfo> GetDevInfos(int[] typeList)
        {
            //List<DevInfo> devInfoList = db.DevInfos.ToList();
            //return devInfoList.ToWcfModelList(); 

            List<DevInfo> devInfoList = null;
            if (typeList == null || typeList.Length == 0)
            {
                devInfoList = db.DevInfos.ToList().ToTModel();
            }
            else
            {
                devInfoList = db.DevInfos.DbSet.Where(i => typeList.Contains(i.Local_TypeCode)).ToList().ToTModel();
            }

            BindingDev(devInfoList);
            return devInfoList.ToWCFList();
        }

        /// <summary>
        /// 获取所有的设备基本信息
        /// </summary>
        /// <returns></returns>
        public IList<DevInfo> FindDevInfos(string key)
        {
            //List<DevInfo> devInfoList = db.DevInfos.ToList();
            //return devInfoList.ToWcfModelList();           
            var devInfoList = db.DevInfos.DbSet.Where(i => i.Name.Contains(key)).ToList().ToTModel();
            BindingDev(devInfoList);
            return devInfoList.ToWCFList();
        }

        /// <summary>
        /// 添加一条设备基本信息
        /// </summary>
        /// <param name="devInfo"></param>
        public DevInfo AddDevInfo(DevInfo devInfo)
        {
            DbModel.Location.AreaAndDev.DevInfo DbDevInfo = devInfo.ToDbModel();
            bool r = db.DevInfos.Add(DbDevInfo);
            return DbDevInfo.ToTModel();
        }
        /// <summary>
        /// 添加设备基本信息（列表形式）
        /// </summary>
        /// <param name="devInfoList"></param>
        public bool AddDevInfoByList(List<DevInfo> devInfoList)
        {
            return db.DevInfos.AddRange(devInfoList.ToDbModel());
        }
        /// <summary>
        /// 修改设备信息
        /// </summary>
        /// <param name="devInfo"></param>
        /// <returns></returns>
        public bool ModifyDevInfo(DevInfo devInfo)
        {
            return db.DevInfos.Edit(devInfo.ToDbModel());
        }
        /// <summary>
        /// 删除设备信息
        /// </summary>
        /// <param name="devInfo"></param>
        /// <returns></returns>
        public bool DeleteDevInfo(DevInfo devInfo)
        {
            bool devResult = db.DevInfos.DeleteById(devInfo.Id);
            //bool posResult = db.DevPos.DeleteById(devInfo.Local_DevID);
            bool value = devResult;
            return value;
        }
        /// <summary>
        /// 通过区域ID,获取区域下所有设备
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public IList<DevInfo> GetDevInfoByParent(int[] pidList)
        {
            List<DevInfo> devInfoList = new List<DevInfo>();
            foreach (var pid in pidList)
            {
                devInfoList.AddRange(db.DevInfos.DbSet.Where(item => item.ParentId == pid).ToList().ToTModel());
                //BindingDev(devInfoList);
            }
            return devInfoList.ToWCFList();
        }
        /// <summary>
        /// 添加门禁设备
        /// </summary>
        /// <param name="doorAccessList"></param>
        /// <returns></returns>
        public bool AddDoorAccessByList(IList<Dev_DoorAccess> doorAccessList)
        {
            return db.Dev_DoorAccess.AddRange(doorAccessList.ToList().ToDbModel());
        }
        /// <summary>
        /// 添加门禁信息
        /// </summary>
        /// <param name="doorAccess"></param>
        /// <returns></returns>
        public bool AddDoorAccess(Dev_DoorAccess doorAccess)
        {
            return db.Dev_DoorAccess.Add(doorAccess.ToDbModel());
        }
        /// <summary>
        /// 删除门禁信息
        /// </summary>
        /// <param name="doorAccessList"></param>
        /// <returns></returns>
        public bool DeleteDoorAccess(IList<Dev_DoorAccess> doorAccessList)
        {
            bool value = true;
            foreach (Dev_DoorAccess item in doorAccessList)
            {
                bool accessResult = db.Dev_DoorAccess.DeleteById(item.Id);
                bool devResult = db.DevInfos.DeleteById(item.DevID);
                //bool posResult = db.DevPos.DeleteById(item.DevID);
                bool valueTemp = devResult && accessResult ? true : false;
                if (!valueTemp) value = valueTemp;
            }
            return value;
        }
        /// <summary>
        /// 修改门禁信息
        /// </summary>
        /// <param name="doorAccessList"></param>
        /// <returns></returns>
        public bool ModifyDoorAccess(IList<Dev_DoorAccess> doorAccessList)
        {
            return db.Dev_DoorAccess.EditRange(db.Db, doorAccessList.ToList().ToDbModel());
        }
        /// <summary>
        /// 通过区域ID,获取区域下所有门禁信息
        /// </summary>
        /// <param name="pid">区域ID</param>
        /// <returns></returns>
        public IList<Dev_DoorAccess> GetDoorAccessInfoByParent(int[] pidList)
        {
            List<Dev_DoorAccess> devInfoList = new List<Dev_DoorAccess>();
            foreach (var pId in pidList)
            {
                devInfoList.AddRange(db.Dev_DoorAccess.DbSet.Where(item => item.ParentId == pId).ToList().ToTModel());
            }
            return devInfoList.ToWCFList();
        }
        #endregion
    }
}
