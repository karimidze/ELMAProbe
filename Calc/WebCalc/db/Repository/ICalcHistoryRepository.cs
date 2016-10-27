using System.Collections.Generic;
using WebCalc.db.Models;

namespace WebCalc.db.Repository
{
    interface ICalcHistoryRepository
    {
        /// <summary>
        /// Получить список событий
        /// </summary>
        /// <returns></returns>
        IEnumerable<CalcHistory> GetList();
        
        /// <summary>
        /// Добавляет событие в историю
        /// </summary>
        /// <param name="">Событие</param>
        void Add(CalcHistory item);

        /// <summary>
        /// Найти события по заданной операции
        /// </summary>
        /// <param name="operation">Операция</param>
        /// <returns>Список событий</returns>
        IEnumerable<CalcHistory> Find(string operation);
    }
}
