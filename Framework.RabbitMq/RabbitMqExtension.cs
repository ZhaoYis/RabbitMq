using System;
using System.Collections.Concurrent;
using System.Configuration;
using System.Reflection;
using System.Text;
using Newtonsoft.Json;

namespace Framework.RabbitMq
{
    public static class RabbitMqExtension
    {
        #region JSON序列化
        /// <summary>
        /// 实体对象转字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ignoreNull"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, bool ignoreNull = false)
        {
            if (obj.IsNull())
                return null;

            return JsonConvert.SerializeObject(obj, Formatting.None, new JsonSerializerSettings
            {
                DateFormatString = "yyyy-MM-dd HH:mm:ss",
                NullValueHandling = ignoreNull ? NullValueHandling.Ignore : NullValueHandling.Include
            });
        }

        /// <summary>
        /// JSON字符串转实体对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonStr"></param>
        /// <returns></returns>
        public static T FromJson<T>(this string jsonStr)
        {
            return jsonStr.IsNullOrEmpty() ? default(T) : JsonConvert.DeserializeObject<T>(jsonStr);
        }
        #endregion

        #region 字节序列
        /// <summary>
        /// 字符串序列化成字节序列
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static byte[] SerializeUtf8(this string str)
        {
            return str == null ? null : Encoding.UTF8.GetBytes(str);
        }

        /// <summary>
        /// 字节序列序列化成字符串
        /// </summary>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static string DeserializeUtf8(this byte[] stream)
        {
            return stream == null ? null : Encoding.UTF8.GetString(stream);
        }
        #endregion


        #region 读取配置文件
        
        /// <summary>
        /// 自定义配置参数
        /// </summary>
        /// <param name="inputStr"></param>
        /// <returns></returns>
        public static string ValueOfAppSetting(this string inputStr)
        {
            return ConfigurationManager.AppSettings[inputStr];
        }

        #endregion

        #region 字符串、对象空判断
        public static bool IsNullOrEmpty(this string inputStr)
        {
            return string.IsNullOrEmpty(inputStr);
        }

        public static bool IsNullOrWhiteSpace(this string inputStr)
        {
            return string.IsNullOrWhiteSpace(inputStr);
        }

        /// <summary>
        /// 对象是空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        /// <summary>
        /// 对象不为空
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private static bool IsNotNull(this object obj)
        {
            return obj != null;
        }
        #endregion

        #region 获取异常
        /// <summary>
        /// 获取异常
        /// </summary>
        public static Exception GetInnestException(this Exception ex)
        {
            var innerException = ex.InnerException;
            return innerException;
        }
        #endregion

        #region 异常文本日志
        /// <summary>
        /// 写入日志文件
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public static void WriteToFile(this Exception ex, Type type, string message)
        {
            LoggerHelper.WriteToFile(type, message, ex);
        }
        #endregion

        #region 获取特性
        /// <summary>
        /// 获取实体特性信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static T GetAttribute<T>(this Type type) where T : class
        {
            var customAttribute = type.GetCustomAttribute(typeof(T));
            if (customAttribute.IsNotNull())
                return customAttribute as T;
            return null;
        }
        #endregion
    }
}