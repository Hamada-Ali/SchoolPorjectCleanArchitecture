using System.Globalization;

namespace SchoolProject.Domain.Common
{
    public class LocalizableEntity
    {
        public string NameAr { set; get; }
        public string NameEn { set; get; }

        public string GetLocalized()
        {
            CultureInfo culture = Thread.CurrentThread.CurrentCulture;

            if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
                return NameAr;
            return NameEn;
        }
    }
}
