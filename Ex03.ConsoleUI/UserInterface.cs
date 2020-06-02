using System;
using System.Collections.Generic;
using Ex03.GarageLogic;

namespace Ex03.ConsoleUI
{
    public class UserInterface
    {
        public void InitializeUI()
        {
            OpenGarage();
        }
        //-----------------------------------------------------------------//
        public void OpenGarage()
        {
            Garage garage = new Garage();
            int userInputChoice;
            bool userExit = false;

            while (!userExit)
            {
                printMenu();
                userInputChoice = getValidUserInputChoice();
                doActionUserAsked(userInputChoice, out userExit);
            }
        }
        //-----------------------------------------------------------------//
        public void printMenu()
        {
            Console.Write(@"Menu options:
1. Enter a vehicle to the garage.
2. Show all the vehicle license plates admitted in the garage.
3. Change vehicle status in the garage.
4. Fill up tires of a chosen vehicle to the max capacity.
5. Fuel up a vehicle.
6. Charge up a vehicle.
7. Show all the information of a vehicle chosen by license plate number
8. Exit garage.

Please enter an action you would like to do: ");
        }
        //-----------------------------------------------------------------//
        private bool didUserExit(int i_UserInput)
        {
            return i_UserInput == 0;
        }
        //-----------------------------------------------------------------//
        private int getValidUserInputChoice()
        {
            string userInputChoice = Console.ReadLine();
            int userInputNumerical = 0;

            while (!int.TryParse(userInputChoice, out userInputNumerical) || userInputNumerical > 8 || userInputNumerical < 1)
            {
                userInputChoice = Console.ReadLine();
            }

            return userInputNumerical;
        }
        //-----------------------------------------------------------------//
        private void doActionUserAsked(int i_UserChoice, out bool i_UserExit)
        {

        }
        //-----------------------------------------------------------------//
    }
}
