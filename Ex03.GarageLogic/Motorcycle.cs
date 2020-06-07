using System;
using System.Collections.Generic;
using System.Text;

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
        public Motorcycle(Engine i_Engine, string i_LicenseNumber, string i_Model, string i_WheelsManufactorName) :
            base(i_Engine, i_LicenseNumber, i_Model, 2, 30, i_WheelsManufactorName)
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
1. A
2. A1
3. AA
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
            else if (ValueOutOfRangeException.ValueOutOfRange(engineVolume, 1, 1500))
            {
                exception = new ValueOutOfRangeException(1500, 1, "Engine volume for the motorcycle is out of range, please try again: ");
                exception.Source = "1";
            }

            if (exception != null)
            {
                throw exception;
            }
            this.m_License = (Motorcycle.eLicenseType)licenseType;
            this.m_EngineCapacity = engineVolume;
        }
        //-----------------------------------------------------------------//
        public override string ToString()
        {
            StringBuilder motorcycleDetails = new StringBuilder();
            motorcycleDetails.Append(base.ToString());
            motorcycleDetails.AppendFormat(@"Motorcycle Details: 
License Type: {0}
Engine Volume: {1}", this.m_License.ToString(), this.m_EngineCapacity.ToString());
            motorcycleDetails.Append(Environment.NewLine);
            return motorcycleDetails.ToString();
        }

        //-----------------------------------------------------------------//
    }
}
