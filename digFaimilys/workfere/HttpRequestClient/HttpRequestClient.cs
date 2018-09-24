﻿using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace workfere.HttpRequestClient
{
 
    
        //zetee
        //不能Host、Connection、User-Agent、Referer、Range、Content-Type、Content-Length、Expect、Proxy-Connection、If-Modified-Since
        //等header. 这些header都是通过属性来设置的 。
        public class HttpRequestClient
        {
            static HashSet<String> UNCHANGEHEADS = new HashSet<string>();
            static HttpRequestClient()
            {
                UNCHANGEHEADS.Add("Host");
                UNCHANGEHEADS.Add("Connection");
                UNCHANGEHEADS.Add("User-Agent");
                UNCHANGEHEADS.Add("Referer");
                UNCHANGEHEADS.Add("Range");
                UNCHANGEHEADS.Add("Content-Type");
                UNCHANGEHEADS.Add("Content-Length");
                UNCHANGEHEADS.Add("Expect");
                UNCHANGEHEADS.Add("Proxy-Connection");
                UNCHANGEHEADS.Add("If-Modified-Since");
                UNCHANGEHEADS.Add("Keep-alive");
                UNCHANGEHEADS.Add("Accept");

                ServicePointManager.DefaultConnectionLimit = 10000;//最大连接数

            }

            /// <summary>
            /// 默认的头
            /// </summary>
            public static string defaultHeaders = @"Accept:text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,*/*;q=0.8
Accept-Encoding:gzip, deflate, sdch
Accept-Language:zh-CN,zh;q=0.8
Cache-Control:no-cache
Connection:keep-alive
Pragma:no-cache
Upgrade-Insecure-Requests:1
User-Agent:Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/45.0.2454.101 Safari/537.36";

            /// <summary>
            /// 是否跟踪cookies
            /// </summary>
            bool isTrackCookies = false;
            /// <summary>
            /// cookies 字典
            /// </summary>
            Dictionary<String, Cookie> cookieDic = new Dictionary<string, Cookie>();

            /// <summary>
            /// 平均相应时间
            /// </summary>
            long avgResponseMilliseconds = -1;

            /// <summary>
            /// 平均相应时间
            /// </summary>
            public long AvgResponseMilliseconds
            {
                get
                {
                    return avgResponseMilliseconds;
                }

                set
                {
                    if (avgResponseMilliseconds != -1)
                    {
                        avgResponseMilliseconds = value + avgResponseMilliseconds / 2;
                    }
                    else
                    {
                        avgResponseMilliseconds = value;
                    }

                }
            }

            public HttpRequestClient(bool isTrackCookies = false)
            {
                this.isTrackCookies = isTrackCookies;
            }
            /// <summary>
            /// http请求
            /// </summary>
            /// <param name="url"></param>
            /// <param name="method">POST,GET</param>
            /// <param name="headers">http的头部,直接拷贝谷歌请求的头部即可</param>
            /// <param name="content">content,每个key,value 都要UrlEncode才行</param>
            /// <param name="contentEncode">content的编码</param>
            /// <param name="proxyUrl">代理url</param>
            /// <returns></returns>
            public string http(string url, string method, string headers, string content, Encoding contentEncode, string proxyUrl)
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = method;
                if (method.Equals("GET", StringComparison.InvariantCultureIgnoreCase))
                {
                    request.MaximumAutomaticRedirections = 100;
                    request.AllowAutoRedirect = false;
                }

                fillHeaders(request, headers);
                fillProxy(request, proxyUrl);

                #region 添加Post 参数  
                if (contentEncode == null)
                {
                    contentEncode = Encoding.UTF8;
                }
                if (!string.IsNullOrWhiteSpace(content))
                {
                    byte[] data = contentEncode.GetBytes(content);
                    request.ContentLength = data.Length;
                    using (Stream reqStream = request.GetRequestStream())
                    {
                        reqStream.Write(data, 0, data.Length);
                        reqStream.Close();
                    }
                }
                #endregion

                HttpWebResponse response = null;
                System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                try
                {
                    sw.Start();
                    response = (HttpWebResponse)request.GetResponse();
                    sw.Stop();
                    AvgResponseMilliseconds = sw.ElapsedMilliseconds;
                    CookieCollection cc = new CookieCollection();
                    string cookieString = response.Headers[HttpResponseHeader.SetCookie];
                    if (!string.IsNullOrWhiteSpace(cookieString))
                    {
                        var spilit = cookieString.Split(';');
                        foreach (string item in spilit)
                        {
                            var kv = item.Split('=');
                            if (kv.Length == 2)
                                cc.Add(new Cookie(kv[0].Trim(), kv[1].Trim()));
                        }
                    }
                    trackCookies(cc);
                }
                catch (Exception ex)
                {
                    sw.Stop();
                    AvgResponseMilliseconds = sw.ElapsedMilliseconds;
                    return "";
                }

                string result = getResponseBody(response);
                return result;
            }

            /// <summary>
            /// post 请求
            /// </summary>
            /// <param name="url"></param>
            /// <param name="headers"></param>
            /// <param name="content"></param>
            /// <param name="contentEncode"></param>
            /// <param name="proxyUrl"></param>
            /// <returns></returns>
            public string httpPost(string url, string headers, string content, Encoding contentEncode, string proxyUrl = null)
            {
                return http(url, "POST", headers, content, contentEncode, proxyUrl);
            }

            /// <summary>
            /// get 请求
            /// </summary>
            /// <param name="url"></param>
            /// <param name="headers"></param>
            /// <param name="content"></param>
            /// <param name="proxyUrl"></param>
            /// <returns></returns>
            public string httpGet(string url, string headers, string content = null, string proxyUrl = null)
            {
                return http(url, "GET", headers, null, null, proxyUrl);
            }

            /// <summary>
            /// 填充代理
            /// </summary>
            /// <param name="proxyUri"></param>
            private void fillProxy(HttpWebRequest request, string proxyUri)
            {
                if (!string.IsNullOrWhiteSpace(proxyUri))
                {
                    WebProxy proxy = new WebProxy();
                    proxy.Address = new Uri(proxyUri);
                    request.Proxy = proxy;
                }
            }


            /// <summary>
            /// 跟踪cookies
            /// </summary>
            /// <param name="cookies"></param>
            private void trackCookies(CookieCollection cookies)
            {
                if (!isTrackCookies) return;
                if (cookies == null) return;
                foreach (Cookie c in cookies)
                {
                    if (cookieDic.ContainsKey(c.Name))
                    {
                        cookieDic[c.Name] = c;
                    }
                    else
                    {
                        cookieDic.Add(c.Name, c);
                    }
                }

            }

            /// <summary>
            /// 格式cookies
            /// </summary>
            /// <param name="cookies"></param>
            private string getCookieStr()
            {
                StringBuilder sb = new StringBuilder();
                foreach (KeyValuePair<string, Cookie> item in cookieDic)
                {
                    if (!item.Value.Expired)
                    {
                        if (sb.Length == 0)
                        {
                            sb.Append(item.Key).Append("=").Append(item.Value.Value);
                        }
                        else
                        {
                            sb.Append("; ").Append(item.Key).Append(" = ").Append(item.Value.Value);
                        }
                    }
                }
                return sb.ToString();

            }

            /// <summary>
            /// 填充头
            /// </summary>
            /// <param name="request"></param>
            /// <param name="headers"></param>
            private void fillHeaders(HttpWebRequest request, string headers, bool isPrint = false)
            {
                if (request == null) return;
                if (string.IsNullOrWhiteSpace(headers)) return;
                string[] hsplit = headers.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string item in hsplit)
                {
                    string[] kv = item.Split(':');
                    string key = kv[0].Trim();
                    string value = string.Join(":", kv.Skip(1)).Trim();
                    if (!UNCHANGEHEADS.Contains(key))
                    {
                        request.Headers.Add(key, value);
                    }
                    else
                    {
                        #region  设置http头
                        switch (key)
                        {

                            case "Accept":
                                {
                                    request.Accept = value;
                                    break;
                                }
                            case "Host":
                                {
                                    request.Host = value;
                                    break;
                                }
                            case "Connection":
                                {
                                    if (value == "keep-alive")
                                    {
                                        request.KeepAlive = true;
                                    }
                                    else
                                    {
                                        request.KeepAlive = false;//just test
                                    }
                                    break;
                                }
                            case "Content-Type":
                                {
                                    request.ContentType = value;
                                    break;
                                }

                            case "User-Agent":
                                {
                                    request.UserAgent = value;
                                    break;
                                }
                            case "Referer":
                                {
                                    request.Referer = value;
                                    break;
                                }

                            case "Content-Length":
                                {
                                    request.ContentLength = Convert.ToInt64(value);
                                    break;
                                }
                            case "Expect":
                                {
                                    request.Expect = value;
                                    break;
                                }
                            case "If-Modified-Since":
                                {
                                    request.IfModifiedSince = Convert.ToDateTime(value);
                                    break;
                                }
                            default:
                                break;
                        }
                        #endregion
                    }
                }
                CookieCollection cc = new CookieCollection();
                string cookieString = request.Headers[HttpRequestHeader.Cookie];
                if (!string.IsNullOrWhiteSpace(cookieString))
                {
                    var spilit = cookieString.Split(';');
                    foreach (string item in spilit)
                    {
                        var kv = item.Split('=');
                        if (kv.Length == 2)
                            cc.Add(new Cookie(kv[0].Trim(), kv[1].Trim()));
                    }
                }
                trackCookies(cc);
                if (!isTrackCookies)
                {
                    request.Headers[HttpRequestHeader.Cookie] = "";
                }
                else
                {
                    request.Headers[HttpRequestHeader.Cookie] = getCookieStr();
                }

                #region 打印头
                if (isPrint)
                {
                    for (int i = 0; i < request.Headers.AllKeys.Length; i++)
                    {
                        string key = request.Headers.AllKeys[i];
                        System.Console.WriteLine(key + ":" + request.Headers[key]);
                    }
                }
                #endregion

            }


            /// <summary>
            /// 打印ResponseHeaders
            /// </summary>
            /// <param name="response"></param>
            private void printResponseHeaders(HttpWebResponse response)
            {
                #region 打印头
                if (response == null) return;
                for (int i = 0; i < response.Headers.AllKeys.Length; i++)
                {
                    string key = response.Headers.AllKeys[i];
                    System.Console.WriteLine(key + ":" + response.Headers[key]);
                }
                #endregion
            }


            /// <summary>
            /// 返回body内容
            /// </summary>
            /// <param name="response"></param>
            /// <returns></returns>
            private string getResponseBody(HttpWebResponse response)
            {
                Encoding defaultEncode = Encoding.UTF8;
                string contentType = response.ContentType;
                if (contentType != null)
                {
                    if (contentType.ToLower().Contains("gb2312"))
                    {
                        defaultEncode = Encoding.GetEncoding("gb2312");
                    }
                    else if (contentType.ToLower().Contains("gbk"))
                    {
                        defaultEncode = Encoding.GetEncoding("gbk");
                    }
                    else if (contentType.ToLower().Contains("zh-cn"))
                    {
                        defaultEncode = Encoding.GetEncoding("zh-cn");
                    }
                }

                string responseBody = string.Empty;
                if (response.ContentEncoding.ToLower().Contains("gzip"))
                {
                    using (GZipStream stream = new GZipStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream))
                        {
                            responseBody = reader.ReadToEnd();
                        }
                    }
                }
                else if (response.ContentEncoding.ToLower().Contains("deflate"))
                {
                    using (DeflateStream stream = new DeflateStream(response.GetResponseStream(), CompressionMode.Decompress))
                    {
                        using (StreamReader reader = new StreamReader(stream, defaultEncode))
                        {
                            responseBody = reader.ReadToEnd();
                        }
                    }
                }
                else
                {
                    using (Stream stream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(stream, defaultEncode))
                        {
                            responseBody = reader.ReadToEnd();
                        }
                    }
                }
                return responseBody;
            }


            public static string UrlEncode(string item, Encoding code)
            {
                return System.Web.HttpUtility.UrlEncode(item.Trim('\t').Trim(), Encoding.GetEncoding("gb2312"));
            }

            public static string UrlEncodeByGB2312(string item)
            {
                return UrlEncode(item, Encoding.GetEncoding("gb2312"));
            }


            public static string UrlEncodeByUTF8(string item)
            {
                return UrlEncode(item, Encoding.GetEncoding("utf-8"));
            }

            public static string HtmlDecode(string item)
            {
                return WebUtility.HtmlDecode(item.Trim('\t').Trim());
            }

        }
    }

