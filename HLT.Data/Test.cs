#region 版本信息 
/************************************************************************************
*Copyright (c) 2014 All Rights Reserved.
*CLR版本：  4.0.30319.42000
*框架版本： 4.6
*机器名称： LYC
*命名空间： HLT.Data
*文件名：   Test
*版本号：   V1.0.0.0
*唯一标识： 2e344053-a8ff-446a-a7d1-dda1f0a7a48a
*创建人：  刘砚晨
*电子邮箱：282823740@qq.com
*创建时间：2018/7/23 9:31:26
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HLT.Model.EF;

namespace HLT.Data
{
    public class Test
    {
        public static string Add()
        {
            string n = string.Empty;
            try
            {
                using (var db = new OracleDBContext())
                {
                    //批量操作用AddRange
                    HLT.Model.Entity.Test test = new Model.Entity.Test();
                    test.ID = "1";
                    test.Name = "hh";
                    db.Tests.Add(test);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return "1";
        }
    }
}
