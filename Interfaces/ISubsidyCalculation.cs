﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    /// <summary>
    /// Интерфейс расчёта субсидии
    /// </summary>
    public interface ISubsidyCalculation
    {
        /// <summary>
        /// Событие оповещения
        /// Должно вызываться перед и после расчёта (в начала и перед возвратом метода CalculateSubsidy)
        /// с текстом "Расчёт начат в ТЕКУЩЕЕВРЕМЯ" и "Расчёт успешно завершён в ТЕКУЩЕЕВРЕМЯ" соответственно
        /// </summary>
        public event EventHandler<string> OnNotify;

        /// <summary>
        /// Событие возникновения ошибки
        /// Должно вызываться при возникновении Exception
        /// Либо при неправильных входных данных
        /// </summary>
        public event EventHandler<Tuple<string, Exception>> OnException;


        /// <summary>
        /// Рассчитать субсидию на дом по указанному объёму и указанному тарифу
        /// </summary>
        /// <param name="volumes"></param>
        /// <param name="tariff"></param>
        /// <returns></returns>
        /// <remarks>
        /// Алгоритм расчёта прост - Значение субсидии = значение объёма * значение тарифа
        ///
        /// Однако, надо проверить, правильные ли данные пришли к нам на вход
        /// Например, совпадают ли идентификаторы домов и услуг у объёма и у тарифа
        /// Также, входит ли месяц объёма в период действия тарифа.
        /// Не допускается нулевых или отрицательных значений тарифа.
        /// Допускаются значения объёма равные или больше нуля.
        ///
        /// При возникновении ошибки - вызвать событие onException и пробросить ошибку дальше (throw;)
        /// При неправильных данных - вызвать событие onException пробросить новую ошибку с указанием неправильного поля (throw new Exception("ТЕСТОВОЕ СООБЩЕНИЕ");)
        /// </remarks>
        public Charge CalculateSubsidy(Volume volumes, Tariff tariff);
    }
}
