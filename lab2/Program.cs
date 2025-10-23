using System;
using System.IO.Pipes;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

struct Message
{
    public int valueA { get; set; }
    public int valueB { get; set; }
    public int Priority { get; set; }
}

class PipeServer
{
    private static Mutex mutex = new Mutex(false, "MyMutex"); 

    static void Main(string[] args)
    {
        using (var pipeServer = new NamedPipeServerStream("MyNamedPipe", PipeDirection.InOut))
        {
            Console.WriteLine("Server is waiting for connection...");
            pipeServer.WaitForConnection();

            CancellationTokenSource cts = new CancellationTokenSource();

            Task t1 = WriteStructAsync(cts.Token);

            Task t2 = ReadAndWritePipeAsync(pipeServer, cts.Token);

            Console.WriteLine("Press Ctrl+C to interrupt.");

            Console.CancelKeyPress += (sender, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            Task.WhenAll(t1, t2).Wait();
        }

        Console.WriteLine("Server's work is done");
    }

    static void WriteToFile(Message message, string filePath)
    {
        // Используем Mutex для синхронизации доступа к файлу
        mutex.WaitOne();
        try
        {
            using (var streamWriter = File.AppendText(filePath))
            {
                streamWriter.WriteLine("Value A = {0}", message.valueA);
                streamWriter.WriteLine("Value B = {0}", message.valueB);
            }
        }
        finally
        {
            mutex.ReleaseMutex();
        }
    }

    static Task WriteStructAsync(CancellationToken cancellationToken)
    {
        return Task.Run(() =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                Message message = new Message();

                Console.WriteLine("Enter the first value");

                if (int.TryParse(Console.ReadLine(), out int valA))
                {
                    message.valueA = valA;
                }
                else
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }

                Console.WriteLine("Enter the 2nd value");

                if (int.TryParse(Console.ReadLine(), out int valB))
                {
                    message.valueB = valB;

                    Console.WriteLine("Enter the priority of value");
                }
                else
                {
                    Console.WriteLine("Invalid format");
                    continue;
                }

                if (int.TryParse(Console.ReadLine(), out int priority))
                {
                    message.Priority = priority;
                }
                else
                {
                    message.Priority = 0;
                }

                using (var pipeStream = new NamedPipeClientStream(".", "MyNamedPipe", PipeDirection.Out))
                {
                    pipeStream.Connect();
                    byte[] bytes = new byte[Unsafe.SizeOf<Message>()];

                    MemoryMarshal.Write(bytes, ref message);

                    try
                    {
                        pipeStream.Write(bytes, 0, bytes.Length);
                        pipeStream.Flush();
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }

                    WriteToFile(message, "textlab.txt");
                }
            }
        });
    }

    static Task ReadAndWritePipeAsync(NamedPipeServerStream pipeServer, CancellationToken cancellationToken)
    {
        return Task.Run(async () =>
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                byte[] bytes = new byte[Unsafe.SizeOf<Message>()];

                try
                {
                    await pipeServer.ReadAsync(bytes, 0, bytes.Length, cancellationToken);
                }
                catch (TaskCanceledException)
                {
                    break;
                }

                Message message = MemoryMarshal.Read<Message>(bytes);

                using (var pipeStream = new NamedPipeClientStream(".", "MyNamedPipe", PipeDirection.Out))
                {
                    pipeStream.Connect();

                    try
                    {
                        pipeStream.Write(bytes, 0, bytes.Length);
                        pipeStream.Flush();
                    }
                    catch (TaskCanceledException)
                    {
                        break;
                    }

                    WriteToFile(message, "textlab.txt");
                }
            }
        });
    }
}
