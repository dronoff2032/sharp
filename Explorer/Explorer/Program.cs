using System.Diagnostics;

namespace Explorer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = null;

            DriveInfo[] all_drives = DriveInfo.GetDrives();

            while (true)
            {
                if (path == null)
                {
                    foreach (DriveInfo drive in all_drives)
                    {
                        Console.WriteLine("   " + drive.Name + " | Название диска: " + drive.VolumeLabel + " | Свободно " + drive.TotalFreeSpace / 1024 / 1024 / 1024 +  " GB из " + drive.TotalSize / 1024 / 1024 / 1024 + " GB");
                    }
                    int choice = Menu.show(0, all_drives.Length - 1);

                    if (choice != -1)
                    {
                        path += all_drives[choice].Name;
                    }
                } else
                {
                    string[] directories = Directory.GetDirectories(path);
                    string[] files = Directory.GetFiles(path);

                    Console.WriteLine("Путь: " + path);
                    Console.WriteLine(" -- -- -- -- -- -- -- -- -- -- -- -- -- --");
                    foreach (string driectory in directories)
                    {
                        Console.WriteLine("   " + driectory.Replace(path, "").Replace("\\", ""));
                    }
                    foreach (string file in files)
                    {
                        Console.WriteLine("   " + file.Replace(path, "").Replace("\\", ""));
                    }

                    if (directories.Length != 0 || files.Length != 0)
                    {
                        int choice = Menu.show(2, directories.Length + files.Length - 1);

                        if (choice == -1)
                        {
                            path = Path.GetDirectoryName(path);
                        }
                        else if (choice <= directories.Length - 1)
                        {
                            // Folders
                            path += directories[choice].Replace(path, "");
                        }
                        else
                        {
                            Process.Start(new ProcessStartInfo { FileName = path + files[choice - directories.Length].Replace(path, ""), UseShellExecute = true });
                        }
                    } else
                    {
                        int choice = Menu.show(2, 0);

                        if (choice == -1)
                        {
                            path = Path.GetDirectoryName(path);
                        }
                    }
                }

                Console.Clear();
            }
        }
    }
}