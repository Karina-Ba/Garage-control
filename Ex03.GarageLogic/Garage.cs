using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        Dictionary<string, InformationOfVehicle> m_VehiclesInTheGarage;
        
        
        public Garage()
        {
            m_VehiclesInTheGarage = new Dictionary<string, InformationOfVehicle>();
        }

        public Dictionary<string, InformationOfVehicle> VehiclesInTheGarage
        {
            get
            {
                return this.m_VehiclesInTheGarage;
            }
            set
            {
                this.m_VehiclesInTheGarage = value;
            }
        }


        public class InformationOfVehicle
        {
            enum eCarStateInGarage
            {
                InRepair,
                Repaired,
                Paid
            };
            eCarStateInGarage m_State;
            string m_NameOfOwner;
            string m_PhoneNumber;
            Vehicle m_Vehicle;

            public InformationOfVehicle(string i_OwnerName, string i_PhoneNumber, Vehicle i_Vehicle)
            {
                m_NameOfOwner = i_OwnerName;
                m_PhoneNumber = i_PhoneNumber;
                m_State = eCarStateInGarage.InRepair;
                m_Vehicle = i_Vehicle;
            }
        }

    }
}
