using SecondTaskProject.Utilities.Providers;
using SecondTaskProject.Utilities;
using SecondTaskProject.Interfaces;

var printer = new ConsolePrinter();
var newtonsoftReader = new NewtonJSONReadeProvider();
var writer = new NewtonJSONWriterProvider();
var consystReader = new ConsystJSONReaderProvider();

Console.WriteLine("Выберите библиотеку для чтения \n" +
                  "1. NewtonsoftJSON   \n" +
                  "2. Собственная библиотека");
var variant = Console.ReadKey().KeyChar;
Console.WriteLine();
IReader reader = variant == '1' ? newtonsoftReader : consystReader;

var employeeManagement = new EmployeeManagement(printer, reader, writer);
employeeManagement.Start();
