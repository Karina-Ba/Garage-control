using System;
using System.Collections.Generic;


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
        override public List<string> GetQuestionStrings()
        {
            List<string> questionString = new List<string>();
            questionString.Add(@"Please choose car's color:
1. Red
2. White
3. Black
4. Silver");
            questionString.Add("Please enter car's number of doors: ");
            return questionString;

        }
        //-----------------------------------------------------------------//
        override public void SetAnswersToVehicle(List<string> answers)
        {
            Exep exception = null;
            int numDoors;

            if(!int.TryParse(answers[0], out numDoors)) 
            {

            }
            else if (numDoors > 4 || numDoors < 1)
            {

            }

            if (!int.TryParse(answers[1], out numDoors)
            {
                exeption = new FormatException("Not a valid door number, please enter again");
                exeption.Source = "0";

            }
           else if (numDoors > 5 || numDoors < 2)
            {

            }


        }
    }
}
