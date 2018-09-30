﻿using System;
using System.Collections.Generic;
using System.Linq;
using Location.BLL.Tool;
using System.IO;
using DbModel.Location.AreaAndDev;
using DbModel.Tools;
using DbModel.Tools.InitInfos;
using Location.Model;
using Location.Model.InitInfos;

namespace BLL
{
    public partial class Bll : IDisposable
    {
        public void UpdateInitDataFromXml()
        {
            
        }

        public bool InitTopoFromXml()
        {
            Log.InfoStart("InitTopoFromXml");
            try
            {
                string initFile = AppDomain.CurrentDomain.BaseDirectory + "Data\\InitInfo.xml";
                if (!File.Exists(initFile))
                {
                    return false;
                }
                InitInfo initInfo = XmlSerializeHelper.LoadFromFile<InitInfo>(initFile);
                TopoInfo topoInfo = initInfo.TopoInfo;
                InitTopo(topoInfo);
                Log.InfoEnd("InitTopoFromXml");
                return true;
            }
            catch (Exception ex)
            {
                Log.Error("InitTopoFromXml", ex);
                Log.InfoEnd("InitTopoFromXml");
                return false;
            }
        }

        public void ClearTopoTable()
        {
            Log.InfoStart("ClearTopoTable");
            Archors.Clear();
            DevInfos.Clear();
            //Maps.Clear();
            //PhysicalTopologys.Clear();
            //TransformMs.Clear();
            NodeKKSs.Clear();
            Points.Clear();
            Bounds.Clear();
            Log.InfoEnd("ClearTopoTable");
        }

        public void InitTopo(TopoInfo topoInfo)
        {
            Log.InfoStart("InitTopo");
            ClearTopoTable();

            Area root = new Area() { Name = topoInfo.Name, Type = topoInfo.Type };
            Areas.Add(root);
            InitTopoChildren(root, topoInfo);
            Log.InfoEnd("InitTopo");
        }

        private void InitTopoChildren(Area root, TopoInfo topoInfo)
        {
            foreach (TopoInfo childInfo in topoInfo.Children)
            {
                var childNode = AddTopoNode(childInfo.Name, childInfo.KKS, root, childInfo.Type);
                SetInitBound(childInfo.BoundInfo, childNode);
                InitTopoChildren(childNode, childInfo);
            }
        }

        private void SetInitBound(BoundInfo boundInfo, Area chidNode)
        {

            if (boundInfo != null)
            {
                bool isRelative = boundInfo.IsRelative;
                float thickness = boundInfo.Thickness;
                List<PointInfo> points = boundInfo.Points;
                if (points != null && points.Count > 0)
                {
                    if (points.Count == 4) //四边点
                    {
                        SetInitBound(chidNode, points[0].X, points[0].Y, points[2].X, points[2].Y, thickness, isRelative, boundInfo.BottomHeight, boundInfo.IsCreateAreaByData, boundInfo.IsOnAlarmArea, boundInfo.IsOnLocationArea);
                    }
                    else if (points.Count == 2) //对角点
                    {
                        SetInitBound(chidNode, points[0].X, points[0].Y, points[1].X, points[1].Y, thickness, isRelative, boundInfo.BottomHeight, boundInfo.IsCreateAreaByData, boundInfo.IsOnAlarmArea, boundInfo.IsOnLocationArea);
                    }
                    else //全部点
                    {
                        List<Point> ps = new List<Point>();
                        for (int i = 0; i < points.Count; i++)
                        {
                            PointInfo p = points[i];
                            ps.Add(new Point(p.X, p.Y, 0, i));
                        }
                        SetInitBound(chidNode, ps.ToArray(), thickness, isRelative, boundInfo.BottomHeight, boundInfo.IsCreateAreaByData, boundInfo.IsOnAlarmArea, boundInfo.IsOnLocationArea);
                    }
                }
            }
        }

        public void InitAreas()
        {
            Log.InfoStart("InitAreas");

            if (!InitTopoFromXml())
            {
                InitTopoByEntities();
            }

            Log.InfoEnd("InitAreas");
        }

        private void InitTopoByEntities()
        {
            var root = new Area() { Name = "根节点", Type = AreaTypes.区域 };
            Areas.Add(root);

            InitElectricityGeneratingStation(root);

            InitChuLingPark(root);
        }

        #region 电厂拓扑初始化

