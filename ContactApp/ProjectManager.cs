using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace ContactsApp
{
    /// <summary>
    /// Статический класс, управляющий сохранением и загрузкой проекта.
    /// </summary>
    public static class ProjectManager
    {
        /// <summary>
        /// Сериализация
        /// </summary>
        /// <param name="data">Путь</param>
        /// <param name="project">Сериализуемый класс</param>
        public static string DocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/ContactApp.txt";


        /// <summary>
        /// Сохраняет данные в файл.
        /// </summary>
        /// <param name="contactList">Проект с данными для сохранения.</param>
        /// <param name="fileName">Имя файла для сохранения.</param>
        public static void SaveToFile(Project contactList, string fileName)
        {
            JsonSerializer serializer = new JsonSerializer();

            //Открываем поток для записи в файл с указанием пути
            using (StreamWriter sw = new StreamWriter(fileName))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                //Вызываем сериализацию и передаем объект, который хотим сериализовать
                serializer.Serialize(writer, (Project)contactList);
            }
        }

        /// <summary>
        /// Загружает данные из файла.
        /// </summary>
        /// <param name="filename">Имя файла для загрузки.</param>
        /// <returns>Загруженные данные.</returns>
        public static Project LoadFromFile(string fileName)
        {
            Project contact = new Project();
            //Создаём экземпляр сериализатора.
            JsonSerializer serializer = new JsonSerializer();
            //Открываем поток для чтения из файла с указанием пути.
            using (StreamReader sr = new StreamReader(fileName))
            using (JsonReader reader = new JsonTextReader(sr))
            {
                //Вызываем десериализацию и явно преобразуем результат в целевой тип данных.
                var contactList = serializer.Deserialize<Project>(reader);
                contact = contactList;
            }

            return contact;
        }

        /// <summary>
        /// Возвращает список контактов из файла по умолчанию.
        /// </summary>
        /// <returns>Список контактов.</returns>
        public static Project LoadFromFile()
        {
            return LoadFromFile(DocumentsPath);
        }

    }
}
