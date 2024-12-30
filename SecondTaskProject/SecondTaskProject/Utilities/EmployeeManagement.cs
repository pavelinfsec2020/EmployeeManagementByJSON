using System.Reflection;
using SecondTaskProject.Helpers;
using SecondTaskProject.Interfaces;
using SecondTaskProject.Models;

namespace SecondTaskProject.Utilities
{
    internal class EmployeeManagement
    {
        private readonly IPrinter _printer; 
        private readonly IReader _reader;
        private readonly IWriter _writer;
        private const string FILE_NAME = "EmployeeData"; 
        private string _filePath;
        public EmployeeManagement(IPrinter printer, IReader reader, IWriter writer) 
        { 
            _printer = printer;
            _reader = reader;  
            _writer = writer;
            Initialize();
        }

        private void Initialize()
        {
           var currentPath =  Assembly.GetExecutingAssembly().Location;
            _filePath = String.Format($"{Path.GetDirectoryName(currentPath)}\\{FILE_NAME}");

            if (!File.Exists(_filePath))
            {
                using (var stream = File.Create(_filePath))
                { 
                
                }
            }
            
        }
        public void Start()
        {
            _printer.PrintMessage("Добро пожаловать в утилиту управления сотрудниками \n" +
                                  "Доступные команды: \n" +
                                  "1. Добавить сотрудника \n" +
                                  "2. Вывести всех сотрудников \n" +
                                  "0. Выйти из программы" );
            ChooseOperation();         
           
        }

        private void ChooseOperation()
        {
            while (true)
            {
                _printer.PrintMessage("Введите номер операции");
                var operation = EnterOperation();

                switch (operation)
                {
                    case 1:
                        var isGood = AddEmployee();
                        var result = isGood ? "Успешно добавлен сотрудник" : "Не удалось добавить сотрудника";
                        _printer.PrintMessage(result);
                        continue;
                    case 2:
                        ShowAllEployees();
                        continue;
                    case 0:
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private int EnterOperation()
        {
            int operation;

            while (true)
            { 
                var input = Console.ReadLine();

                if (Int32.TryParse(input, out operation))
                    return operation;
                else _printer.PrintMessage("Операция введена неверно, введите повторно:");
            }
        }

        private bool AddEmployee()
        {
            _printer.PrintMessage("Введите имя сотрудника: ");
            var name = Console.ReadLine();
           
            _printer.PrintMessage("Введите дату рождения:");
            short birthYear;

            while (true)
            {
                if (EmployeeHelper.TryParseBirthYear(Console.ReadLine(), out birthYear))
                    break;
                else _printer.PrintMessage("Год рождения введен неверно, введите повторно:");             
            }

            _printer.PrintMessage("Введите пол сотрудника:");
            Gender gender;

            while (true)
            {
                if (EmployeeHelper.TryParseGender(Console.ReadLine(),out gender))
                    break;
                else _printer.PrintMessage("Пол введен неверно, введите повторно:");
            }

            _printer.PrintMessage("Введите должность: ");
            var workPosition = Console.ReadLine();
            _printer.PrintMessage("Введите отдел: ");
            var department = Console.ReadLine();

            var employee = new Employee(name, birthYear, gender, workPosition, department);
            
            return _writer.AddObjectToJSON<Employee>(employee, _filePath);
        }

        private void ShowAllEployees()
        {
            var employees = _reader.GetJSONObjects<Employee>(_filePath);

            if (employees == null || !employees.Any())
            {
                _printer.PrintMessage("Список сотрудников пуст");
                return;
            }

            foreach ( var employee in employees )
            {
                PrintEmployee(employee);
                _printer.PrintMessage("-----------------------------");
            }           
        }

        private void PrintEmployee(Employee employee)
        {
            _printer.PrintMessage(employee.Name);
            _printer.PrintMessage(employee.BirthYear.ToString());
            var gender = employee.Gender == Gender.Male ? "мужской" : "женский";
            _printer.PrintMessage(String.Format($"Пол: {gender}"));
            _printer.PrintMessage(employee.Department);
            _printer.PrintMessage(employee.WorkPosition);
        }
    }
}
