// See https://aka.ms/new-console-template for more information

using ParallelProcessing.Exceptions;
using ParallelProcessing.Exceptions.Abstractions;
using ParallelProcessing.Root;

var startUpConfigurator = new TrafficControlStartupConfigurator();

try
{
    await startUpConfigurator.Run();
    Console.ReadLine();
}
catch (ProcessingItemCreationException ex)
{
    Console.WriteLine(ex);
    Console.WriteLine($"With Data: \n  {ex.Data}");

    throw;
}
catch (ProcessingException processingException)
{
    Console.WriteLine(processingException);
    throw;
}
catch (AnalysingException analysingException)
{
    Console.WriteLine(analysingException);
    throw;
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
Console.WriteLine("Hello, World!");