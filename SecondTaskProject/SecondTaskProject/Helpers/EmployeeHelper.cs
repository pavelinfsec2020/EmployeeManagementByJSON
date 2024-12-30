using SecondTaskProject.Models;

namespace SecondTaskProject.Helpers
{
    public static class EmployeeHelper
    {
        private static readonly string[] _maleInputVariants = { "м", "мужчина", "мужской" , "парень", "муж"};
        private static readonly string[] _femaleInputVariants = { "ж", "женщина", "женский", "девушка", "жен"};
        public static bool TryParseGender (string inputValue, out Gender gender)
        {
            for (int i = 0; i < _maleInputVariants.Length; i++)
            {
                if (_maleInputVariants[i].Equals(
                    inputValue.ToLower()))
                {
                    gender = Gender.Male;
                    return true;
                }
            }

            for (int i = 0; i < _femaleInputVariants.Length; i++)
            {
                if (_femaleInputVariants[i].Equals(
                    inputValue.ToLower()))
                { 
                    gender = Gender.Female;   
                    return true;
                }
            }

            gender = Gender.Undefind;

            return false;
        }

        public static bool TryParseBirthYear(string inputValue, out short birthYear)
        {
            short number;
            var isNumber = short.TryParse(inputValue, out number);

            if (isNumber &&
                (number > 1900 && number < 2024))
            {
                birthYear = number;
                return true;
            }
            else 
            { 
              birthYear= 0;
              return false;
            }
        }
    }
}
