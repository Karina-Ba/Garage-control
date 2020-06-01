using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Motorcycle: Vehicle
    {
        //maybe private?
        public enum eLicenseType
        {
            A,
            A1,
            AA,
            B
        };
        //-----------------------------------------------------------------//
        private eLicenseType m_License;
        private int m_EngineCapacity;
        //-----------------------------------------------------------------//
        Motorcycle(eLicenseType i_License, int i_EngineCapacity, string i_Model, string i_LicenseNumber, float i_EnergyPrecentage, List<Wheel> i_Wheels, Engine i_Engine) :
            base(i_Model, i_LicenseNumber, i_EnergyPrecentage, i_Wheels, i_Engine)
        {
            this.m_EngineCapacity = i_EngineCapacity;
            this.m_License = i_License;
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
        }
        //-----------------------------------------------------------------//
    }
}
