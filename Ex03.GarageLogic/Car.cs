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
        public Car(Engine i_Engine, string i_LicenceNumber) :
            base(i_Engine, i_LicenceNumber, 4, 32)
        {
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
