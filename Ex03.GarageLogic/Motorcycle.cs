﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    class Motorcycle: Vehicle
    {
        enum eLicenseType
        {
            A,
            A1,
            AA,
            B
        };     
        private eLicenseType m_License;
        private int m_EngineCapacity;
    }
}
