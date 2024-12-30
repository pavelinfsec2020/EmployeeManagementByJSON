
namespace ConsystJSON.Models;

public class Employee
{
    private readonly string _name;
    private readonly short _birthYear;
    private readonly bool _gender;
    private string _workPosition;
    private string _department;

    public Employee(string name, short birthday, bool gender,
                    string workPosition, string department)
    {
        _name = name;
        _birthYear = birthday;
        _gender = gender;
        _workPosition = workPosition;
        _department = department;
    }

    public string Name
    { 
       get { return _name; }
    }

    public short BirthYear
    {
        get { return _birthYear; }
    }

    public bool Gender 
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
}
