using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Part1_Mod8
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task_8_2_1();
            //Task_8_2_2("C", "NewFolder");
            //Task_8_2_3("C", "NewFolder");
            //Task_8_2_1();
            //GetCatalogs();
            //DriveInfoSample();
            Console.WriteLine("-- End --");
        }

        #region 8.2.3
        /// <summary>
        /// Добавьте в задание 8.2.2 удаление вновь созданной директории и проверьте: теперь ваша программа не должна оставлять после себя следов!
        /// </summary>
        /// <param name="driveName"></param>
        /// <param name="dirName"></param>
        private static void Task_8_2_3(string driveName, string dirName)
        {
            string name = driveName + ":\\" + dirName;
            try
            {
                if (Directory.Exists(name))
                {
                    Console.WriteLine($"Trying to remove the folder: {name}");
                    Directory.Delete(name, true);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion 8.2.3

        #region 8.2.2
        /// <summary>
        /// Добавьте в метод из задания 8.2.1 создание новой директории в корне вашего диска, а после вновь выведите количество элементов уже после создания нового.
        /// </summary>
        private static void Task_8_2_2(string driveName, string dirName)
        {
            string name = driveName + ":\\" + dirName;
            try
            {
                if (!Directory.Exists(name))
                {
                    Console.WriteLine($"Trying to create new folder: {name}");
                    Directory.CreateDirectory(name);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        #endregion 8.2.2

        #region 8.2.1
        /// <summary>
        /// метод, который считает количество файлов и папок в корне вашего диска и выводит итоговое количество объектов.
        /// </summary>
        private static void Task_8_2_1()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in drives)
            {
                if (drive.IsReady)
                {
                    DirectoryInfo rootDir = drive.RootDirectory;
                    Console.WriteLine($"There are {rootDir.GetDirectories().Length} folders in {rootDir.Name}");
                    Console.WriteLine($"There are {rootDir.GetFiles().Length} files in {rootDir.Name}");
                }
                else
                {
                    Console.WriteLine($"Drive {drive} is not ready");
                }
            }
        }
        #endregion 8.2.1

        #region DriveInfoSample

        private static void DriveInfoSample()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            // Пробежимся по дискам и выведем их свойства
            foreach (DriveInfo drive in drives)
            {
                Console.WriteLine($"Название: {drive.Name}");
                Console.WriteLine($"Тип: {drive.DriveType}");
                if (drive.IsReady)
                {
                    Console.WriteLine($"Объем: {drive.TotalSize}");
                    Console.WriteLine($"Свободно: {drive.TotalFreeSpace}");
                    Console.WriteLine($"Метка: {drive.VolumeLabel}");
                }
            }
        }

        static void GetCatalogs()
        {
            string dirName = @"C:\"; // Прописываем путь к корневой директории MacOS (для Windows скорее всего тут будет "C:\\")
            if (Directory.Exists(dirName)) // Проверим, что директория существует
            {
                ShowStringArray ("Folders:", Directory.GetDirectories(dirName));  // Получим все директории корневого каталога
                ShowStringArray("Files", Directory.GetFiles(dirName));// Получим все файлы корневого каталога
            }

            void ShowStringArray(string header, string[] items)
            {
                Console.WriteLine(header);
                foreach (string s in items)
                {
                    Console.WriteLine(s);
                }
                Console.WriteLine();
            }
        }
        #endregion
        #region 8.1.4
        /// <summary>
        /// Для задачи 8.1.4 
        /// </summary>
        private class DiskInfo
        {
            public string DiskName { get; set; }
            public ulong TotalSpace { get; set; }
            public ulong FreeSpace { get; set; }
            public Folder FilesAndFolders { get; set; }

            public DiskInfo(string name, ulong space)
            {
                DiskName = name;
                TotalSpace = FreeSpace = space;
                FilesAndFolders = new Folder();
            }
            public void AddFolder(string name)
            {
                FilesAndFolders.Folders.Add(name, new Folder());
            }
        }
        #endregion

        #region 8.1.5
        internal class Folder
        {
            public Dictionary<string,Folder> Folders { get; set; }
            public Dictionary<string,File> Files { get; set; }
        }
        public class File
        {
            public string Name { get; set; }
            public ulong Size { get; set; }
        }
        #endregion
    }

}
