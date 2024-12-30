using System.Reflection;
using ConsystJSON.Models;

namespace ConsystJSON
{
    public static class JsonConverter
    {
        public static List<T> DeserializeArray<T>(string jsonData) 
        {
            var leftBracketsIndexes = new List<int>();
            var rightBracketsIndexes = new List<int>();
            var employees = new List<T>();

            #region Находим все элементы массива по фигурным скобкам
            for (int i = 0; i < jsonData.Length; i++)
            {
                if (jsonData[i] == '{')
                {
                    leftBracketsIndexes.Add(i);
                    continue;
                }

                if (jsonData[i] == '}')
                {
                    rightBracketsIndexes.Add(i);
                }
            }

            if (leftBracketsIndexes.Count != rightBracketsIndexes.Count)
            {
                return employees;
            }

            var employeeStrings = new string[leftBracketsIndexes.Count];

            for (int i = 0; i < leftBracketsIndexes.Count; i++)
            {
                var length = rightBracketsIndexes[i] - leftBracketsIndexes[i] + 1;
                employeeStrings[i] = jsonData.Substring(leftBracketsIndexes[i], length);
            }
            #endregion


            foreach (var employeeStr in employeeStrings)
            {
                var name = String.Empty;
                short yearBirth;
                bool gender;
                var workPosition = String.Empty;
                var department = String.Empty;

                #region Парсим имя
                var nameIndexStart = employeeStr.IndexOf("Name") + "Name".Length + 2;
                int nameIndexEnd;

                for (int i = nameIndexStart; ; i++)
                {
                    if (employeeStr[i] == ',')
                    {
                        nameIndexEnd = i;
                        break;
                    }
                }


                var nameLength = nameIndexEnd - nameIndexStart;
                name = employeeStr.Substring(nameIndexStart, nameLength).Replace("\"", "");
                #endregion

                #region Парсим дату рождения
                var yearIndexStart = employeeStr.IndexOf("BirthYear") + "BirthYear".Length + 2;
                int yearIndexEnd;

                for (int i = yearIndexStart; ; i++)
                {
                    if (employeeStr[i] == ',')
                    {
                        yearIndexEnd = i;
                        break;
                    }
                }


                var yearLength = yearIndexEnd - yearIndexStart;
                yearBirth = short.Parse(
                                        employeeStr.Substring(yearIndexStart, yearLength).Replace("\"", "")
                                        );
                #endregion

                #region Парсим пол
                var genderIndexStart = employeeStr.IndexOf("Gender") + "Gender".Length + 2;
                int genderIndexEnd;

                for (int i = genderIndexStart; ; i++)
                {
                    if (employeeStr[i] == ',')
                    {
                        genderIndexEnd = i;
                        break;
                    }
                }


                var genderLength = genderIndexEnd - genderIndexStart;
                var genderValue = short.Parse(
                                        employeeStr.Substring(genderIndexStart, genderLength).Replace("\"", "")
                                        );
                gender = genderValue == 0 ? true : false;
                #endregion

                #region Парсим должность
                var workIndexStart = employeeStr.IndexOf("WorkPosition") + "WorkPosition".Length + 2;
                int workIndexEnd;

                for (int i = workIndexStart; ; i++)
                {
                    if (employeeStr[i] == ',')
                    {
                        workIndexEnd = i;
                        break;
                    }
                }


                var workLength = workIndexEnd - workIndexStart;
                workPosition = employeeStr.Substring(workIndexStart, workLength).Replace("\"", "");
                #endregion

                #region Парсим отдел
                var departmentIndexStart = employeeStr.IndexOf("Department") + "Department".Length + 2;
                int departmentIndexEnd;

                for (int i = departmentIndexStart; ; i++)
                {
                    if (employeeStr[i] == '}')
                    {
                        departmentIndexEnd = i;
                        break;
                    }
                }

                var departmentLength = departmentIndexEnd - departmentIndexStart;
                department = employeeStr.Substring(departmentIndexStart, departmentLength).Replace("\"", "")
                                                                                          .Replace("\r", "")
                                                                                          .Replace("\n", "");
                #endregion

                dynamic employee = new Employee(name, yearBirth, gender, workPosition, department);

                employees.Add((T)employee);
            }

            return employees;
        }
    }
}
