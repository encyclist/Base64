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
            string decodeStr = Base64Decode(first);
            string encodeStr = Base64Encode(first);

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

        // 编码
        public String Base64Encode(string str)
        {
            try
            {
                byte[] bytes = Encoding.Default.GetBytes(str);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // 解码
        public String Base64Decode(string str)
        {
            try
            {
                byte[] outputb = Convert.FromBase64String(str);
                string orgStr = Encoding.Default.GetString(outputb);
                return orgStr;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
