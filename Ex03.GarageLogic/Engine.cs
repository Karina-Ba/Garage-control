using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        public class ElectricEngine: Engine
        {
            private float m_BatteryTimeLeft;
            private float m_MaxBatteryTime;


            public void ChargeBattery(float i_ChargeToAdd)
            {
                
            }

        }



        public class FuelEngine: Engine
        {
            enum eFuelType
            {
                Octan95,
                Octan96,
                Octan98,
                Soler
            };

            private float m_FuelLeft;
            private float m_MaxFuelCapacity;

            public void Refuel(float i_FuelToAdd)
            {

            }
            
        }




    }



}
