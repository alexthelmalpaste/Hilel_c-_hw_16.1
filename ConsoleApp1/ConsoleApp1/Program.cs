using System;
using System.IO;

class FileCopier
{
    static void Main()
    {
        Console.WriteLine("Програма для копіювання текстового файлу");

        // Отримуємо шляхи від користувача
        Console.Write("Введіть шлях до вихідного файлу: ");
        string sourcePath = Console.ReadLine();

        Console.Write("Введіть шлях до файлу, в який потрібно скопіювати дані: ");
        string destinationPath = Console.ReadLine();

        try
        {
            // Викликаємо метод копіювання
            CopyFile(sourcePath, destinationPath);
            Console.WriteLine("Файл успішно скопійовано!");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Помилка: Вихідний файл не знайдено.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Помилка: Директорія не знайдена.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"Помилка вводу/виводу: {ex.Message}");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Помилка: Немає доступу до файлу.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Сталася невідома помилка: {ex.Message}");
        }
    }

    static void CopyFile(string sourcePath, string destinationPath)
    {
        // Перевіряємо, чи існує вихідний файл
        if (!File.Exists(sourcePath))
        {
            throw new FileNotFoundException();
        }

        // Читаємо весь вміст вихідного файлу
        string content = File.ReadAllText(sourcePath);

        // Записуємо вміст у цільовий файл
        File.WriteAllText(destinationPath, content);
    }
}