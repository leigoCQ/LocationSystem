﻿using BLL;
using BLL.Tools;
using DbModel.Location.AreaAndDev;
using ExcelLib;
using IModel.Enums;
using Location.BLL.Tool;
using LocationServer.Tools;
using LocationServices.Locations;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using TModel.Location.AreaAndDev;
using WPFClientControlLib;
using static Location.BLL.Tool.KKSCodeHelper;
using DevMonitorNode = DbModel.Location.AreaAndDev.DevMonitorNode;

namespace LocationServer.Windows
{
    /// <summary>
    /// KKSMonitorDataWindow.xaml 的交互逻辑
    /// </summary>
    public partial class KKSMonitorDataWindow : Window
    {
        public KKSMonitorDataWindow()
        {
            InitializeComponent();
            //Location.BLL.Tool.Log.NewLogEvent += ListenToLog;
            logTbController.Init(TbLogs, LogTags.KKS);
        }

        LogTextBoxController logTbController = new LogTextBoxController();

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //LoadData();
        }

        private void LoadData()
        {
            devs = bll.DevInfos.Where(i => i.Local_TypeCode == 20181008);
            dg_sisDevs.ItemsSource = devs;

            lst = ls.KKSCodes;
            dg_kks.ItemsSource = lst;

            var monitors = bll.DevMonitorNodes.ToList();
            dg_monitor.ItemsSource = monitors;
        }

        List<DevInfo> devs;

        LocationService ls = new LocationService();
        private Bll _bll;

        protected Bll bll
        {
            get
            {
                if (_bll == null)
                {
                    _bll = new Bll();
                }
                return _bll;
            }
        }
        List<DbModel.Location.AreaAndDev.KKSCode> lst;
        private void MenuGetAllMonitorData_Click(object sender, RoutedEventArgs e)
        {
            Worker.Run(() =>
            {
                DevMonitorHelper.GetAllKKSMonitorData();
            }, () =>
             {
                 Log.Info(LogTags.KKS, "获取数据完成");
                 MessageBox.Show("获取数据完成！");
             });
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //Location.BLL.Tool.Log.NewLogEvent -= ListenToLog;
            logTbController.Dispose();
        }

        private void MenuGetKKSData_Click(object sender, RoutedEventArgs e)
        {
            var info = dg_sisDevs.SelectedItem as DbModel.Location.AreaAndDev.KKSCode;
            if (info != null)
            {
                var monitor = ls.GetDevMonitorInfoByKKS(info.Code, true);
            }
        }

        private void MenuGetDevData_Click(object sender, RoutedEventArgs e)
        {
            var dev = dg_sisDevs.SelectedItem as DevInfo;
            if (dev != null)
            {
                Log.Info(LogTags.KKS, string.Format("获取数据:{0}[{1}]", dev.Name, dev.KKS));
                var monitor = ls.GetDevMonitorInfoByKKS(dev.KKS, true);
            }
        }

        private void MenuGetMonitorData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void GetJ1F2DevMonitors_Click(object sender, RoutedEventArgs e)
        {
            Worker.Run(() =>
            {
                DevMonitorHelper.GetJ1F2DevsMonitorNodes();
            }, () =>
            {
                MessageBox.Show("完成");
            });
        } 

        private void MenuGetDevDataAll_Click(object sender, RoutedEventArgs e)
        {
            Worker.Run(() =>
            {
                DevMonitorHelper.GetAllStaticDevsMonitorData();
            }, () =>
            {
                MessageBox.Show("完成");
            });
        }

        private void GetAllMonitorNodes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MenuParseOriginalKKSCode_Click(object sender, RoutedEventArgs e)
        {
            Worker.Run(() =>
            {
                DevMonitorHelper.ParseMonitorPoint();
            }, () =>
            {
                MessageBox.Show("完成");
            });
        }

        private void MenuUpdateParseOriginalKKSCode_OnClick(object sender, RoutedEventArgs e)
        {
            //ReParseMonitPoint()
            Worker.Run(() =>
            {
                DevMonitorHelper.ReParseMonitPoint(false);
            }, () =>
            {
                MessageBox.Show("初始化KKSNode点完成");
            });
        }

        private void BtnSearchKKS_OnClick(object sender, RoutedEventArgs e)
        {
            var key = TbKKSKey.Text;
            dg_kks.ItemsSource = lst.Where(i=>i.Code.Contains(key));
        }

        private void InitKKSCode_OnClick(object sender, RoutedEventArgs e)
        {
            Worker.Run(() =>
            {
                DevMonitorHelper.InitKKSCode();
            }, () =>
            {
                MessageBox.Show("初始化KKSCode点完成");
            });
        }

        private void InitKKSNode_OnClick(object sender, RoutedEventArgs e)
        {
            Worker.Run(() =>
            {
                DevMonitorHelper.InitKKSNode();

            }, () =>
            {
                MessageBox.Show("初始化KKSNode点完成");
            });
        }



        private void MenuUpdateMonitorData_OnClick(object sender, RoutedEventArgs e)
        {
            Worker.Run(() =>
            {
                DevMonitorHelper.GetAllMonitorNodeData();

            }, () =>
            {
                MessageBox.Show("初始化KKSNode点完成");
            });
        }

        private void MenuUpdateAllDate_OnClick(object sender, RoutedEventArgs e)
        {
            Worker.Run(() =>
            {
                DateTime start = DateTime.Now;
                DevMonitorHelper.InitKKSNode();
                DevMonitorHelper.ParseMonitorPoint();
                DevMonitorHelper.SaveMonitorPoint();
                DevMonitorHelper.ReParseMonitPoint(true);
                DevMonitorHelper.GetAllMonitorNodeData();

                TimeSpan time = DateTime.Now - start;
                Log.Info(LogTags.KKS, string.Format("【全部】完成 用时:{0}", time));
            }, () =>
            {
                MessageBox.Show("更新数据完成");
            });
        }

        private void MenuUpdateOriginalKKSCode_Click(object sender, RoutedEventArgs e)
        {
            Worker.Run(() =>
            {
                DevMonitorHelper.SaveMonitorPoint();
            }, () =>
            {
                MessageBox.Show("初始化KKSNode点完成");
            });
        }
       

        

        private void MenuLoadData_OnClick(object sender, RoutedEventArgs e)
        {
            LoadData();
        }
    }
}
