using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartClient.Core.Services
{
    public interface IDialogService : IService
    {
        /// <summary>
        /// Спросить подтверждения пользователя
        /// </summary>
        /// <param name="text"></param>
        /// <param name="caption"></param>
        /// <param name="cancelable"></param>
        /// <returns></returns>
        bool? Ask(string text, string caption = "Вопрос", bool cancelable = false);

        /// <summary>
        /// Выбрать директорию
        /// </summary>
        /// <param name="defaultPath"></param>
        /// <returns></returns>
        string FolderBrowser(string defaultPath);

        /// <summary>
        /// Выбрать файл
        /// </summary>
        /// <param name="defaultPath"></param>
        /// <param name="filter"></param>
        /// <returns></returns>
        string OpenFile(string defaultPath, string filter = null);

        string SaveFile(string defaultPath, string filter = null);
    }
}
