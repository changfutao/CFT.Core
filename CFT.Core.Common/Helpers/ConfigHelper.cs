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
        public IConfiguration Load(string fileName, string extension, string environmentName = "", bool reloadOnChange = false)
        {
            var filePath = Path.Combine(AppContext.BaseDirectory, "configs");
            if (!Directory.Exists(filePath))
            {
                return null;
            }
            var configurationBuilder = new ConfigurationBuilder()
                                           .SetBasePath(filePath);
            switch (extension)
            {
                case ".xml":
                    configurationBuilder = configurationBuilder.AddXmlFile(path: $"{fileName.ToLower()}{extension}", optional: true, reloadOnChange: reloadOnChange);
                    if (!string.IsNullOrWhiteSpace(environmentName))
                    {
                        configurationBuilder = configurationBuilder.AddXmlFile(path: $"{fileName.ToLower()}.{environmentName}{extension}", optional: true, reloadOnChange: reloadOnChange);
                    }
                    break;
                case ".json":
                    configurationBuilder = configurationBuilder.AddJsonFile(path: $"{fileName.ToLower()}{extension}", optional: true, reloadOnChange: reloadOnChange);
                    if (!string.IsNullOrWhiteSpace(environmentName))
                    {
                        configurationBuilder = configurationBuilder.AddJsonFile(path: $"{fileName.ToLower()}.{environmentName}{extension}", optional: true, reloadOnChange: reloadOnChange);
                    }
                    break;
                default:
                    break;
            }
            return configurationBuilder.Build();
        }

        /// <summary>
        /// 获得配置信息
        /// </summary>
        /// <typeparam name="T">配置信息</typeparam>
        /// <param name="fileName">文件名称</param>
        /// <param name="extension">后缀名</param>
        /// <param name="environmentName">环境名称</param>
        /// <param name="reloadOnChange">自动更新</param>
        /// <returns></returns>
        public T Get<T>(string fileName, string extension, string environmentName = "", bool reloadOnChange = false)
        {
            var configuration = Load(fileName, extension, environmentName, reloadOnChange);
            if(configuration == null)
            {
                return default(T);
            }
            return configuration.Get<T>();
        }

        /// <summary>
        /// 绑定实例配置信息
        /// </summary>
        /// <param name="fileName">文件名称</param>
        /// <param name="instance">实例配置</param>
        /// <param name="extension">后缀名</param>
        /// <param name="environmentName">环境名称</param>
        /// <param name="reloadOnChange">自动更新</param>
        public void Bind(string fileName, object instance,string extension, string environmentName = "", bool reloadOnChange = false)
        {
             var configuration = Load(fileName, extension, environmentName, reloadOnChange);
            if (configuration == null || instance == null)
                return;
            configuration.Bind(instance);
        }
    }
}
