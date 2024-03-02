using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KMA.ProgrammingInCSharp2024.Models
{
    internal class UserCandidate
    {
        #region Fields
        private DateTime _birthDate;
        private string _age;
        private string _westernZodiac;
        private string _chineseZodiac;
        #endregion

        #region Properties
        public DateTime BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }
        public string Age
        {
            get { return _age; }
            set { _age = value; }

        }
        public string WesternZodiac
        {
            get { return _westernZodiac; }
            set { _westernZodiac = value; }
        }

        public string ChineseZodiac
        {
            get { return _chineseZodiac; }
            set { _chineseZodiac = value; }
        }


        #endregion



    }
}
