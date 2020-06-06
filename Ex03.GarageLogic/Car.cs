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
        public Car(Engine i_Engine, string i_LicenceNumber, string i_Model) :
            base(i_Engine, i_LicenceNumber, i_Model, 4, 32)
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
        public override List<string> GetQuestionStrings()
        {
            List<string> questionString = new List<string>();
            questionString.Add(@"Please choose the car's color:
1. Red
2. White
3. Black
4. Silver
");
            questionString.Add("Please enter the car's number of doors: ");
            return questionString;

        }
        //-----------------------------------------------------------------//
        public override void SetAnswersToVehicle(List<string> i_Answers)
        {
            Exception exception = null;
            int colorChoice = -1, amountOfDoors = -1;
            //need to be in try??
            if (!int.TryParse(i_Answers[0], out colorChoice))
            {
                exception = new FormatException("Format of input of the color isn't valid, please try again: ");
                exception.Source = "0";
            }
            else if (ValueOutOfRangeException.ValueOutOfRange(colorChoice, 4, 1))
            {
                exception = new ValueOutOfRangeException(4, 1, "Color choice for the car is out of range, please try again: ", exception);
                exception.Source = "0";
            }

            if (!int.TryParse(i_Answers[1], out amountOfDoors))
            {
                exception = new FormatException("Format of input of the number of doors isn't valid, please try again: ", exception);
                exception.Source = "1";
            }
            else if (ValueOutOfRangeException.ValueOutOfRange(amountOfDoors, 5, 2))
            {
                exception = new ValueOutOfRangeException(5, 1, "Number of doors for the car is out of range, please try again: ", exception);
                exception.Source = "1";
            }


            if (exception != null)
            {
                throw exception;
            }
        }
        //-----------------------------------------------------------------//
        public override string ToString()
        {
            System.Text.StringBuilder carDetails = new System.Text.StringBuilder();
            carDetails.Append(base.ToString());
            carDetails.AppendFormat(@"Color: {0}
Number of Doors: {1}", this.m_Color.ToString(), this.m_NumberOfDoors.ToString());
            return carDetails.ToString();
        }
        //-----------------------------------------------------------------//
    }
}
