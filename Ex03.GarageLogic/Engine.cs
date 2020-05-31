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


            public ElectricEngine(float i_BatteryTimeLeft, float i_MaxBatteryTime) : base()
            {
                this.m_BatteryTimeLeft = i_BatteryTimeLeft;
                this.m_MaxBatteryTime = i_MaxBatteryTime;
            }

            public float BatteryTimeLeft
            {
                get
                {
                    return this.m_BatteryTimeLeft;
                }
                set
                {
                    this.m_BatteryTimeLeft = value;
                }
            }

            public float MaxBatteryTime
            {
                get
                {
                    return this.m_MaxBatteryTime;
                }
                set
                {
                    this.m_MaxBatteryTime = value;
                }
            }
            public void ChargeBattery(float i_ChargeToAdd)
            {

            }
        }



        public class FuelEngine: Engine
        {
            public enum eFuelType
            {
                Octan95,
                Octan96,
                Octan98,
                Soler
            };
            private eFuelType m_FuelType;
            private float m_FuelLeft;
            private float m_MaxFuelCapacity;

            

            public FuelEngine(eFuelType i_FuelType, float i_FuelLeft, float i_MaxFuel)
            {
                this.m_FuelType = i_FuelType;
                this.m_FuelLeft = i_FuelLeft;
                this.m_MaxFuelCapacity = i_MaxFuel;
            }


            public eFuelType FuelType
            {
                get
                {
                    return this.m_FuelType;
                }
                set
                {
                    this.m_FuelType = value;
                }
            }

            public float FuelLeft
            {
                get
                {
                    return this.m_FuelLeft;
                }
                set
                {
                    this.m_FuelLeft = value;
                }
            }

            public float MaxFuelCapacity
            {
                get
                {
                    return this.m_MaxFuelCapacity;
                }
                set
                {
                    this.m_MaxFuelCapacity = value;
                }
            }

               
            public void Refuel(float i_FuelToAdd)
            {

            }

        }




    }



}
