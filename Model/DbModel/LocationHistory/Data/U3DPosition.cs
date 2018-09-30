﻿using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Location.TModel.Tools;

namespace DbModel.LocationHistory.Data
{
    /// <summary>
    /// 位置信息 (历史位置记录）
    /// </summary>
    [DataContract]
    public class U3DPosition
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [DataMember]
        [Display(Name = "主键Id")]
        public int Id { get; set; }

        /// <summary>
        /// 定位卡编号
        /// </summary>
        [DataMember]
        [Display(Name = "定位卡编号")]
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// X
        /// </summary>
        [DataMember]
        [Display(Name = "X")]
        public double X { get; set; }

        /// <summary>
        /// Y
        /// </summary>
        [DataMember]
        [Display(Name = "Y")]
        public double Y { get; set; }

        /// <summary>
        /// Z
        /// </summary>
        [DataMember]
        [Display(Name = "Z")]
        public double Z { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [DataMember]
        [Display(Name = "时间")]
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 时间戳（毫秒）
        /// </summary>
        [DataMember]
        [Display(Name = "时间戳")]
        public long DateTimeStamp { get; set; }

        /// <summary>
        /// 电量（伏*100)
        /// </summary>
        [DataMember]
        [Display(Name = "电量")]
        public int Power { get; set; }

        /// <summary>
        /// 序号（新的卡才有的）
        /// </summary>
        [DataMember]
        [Display(Name = "序号")]
        public int Number { get; set; }

        /// <summary>
        /// 不知道什么信息 格式是 0:0:0:0:0 或者 0:0:0:0:1。
        /// 感觉是卡不动时会发1，动时发0。可能用:分开，不同位有不同作用
        /// 补充：卡大约20秒中不动后，会发0:0:0:0:1，然后再不动大约10秒后，不发位置信息
        /// </summary>
        [DataMember]
        [Display(Name = "信息")]
        public string Flag { get; set; }

        public bool Parse(string info)
        {
            try
            {
                string[] parts = info.Split(',');
                int length = parts.Length;
                if (length <= 1) return false;//心跳包回拨
                Code = parts[0];
                X = double.Parse(parts[1]);
                Y = double.Parse(parts[2]);
                Z = double.Parse(parts[3]);
                DateTimeStamp = long.Parse(parts[4]);
                DateTime = TimeConvert.TimeStampToDateTime(DateTimeStamp / 1000);
                
                if (length > 4)
                    Power = int.Parse(parts[5]);
                if (length > 5)
                    Number = int.Parse(parts[6]);
                if (length > 6)
                    Flag = parts[7];
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public U3DPosition Clone()
        {
            return this.CloneObjectByBinary();
        }
    }
}