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
            int numOfDoors, colorChoice;
            try
            {
                checkFormatException(answers, out numOfDoors, out colorChoice);
            }
            catch (FormatException exception)
            {
                throw exception;
            }

           





            //int numDoors;

           // if(!int.TryParse(answers[0], out numDoors)) 
           // {

           // }
           // else if (numDoors > 4 || numDoors < 1)
           // {

           // }

           // if (!int.TryParse(answers[1], out numDoors)
           // {
           //     exception = new FormatException("Not a valid door number, please enter again");
           //     exception.Source = "0";
           //     exception.InnerException

           // }
           //else if (numDoors > 5 || numDoors < 2)
           // {
                
           // }


        }


        private void checkFormatException(List<string> i_Answers, out int o_numOfDoors, out int o_Color)
        {
            o_numOfDoors = -1;
            o_Color = -1;
            FormatException exception1 = null, exception2 = null;

            if (!int.TryParse(i_Answers[0], out o_Color))
            {
                exception1 = new FormatException("No such choice, please enter another: ");
                exception1.Source = "0";
            }

            if(!int.TryParse(i_Answers[1], out o_numOfDoors))
            {
                exception2 = new FormatException("That's not a valid number, please enter another: ", exception1);
                exception1.Source = "1";
            }

            if(exception2 != null)
            {
                throw exception2;
            }
            else if(exception1 != null)
            {
                throw exception1;
            }
        }
    }
}
