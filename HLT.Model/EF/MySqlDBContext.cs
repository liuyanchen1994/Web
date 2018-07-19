#region 版本信息 
/************************************************************************************
*Copyright (c) 2014 All Rights Reserved.
*CLR版本：  4.0.30319.42000
*框架版本： 4.6
*机器名称： LYC
*命名空间： HLT.Model.EF
*文件名：   MySqlDBContext
*版本号：   V1.0.0.0
*唯一标识： e0d9f7c1-f748-411c-be30-3039a17b3777
*创建人：  刘砚晨
*电子邮箱：282823740@qq.com
*创建时间：2018/7/19 15:44:37
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
    public class MySqlDBContext : DbContext, IUnitOfWork
    {
        public MySqlDBContext() : base("MySql")
        {

        }

        public MySqlDBContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }
    }
}
