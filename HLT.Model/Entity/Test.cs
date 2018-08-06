#region 版本信息 
/************************************************************************************
*Copyright (c) 2014 All Rights Reserved.
*CLR版本：  4.0.30319.42000
*框架版本： 4.6
*机器名称： LYC
*命名空间： HLT.Model.Entity
*文件名：   Test
*版本号：   V1.0.0.0
*唯一标识： 46c99809-d2d6-4508-925d-fad41d70818e
*创建人：  刘砚晨
*电子邮箱：282823740@qq.com
*创建时间：2018/7/23 9:23:30
*描述：
*
*=====================================================================
*修改标记
*修改时间：
*修改人： 
*版本号： V1.0.0.0
*描述：
*
/************************************************************************************/
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLT.Model.Entity
{
    [Table("TEST")]
    public class Test
    {
        [Key]
        [Column("ID")]
        [StringLength(10)]
        public string ID { get; set; }

        [Column("NAME")]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
