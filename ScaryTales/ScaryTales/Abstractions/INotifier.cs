using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Abstractions
{
    /// <summary>
    /// Интерфейс уведомлений (для отображения информации игрокам)
    /// </summary>
    public interface INotifier
    {
        void Notify(string message);
    }
}
