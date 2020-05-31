using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Truck: Vehicle
    {
        private bool m_IsTransportingHazardousGoods;
        private float m_BaggageCapacity;

        public Truck(bool i_HazardousGoods, int i_BaggageCapacity): base()
        {
            this.m_IsTransportingHazardousGoods = i_HazardousGoods;
            this.m_BaggageCapacity = i_BaggageCapacity;
        }


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

    }


}
