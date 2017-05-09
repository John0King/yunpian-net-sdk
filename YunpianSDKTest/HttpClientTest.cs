using System;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace YunpianSDKTest
{
    ///// <summary>
    ///// 该测试，测试HttpClient 的错误行为是否跟 webRequest 一样,
    ///// <para>结论： httpclient 不会跟webrequest 一样，失败不会引发webExpection</para>
    ///// </summary>
    //public class HttpClientTest
    //{

    //    [Fact]
    //    public async Task FailTest()
    //    {
    //        using (var client = new HttpClient())
    //        {
    //            using (var response = await client.PostAsync("http://www.juxueedu.com/aaaaa", null))
    //            {
    //                Assert.False(response.IsSuccessStatusCode);
    //                Assert.True(response.StatusCode == System.Net.HttpStatusCode.NotFound);
    //            }
    //            using (var response = await client.PostAsync("http://www.juxueedu.com/Api/PingLun/Add.ashx", null))
    //            {
    //                Assert.False(response.IsSuccessStatusCode);
    //                Assert.True(response.StatusCode == System.Net.HttpStatusCode.Unauthorized);
    //            }
    //        }
    //    }
    //    [Fact]
    //    public async Task WebRequestTest()
    //    {
    //        bool hasException = false;
    //        try
    //        {
    //            var request = HttpWebRequest.CreateHttp("http://www.juxueedu.com/aaaaa");
    //            var response = (HttpWebResponse)await request.GetResponseAsync();
    //        }
    //        catch (WebException e)
    //        {
    //            hasException = true;
    //            var res = (HttpWebResponse)e.Response;
    //            Assert.Equal(res.StatusCode, HttpStatusCode.NotFound);
    //        }

    //        Assert.True(hasException);

    //    }
    //}

}
