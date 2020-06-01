using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{


    public class Car : Vehicle
    {
        public enum eColor
        {
            Red,
            White,
            Black,
            Silver    
        };
        //-----------------------------------------------------------------//
        private eColor m_Color;
        private int m_NumberOfDoors;
        //-----------------------------------------------------------------//
        public Car(eColor i_CarColor, int i_NumberOfDoors, string i_Model, string i_LicenseNumber, float i_EnergyPrecentage, List<Wheel> i_Wheels, Engine i_Engine) : 
            base(i_Model, i_LicenseNumber, i_EnergyPrecentage, i_Wheels, i_Engine)
        {
            this.m_Color = i_CarColor;
            this.m_NumberOfDoors = i_NumberOfDoors;
        }
        //-----------------------------------------------------------------//
        public eColor Color
        {
            get
            {
                return this.m_Color;
            }
            set
            {
                this.m_Color = value;
            }
        }
        //-----------------------------------------------------------------//
        public int NumberOfDoors
        {
            get
            {
                return this.m_NumberOfDoors;
            }
            set
            {
                this.m_NumberOfDoors = value;
            }
        }
        //-----------------------------------------------------------------//
    }
}
