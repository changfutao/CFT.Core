using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CFT.Core.Common
{
    /// <summary>
    /// 配置帮助类
    /// </summary>
    public class ConfigHelper
    {
        /// <summary>
        /// 加载配置文件
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="extension">后缀名</param>
        /// <param name="environmentName">环境名称</param>
        /// <param name="reloadOnChange">自动更新</param>
        /// <returns></returns>
        public IConfiguration Load(string fileName,string extension, string environmentName = "", bool reloadOnChange = false)
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "configs");
            if (!Directory.Exists(filePath))
            {
                return null;
            }
            var configurationBuilder = new ConfigurationBuilder()
                                           .SetBasePath(filePath);
            string _environmentName = string.Empty;
            if(!string.IsNullOrWhiteSpace(environmentName))
            {
                _environmentName = $".{environmentName}";
            }
            switch (extension)
            {
                case ".xml":
                    configurationBuilder = configurationBuilder.AddXmlFile(path: $"{fileName.ToLower()}{_environmentName}{extension}", optional: true, reloadOnChange: reloadOnChange);
                    break;
                case ".json":
                    configurationBuilder = configurationBuilder.AddJsonFile(path: $"{fileName.ToLower()}{_environmentName}{extension}", optional: true, reloadOnChange: reloadOnChange);
                    break;
                default:
                    break;
            }
            var configuration = configurationBuilder.Build();

        }
    }
}
