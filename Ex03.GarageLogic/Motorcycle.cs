using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Motorcycle: Vehicle
    {
        public enum eLicenseType
        {
            A = 1,
            A1 = 2,
            AA = 3,
            B = 4
        };
        //-----------------------------------------------------------------//
        private eLicenseType m_License;
        private int m_EngineCapacity;
        //-----------------------------------------------------------------//
        public Motorcycle(Engine i_Engine, string i_LicenseNumber) :
            base(i_Engine, i_LicenseNumber, 2, 30)
        {
        }
        //-----------------------------------------------------------------//
        public eLicenseType License
        {
            get
            {
                return this.m_License;
            }
            set
            {
                this.m_License = value;
            }
        }
        //-----------------------------------------------------------------//
        public int EngineCapacity
        {
            get
            {
                return this.m_EngineCapacity;
            }
            set
            {
                this.m_EngineCapacity = value;
            }
        }
        //-----------------------------------------------------------------//
        public override List<string> GetQuestionStrings()
        {
            List<string> questionString = new List<string>();
            questionString.Add(@"Please choose the motorcycle's license type:
1. A,
2. A1,
3. AA,
4. B");
            questionString.Add("Please enter the motorcycle's engine capacity: ");
            return questionString;

        }
        //-----------------------------------------------------------------//
        public override void SetAnswersToVehicle(List<string> i_Answers)
        {
            Exception exception = null;
            int licenseType = -1, engineVolume = -1;
            if (!int.TryParse(i_Answers[0], out licenseType))
            {
                exception = new FormatException("Format of input of the license type is't valid, please try again: ");
                exception.Source = "0";
            }
            else if (ValueOutOfRangeException.ValueOutOfRange(licenseType, 4, 1))
            {
                exception = new ValueOutOfRangeException(4, 1, "License type for the motorcycle is out of range, please try again: ", exception);
                exception.Source = "0";
            }
            if (!int.TryParse(i_Answers[1], out engineVolume))
            {
                exception = new FormatException("Format of input engine volume isn't valid, please try again: ", exception);
                exception.Source = "1";
            }
            else if (ValueOutOfRangeException.ValueOutOfRange(engineVolume, 1, 1500))//google it
            {
                exception = new ValueOutOfRangeException(1500, 1, "Engine volume for the motorcycle is out of range, please try again: ");
                exception.Source = "1";
            }
        }
    }
}
