using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Abstractions
{
    /// <summary>
    /// Интерфейс логирования событий игры (для отладки)
    /// </summary>
    public interface ILogger
    {
        void Log(string message);
    }
}
