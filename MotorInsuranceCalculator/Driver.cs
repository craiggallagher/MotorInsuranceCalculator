using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorInsuranceCalculator
{
    class Driver : IDataErrorInfo
    {// my validations for textBoxs. 
       //didn't work when I tried with datePicker
        public string Name { get; set; }
        public string Occupation { get; set; }
        public string DOB { get; set; }
       
        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        public string this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "Name")
                {
                    if (string.IsNullOrEmpty(Name) || Name.Length < 3)
                        result = "Please enter a Name";
                }
                if (columnName == "Occupation")
                {
                    if (string.IsNullOrEmpty(Occupation))
                        result = "Please enter a Occupation";
                }
                //if (columnName == "DOB")
                //{
                //    if (string.IsNullOrEmpty(DOB))
                //        result = "Please enter Date Of Birth";
                //}
                return result;
            }

        }
    }
}
