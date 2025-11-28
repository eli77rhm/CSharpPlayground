using System.Collections.Concurrent;

namespace ConcurrentDictionaryPlayground.Services;

public class ConcurrentAddPromoVoucherToCityService
{
    public readonly ConcurrentDictionary<string, int> voucherList = new ConcurrentDictionary<string, int>();

    public void AddVouchers(object? city)
    {
        var cityStr = city as string;
        for (int i = 0; i < 100; i++)
        {
            voucherList.AddOrUpdate(cityStr, 1, (key, oldValue) => oldValue + 1);
        }
    }

    public void Print()
    {
        foreach (var item in voucherList)
        {
            Console.WriteLine($"{item.Key}:{item.Value}");
        }
    }
}