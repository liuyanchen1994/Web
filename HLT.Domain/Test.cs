#region 版本信息 
/************************************************************************************
*Copyright (c) 2014 All Rights Reserved.
*CLR版本：  4.0.30319.42000
*框架版本： 4.6
*机器名称： LYC
*命名空间： HLT.Domain
*文件名：   Test
*版本号：   V1.0.0.0
*唯一标识： 52e47179-2b6c-408f-a18b-0b8a075110b6
*创建人：  刘砚晨
*电子邮箱：282823740@qq.com
*创建时间：2018/7/20 8:45:02
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

namespace HLT.Domain
{
    public class Test : ITest
    {
        public string Add(string id)
        {
            return "测试依赖注入";
        }
    }
}
