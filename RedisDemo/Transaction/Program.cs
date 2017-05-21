using Common;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Transaction
{
    class Program
    {
        static RedisStackExchangeHelper _redis = new RedisStackExchangeHelper();
        static void Main(string[] args)
        {
            Tran();
            Console.ReadLine();
        }
        static void Tran()
        {
            var tran = _redis.CreateTransaction();
             tran.StringSetAsync("test1", "xiaopotian");
             tran.StringSetAsync("test2", "xiaopangu");
            var commit = tran.ExecuteAsync();
            Console.WriteLine(commit);
        }
    }
}