        private void InitJ1(Area building1MainFactory)
        {
            #region 主厂房
            var mainFactoryFloor1 = AddTopoNode("主厂房0m层", "", building1MainFactory, AreaTypes.楼层);
            var mainFactoryFloor2 = AddTopoNode("主厂房4.5m层", "", building1MainFactory, AreaTypes.楼层);
            var mainFactoryFloor3 = AddTopoNode("主厂房11.0m层", "", building1MainFactory, AreaTypes.楼层);

            //PhysicalTopologys.AddRange(mainFactoryFloor1, mainFactoryFloor2, mainFactoryFloor3);

            var mainFactoryFloor1Room1 = AddTopoNode("#1汽机房区域", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room2 = AddTopoNode("#1汽机房检修场地", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room3 = AddTopoNode("#1燃机机房区域", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room4 = AddTopoNode("#1燃机机房检修场地", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room5 = AddTopoNode("#1机组就地MCC配电间", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room6 = AddTopoNode("#1机组6kV配电间", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room7 = AddTopoNode("#2汽机房区域", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room8 = AddTopoNode("#2汽机房检修场地", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room9 = AddTopoNode("#2燃机机房区域", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room10 = AddTopoNode("#2燃机机房检修场地", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room11 = AddTopoNode("#2机组就地MCC配电间", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room12 = AddTopoNode("#2机组6kV配电间", "", mainFactoryFloor1, AreaTypes.机房);
            var mainFactoryFloor1Room13 = AddTopoNode("汽机事故油池", "", mainFactoryFloor1, AreaTypes.机房);
            //PhysicalTopologys.AddRange(mainFactoryFloor1Room1, mainFactoryFloor1Room2, mainFactoryFloor1Room3, mainFactoryFloor1Room4, mainFactoryFloor1Room5, mainFactoryFloor1Room6, mainFactoryFloor1Room7, mainFactoryFloor1Room8, mainFactoryFloor1Room9, mainFactoryFloor1Room10, mainFactoryFloor1Room11, mainFactoryFloor1Room12, mainFactoryFloor1Room13);

            var mainFactoryFloor2Room1 = AddTopoNode("#1汽机房检修平台", "", mainFactoryFloor2, AreaTypes.机房);
            var mainFactoryFloor2Room2 = AddTopoNode("#1机组励磁小室", "", mainFactoryFloor2, AreaTypes.机房);
            var mainFactoryFloor2Room3 = AddTopoNode("#1机组励磁及变频起动柜室", "", mainFactoryFloor2, AreaTypes.机房);
            var mainFactoryFloor2Room4 = AddTopoNode("#1机组配电间", "", mainFactoryFloor2, AreaTypes.机房);
            var mainFactoryFloor2Room5 = AddTopoNode("#1燃机电子设备间", "", mainFactoryFloor2, AreaTypes.机房);
            var mainFactoryFloor2Room6 = AddTopoNode("#2汽机房检修平台", "", mainFactoryFloor2, AreaTypes.机房);
            var mainFactoryFloor2Room7 = AddTopoNode("#2机组励磁小室", "", mainFactoryFloor2, AreaTypes.机房);
            var mainFactoryFloor2Room8 = AddTopoNode("#2机组励磁及变频起动柜室", "", mainFactoryFloor2, AreaTypes.机房);
            var mainFactoryFloor2Room9 = AddTopoNode("#2机组配电间", "", mainFactoryFloor2, AreaTypes.机房);
            var mainFactoryFloor2Room10 = AddTopoNode("#2燃机电子设备间", "", mainFactoryFloor2, AreaTypes.机房);
            //PhysicalTopologys.AddRange(mainFactoryFloor2Room1, mainFactoryFloor2Room2, mainFactoryFloor2Room3, mainFactoryFloor2Room4, mainFactoryFloor2Room5, mainFactoryFloor2Room6, mainFactoryFloor2Room7, mainFactoryFloor2Room8, mainFactoryFloor2Room9, mainFactoryFloor2Room10);

            #endregion
        }

        private void InitJ4(Area building5)
        {
            #region 集控楼
            var floor1 = AddTopoNode("集控楼0m层", "", building5, AreaTypes.楼层);
            SetInitBound(floor1, -4.3, 0, 55, 23.75, 4.5);

            var floor2 = AddTopoNode("集控楼4.5m层", "", building5, AreaTypes.楼层);
            SetInitBound(floor2, -4.3, 0, 55, 23.75, 4.3);
            var floor3 = AddTopoNode("集控楼8.8m层", "", building5, AreaTypes.楼层);
            SetInitBound(floor3, -4.3, 0, 55, 23.75, 4.3);
            var floor4 = AddTopoNode("集控楼13.1m层", "", building5, AreaTypes.楼层);
            SetInitBound(floor4, -4.3, 0, 55, 23.75, 4.3);
            //PhysicalTopologys.AddRange(building5Floor1, building5Floor2, building5Floor3, building5Floor4);
            float height1 = 4.5f;
            var room1 = AddTopoNode("工作段配电室", "", floor1, AreaTypes.机房);
            SetInitBound(room1, new Point[] {new Point(0.02,4.45,0,0),new Point(7.15,4.45,0,1),new Point(7.15,11.05,0,2),new Point(14.3,11.05,0,3),new Point(14.3,23.55,0,4),new Point(0.02,23.55,0,5)}, height1);
            var room2 = AddTopoNode("空调机房1", "", floor1, AreaTypes.机房);
            SetInitBound(room2, 0.02, 0.02, 7.15, 4.25, height1);
            var room3 = AddTopoNode("电子设备间", "", floor1, AreaTypes.机房);
            SetInitBound(room3, 7.35, 10.85, 33.8, 0.02, height1);
            var room4 = AddTopoNode("化学加药间", "", floor1, AreaTypes.机房);
            SetInitBound(room4, 34, 10.85,49.65, 0.02, height1);
            var room5 = AddTopoNode("联氨贮存间", "", floor1, AreaTypes.机房);
            SetInitBound(room5, 49.85, 6.6, 54.8, 0.02, height1);
            var room6 = AddTopoNode("磷酸盐贮存间", "", floor1, AreaTypes.机房);
            SetInitBound(room6, 49.85, 6.8, 54.8, 10.85, height1);
            var room7 = AddTopoNode("男卫生间", "", floor1, AreaTypes.机房);
            SetInitBound(room7, 50.05, 23.55,51.85, 18.95, height1);
            var room8 = AddTopoNode("女卫生间", "", floor1, AreaTypes.机房);
            SetInitBound(room8, 47.7, 18.95, 49.85, 23.55, height1);
            var room9 = AddTopoNode("柴油发电机房", "", floor1, AreaTypes.机房);
            SetInitBound(room9,34,23.55,47.5,13, height1);
            var room10 = AddTopoNode("油箱间1", "", floor1, AreaTypes.机房);
            SetInitBound(room10, 30.55,17.55,33.8,23.55, height1);
            var room11 = AddTopoNode("油箱间2", "", floor1, AreaTypes.机房);
            SetInitBound(room11, 27.35,23.55,30.35,17.55,height1);
            var room12 = AddTopoNode("机房备件间", "", floor1, AreaTypes.机房);
            SetInitBound(room12, 30.55,13,33.8,17.35, height1);
            var room13 = AddTopoNode("备件间", "", floor1, AreaTypes.机房);
            SetInitBound(room13, 27.35,13,30.35,17.35, height1);
            var room14 = AddTopoNode("空调机房2", "", floor1, AreaTypes.机房);
            SetInitBound(room14, 20.2,23.55,27.15,13, height1);
            //PhysicalTopologys.AddRange(room1, room2, room3, room4, room5, room6, room7, room8, room9, room10, room11, room12, room13, room14);

            AddSubNodes(floor2, AreaTypes.机房, "集控室", "消防气瓶间", "工作票室", "电气工程师室", "交接班室", "SIS室", "电缆夹层", "仪表盘间", "高温架间", "饮水间", "男卫生间", "女卫生间", "会议室", "工程师室");
            AddSubNodes(floor3, AreaTypes.机房, "空调机房", "继电器室", "蓄电池室", "备品间", "饮水间", "男卫生间", "女卫生间", "会议室", "运行人员办公室1", "运行人员办公室2", "运行人员办公室3");

            #endregion
        }

        private void InitJ5(Area building6)
        {
            #region 联合车间
            List<Area> building6Floors = AddSubNodes(building6, AreaTypes.楼层, "联合车间0m层", "联合车间4.5m层", "联合车间7.8m层");
            AddSubNodes(building6Floors[0], AreaTypes.机房, "电子设备间", "工作段配电室", "进气冷却装置空调机房", "空压机房");
            AddSubNodes(building6Floors[1], AreaTypes.机房, "消防气瓶间", "空调机房", "电缆夹层1", "电缆夹层2", "配电室");
            AddSubNodes(building6Floors[2], AreaTypes.机房, "空调机房", "蓄电池室", "公用段配电间", "继电器室");
            #endregion
        }

        private void InitH2(Area building20)
        {
            #region 锅炉补给水处理车间
            List<Area> building20Floors = AddSubNodes(building20, AreaTypes.楼层, "锅炉补给水处理车间0m层", "锅炉补给水处理车间4.5m层", "锅炉补给水处理车间7m层");
            AddSubNodes(building20Floors[0], AreaTypes.机房, "配电间", "电子设备间", "水系统控制室", "运行化验室", "男卫生间", "女卫生间", "加药及化学清洗间", "贮存区域", "除盐间", "水泵间");
            AddSubNodes(building20Floors[1], AreaTypes.机房, "药品仓库", "色谱仪室", "气瓶间", "精密仪器室", "会议室", "办公室", "天平室", "油分析室", "水分析/环保实验室");
            #endregion
        }

        private void InitElectricityGeneratingStation(Area root)
        {
            int defaultHeight = 20;
            var factoryRoot = AddTopoNode("四会热电厂", "", root, AreaTypes.分组);
            //PhysicalTopologys.Add(factoryRoot);

            var buildingGroup1 = AddTopoNode("主机装置建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup1);
            var buildingGroup2 = AddTopoNode("常规燃料供应建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup2);
            var buildingGroup3 = AddTopoNode("仪表与控制建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup3);
            var buildingGroup4 = AddTopoNode("常规产热建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup4);
            var buildingGroup5 = AddTopoNode("辅助系统建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup5);
            var buildingGroup6 = AddTopoNode("电力送出与厂用电建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup6);
            var buildingGroup7 = AddTopoNode("供水与水处理建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup7);
            var buildingGroup8 = AddTopoNode("循环冷却水系统建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup8);
            var buildingGroup9 = AddTopoNode("冷却塔系统建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup9);
            var buildingGroup10 = AddTopoNode("一般服务类建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup10);

            #region 电厂主要建筑

            var J1 = AddTopoNode("主厂房", "J1UMA", buildingGroup1, AreaTypes.大楼, null, "J1");
            SetInitBound(J1,2200, 1800, 2244, 1648.2, defaultHeight, false);
            InitJ1(J1);

            var building2 = AddTopoNode("#2燃气轮机房", "11UMB", buildingGroup1, AreaTypes.大楼);
            var building3 = AddTopoNode("#4燃气轮机房", "21UMB", buildingGroup1, AreaTypes.大楼);
            var building4 = AddTopoNode("调压站控制室", "J1UER", buildingGroup2, AreaTypes.大楼);

            var J4 = AddTopoNode("集控楼", "J1UCA", buildingGroup3, AreaTypes.大楼, null, "J4");
            SetInitBound(J4,2249.5,1769.4, 2304, 1792.5, 19.1, false);
            InitJ4(J4);


            var J5 = AddTopoNode("联合车间", "", buildingGroup3, AreaTypes.大楼,null,"J5");
            SetInitBound(J5, 2249.5, 1692.8, 2293, 1715.9, defaultHeight, false);
            InitJ5(J5);

            Db.SaveChanges();
            //return;

            var building7 = AddTopoNode("#1锅炉房", "", buildingGroup4, AreaTypes.大楼);
            var building8 = AddTopoNode("#3锅炉房", "", buildingGroup4, AreaTypes.大楼);
            var building9 = AddTopoNode("#1烟囱", "", buildingGroup4, AreaTypes.大楼);
            var building10 = AddTopoNode("#3烟囱", "", buildingGroup4, AreaTypes.大楼);

            var building11 = AddTopoNode("#1锅炉辅助间", "", buildingGroup5, AreaTypes.大楼);
            var building12 = AddTopoNode("#3锅炉辅助间", "", buildingGroup5, AreaTypes.大楼);
            var building13 = AddTopoNode("启动锅炉", "", buildingGroup5, AreaTypes.大楼);

            var building14 = AddTopoNode("GIS配电装置楼", "", buildingGroup6, AreaTypes.大楼);
            var building34 = AddTopoNode("#1启备变区域", "", buildingGroup6, AreaTypes.大楼);
            var building35 = AddTopoNode("#1主变区域", "", buildingGroup6, AreaTypes.大楼);
            var building36 = AddTopoNode("#2主变区域", "", buildingGroup6, AreaTypes.大楼);
            var building37 = AddTopoNode("#3主变区域", "", buildingGroup6, AreaTypes.大楼);
            var building38 = AddTopoNode("#4主变区域", "", buildingGroup6, AreaTypes.大楼);
            var building39 = AddTopoNode("#1高厂变区域", "", buildingGroup6, AreaTypes.大楼);
            var building40 = AddTopoNode("#2高厂变区域", "", buildingGroup6, AreaTypes.大楼);

            var building15 = AddTopoNode("循环水泵房配电间", "", buildingGroup7, AreaTypes.大楼);
            var building16 = AddTopoNode("补给水泵房", "", buildingGroup7, AreaTypes.大楼);
            var building17 = AddTopoNode("净水站", "", buildingGroup7, AreaTypes.大楼);
            var building18 = AddTopoNode("综合泵房", "", buildingGroup7, AreaTypes.大楼);
            var building19 = AddTopoNode("雨水泵房", "", buildingGroup7, AreaTypes.大楼);
            var H2 = AddTopoNode("锅炉补给水处理车间", "", buildingGroup7, AreaTypes.大楼,null,"H2");
            InitH2(H2);
            SetInitBound(H2,2330, 1712, 2362, 1650, defaultHeight,false);

            var building21 = AddTopoNode("废水集中处理站", "", buildingGroup7, AreaTypes.大楼);
            var building22 = AddTopoNode("生活污水处理站", "", buildingGroup7, AreaTypes.大楼);
            var building23 = AddTopoNode("循环水加药间", "", buildingGroup7, AreaTypes.大楼);

            var building24 = AddTopoNode("循环水泵房", "", buildingGroup8, AreaTypes.大楼);

            var building25 = AddTopoNode("自然通风冷却塔", "", buildingGroup9, AreaTypes.大楼);

            var building26 = AddTopoNode("供氢站", "", factoryRoot, AreaTypes.大楼);
            var building27 = AddTopoNode("检修间及材料库", "", buildingGroup10, AreaTypes.大楼);
            //PhysicalTopologys.AddRange(building2, building3, building4, building5, building6, building7, building8,building9, building10, building11, building12, building13, building14, building15, building16,building17, building18, building19, building20, building21, building22, building23, building24,building25, building26, building27);

            DevInfo dev1 = new DevInfo() { Local_DevID = "DevId1", IP = "12.11.11.11", Name = "设备1", Local_TypeCode = 555, ParentId = building2.Id, CreateTime = DateTime.Now, ModifyTime = DateTime.Now };
            building2.LeafNodes = new List<DevInfo>();
            building2.LeafNodes.Add(dev1);
            DevInfos.Add(dev1);

            var buildingGroup11 = AddTopoNode("非生产类建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup11);
            var buildingGroup12 = AddTopoNode("电网和配电系统的建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup12);
            var buildingGroup13 = AddTopoNode("电力送出与厂用电建筑物", "", factoryRoot, AreaTypes.分组);
            //PhysicalTopologys.Add(buildingGroup13);

            var building28 = AddTopoNode("行政综合楼", "", buildingGroup11, AreaTypes.大楼);
            var building29 = AddTopoNode("食堂及公寓", "", buildingGroup11, AreaTypes.大楼);
            var building30 = AddTopoNode("主入口门卫值班室", "", buildingGroup11, AreaTypes.大楼);
            var building31 = AddTopoNode("消防车库", "", buildingGroup11, AreaTypes.大楼);
            var building32 = AddTopoNode("停车棚", "", buildingGroup11, AreaTypes.大楼);

            var building33 = AddTopoNode("220kV升压站", "", buildingGroup12, AreaTypes.大楼);


            //PhysicalTopologys.AddRange(building28, building29, building30, building31, building32, building33,building34, building35, building36, building37, building38, building39, building40);

            #endregion

            #region #1锅炉辅助间
            var building11Floor1 = AddTopoNode("#1锅炉辅助间0m层", "", building11, AreaTypes.楼层);
            var building11Floor2 = AddTopoNode("#1锅炉辅助间4.5m层", "", building11, AreaTypes.楼层);
            var building11Floor3 = AddTopoNode("#1锅炉辅助间8.5m层", "", building11, AreaTypes.楼层);
            var building11Floor4 = AddTopoNode("#1锅炉辅助间13.15m层", "", building11, AreaTypes.楼层);
            //PhysicalTopologys.AddRange(building11Floor1, building11Floor2, building11Floor3, building11Floor4);
            #endregion

            #region #3锅炉辅助间
            var building12Floor1 = AddTopoNode("#3锅炉辅助间0m层", "", building12, AreaTypes.楼层);
            var building12Floor2 = AddTopoNode("#3锅炉辅助间4.5m层", "", building12, AreaTypes.楼层);
            var building12Floor3 = AddTopoNode("#3锅炉辅助间8.5m层", "", building12, AreaTypes.楼层);
            var building12Floor4 = AddTopoNode("#3锅炉辅助间13.15m层", "", building12, AreaTypes.楼层);
            //PhysicalTopologys.AddRange(building12Floor1, building12Floor2, building12Floor3, building12Floor4);
            #endregion

        }

        private void SetInitBound(Area topo, double x1, double y1, double x2, double y2, double thicknessT,
            bool isRelative = true,
            double bottomHeightT = 0, bool isOnNormalArea = true, bool isOnAlarmArea = false,
            bool isOnLocationArea = false)
        {
            SetInitBound(topo, (float) x1, (float) y1, (float) x2, (float) y2, (float) thicknessT,
                isRelative,
                (float) bottomHeightT, isOnNormalArea, isOnAlarmArea,
                isOnLocationArea);
        }

        private void SetInitBound(Area topo, float x1, float y1, float x2, float y2, float thicknessT, bool isRelative = true,
            float bottomHeightT = 0, bool isOnNormalArea = true, bool isOnAlarmArea = false, bool isOnLocationArea = false)
        {
            Bound initBound = new Bound(x1, y1, x2, y2, bottomHeightT, thicknessT, isRelative);
            Bound editBound = new Bound(x1, y1, x2, y2, bottomHeightT, thicknessT, isRelative);
            var transfrom = new TransformM(initBound);
            Bounds.Add(initBound);
            Bounds.Add(editBound);
            transfrom.IsCreateAreaByData = isOnNormalArea;
            transfrom.IsOnAlarmArea = isOnAlarmArea;
            transfrom.IsOnLocationArea = isOnLocationArea;
            //TransformMs.Add(transfrom);

            topo.SetTransform(transfrom);
            topo.InitBound = initBound;
            topo.EditBound = editBound;
            Areas.Edit(topo);
        }

        private void SetInitBound(Area topo, Point[] points, float thicknessT, bool isRelative=true,
            float bottomHeightT = 0, bool isOnNormalArea = true, bool isOnAlarmArea = false, bool isOnLocationArea = false)
        {
            Bound initBound = new Bound(points, bottomHeightT, thicknessT, isRelative);
            Bound editBound = new Bound(points, bottomHeightT, thicknessT, isRelative);
            var transfrom = new TransformM(initBound);
            Bounds.Add(initBound);
            Bounds.Add(editBound);
            transfrom.IsCreateAreaByData = isOnNormalArea;
            transfrom.IsOnAlarmArea = isOnAlarmArea;
            transfrom.IsOnLocationArea = isOnLocationArea;
            //TransformMs.Add(transfrom);

            topo.SetTransform(transfrom);
            topo.InitBound = initBound;
            topo.EditBound = editBound;
            Areas.Edit(topo);
        }

        #endregion

        private void InitChuLingPark(Area root)
        {
            #region 初灵大楼


            var transformMTT = new TransformM() { X = 2293.5f, Y = 1, Z = 1715.5f, RX = 0, RY = 0, RZ = 0, SX = 1, SY = 1, SZ = 1 };
            var gaoxin = AddTopoNode("高新软件园", "", root, AreaTypes.分组, transformMTT);
            var gaoxinBuldingGroup1 = AddTopoNode("左侧区域", "", gaoxin, AreaTypes.分组);
            var chulingRoot = AddTopoNode("初灵大楼", "", gaoxinBuldingGroup1, AreaTypes.大楼);

            var transformMTT1 = new TransformM() { X = 2293.5f, Y = 1, Z = 1715.5f, RX = 0, RY = 0, RZ = 0, SX = 1, SY = 1, SZ = 1 };
            var chulingFloor1 = AddTopoNode("初灵大楼一层", "", chulingRoot, AreaTypes.楼层, transformMTT1);
            //PhysicalTopologys.AddRange(gaoxin, gaoxinBuldingGroup1,chulingRoot, chulingFloor1);

            var chulingFloor1Room1 = AddTopoNode("莘科机房", "", chulingFloor1, AreaTypes.机房);
            var chulingFloor1Room2 = AddTopoNode("莘科储物间", "", chulingFloor1, AreaTypes.机房);
            var chulingFloor1Room3 = AddTopoNode("莘科办公室", "", chulingFloor1, AreaTypes.机房);
            var chulingFloor1Room4 = AddTopoNode("莘科办公室(小)", "", chulingFloor1, AreaTypes.机房);
            var chulingFloor1Room5 = AddTopoNode("一楼走道", "", chulingFloor1, AreaTypes.机房);
            //PhysicalTopologys.AddRange(chulingFloor1Room1, chulingFloor1Room2, chulingFloor1Room3, chulingFloor1Room4, chulingFloor1Room5);

            var chulingFloor2 = AddTopoNode("初灵大楼二层", "", chulingRoot, AreaTypes.大楼);
            var chulingFloor2Room1 = AddTopoNode("财务室", "", chulingFloor2, AreaTypes.机房);
            var chulingFloor2Room2 = AddTopoNode("健身区", "", chulingFloor2, AreaTypes.机房);
            var chulingFloor2Room3 = AddTopoNode("监控区域2", "", chulingFloor2, AreaTypes.机房);
            //PhysicalTopologys.AddRange(chulingFloor2, chulingFloor2Room1, chulingFloor2Room2, chulingFloor2Room3);
            //var chulingFloor2Room4 = AddTopoNode("范围1", "", chulingFloor1Room1, AreaTypes.范围);
            //var chulingFloor2Room5 = AddTopoNode("范围2", "", chulingFloor1Room1, AreaTypes.范围);

            //Map map1 = new Map() { Name = "一楼地图", MinX = -100, MinY = -100, MinZ = 0, MaxX = 6068, MaxY = 2098, MaxZ = 400, TopoNode = chulingFloor1 };
            //Map map2 = new Map() { Name = "二楼地图", MinX = -100, MinY = -100, MinZ = 450, MaxX = 6068, MaxY = 2080, MaxZ = 900, TopoNode = chulingFloor2 };
            //List<Map> maps = new List<Map>() { map1, map2 };
            //Maps.AddRange(maps);


            var transformM1 = new TransformM() { X = 2293.5f, Y = 10, Z = 1715.5f, RX = 0, RY = 0, RZ = 0, SX = 1, SY = 1, SZ = 1 };
            var area1 = AddTopoNode("范围1", "", gaoxin, AreaTypes.区域, transformM1);


            var transformM2 = new TransformM() { X = 2293.5f, Y = 10, Z = 1715.5f, RX = 0, RY = 0, RZ = 0, SX = 1, SY = 1, SZ = 1 };
            var area2 = AddTopoNode("范围2", "", gaoxin, AreaTypes.区域, transformM2);
            //PhysicalTopologys.AddRange(area1, area2);


            var transformM3 = new TransformM() { X = 2293.5f, Y = 10, Z = 1715.5f, RX = 0, RY = 0, RZ = 0, SX = 1, SY = 1, SZ = 1 };
            var area3 = AddTopoNode("范围3", "", chulingFloor1, AreaTypes.范围, transformM3);


            var transformM4 = new TransformM() { X = 2293.5f, Y = 10, Z = 1715.5f, RX = 0, RY = 0, RZ = 0, SX = 1, SY = 1, SZ = 1 };
            var area4 = AddTopoNode("范围4", "", chulingFloor1, AreaTypes.范围, transformM4);

            Archor archor1 = new Archor() { Code = "85A4", Name = "基站1", X = 3000, Y = 870, Z = 200, Type = 0, IsAutoIp = true, Ip = "", ServerIp = "", ServerPort = 0, Power = 0, AliveTime = 0, Enable = IsStart.是 };
            Archor archor2 = new Archor() { Code = "85D8", Name = "基站2", X = 4960, Y = 1925, Z = 200, Type = 0, IsAutoIp = true, Ip = "", ServerIp = "", ServerPort = 0, Power = 0, AliveTime = 0, Enable = IsStart.是 };
            Archor archor3 = new Archor() { Code = "85E8", Name = "基站3", X = 4960, Y = 1125, Z = 200, Type = 0, IsAutoIp = true, Ip = "", ServerIp = "", ServerPort = 0, Power = 0, AliveTime = 0, Enable = IsStart.是 };
            Archor archor4 = new Archor() { Code = "85D4", Name = "基站4", X = 3500, Y = 1965, Z = 200, Type = 0, IsAutoIp = true, Ip = "", ServerIp = "", ServerPort = 0, Power = 0, AliveTime = 0, Enable = IsStart.是 };
            Archor archor5 = new Archor() { Code = "85B2", Name = "基站5", X = 4960, Y = 870, Z = 200, Type = 0, IsAutoIp = true, Ip = "", ServerIp = "", ServerPort = 0, Power = 0, AliveTime = 0, Enable = IsStart.是 };
            Archor archor6 = new Archor() { Code = "85D2", Name = "基站6", X = 3500, Y = 1005, Z = 200, Type = 0, IsAutoIp = true, Ip = "", ServerIp = "", ServerPort = 0, Power = 0, AliveTime = 0, Enable = IsStart.是 };

            Archor archor7 = new Archor() { Code = "85A8", Name = "基站7", X = 5025, Y = 1630, Z = 500, Type = 0, IsAutoIp = true, Ip = "", ServerIp = "", ServerPort = 0, Power = 0, AliveTime = 0, Enable = IsStart.是 };
            Archor archor8 = new Archor() { Code = "85D6", Name = "基站8", X = 5585, Y = 1953, Z = 500, Type = 0, IsAutoIp = true, Ip = "", ServerIp = "", ServerPort = 0, Power = 0, AliveTime = 0, Enable = IsStart.是 };
            Archor archor9 = new Archor() { Code = "85CE", Name = "基站9", X = 5585, Y = 1623, Z = 500, Type = 0, IsAutoIp = true, Ip = "", ServerIp = "", ServerPort = 0, Power = 0, AliveTime = 0, Enable = IsStart.是 };
            Archor archor10 = new Archor() { Code = "85CC", Name = "基站10", X = 5025, Y = 1930, Z = 500, Type = 0, IsAutoIp = true, Ip = "", ServerIp = "", ServerPort = 0, Power = 0, AliveTime = 0, Enable = IsStart.是 };

            List<Archor> archors0 = new List<Archor>() { archor1, archor2, archor3, archor4 };
            List<Archor> archors1 = new List<Archor>() { archor5, archor6 };
            List<Archor> archors2 = new List<Archor>() { archor7, archor8, archor9, archor10 };
            AddArchorDevs(archors0, chulingFloor1Room3);
            AddArchorDevs(archors1, chulingFloor1Room5);
            AddArchorDevs(archors2, chulingFloor2Room3);

            #endregion
        }

        private Area AddTopoNode(string name, string kks, Area parent, AreaTypes type,
            TransformM transform = null, string otherName = "")
        {
            if (string.IsNullOrEmpty(kks))
            {
                KKSCode kksCode = KKSCodes.DbSet.FirstOrDefault(i => i.Name.Contains(name));
                if (kksCode != null)
                {
                    kks = kksCode.Code;
                }
            }

            if (!string.IsNullOrEmpty(kks))
            {
                var topoNode = new Area()
                {
                    Name = name,
                    ParentId = parent.Id,
                    Type = type,

                    //Transfrom = transform,
                };
                topoNode.SetTransform(transform);
                Areas.Add(topoNode);

                KKSCode kksCode = KKSCodes.DbSet.FirstOrDefault(i => i.Code == kks);
                NodeKKS kks1 = null;
                if (kksCode != null)
                {
                    kks1 = new NodeKKS() { KKS = kks, NodeType = type, NodeId = topoNode.Id, KKSId = kksCode.Id };
                    NodeKKSs.Add(kks1);
                }
                else
                {
                    kks1 = new NodeKKS() { KKS = kks, NodeType = type, NodeId = topoNode.Id };
                    NodeKKSs.Add(kks1);
                }
                topoNode.KKS = kks1.KKS;
                //topoNode.Nodekks = kks1;
                //topoNode.NodekksId = kks1.Id;
                Areas.Edit(topoNode);

                return topoNode;
            }
            else
            {
                var topoNode = new Area()
                {
                    Name = name,
                    ParentId = parent.Id,
                    Type = type,
                    //Transfrom = transform
                };
                topoNode.SetTransform(transform);
                Areas.Add(topoNode);
                return topoNode;
            }
        }

        private List<Area> AddSubNodes(Area parent, AreaTypes type, params string[] names)
        {
            List<Area> nodes = new List<Area>();
            foreach (string name in names)
            {
                if (string.IsNullOrEmpty(name)) continue;
                var node = AddTopoNode(name, "", parent, type);
                if (node == null) continue;
                nodes.Add(node);
            }
            return nodes;
        }
        private void AddArchorDevs(List<Archor> archors, Area parent)
        {
            foreach (var item in archors)
            {
                AddArchorDev(item, parent);
            }
        }

        private void AddArchorDev(Archor archor1, Area parent)
        {
            DevInfo archor1Dev = new DevInfo() { Name = archor1.Name, Local_DevID = Guid.NewGuid().ToString(), ParentId = parent.Id, Local_TypeCode = 6345 };
            archor1.DevInfo = archor1Dev;
            DevInfos.Add(archor1Dev);
            Archors.Add(archor1);
        }
    }
}