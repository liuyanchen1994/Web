#region 版本信息 
/************************************************************************************
*Copyright (c) 2014 All Rights Reserved.
*CLR版本：  4.0.30319.42000
*框架版本： 4.6
*机器名称： LYC
*命名空间： HLT.Model.EF
*文件名：   MsSqlDBContext
*版本号：   V1.0.0.0
*唯一标识： 220f8c01-41ea-40af-bf16-95f348facd47
*创建人：  刘砚晨
*电子邮箱：282823740@qq.com
*创建时间：2018/7/19 15:44:16
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
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLT.Model.EF
{
    public class MsSqlDBContext : DbContext, IUnitOfWork
    {
        public MsSqlDBContext() : base("SqlServer")
        {

        }

        public MsSqlDBContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
