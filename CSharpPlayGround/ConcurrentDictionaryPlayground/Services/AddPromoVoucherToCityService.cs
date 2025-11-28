namespace ConcurrentDictionaryPlayground.Services;

public class AddPromoVoucherToCityService
{
    public readonly Dictionary<string, int> voucherList = new Dictionary<string, int>();
    public void AddVouchers(object? city) {  
        var cityStr = city as string;
        lock (voucherList)
        {
            for (int i = 0; i < 100; i++)
            {
                if (!voucherList.ContainsKey(cityStr))
                    voucherList[cityStr] = 0;
                voucherList[cityStr] += 1;
            }
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