using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Abstractions
{
    /// <summary>
    /// Отвечает за выбор объектов
    /// </summary>
    public interface IPlayerInput
    {
        /// <summary>
        /// Позволяет игроку выбрать один объект из списка.
        /// </summary>
        T Select<T>(List<T> options);
        /// <summary>
        /// Позволяет пользователю выбрать Да/Нет
        /// </summary>
        bool YesOrNo();
    }
}
