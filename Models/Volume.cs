﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    /// <summary>
    /// Объём
    /// </summary>
    public class Volume
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
        /// Месяц начисления
        /// </summary>
        public DateTime Month { get; set; }

        /// <summary>
        /// Значение объёма
        /// </summary>
        public decimal Value { get; set; }
    }
}
