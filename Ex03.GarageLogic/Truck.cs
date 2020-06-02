using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Truck: Vehicle
    {
        private bool m_IsTransportingHazardousGoods;
        private float m_BaggageCapacity;
        //-----------------------------------------------------------------//
        public Truck(Engine i_Engine, string i_LicenseNumber) :
            base(i_Engine, i_LicenseNumber, 16, 28)
        {
        }
        //-----------------------------------------------------------------//
        public bool IsTransportingHazardousGoods
        {
            get
            {
                return this.m_IsTransportingHazardousGoods;
            }
            set
            {
                this.m_IsTransportingHazardousGoods = value;
            }
        }
        //-----------------------------------------------------------------//
        public float BaggageCapacity
        {
            get
            {
                return this.m_BaggageCapacity;
            }
            set
            {
                this.m_BaggageCapacity = value;
            }
        }
        //-----------------------------------------------------------------//

    }
}
