using System;
using System.Collections.Generic;

namespace Ex03.GarageLogic
{
    class Truck: Vehicle
    {
        private bool m_IsTransportingHazardousGoods;
        private float m_BaggageCapacity;
        //-----------------------------------------------------------------//
        public Truck(Engine i_Engine, string i_LicenseNumber) :
            base(i_Engine, i_LicenseNumber, 16, 28)
        {
        }
        //-----------------------------------------------------------------//
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
        //-----------------------------------------------------------------//
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
        //-----------------------------------------------------------------//
        public override List<string> GetQuestionStrings()
        {
            List<string> questionString = new List<string>();
            questionString.Add("Is the truck transporting hazardous goods? Y/N: ");
            questionString.Add("Please enter the truck's baggage capacity: ");
            return questionString;

        }
        //-----------------------------------------------------------------//
        public override void SetAnswersToVehicle(List<string> i_Answers)
        {
            Exception exception;
            char userBool;//change name
            float baggageCapacity;
            if(!char.TryParse(i_Answers[0], out userBool))
            {
                exception = new FormatException("Format of input of the hazardous goods isn't valid, please try again: ");
                exception.Source = "0";
            }
            else if(!userBool.Equals('Y') || !userBool.Equals('y') 
                || !userBool.Equals('N') || !userBool.Equals('n'))
            {
                //what kind of exeption?
            }
        }
    }
}
