#region 版本信息 
/************************************************************************************
*Copyright (c) 2014 All Rights Reserved.
*CLR版本：  4.0.30319.42000
*框架版本： 4.6
*机器名称： LYC
*命名空间： HLT.Web.Areas.HelpPage.Models
*文件名：   MultiXmlDocumentationProvider
*版本号：   V1.0.0.0
*唯一标识： df008bac-7469-43f9-9ef4-055c5da0ecc2
*创建人：  刘砚晨
*电子邮箱：282823740@qq.com
*创建时间：2018/7/19 15:33:25
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

using HLT.Web.Areas.HelpPage.ModelDescriptions;
using System;
using System.Linq;
using System.Reflection;
using System.Web.Http.Controllers;
using System.Web.Http.Description;

namespace HLT.Web.Areas.HelpPage.Models
{
    public class MultiXmlDocumentationProvider:IDocumentationProvider, IModelDocumentationProvider
    {
        private readonly XmlDocumentationProvider[] Providers;


        /*********
        ** Public methods
        *********/
        /// <summary>Construct an instance.</summary>
        /// <param name="paths">The physical paths to the XML documents.</param>
        public MultiXmlDocumentationProvider(params string[] paths)
        {
            this.Providers = paths.Select(p => new XmlDocumentationProvider(p)).ToArray();
        }

        /// <summary>Gets the documentation for a subject.</summary>
        /// <param name="subject">The subject to document.</param>
        public string GetDocumentation(MemberInfo subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }

        /// <summary>Gets the documentation for a subject.</summary>
        /// <param name="subject">The subject to document.</param>
        public string GetDocumentation(Type subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }

        /// <summary>Gets the documentation for a subject.</summary>
        /// <param name="subject">The subject to document.</param>
        public string GetDocumentation(HttpControllerDescriptor subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }

        /// <summary>Gets the documentation for a subject.</summary>
        /// <param name="subject">The subject to document.</param>
        public string GetDocumentation(HttpActionDescriptor subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }

        /// <summary>Gets the documentation for a subject.</summary>
        /// <param name="subject">The subject to document.</param>
        public string GetDocumentation(HttpParameterDescriptor subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }

        /// <summary>Gets the documentation for a subject.</summary>
        /// <param name="subject">The subject to document.</param>
        public string GetResponseDocumentation(HttpActionDescriptor subject)
        {
            return this.GetFirstMatch(p => p.GetDocumentation(subject));
        }


        /*********
        ** Private methods
        *********/
        /// <summary>Get the first valid result from the collection of XML documentation providers.</summary>
        /// <param name="expr">The method to invoke.</param>
        private string GetFirstMatch(Func<XmlDocumentationProvider, string> expr)
        {
            return this.Providers
                .Select(expr)
                .FirstOrDefault(p => !String.IsNullOrWhiteSpace(p));
        }
    }
}