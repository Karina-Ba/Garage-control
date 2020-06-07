using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                Console.Clear();
            }
        }
        //-----------------------------------------------------------------//
        private void printMenu()
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
        private void printVehicleMenu()
        {
            Console.Write(@"Please choose the vehicle type:
1. Electric car.
2. Fuel car.
3. Electric motorcycle.
4. Fuel motorcycle
5. Truck
Choice: ");
        }
        //-----------------------------------------------------------------//
        private int printMenuForLicensePlatesGetUserChoice()
        {
            Console.Write(@"Menu options:
1. Filter by state in the garage
2. No filtering
Choice: ");
            int choiceNum = getValidUserInputChoice(1, 2);

            return choiceNum;
        }
        //-----------------------------------------------------------------//
        private int printWrongInputMenuGetUserInput()
        {
            Console.WriteLine(@"Incorrect input, please choose: 
1. Input again
2. Go back to menu
Choice: ");
            int choiceNum = getValidUserInputChoice(1, 2);

            return choiceNum;
        }
        //-----------------------------------------------------------------//
        private void backToMenuPause()
        {
            Console.WriteLine("Press any key to go back to menu");
            Console.ReadKey();
        }
        //-----------------------------------------------------------------//
        private void doActionUserAsked(int i_UserChoice, out bool i_UserExit, Garage i_Garage)
        {
            i_UserExit = false;
            Console.Clear();

            switch(i_UserChoice)
            {
                case 1:
                    this.getVehicleInformation(i_Garage);
                    break;
                case 2:
                    this.printLicensePlatesInGarage(printMenuForLicensePlatesGetUserChoice(), i_Garage);
                    break;
                case 3:
                    this.changeVehicleStateInGarage(i_Garage);
                    break;
                case 4:
                    this.fillTiresOfVehicle(i_Garage);
                    break;
                case 5:
                    this.fuelVehicle(i_Garage);
                    break;
                case 6:
                    this.chargeVehicle(i_Garage);
                    break;
                case 7:
                    this.printVehicleInformationFromGarage(i_Garage);
                    break;
                case 8:
                    i_UserExit = true;
                    break;
            }
        }
        //-----------------------------------------------------------------//
        private void getVehicleInformation(Garage i_Garage)
        {
            string ownerPhoneNumber, ownerName, model, wheelsmanufactor;
            Garage.InformationOfVehicle informationOfVehicle = null;
            string licenseNumber = getLicenseNumberFromUser();

            if (i_Garage.VehiclesInTheGarage.TryGetValue(licenseNumber, out informationOfVehicle))
            {
                Console.WriteLine("This license number already exists in the garage, changing state to In Repair");
                informationOfVehicle.State = Garage.InformationOfVehicle.eVehicleStateInGarage.InRepair;
            }
            else
            {
                //place to enter a presence if needed

                this.printVehicleMenu();
                VehicleAllocator.eVehicleType vehicleType = (VehicleAllocator.eVehicleType)getValidUserInputChoice(1, 5);
                Console.Write("Please enter the model: ");
                model = getValidStringInput();
                Console.Write("Please enter wheels manufactor name: ");
                wheelsmanufactor = getValidStringInput();
                Vehicle newVehicle = VehicleAllocator.AllocateVehicle(vehicleType, licenseNumber, model, wheelsmanufactor);
                completeVehicleInformation(ref newVehicle, vehicleType);
                getOwnerInformation(out ownerName, out ownerPhoneNumber);
                informationOfVehicle = new Garage.InformationOfVehicle(ownerName, ownerPhoneNumber, newVehicle);
                i_Garage.VehiclesInTheGarage.Add(licenseNumber, informationOfVehicle);
            }
        }
        //-----------------------------------------------------------------//
        private string getLicenseNumberFromUser()
        {
            Console.Write("Please enter the license number of the vehicle: ");
            string licenseNumber = getValidStringInput();

            return licenseNumber;
        }
        //-----------------------------------------------------------------//
        private void completeVehicleInformation(ref Vehicle io_Vehicle, VehicleAllocator.eVehicleType i_VehicleType)
        {
            List<string> questions = VehicleAllocator.GetQuestionsAboutVehicle(i_VehicleType, io_Vehicle);
            List<string> answers = new List<string>(questions.Capacity);
            bool isWrongAnswer = true;

            foreach(string currentString in questions)
            {
                Console.Write(currentString);
                answers.Add(Console.ReadLine());
            }

            while(isWrongAnswer)
            {
                try
                {
                    VehicleAllocator.SetAnswersAboutVehicle(i_VehicleType, io_Vehicle, answers);
                    isWrongAnswer = false;
                }
                catch (Exception exception)
                {
                    while (exception != null)
                    {
                        Console.WriteLine(exception.Message);
                        answers[int.Parse(exception.Source)] = Console.ReadLine();
                        exception = exception.InnerException;
                    }
                }
            }
        }
        //-----------------------------------------------------------------//
        private void getOwnerInformation(out string o_ownerName, out string o_ownerPhoneNumber)
        {
            uint ownerPhone;
            bool isValidNameString = false;
            Console.Write("Please Enter your name: ");
            o_ownerName = Console.ReadLine();

            while (!isValidNameString)
            {
                isValidNameString = true;
                foreach (char currentChar in o_ownerName)
                {
                    if(!char.IsLetter(currentChar) && !(currentChar == ' '))
                    {
                        isValidNameString = false;
                        Console.Write("Only letters and spaces allowed, please enter your name again: ");
                        o_ownerName = Console.ReadLine();
                        break;
                    }
                }
            }

            Console.Write("Please enter your phone number: ");
            o_ownerPhoneNumber = Console.ReadLine();

            while(!uint.TryParse(o_ownerPhoneNumber, out ownerPhone))
            {
                Console.Write("Phone can only consist of number, please enter again: ");
                o_ownerPhoneNumber = Console.ReadLine();
            }
        }
        //-----------------------------------------------------------------//
        private void printLicensePlatesInGarage(int i_UserChoice, Garage i_Garage)
        {
            StringBuilder licensePlates;
            Garage.InformationOfVehicle.eVehicleStateInGarage state = Garage.InformationOfVehicle.eVehicleStateInGarage.Default;

            if (i_UserChoice == 1)
            {
                state = getVehicleStateFromUser(); 
            }

            licensePlates = i_Garage.GetLicensePlatesByState(state);
            if (licensePlates.Length != 0)
            {
                Console.WriteLine(licensePlates.ToString());
            }
            else
            {
                Console.WriteLine("No vehicles with this state in the garage.");
            }

            this.backToMenuPause();
        }
        //-----------------------------------------------------------------//
        private Garage.InformationOfVehicle.eVehicleStateInGarage getVehicleStateFromUser()
        {
            Garage.InformationOfVehicle.eVehicleStateInGarage state;

            Console.Clear();
            Console.Write(@"Choose the desired state: 
1. In repair
2. Repaired
3. Paid
Choice: ");
            int choiceNum = getValidUserInputChoice(1, 3);
            state = (Garage.InformationOfVehicle.eVehicleStateInGarage)choiceNum;

            return state;
        }
        //-----------------------------------------------------------------//
        private void changeVehicleStateInGarage(Garage i_Garage)
        {
            string licenseNumber = this.getLicenseNumberFromUser();
            Garage.InformationOfVehicle.eVehicleStateInGarage state = this.getVehicleStateFromUser();
            int userChoice = 1;

            while (userChoice == 1)
            {
                try
                {
                    i_Garage.ChangeVehicleState(licenseNumber, state);
                    userChoice = 2;
                    Console.WriteLine("Vehicle state has been changed successfully!");
                }
                catch (ArgumentException exception)
                {
                    Console.WriteLine(exception.Message);
                    userChoice = this.printWrongInputMenuGetUserInput();
                }
            }

            this.backToMenuPause();
        }
        //-----------------------------------------------------------------//
        private void fillTiresOfVehicle(Garage i_Garage)
        {
            string licenseNumber = this.getLicenseNumberFromUser();
            int userChoice = 1;

            while (userChoice == 1)
            {
                try
                {
                    i_Garage.FillTiresToMax(licenseNumber);
                    userChoice = 2;
                    Console.WriteLine("Tires have been inflated to the maximum capacity successfully!");
                }
                catch (ValueOutOfRangeException exception)
                {
                    Console.WriteLine(exception.Message);
                    userChoice = this.printWrongInputMenuGetUserInput();
                }
            }

            this.backToMenuPause();
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
                    if (!char.IsDigit(currentChar) && !char.IsLetter(currentChar)) 
                    {
                        Console.Write("Input string can only consist of letters and numbers, please input again: ");
                        userStringInput = Console.ReadLine();
                        isInvalidString = true;
                        break;
                    }
                }  
            }

            return userStringInput;
        }
        //-----------------------------------------------------------------//
        private int getValidUserInputChoice(int i_MinValue, int i_MaxValue)
        {
            string userInputChoice = Console.ReadLine();
            int userInputNumerical = 0;

            while (!int.TryParse(userInputChoice, out userInputNumerical) ||
                   ValueOutOfRangeException.ValueOutOfRange(userInputNumerical, i_MaxValue, i_MinValue))
            {
                Console.WriteLine("Choice is out of boundaries, Please enter again: ");
                userInputChoice = Console.ReadLine();
            }

            return userInputNumerical;
        }
        //-----------------------------------------------------------------//































        //--------------------------------------------------------Matan Era---------------------------------------------//
        //No entry for working people
        //guarded by a furious Pug dog("Woof woof")
        private bool getValidVehicleFromGarage(Garage i_Garage, out Garage.InformationOfVehicle o_VehicleInfromation)
        {
            bool found = false;
            int userChoice;
            string licenseNumber;
            licenseNumber = getLicenseNumberFromUser();
            o_VehicleInfromation = null;
            //from here
            while(!i_Garage.VehiclesInTheGarage.TryGetValue(licenseNumber, out o_VehicleInfromation))
            {
                userChoice = this.printWrongInputMenuGetUserInput();
                if (userChoice.Equals(1))
                {
                    licenseNumber = getLicenseNumberFromUser();
                }
                else
                {
                    break;
                }
                //to here  ------- A function of its own - repetetive print :::: Which one?
            }
            if(o_VehicleInfromation != null)
            {
                found = true;
            }
            return found;
        }


        private void printFuelMenu()
        {
            Console.Write(@"Please choose the fuel type:
1. Octan95,
2. Octan96,
3. Octan98,
4. Soler
Choice: ");
        }

        private void fuelVehicle(Garage i_Garage)
        {
            Garage.InformationOfVehicle vehicleToFuel;
            int userChoice;
            int howMuchToAdd;
            if(i_Garage.isEmptyGarage())
            {
                Console.WriteLine("The garage is empty");
                this.backToMenuPause();
            }
            else
            {
                if(!getValidVehicleFromGarage(i_Garage, out vehicleToFuel))
                {
                    this.backToMenuPause();
                }
                else
                {
                    if(vehicleToFuel.Vehicle.Engine is Engine.FuelEngine)
                    {
                        howMuchToAdd = getValidUserPositiveNumberInput("Please enter how much fuel you want to add to the vehicle");
                        Console.WriteLine("Please enter the type of fuel you want to add");
                        this.printFuelMenu();
                        userChoice = getValidUserInputChoice(1, 4);
                        try
                        {
                            (vehicleToFuel.Vehicle.Engine as Engine.FuelEngine).Refuel(howMuchToAdd, (Engine.FuelEngine.eFuelType)userChoice);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("This vehicle cannot be fueled");
                        this.backToMenuPause();
                    }
                }
            }
        }

        private int getValidUserPositiveNumberInput(string i_Message)
        {
            int numberToReturn;
            string userInput;
            Console.WriteLine(i_Message);
            userInput = Console.ReadLine();
            while(!int.TryParse(userInput, out numberToReturn) || numberToReturn < 1) 
            {
                Console.WriteLine("Invalid number, pleasae try again: ");
                userInput = Console.ReadLine();
            }
            return numberToReturn;
        }

        private void chargeVehicle(Garage i_Garage)
        {
            Garage.InformationOfVehicle vehicleToCharge;
            int howMuchToAdd;
            if (i_Garage.isEmptyGarage())
            {
                Console.WriteLine("The garage is empty");
                this.backToMenuPause();
            }
            else
            {
                if (!getValidVehicleFromGarage(i_Garage, out vehicleToCharge))
                {
                    this.backToMenuPause();
                }
                else
                {
                    if (vehicleToCharge.Vehicle.Engine is Engine.ElectricEngine)
                    {
                        howMuchToAdd = getValidUserPositiveNumberInput("Please enter how much you want to charge the vehicle");
                        try
                        {
                            (vehicleToCharge.Vehicle.Engine as Engine.ElectricEngine).ChargeBattery(howMuchToAdd);
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine(exception.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("This vehicle cannot be charged");
                        this.backToMenuPause();
                    }
                }

            }
        }

        private void printVehicleInformationFromGarage(Garage i_Garage)
        {
            Garage.InformationOfVehicle userVehicle;
            if(i_Garage.isEmptyGarage())
            {
                Console.WriteLine("The garage is empty");
                this.backToMenuPause();
            }
            else
            {
                if(!getValidVehicleFromGarage(i_Garage, out userVehicle))
                {
                    this.backToMenuPause();
                }
                else
                {
                    Console.WriteLine(userVehicle.ToString());
                }

            }
        }

    }

    
}
