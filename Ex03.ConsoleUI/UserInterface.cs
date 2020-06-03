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
                userInputChoice = getValidUserInputChoice(1, 8);
                doActionUserAsked(userInputChoice, out userExit, garage);
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
        private int getValidUserInputChoice(int i_MinimumValue, int i_MaximumValue)
        {
            string userInputChoice = Console.ReadLine();
            int userInputNumerical = 0;

            while (!int.TryParse(userInputChoice, out userInputNumerical) || userInputNumerical > i_MaximumValue || userInputNumerical < i_MinimumValue)
            {
                Console.WriteLine("Choice is out of boundaries, Please enter again: ");
                userInputChoice = Console.ReadLine();
            }

            return userInputNumerical;
        }
        //-----------------------------------------------------------------//
        private void doActionUserAsked(int i_UserChoice, out bool i_UserExit, Garage i_Garage)
        {
            i_UserExit = true;
            switch(i_UserChoice)
            {
              //  case 1:


            }
        }
        //-----------------------------------------------------------------//
        private void getVehicleInformation(Garage i_Garage)
        {
            string licenseNumber, userInputChoice, ownerPhoneNumber, ownerName;
            VehicleAllocator.eVehicleType vehicleType;
            Console.WriteLine(@"Please choose which Vehicle you want to make:
1. Electric car.
2. Fuel car.
3. Electric motorcycle.
4. Fuel motorcycle
5. Truck");
            vehicleType = (VehicleAllocator.eVehicleType)getValidUserInputChoice(1, 5);
            Console.WriteLine("Please enter the license number of the chosen vehicle: ");
            licenseNumber = getValidStringInput();
            Vehicle newVehicle = VehicleAllocator.AllocateVehicle(vehicleType, licenseNumber);
            completeVehicleInformation(ref newVehicle, vehicleType);
            getOwnerInformation(out ownerPhoneNumber, out ownerName);
            //new information(...)
            //i_Garage.VehiclesInTheGarage.Add(licenseNumber, new info)

        }

        //-----------------------------------------------------------------//
        private void completeVehicleInformation(ref Vehicle io_Vehicle, VehicleAllocator.eVehicleType i_VehicleType)
        {
            List<string> questions = VehicleAllocator.GetQuestionsAboutVehicle(i_VehicleType, io_Vehicle);
            List<string> answers = new List<string>();
            bool isWrongAnswer = true;
            foreach(string currentString in questions)
            {
                Console.WriteLine(currentString);
                answers.Add(Console.ReadLine());
            }

            while(isWrongAnswer)
            {
                try
                {
                    VehicleAllocator.SetAnswersAboutVehicle(i_VehicleType, io_Vehicle, answers);
                    isWrongAnswer = false;
                }
                catch
                {

                }
            }
        
        }
        //-----------------------------------------------------------------//
        private void getOwnerInformation(out string o_ownerPhoneNumber, out string o_ownerName)
        {
            uint ownerPhone;
            bool isValidNameString = false;
            Console.WriteLine("Please Enter your name:");
            o_ownerName = Console.ReadLine();

            while (!isValidNameString)
            {
                isValidNameString = true;
                foreach (char currentChar in o_ownerName)
                {
                    if(!char.IsLetter(currentChar) || !(currentChar == ' '))
                    {
                        isValidNameString = false;
                        Console.WriteLine("Only letters and spaces allowed, please enter your name again:");
                        o_ownerName = Console.ReadLine();
                        break;
                    }
                }
            }

            o_ownerPhoneNumber = Console.ReadLine();
            Console.WriteLine("Please enter your phone number:");

            while(!uint.TryParse(o_ownerPhoneNumber, out ownerPhone))
            {
                Console.WriteLine("Phone can only consist of number, please enter again:");
                o_ownerPhoneNumber = Console.ReadLine();
            }
        }
        //-----------------------------------------------------------------//
        private string getValidStringInput()
        {
            string userStringInput = Console.ReadLine(); ;
            bool isInvalidString = true;
             
            while(isInvalidString)
            {
                isInvalidString = false;
                foreach(char currentChar in userStringInput)
                {
                    if (!char.IsDigit(currentChar) || !char.IsLetter(currentChar)) 
                    {
                        Console.WriteLine("License number can only consist of letters and numbers, please input again: ");
                        userStringInput = Console.ReadLine();
                        isInvalidString = true;
                        break;
                    }
                }
            }
            return userStringInput;
        }
    }
}
