using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private eLicenseType m_License;
        private int m_EngineCapacity;

        Motorcycle(eLicenseType i_License, int i_EngineCapacity) : base()
        {
            this.m_EngineCapacity = i_EngineCapacity;
            this.m_License = i_License;
        }

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



    }
}
