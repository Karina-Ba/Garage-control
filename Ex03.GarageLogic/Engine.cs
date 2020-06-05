﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class Engine
    {
        //-----------------------------------------------------------------//
        //Nested class
        public class ElectricEngine: Engine
        {
            private float m_MaxBatteryTime;
            private float m_BatteryTimeLeft;
            //-----------------------------------------------------------------//
            public ElectricEngine(float i_MaxBatteryTime) : base()
            {
                this.m_MaxBatteryTime = i_MaxBatteryTime;
            }
            //-----------------------------------------------------------------//
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
            //-----------------------------------------------------------------//
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
            //-----------------------------------------------------------------//
            public void ChargeBattery(float i_ChargeToAdd)
            {
                this.m_BatteryTimeLeft += i_ChargeToAdd;

                if (this.m_BatteryTimeLeft > this.m_MaxBatteryTime)
                {
                    string errorMessage = "Maximum battery charge exceeded";
                    this.m_BatteryTimeLeft -= i_ChargeToAdd;
                    throw new ValueOutOfRangeException(this.m_MaxBatteryTime, 0, errorMessage); 
                }
            }
        }
        //-----------------------------------------------------------------//
        //Nested class
        public class FuelEngine: Engine
        {
            public enum eFuelType
            {
                Octan95,
                Octan96,
                Octan98,
                Soler
            };
            //-----------------------------------------------------------------//
            private eFuelType m_FuelType;
            private float m_MaxFuelCapacity;
            private float m_FuelLeft;
            //-----------------------------------------------------------------//
            public FuelEngine(eFuelType i_FuelType, float i_MaxFuel)
            {
                this.m_FuelType = i_FuelType;
                this.m_MaxFuelCapacity = i_MaxFuel;
            }
            //-----------------------------------------------------------------//
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
            //-----------------------------------------------------------------//
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
            //-----------------------------------------------------------------//
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
            //-----------------------------------------------------------------//
            public void Refuel(float i_FuelToAdd)
            {

            }
        }
        //-----------------------------------------------------------------//
    }
}
