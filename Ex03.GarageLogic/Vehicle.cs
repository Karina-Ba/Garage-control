using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private Engine m_Engine; 
        private string m_LicenseNumber; 
        private readonly List<Wheel> m_Wheels; 
        private float m_EnergyPercentage; //Need
        private string m_Model;           //Need
        //-----------------------------------------------------------------//
        public Vehicle(Engine i_Engine, string i_LicenseNumber, int i_NumberOfWheels, float i_MaxAirPressure)
        {
            this.m_Engine = i_Engine;
            this.m_LicenseNumber = LicenseNumber;
            this.m_Wheels = new List<Wheel>(i_NumberOfWheels);
            this.m_EnergyPercentage = 0;

            for (int i = 0; i < i_NumberOfWheels; ++i) 
            {
                this.m_Wheels.Add(new Wheel(i_MaxAirPressure));
            }
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
                this.m_CurrentAirPressure = 0;
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
            public void InflatingWheel(float i_AirToAdd)  //In progress
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

        }
    }
}
