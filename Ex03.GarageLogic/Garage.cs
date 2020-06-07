using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public class Garage
    {
        private readonly Dictionary<string, InformationOfVehicle> m_VehiclesInTheGarage;
        //-----------------------------------------------------------------//
        public Garage()
        {
            m_VehiclesInTheGarage = new Dictionary<string, InformationOfVehicle>();
        }
        //-----------------------------------------------------------------//
        public Dictionary<string, InformationOfVehicle> VehiclesInTheGarage
        {
            get
            {
                return this.m_VehiclesInTheGarage;
            }
        }
        //-----------------------------------------------------------------//
        public bool isEmptyGarage()
        {
            return this.m_VehiclesInTheGarage.Count == 0;
        }
        //-----------------------------------------------------------------//
        public StringBuilder GetLicensePlatesByState(InformationOfVehicle.eVehicleStateInGarage i_State)
        {
            StringBuilder KeyString = new StringBuilder();
            int index = 0;

            foreach (KeyValuePair<string, InformationOfVehicle> currentKey in this.m_VehiclesInTheGarage)
            {
                if (i_State == InformationOfVehicle.eVehicleStateInGarage.Default || currentKey.Value.State == i_State)
                {
                    ++index;
                    KeyString.Append(index.ToString() + ". ");
                    KeyString.Append(currentKey.Key);
                    KeyString.Append(Environment.NewLine.ToString());
                }
            }

            return KeyString;
        }
        //-----------------------------------------------------------------//
        public void ChangeVehicleState(string i_LicenseNumber, InformationOfVehicle.eVehicleStateInGarage i_NewState)
        {
            try
            {
                InformationOfVehicle vehicleInformation = this.checkForLicensePlate(i_LicenseNumber); ;
                vehicleInformation.State = i_NewState;
            }
            catch (ArgumentException exception)
            {
                throw exception;
            }
        }
        //-----------------------------------------------------------------//
        public void FillTiresToMax(string i_LicenseNumber)
        {
            try
            {
                InformationOfVehicle vehicleInformation = this.checkForLicensePlate(i_LicenseNumber);
                vehicleInformation.Vehicle.FillTiresToMax();
            }
            catch (ArgumentException exception)
            {
                throw exception;
            }
        }
        //-----------------------------------------------------------------//
        private InformationOfVehicle checkForLicensePlate(string i_LicenseNumber)
        {
            InformationOfVehicle vehicleInformation;
            bool foundVehicle = this.m_VehiclesInTheGarage.TryGetValue(i_LicenseNumber, out vehicleInformation);

            if (!foundVehicle)
            {
                ArgumentException exception = new ArgumentException("Vehicle by this license number doesn't exist in the garage");
                throw exception;
            }
            else
            {
                return vehicleInformation;
            }
        }
        //-----------------------------------------------------------------//
        //Nested class
        public class InformationOfVehicle
        {
            public enum eVehicleStateInGarage
            {
                Default,
                InRepair,
                Repaired,
                Paid
            };
            //-----------------------------------------------------------------//
            eVehicleStateInGarage m_State;
            string m_OwnerName;
            string m_OwnerPhoneNumber;
            Vehicle m_Vehicle;
            //-----------------------------------------------------------------//
            public InformationOfVehicle(string i_OwnerName, string i_PhoneNumber, Vehicle i_Vehicle)
            {
                m_OwnerName = i_OwnerName;
                m_OwnerPhoneNumber = i_PhoneNumber;
                m_State = eVehicleStateInGarage.InRepair;
                m_Vehicle = i_Vehicle;
            }
            //-----------------------------------------------------------------//
            public eVehicleStateInGarage State
            {
                get
                {
                    return this.m_State;
                }
                set
                {
                    this.m_State = value;
                }
            }
            //-----------------------------------------------------------------//
            public string OwnerName
            {
                get
                {
                    return this.m_OwnerName;
                }
                set
                {
                    this.m_OwnerName = value;
                }
            }
            //-----------------------------------------------------------------//
            public string OwnerPhoneNumber
            {
                get
                {
                    return this.m_OwnerPhoneNumber;
                }
                set
                {
                    this.m_OwnerPhoneNumber = value;
                }
            }
            //-----------------------------------------------------------------//
            public Vehicle Vehicle
            {
                get
                {
                    return this.m_Vehicle;
                }
                set
                {
                    this.m_Vehicle = value;
                }
            }
            //-----------------------------------------------------------------//
            public override string ToString()
            {
                StringBuilder vehicleInGarageDetails = new StringBuilder();
                vehicleInGarageDetails.AppendFormat(@"Owner Information
Name: {0}
Phone Number: {1}
", this.m_OwnerName, this.m_OwnerPhoneNumber);
                vehicleInGarageDetails.AppendFormat(this.m_Vehicle.ToString());
                vehicleInGarageDetails.AppendFormat("Vehicle's Status: {0}", this.m_State.ToString());
                return vehicleInGarageDetails.ToString();
            }
            //-----------------------------------------------------------------//
        }
    }
}
