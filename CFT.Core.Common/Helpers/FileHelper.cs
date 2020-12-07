using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Core.Common.Helpers
{
    public class FileHelper : IDisposable
    {
        private bool _alreadyDispose = false;

        public FileHelper()
        {

        }

        ~FileHelper()
        {
            Dispose();
        }

        protected virtual void Dispose(bool isDisposing)
        {
            if (_alreadyDispose) return;
            _alreadyDispose = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="content">文件内容</param>
        public static void WriteFile(string path, string content)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            StreamWriter streamWriter = new StreamWriter(path: path, append: false);
            streamWriter.Write(content);
            streamWriter.Close();
            streamWriter.Dispose();
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="content">文件内容</param>
        /// <param name="encode">编码格式</param>
        public static void WriteFile(string path, string content, Encoding encode)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
            StreamWriter streamWriter = new StreamWriter(path: path, append: false, encoding: encode);
            streamWriter.Write(content);
            streamWriter.Close();
            streamWriter.Dispose();

        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <returns></returns>
        public static string ReadFile(string path)
        {
            string s;
            if(!File.Exists(path))
            {
                s = "不存在相应的目录";
            }
            else
            {
                StreamReader streamReader = new StreamReader(path);
                s = streamReader.ReadToEnd();
                streamReader.Close();
                streamReader.Dispose();
            }
            return s;
        }

        /// <summary>
        /// 读文件
        /// </summary>
        /// <param name="path">文件路径</param>
        /// <param name="encode">编码格式</param>
        /// <returns></returns>
        public static string ReadFile(string path, Encoding encode)
        {
            string s;
            if (!File.Exists(path))
                s = "不存在相应的目录";
            else
            {
                StreamReader streamReader = new StreamReader(path, encode);
                s = streamReader.ReadToEnd();
                streamReader.Close();
                streamReader.Dispose();
            }
            return s;
        }
    }
}
