using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Wox.Plugin;

namespace Base64
{
    public class Class1 : IPlugin
    {
        public void Init(PluginInitContext context)
        {
        }

        public List<Result> Query(Query query)
        {
            string first = query.FirstSearch;
            string decodeStr = DecodeBase64(first);
            string encodeStr = EncodeBase64(first);

            List<Result> list = new List<Result>();

            if (decodeStr != null && decodeStr.Length > 0)
            {
                list.Add(
                    new Result()
                    {
                        Title = "   " + decodeStr,
                        SubTitle = "    Enter to copy the decode result",
                        IcoPath = "img/icon.png",  //相对于插件目录的相对路径
                        Action = e =>
                        {
                            // 处理用户选择之后的操作
                            Clipboard.SetText(decodeStr);
                            //返回false告诉Wox不要隐藏查询窗体，返回true则会自动隐藏Wox查询窗口
                            return true;
                        }
                    }
                );
            }
            if (encodeStr != null && encodeStr.Length > 0)
            {
                list.Add(
                    new Result()
                    {
                        Title = "   " + encodeStr,
                        SubTitle = "    Enter to copy the encode result",
                        IcoPath = "img/icon.png",  //相对于插件目录的相对路径
                        Action = e =>
                        {
                            // 处理用户选择之后的操作
                            Clipboard.SetText(encodeStr);
                            //返回false告诉Wox不要隐藏查询窗体，返回true则会自动隐藏Wox查询窗口
                            return true;
                        }
                    }
                );
            }


            return list;
        }

        /// <summary>
        /// Base64加密，采用utf8编码方式加密
        /// </summary>
        /// <param name="source">待加密的明文</param>
        /// <returns>加密后的字符串</returns>
        public static string EncodeBase64(string source)
        {
            return EncodeBase64(Encoding.UTF8, source);
        }

        /// <summary>
        /// Base64加密
        /// </summary>
        /// <param name="codeName">加密采用的编码方式</param>
        /// <param name="source">待加密的明文</param>
        /// <returns></returns>
        public static string EncodeBase64(Encoding encode, string source)
        {
            byte[] bytes = encode.GetBytes(source);
            string decode;
            try
            {
                decode = Convert.ToBase64String(bytes);
            }
            catch
            {
                decode = "";
            }
            return decode;
        }

        /// <summary>
        /// Base64解密，采用utf8编码方式解密
        /// </summary>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(string result)
        {
            return DecodeBase64(Encoding.UTF8, result);
        }
        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="codeName">解密采用的编码方式，注意和加密时采用的方式一致</param>
        /// <param name="result">待解密的密文</param>
        /// <returns>解密后的字符串</returns>
        public static string DecodeBase64(Encoding encode, string result)
        {
            byte[] bytes = Convert.FromBase64String(result);
            string decode;
            try
            {
                decode = encode.GetString(bytes);
            }
            catch
            {
                decode = "";
            }
            return decode;
        }
    }
}
