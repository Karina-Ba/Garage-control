using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Motorcycle: Vehicle
    {
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
    }
}
