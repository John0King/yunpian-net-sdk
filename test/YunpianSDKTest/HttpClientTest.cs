using System;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net;

namespace YunpianSDKTest
{
    ///// <summary>
    ///// �ò��ԣ�����HttpClient �Ĵ�����Ϊ�Ƿ�� webRequest һ��,
    ///// <para>���ۣ� httpclient �����webrequest һ����ʧ�ܲ�������webExpection</para>
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
