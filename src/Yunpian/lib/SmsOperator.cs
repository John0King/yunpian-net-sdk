using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Yunpian.conf;
using Yunpian.model;
using System.Net;

namespace Yunpian.lib
{
    /// <summary>
    /// 短信发送Api
    /// </summary>
    public class SmsOperator : AbstractOperator
    {
        public SmsOperator(Config config) : base(config)
        {
        }
        [Obsolete]
        public Result singleSend(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_send_single_sms, parms);
        }
        /// <summary>
        /// 单条短信发送
        /// </summary>
        /// <param name="mobile">号码</param>
        /// <param name="text">短信内容</param>
        /// <returns></returns>
        public Result SingleSend(string mobile,string text)
        {
            if(mobile == null)
            {
                throw new ArgumentNullException(nameof(mobile));
            }
            if(text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            var dic = new Dictionary<string, string>();
            dic.Add("apikey", config.apikey);
            dic.Add("mobile", mobile);
            dic.Add("text", text);
            return HttpUtil.HttpPost(Config.url_send_single_sms, dic);

        }
        [Obsolete]
        public Result batchSend(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_send_batch_sms, parms);
        }
        /// <summary>
        /// 批量发送相同的短信
        /// </summary>
        /// <param name="mobiles"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public Result BatchSend(IEnumerable<string> mobiles,string text)
        {
            return BatchSend(string.Join(",", mobiles), text);
        }
        /// <summary>
        /// 批量发送相同的短信
        /// </summary>
        /// <param name="mobiles"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public Result BatchSend(string mobiles,string text)
        {
            if (mobiles == null)
            {
                throw new ArgumentNullException(nameof(mobiles));
            }
            if (text == null)
            {
                throw new ArgumentNullException(nameof(text));
            }
            var dic = new Dictionary<string, string>();
            dic.Add("apikey", config.apikey);
            dic.Add("mobile", mobiles);
            dic.Add("text", text);
            return HttpUtil.HttpPost(Config.url_send_batch_sms, dic);
        }

        
        [Obsolete]
        public Result multiSend(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            string text = parms["text"];
            string[] textArr = text.Split(',');
            StringBuilder sb = new StringBuilder();
            foreach (var s in textArr)
            {
                if (sb.Length != 0)
                    sb.Append(",");
                sb.Append(WebUtility.UrlEncode(s));
            }
            parms["text"] = sb.ToString();
            return HttpUtil.HttpPost(Config.url_send_multi_sms, parms);
        }
        /// <summary>
        /// 批量发送内容不一样的短信
        /// </summary>
        /// <param name="mobileTextPair">号码-短信对</param>
        /// <returns></returns>
        public Result MultiSend(IEnumerable<KeyValuePair<string, string>> mobileTextPair)
        {
            if (mobileTextPair == null)
            {
                throw new ArgumentNullException(nameof(mobileTextPair));
            }
            var mobileStr = string.Join(",", mobileTextPair.Select(p => p.Key));
            var textStr = string.Join(",", mobileTextPair.Select(p => WebUtility.UrlEncode(p.Value)));
            var dic = new Dictionary<string, string>();
            dic.Add("apikey", config.apikey);
            dic.Add("mobile", mobileStr);
            dic.Add("text", textStr);
            return HttpUtil.HttpPost(Config.url_send_multi_sms, dic);
        }
        /// <summary>
        /// 批量发送内容不一样的短信
        /// </summary>
        /// <param name="mobiles">多个号码</param>
        /// <param name="texts">多个短信，个数必须与号码一致</param>
        /// <returns></returns>
        public Result MultiSend(IEnumerable<string> mobiles,IEnumerable<string> texts)
        {
            if (mobiles.Count() != texts.Count())
            {
                throw new ArgumentException("电话号码跟短信个数一样");
            }
            var list = new List<KeyValuePair<string, string>>();
            for(var i = 0;i<mobiles.Count(); i++)
            {
                list.Add(new KeyValuePair<string, string>(mobiles.ElementAt(i), texts.ElementAt(i)));
            }
            return MultiSend(list);
        }
        public Result tplSingleSend(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_send_tpl_single_sms, parms);
        }
        public Result tplBatchSend(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_send_tpl_batch_sms, parms);
        }
    }
}
