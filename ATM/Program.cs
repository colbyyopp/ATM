using System;

public class cardHolder
{
    String cardNum;
    int pin;
    String firstName;
    String lastName;
    double balance;

    public cardHolder(string cardNum, int pin, string firstName, string lastName, double balance) //constructor - passing in variables we declared and passing them into this constructor and substantiating them as new objects
    {
        this.cardNum = cardNum;
        this.pin = pin;
        this.firstName = firstName;
        this.lastName = lastName;
        this.balance = balance;
    }

    public String getNum() //getters
    {
        return cardNum;
    }

    public int getPin()
    {
        return pin;
    }

    public String getFirstName()
    {
        return firstName;
    }

    public String getLastName()
    {
        return lastName;

    }
    public double getBalance()
    {
        return balance;
    }

    //setters
    public void setNum(String newCardNum)
    {
        cardNum = newCardNum;
    }

    public void setPin(int newPin)
    {
        pin = newPin;

    }
    public void setFirstName(String newFirstName)
    {
        firstName = newFirstName;
    }
    public void setLastName(String newLastName)
    { 
        lastName = newLastName;
    }
    public void setBalance(double newBalance)
    {
        balance = newBalance;
    }

    public static void Main(String[] args)
    {
        void printOptions()
        {
            Console.WriteLine("Please choose from one of the following options...");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Show Balance");
            Console.WriteLine("4. Exit");

        }

        void deposit(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to deposit? ");
            double deposit = Double.Parse(Console.ReadLine()); //parse pulls the data from string and turns it into a double
            currentUser.setBalance(currentUser.getBalance() + deposit);
            Console.WriteLine("Thank you for your $$. Your new balance is: " + currentUser.getBalance());
        }

        void withdraw(cardHolder currentUser)
        {
            Console.WriteLine("How much $$ would you like to withdraw: ");
            double withdrawal = Double.Parse(Console.ReadLine());
            //check is user has enough $$ for request
            if(currentUser.getBalance() < withdrawal)
            {
                Console.WriteLine("Insufficient balance :(");
            } else
            {
            
                currentUser.setBalance(currentUser.getBalance() - withdrawal);
                Console.WriteLine("You're good to go! Thank you :)");
            }
        }

        void balance(cardHolder currentUser)
        {
            Console.WriteLine("Current balance: " + currentUser.getBalance());
        }

        List<cardHolder> cardHolders= new List<cardHolder>(); //adding users
        cardHolders.Add(new cardHolder("321321321321321", 3212, "john", "griffith", 150.31));
        cardHolders.Add(new cardHolder("654654654654654", 6545, "Mike", "Wazowski", 654.21));
        cardHolders.Add(new cardHolder("987987987987987", 9878, "steve", "madden", 987.33));

        //prompt user
        Console.WriteLine("Welcome to SimpleATM");
        Console.WriteLine("Please insert debit card: ");
        String debitCardNum = "";
        cardHolder currentUser;

        while(true)
        {
            try
            {
                debitCardNum= Console.ReadLine();
                //check against database
                currentUser = cardHolders.FirstOrDefault(a => a.cardNum == debitCardNum);
                if (currentUser != null) { break; }
                else { Console.WriteLine("Card not recognized. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Card not recognized. Please try again");
            }
        }
        Console.WriteLine("Please enter your PIN: ");
        int userPin = 0;
        while(true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine()); //parsing the string into integer
                //check against database
                if (currentUser.getPin() == userPin) { break; }
                else { Console.WriteLine("Incorrect PIN. Please try again"); }
            }
            catch
            {
                Console.WriteLine("Incorrect PIN. Please try again");
            }
        }

        Console.WriteLine("Welcome " + currentUser.getFirstName() + " :)");
        int option = 0;
        do
        {
            printOptions();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if(option ==1) { deposit(currentUser);  }
            else if(option==2) { withdraw(currentUser); }
            else if (option == 3) { balance(currentUser); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);
        Console.WriteLine("thank you. have a nice day");
    }
}