using System.Text;
using System.IO;
using System.Web;

namespace HLT.Core.Helper
{
    public class FileHelper
    {
        /// <summary>
        /// 检测文件是否存在
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static bool ExistFile(string fullName)
        {
            return File.Exists(fullName);
        }
        /// <summary>
        /// 文件夹是否存在
        /// </summary>
        /// <param name="fullPath"></param>
        /// <returns></returns>
        public static bool ExistDir(string fullPath)
        {
            return Directory.Exists(fullPath);
        }
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static bool CreateFile(string fullName, string content)
        {
            bool result = false;
            FileInfo Finfo = new FileInfo(fullName);
            CreateDir(Finfo.DirectoryName);
            StreamWriter sw = new StreamWriter(fullName, false, Encoding.UTF8);
            try
            {
                sw.Write(content);
                result = true;
            }
            catch { }
            finally
            {
                sw.Flush();
                sw.Close();
                sw.Dispose();
            }
            return result;
        }
        /// <summary>
        /// 读取文件
        /// </summary>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public static string ReadFile(string fullName)
        {
            string content = string.Empty;
            StreamReader sr = null;
            if (ExistFile(fullName))
            {
                sr = new StreamReader(fullName, Encoding.UTF8);
                content = sr.ReadToEnd();
            }
            if (sr != null)
            {
                sr.Close();
                sr.Dispose();
            }
            return content;
        }

        /// <summary>
        /// 创建文件夹
        /// </summary>
        /// <param name="DirFullPath"></param>
        public static void CreateDir(string DirFullPath)
        {
            if (string.IsNullOrEmpty(DirFullPath)) return;
            if (!ExistDir(DirFullPath))
            {
                Directory.CreateDirectory(DirFullPath);
            }
        }

        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="fullName"></param>
        public static void RemoveFile(string fullName)
        {
            if (string.IsNullOrEmpty(fullName)) return;
            if (ExistFile(fullName))
            {
                File.Delete(fullName);
            }
        }
        /// <summary>
        /// 删除文件夹
        /// </summary>
        /// <param name="DirFullPath"></param>
        public static void RemoveDir(string DirFullPath)
        {
            if (string.IsNullOrEmpty(DirFullPath)) return;
            if (ExistDir(DirFullPath))
            {
                if (new DirectoryInfo(DirFullPath).GetFiles().Length <= 0)
                {
                    Directory.Delete(DirFullPath);
                }
            }
        }
        /// <summary>
        /// 删除文件夹（同时会删除文件夹内的所有文件）
        /// </summary>
        /// <param name="DirFullPath"></param>
        public static void RemoveDirWithFiles(string DirFullPath)
        {
            if (string.IsNullOrEmpty(DirFullPath)) return;
            if (ExistDir(DirFullPath))
            {
                FileInfo[] files = new DirectoryInfo(DirFullPath).GetFiles();
                foreach (FileInfo f in files)
                {
                    File.Delete(f.FullName);
                }
            }
        }
        /// <summary>
        /// 文件拷贝
        /// </summary>
        /// <param name="FileFullPath"></param>
        /// <param name="toFileFullPath"></param>
        public static void Copy(string sourceFileFullPath, string toFileFullPath)
        {
            FileInfo toFile = new FileInfo(toFileFullPath);
            CreateDir(toFile.DirectoryName);
            if (ExistFile(sourceFileFullPath))
            {
                File.Copy(sourceFileFullPath, toFileFullPath, true);
            }
        }
        /// <summary>
        /// 将磁盘文件二进制输出
        /// </summary>
        /// <param name="file"></param>
        public static void Response(string file)
        {
            HttpResponse response = System.Web.HttpContext.Current.Response;
            if (!FileHelper.ExistFile(file))
            {
                response.StatusCode = 404;
                response.StatusDescription = "您要下载的文件已经删除或者不存在！";
                response.Write("您要下载的文件已经删除或者不存在！");
                response.End();
                return;
            }
            string name = Path.GetFileName(file);
            name = name.Substring(0, name.LastIndexOf(".") + 1);
            string exten = Path.GetExtension(file);

            response.Clear();
            response.ContentType = "application/octet-stream";
            response.AddHeader("Content-Disposition", string.Format("attachment; filename=" + HttpUtility.UrlEncode(name) + exten));

            FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            long total = fs.Length;
            byte[] buffer = new byte[1024];
            while (response.IsClientConnected)
            {
                if (total > 0)
                {
                    int length = fs.Read(buffer, 0, buffer.Length);
                    response.OutputStream.Write(buffer, 0, length);
                    response.Flush();
                    buffer = new byte[1024];
                    total -= length;
                }
                else
                {
                    break;
                }
            }
            response.Flush();
            response.End();
        }
    }
}
