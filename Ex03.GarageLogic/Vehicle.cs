using System;
using System.Collections.Generic;


namespace Ex03.GarageLogic
{
    public abstract class Vehicle
    {
        private string m_Model;
        private string m_LicenseNumber;
        private float m_EnergyPercentage;
        private List<Wheel> m_Wheels;
        private Engine m_Engine;
        //-----------------------------------------------------------------//
        public Vehicle(string i_Model, string i_LicenseNumber, float i_EnergyPrecentage, List<Wheel> i_Wheels,
            Engine i_Engine)
        {
            this.m_Model = i_Model;
            this.m_LicenseNumber = i_LicenseNumber;
            this.m_EnergyPercentage = i_EnergyPrecentage;
            this.m_Wheels = i_Wheels;
            this.m_Engine = i_Engine;
        }
        //-----------------------------------------------------------------//
        public string Model
        {
            get
            {
                return this.m_Model;
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
            set
            {
                this.m_Wheels = value;
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
        //Nested class
        public class Wheel
        {
            private string m_ManufactorName;
            private float m_CurrentAirPressure;
            private float m_MaxAirPressureByManufactor;
            //-----------------------------------------------------------------//
            public Wheel(string i_ManufactorName, float i_CurrentPressure, float i_MaxPressure)
            {
                this.m_ManufactorName = i_ManufactorName;
                this.m_CurrentAirPressure = i_CurrentPressure;
                this.m_MaxAirPressureByManufactor = i_MaxPressure;
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
            public float MaxAirPressure
            {
                get
                {
                    return this.m_MaxAirPressureByManufactor;
                }
            }
            //-----------------------------------------------------------------//
            public void InflatingWheel(float i_AirToAdd)
            {
                
                this.m_CurrentAirPressure += i_AirToAdd;

                    if (this.m_CurrentAirPressure > this.m_MaxAirPressureByManufactor)
                {
                    ValueOutOfRangeException exception = new ValueOutOfRangeException(this.m_MaxAirPressureByManufactor, o);
                    this.m_CurrentAirPressure -= i_AirToAdd;
                    throw exception;
                }
            }
            //-----------------------------------------------------------------//

        }
    }
}
