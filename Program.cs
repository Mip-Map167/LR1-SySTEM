using System;
using System.Diagnostics;

class Processes
{
    public static void Main(string[] args)
    {
        List<Process> processes = new List<Process>();
        int j = 0;
        for (int i = 0; i < 3;)
        {
            Console.Write("Введите имя процесса который хотите запустить: ");
            string pr = Convert.ToString(Console.ReadLine());
            if (pr.Equals("Блокнот"))
            {
                Process notepad = Process.Start("notepad.exe");
                processes.Add(notepad);

                Console.Write($"Блокнот: " +
                $"\n Id: {notepad.Id} " +
                $"\n Имя процесса: {notepad.ProcessName}" +
                $"\n Время запуска: {notepad.StartTime} " +
                $"\n Выделенная память: {notepad.WorkingSet64 / 1024 / 1024} МБ" +
                $"\n Приоритет: {notepad.PriorityClass} \n\n");

                Console.Write("Закрыть процесс? ");
                string nd = Convert.ToString(Console.ReadLine());
                if (nd.Equals("да"))
                {
                    notepad.Kill();
                    notepad.Dispose();
                    Console.WriteLine("Блокнот закрыт");
                    processes.Remove(notepad);
                }
                else if (nd.Equals("нет"))
                {
                    i++;
                    j++;
                }
            }
            else if (pr.Equals("Пеинт"))
            {
                Process paint = Process.Start("mspaint.exe");
                processes.Add(paint);

                Console.Write($"Пеинт: " +
                $"\n Id: {paint.Id} " +
                $"\n Имя процесса: {paint.ProcessName}" +
                $"\n Время запуска: {paint.StartTime} " +
                $"\n Выделенная память: {paint.WorkingSet64 / 1024 / 1024} МБ" +
                $"\n Приоритет: {paint.PriorityClass} \n\n");


                Console.Write("Закрыть процесс? ");
                string pt = Convert.ToString(Console.ReadLine());
                if (pt.Equals("да"))
                {
                    paint.Kill();
                    paint.Dispose();
                    Console.WriteLine("Пеинт закрыт");
                    processes.Remove(paint);
                }
                else if (pt.Equals("нет"))
                {
                    i++;
                    j++;
                }
            }
            else if (pr.Equals("Ворд"))
            {
                Process word = Process.Start(@"C:\Program Files\Microsoft Office\root\Office16\WINWORD.EXE");
                processes.Add(word);

                Console.Write($"Ворд: " +
                $"\n Id: {word.Id} " +
                $"\n Имя процесса: {word.ProcessName}" +
                $"\n Время запуска: {word.StartTime} " +
                $"\n Выделенная память: {word.WorkingSet64 / 1024 / 1024} МБ" +
                $"\n Приоритет: {word.PriorityClass} \n\n");

                Console.Write("Закрыть процесс? ");
                string wd = Convert.ToString(Console.ReadLine());
                if (wd.Equals("да"))
                {
                    word.Kill();
                    word.Dispose();
                    Console.WriteLine("Ворд закрыт");
                    processes.Remove(word);
                }
                else if (wd.Equals("нет"))
                {
                    i++;
                    j++;
                }
            }
        }

        Console.WriteLine("Запущено 3 процесса, через 5 секунд они будут закрыты");

        foreach(Process p in processes)
        {
            Console.WriteLine($"PiD {p.ProcessName}: {p.Id}");
        }
        
        Thread.Sleep(5000);

        foreach (Process p in processes)
        {
            p.Kill();
            Console.WriteLine($"Процесс {p.ProcessName} закрыт");
            p.Dispose();
        }
    }
}
