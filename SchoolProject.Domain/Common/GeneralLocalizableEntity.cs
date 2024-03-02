using System.Globalization;

namespace SchoolProject.Domain.Common
{
    public class GeneralLocalizableEntity
    {
        public string Localize(string textAr, string textEN)
        {
            CultureInfo CultureInfo = Thread.CurrentThread.CurrentCulture;
            if (CultureInfo.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            {
                return textAr;
            }
            else
            {
                return textEN;
            }
        }
    }
}

