using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PubSub
{
    class Program
    {
        static RedisStackExchangeHelper _redis = new RedisStackExchangeHelper();
        static void Main(string[] args)
        {
            Console.WriteLine("请输入发布订阅类型?1:发布；2：订阅");
            var type = Console.ReadLine();
            if (type == "1")
            {
                Pub();
            }
            else if(type=="2")
            {
                Sub();
            }


            Console.ReadLine();
        }

        static async Task Pub()
        {
            Console.WriteLine("请输入要发布向哪个通道？");
            var channel = Console.ReadLine();

            await Task.Delay(10);
            for(int i = 0; i < 10; i++)
            {
                await _redis.PublishAsync(channel, i.ToString());
            }
                
        }

        static async Task Sub()
        {
            Console.WriteLine("请输入您要订阅哪个通道的信息？");
            var channelKey = Console.ReadLine();
            await _redis.SubscribeAsync(channelKey, (channel, message) =>
            {
                Console.WriteLine("接受到发布的内容为：" + message);
            });
            Console.WriteLine("您订阅的通道为：<< " + channelKey + " >> ! 请耐心等待消息的到来！！");
        }
    }
}
