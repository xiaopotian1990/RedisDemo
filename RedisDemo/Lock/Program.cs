using Common;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lock
{
    class Program
    {
        static RedisStackExchangeHelper _redis = new RedisStackExchangeHelper();
        static void Main(string[] args)
        {
            Lock();
           
        }

        static void Lock()
        {
            Console.WriteLine("Start..........");
            var db = _redis.GetDatabase();
            RedisValue token = Environment.MachineName;
            //实际项目秒杀此处可换成商品ID
            if (db.LockTake("test", token, TimeSpan.FromSeconds(10)))
            {
                try
                {
                    Console.WriteLine("Working..........");
                    Thread.Sleep(5000);
                }
                finally
                {
                    db.LockRelease("test", token);
                }
            }

            Console.WriteLine("Over..........");
        }
    }
}
