using System;
using System.Collections.Generic;
using System.Text;

namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private Engine m_Engine; 
        private string m_LicenseNumber; 
        private readonly List<Wheel> m_Wheels; 
        private string m_Model;           
        private float m_EnergyPercentage; //ask user 
        //-----------------------------------------------------------------//
        public Vehicle(Engine i_Engine, string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPressure)
        {
            this.m_Engine = i_Engine;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_Wheels = new List<Wheel>(i_NumberOfWheels);
            this.m_EnergyPercentage = 0;
        }
        //-----------------------------------------------------------------//
        public Engine Engine
        {
            get
            {
                return this.m_Engine;
            }
            set
            {
                this.m_Engine = value;
            }
        }
        //-----------------------------------------------------------------//
        public string LicenseNumber
        {
            get
            {
                return this.m_LicenseNumber;
            }
        }
        //-----------------------------------------------------------------//
        public float EnergyPrecentage
        {
            get
            {
                return this.m_EnergyPercentage;
            }
            set
            {
                this.m_EnergyPercentage = value;
            }
        }
        //-----------------------------------------------------------------//
        public List<Wheel> Wheels
        {
            get
            {
                return this.m_Wheels;
            }
        }
        //-----------------------------------------------------------------//
        public string Model
        {
            get
            {
                return this.m_Model;
            }
            set
            {
                this.m_Model = value;
            }
        }
        //-----------------------------------------------------------------//
        abstract public List<string> GetQuestionStrings();
        //-----------------------------------------------------------------//
        abstract public void SetAnswersToVehicle(List<string> answers);
        //-----------------------------------------------------------------//
        public void FillTiresToMax()
        {
            float airToAdd;

            foreach (Wheel wheel in this.m_Wheels)
            {
                airToAdd = wheel.MaxAirPressure - wheel.CurrentAirPressure;
                wheel.InflateWheel(airToAdd);
            }
        }
        //-----------------------------------------------------------------//
        public override string ToString()    
        {
            System.Text.StringBuilder vehicleInformation = new System.Text.StringBuilder();
            int numOfWheels = this.m_Wheels.Capacity;
            vehicleInformation.AppendFormat(@"
License Number: {0}
Model Name: {1}
Wheels:
", this.m_LicenseNumber.ToString(), this.m_Model.ToString());
            foreach (Wheel currentWheel in this.m_Wheels)
            {
                vehicleInformation.AppendLine(currentWheel.ToString());
            }
            vehicleInformation.Append(this.m_Engine.ToString());
            return vehicleInformation.ToString();
        }
        //-----------------------------------------------------------------//
        //Nested class
        public class Wheel
        {
            private float m_MaxAirPressureByManufactor; 
            private float m_CurrentAirPressure;
            private string m_ManufactorName;
            //-----------------------------------------------------------------//
            public Wheel(float i_MaxPressure)
            {
                this.m_MaxAirPressureByManufactor = i_MaxPressure;
            }
            //-----------------------------------------------------------------//
            public float MaxAirPressure
            {
                get
                {
                    return this.m_MaxAirPressureByManufactor;
                }
            }
            //-----------------------------------------------------------------//
            public float CurrentAirPressure
            {
                get
                {
                    return this.m_CurrentAirPressure;
                }
                set
                {
                    this.m_CurrentAirPressure = value;
                }
            }
            //-----------------------------------------------------------------//
            public string ManufactorName
            {
                get
                {
                    return this.m_ManufactorName;
                }
                set
                {
                    this.m_ManufactorName = value;
                }
            }
            //-----------------------------------------------------------------//
            public void InflateWheel(float i_AirToAdd)  //In progress
            {
                this.m_CurrentAirPressure += i_AirToAdd;

                if (this.m_CurrentAirPressure > this.m_MaxAirPressureByManufactor)
                {
                    string errorMessage = "Maximum air pressure in tire exceeded";
                    this.m_CurrentAirPressure -= i_AirToAdd;
                    throw new ValueOutOfRangeException(this.m_MaxAirPressureByManufactor, 0, errorMessage); //add string with proper message
                }
            }
            //-----------------------------------------------------------------//
            public override string ToString()
            {
                StringBuilder information = new StringBuilder() ;
                information.AppendFormat(@"   Maximum Air Presure: {0}
    Current Air Presure: {1}
    Manufactor: {2}", this.m_MaxAirPressureByManufactor.ToString(), this.m_CurrentAirPressure.ToString(), this.m_ManufactorName.ToString());
                information.Append(Environment.NewLine);
                return information.ToString();
            }

            //-----------------------------------------------------------------//
        }
    }
}
