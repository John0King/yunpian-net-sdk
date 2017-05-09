using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Xunit;
using Yunpian.conf;
using Yunpian.lib;

namespace YunpianSDKTest
{
    public class SmsSendTest
    {
        private IConfigurationRoot Configration { get; }
        private Config YunConfig { get; }
        public SmsSendTest()
        {
            var configBuilder = new ConfigurationBuilder();
            configBuilder.AddEnvironmentVariables();
            Configration = configBuilder.Build();
            YunConfig = new Config(Configration["YunPian-AppKey"]);
        }

        [Fact]
        public void SingleTest()
        {
            var client = new SmsOperator(YunConfig);
            var result = client.SingleSend("15194118449", "【钜学教育】您的验证码是：123456");
            Assert.True(result.success);
        }
    }
}
