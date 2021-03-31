﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    /// <summary>
    /// Тариф
    /// </summary>
    public class Tariff
    {
        /// <summary>
        /// Идентификатор услуги
        /// </summary>
        public int ServiceId { get; set; }

        /// <summary>
        /// Идентификатор дома
        /// </summary>
        public int HouseId { get; set; }

        /// <summary>
        /// Месяц начала действия периода тарифа
        /// </summary>
        public DateTime PeriodBegin { get; set; }

        /// <summary>
        /// Месяц конец действия периода тарифа
        /// </summary>
        public DateTime PeriodEnd { get; set; }


        /// <summary>
        /// Значение тарифа
        /// </summary>
        public decimal Value { get; set; }
    }
}
