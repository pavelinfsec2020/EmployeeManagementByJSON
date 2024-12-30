using System.Diagnostics.Metrics;

namespace SecondTaskProject.Models;

internal class Employee
{
    private readonly string _name;
    private readonly short _birthYear;
    private readonly Gender _gender;
    private string _workPosition;
    private string _department;

    public Employee(string name, short birthday, Gender gender,
                    string workPosition, string department)
    {
        _name = name;
        _birthYear = birthday;
        _gender = gender;
        _workPosition = workPosition;
        _department = department;
    }

    public static explicit operator Employee(ConsystJSON.Models.Employee employee)
    {
        return new Employee(employee.Name, employee.BirthYear, employee.Gender ? Gender.Male : Gender.Female, employee.WorkPosition, employee.Department);
    }

    public string Name
    { 
       get { return _name; }
    }

    public short BirthYear
    {
        get { return _birthYear; }
    }

    public Gender Gender 
    { 
        get { return _gender; } 
    }

    public string WorkPosition
    {
        get { return _workPosition; }
    }

    public string Department
    {
        get { return _department;  }
    }

    public void ChangeWorkPosition (string newWorkPosition)
    {
        _workPosition = newWorkPosition;
    }

    public void ChangeDepartment(string newWorkDepartment)
    {
        _department = newWorkDepartment;
    }
}
