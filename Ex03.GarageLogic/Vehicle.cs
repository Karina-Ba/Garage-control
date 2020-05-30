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
        public class Wheel
        {
            private string m_ManufactorName;
            private float m_CurrentAirPressure;
            private float m_MaxAirPressureByManufactor;

            public void InflatingWheel(float i_AirToAdd)
            {
                //TO-DO
                //add pressure if not above the maximum
                //
            }
        }
    }
}
