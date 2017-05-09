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
            // 测试时请在测试机上设置该环境变量
            YunConfig = new Config(Configration["YunPian-AppKey"]);
        }

        [Fact]
        public void SingleTest()
        {
            var client = new SmsOperator(YunConfig);
            var result = client.SingleSend("15726102865", "【钜学教育】您的验证码是：123456");
            Assert.True(result.success);
        }
    }
}
