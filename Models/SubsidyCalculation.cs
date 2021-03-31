using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    public class SubsidyCalculation : ISubsidyCalculation
    {
        public event EventHandler<string> OnNotify;
        public event EventHandler<Tuple<string, Exception>> OnException;

        public Charge CalculateSubsidy(Volume volumes, Tariff tariff)
        {
            Charge charge = null;
            try
            {
                try
                {
                    OnNotify?.Invoke(this, $"Расчёт начат в {DateTime.Now.ToString("G")}");
                    if (IsCorrect(volumes, tariff))
                    {
                        charge = new Charge
                        {
                            Value = volumes.Value * tariff.Value,
                            Month = volumes.Month,
                            HouseId = tariff.HouseId,
                            ServiceId = tariff.ServiceId
                        };
                    }
                    OnNotify?.Invoke(this, $"Расчёт успешно завершён в {DateTime.Now.ToString("G")}");
                }
                catch 
                {
                    OnException?.Invoke(this, new Tuple<string, Exception>("Исключение", new Exception("Возникло Исключение")));
                    throw;
                }
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
                OnException?.Invoke(this, new Tuple<string, Exception>("Исключение", e));
            }
            return charge;
        }

        private bool IsCorrect(Volume volumes, Tariff tariff) 
        {
            if (volumes == null || tariff == null) 
            {
                throw new Exception("Null Exception");
            }
            if (volumes.ServiceId != tariff.ServiceId)
            {
                throw new Exception("Поля ServiceId не совпадают");
            }
            if (volumes.HouseId != tariff.HouseId)
            {
                throw new Exception("Поля HouseId не совпадают");
            }
            if (volumes.Month< tariff.PeriodBegin|| volumes.Month> tariff.PeriodEnd)
            {
                throw new Exception("Поле volumes.Month не входит в рамки тарифа");
            }
            if (tariff.Value<=0)
            {
                throw new Exception("Поле tariff.Value не может быть меньше или равно 0");
            }
            if (volumes.Value < 0)
            {
                throw new Exception("Поле volumes.Value не может быть меньше 0");
            }
            return true;
        }
    }
}
