using System;

namespace Events
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new SubsidyCalculation();
            a.CalculateSubsidy(new Volume { Value=34,HouseId=2,ServiceId=3,Month= new DateTime(2021, 2, 12) },new Tariff { Value=45,HouseId=2,ServiceId=3,PeriodBegin=new DateTime(2021,4,12),PeriodEnd= new DateTime(2021, 5, 12) });
        }
    }
}
