using ScaryTales.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScaryTales.Interaction_Entities.EnvConsole
{
    /// <summary>
    /// Консольная версия выбора карты
    /// </summary>
    public class ConsolePlayerInput : IPlayerInput
    {
        public T Select<T>(List<T> options)
        {
            Console.WriteLine("Выберите один из вариантов:");
            for (int i = 0; i < options.Count; i++)
            {
                Console.WriteLine($"{i + 1}: {options[i]}");
            }

            int index;
            while (!int.TryParse(Console.ReadLine(), out index) || index < 0 || index >= options.Count)
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
            }

            return options[index - 1];
        }

        public bool YesOrNo()
        {
            Console.WriteLine("Да - 1 | Нет - 0");
            while (true)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        return true;
                    case "2":
                        return false;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}
