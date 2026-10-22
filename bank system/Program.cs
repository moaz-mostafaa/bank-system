using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Xml.Linq;


class program
{
    static List<int> AccountID = new List<int>();
    static List<String> CustomerName = new List<String>();
    static List<int> PIN = new List<int>();
    static List<double> Balance = new List<double>();
    static DateTime banUntil = DateTime.MinValue;

    static void SignIn()
    {
        bool inp1 = false;
        bool inp2 = false;
        int num = 0;
        Console.WriteLine("enter your name ");
        string username = Console.ReadLine();
        Console.WriteLine("enter PIN ");
        int.TryParse(Console.ReadLine(), out int pin);

        for (int i = 0; i < CustomerName.Count; i++)
        {
            if (username == CustomerName[i])
            {
                inp1 = true;
                num = i;
            }
        }
        if (pin == PIN[num])
        {
            inp2 = true;
        }
        if (inp1 == inp2 == true)
        {
            Console.WriteLine($" welcome {CustomerName[num]} ");
        }
        else
        {
            if (inp1 == false) Console.WriteLine("There is a problem with the name isn't there. ");
            if (inp2 = false) Console.WriteLine("The number is incorrect");
        }
    }

    static int numattempts = 3;
    static void SignUp()
    {
        int numattempts = 3;
        bool found = true;
        string usename;

        while (found && numattempts > 0)
        {
            found = false;

            Console.WriteLine("Enter your name:");
            usename = Console.ReadLine();

            for (int i = 0; i < CustomerName.Count; i++)
            {
                if (usename == CustomerName[i])
                {
                    found = true;
                    numattempts--;

                    Console.WriteLine("This username is taken. Try another one.");
                    Console.WriteLine($"Remaining attempts: {numattempts}");
                    break;
                }
            }

            if (numattempts == 0)
            {
                Console.WriteLine("Too many attempts. Application will close.");
                Environment.Exit(0);
            }
            if (found == false)
            {
                AddAccount(usename);
            }
        }
    }
    
    static void AddAccount(string usename)
    {

         Console.WriteLine("enter ID ");
         int.TryParse(Console.ReadLine() , out int ID );
         bool found = false;

        for (int i = 0 ; i < AccountID.Count ;i++)
        {
            if (AccountID[i] == ID)
            {
                found = true;
            }
        }

        if (found == true) Console.WriteLine(" The account already exists ");

        else
        {
            AccountID.Add(ID);

            CustomerName.Add(usename);

            Console.WriteLine("enter PIN ");
            int.TryParse(Console.ReadLine(), out int pin);
            PIN.Add(pin);

            Console.WriteLine("enter Balance ");
            int.TryParse(Console.ReadLine(), out int balance);
            if (balance > 0)
            {
                Balance.Add(balance);
            }
            else Console.WriteLine("The number must be greater than zero.");
            
        }
    }


    static void SearchAccount(int num)
    {
        bool found = false;

        for (int i = 0; i < AccountID.Count; i++)
        {
            if (AccountID[i] == num)
            {
                Console.WriteLine("found");
                found = true;
                break;
            }
        }

        if (found == false)
        {
            Console.WriteLine("not found");
        }
    }
   
    static void Withdraw(int winum)
    {
        Console.WriteLine(" Enter ID person you want to withdraw from ");
        if (!int.TryParse( Console.ReadLine(), out int idnum))
        {
            Console.WriteLine(" Invalid ID Please enter a number ");
            return;
        }

        Console.WriteLine(" enter PIN ");
        if (!int.TryParse(Console.ReadLine(), out int pinnum))
        {
            Console.WriteLine(" Invalid PIN Please enter a PIN number ");
        }

        
        bool found = false;

        for (int i = 0; i < AccountID.Count; i++)
        {
            if (AccountID[i] == idnum && PIN[i] == pinnum)
            {
                found = true;

                if ( Balance[i] >= winum)
                {
                    Balance[i] -= winum ;
                    Console.WriteLine(" DONE " );
                }
                else
                {
                    Console.WriteLine(" Insufficient balance ");
                }

                break;
            }
        }

        if (found == false)
        {
            Console.WriteLine(" Account not found ");
        }
    }

    static void Deposit(int denum)
    {
        Console.WriteLine(" Enter ID person you want to Deposit to ");
        if (!int.TryParse(Console.ReadLine() , out int idnum))
        {
            Console.WriteLine("Invalid ID Please enter a number");
        }

        bool found = false;


        for (int i = 0; i < AccountID.Count; i++)
        {

            if (AccountID[i] == idnum )
            {
                found = true;

                if (denum > 0)
                {
                    Balance[i] += denum;
                    Console.WriteLine(" DONE \n");
                }

                else
                {
                    Console.WriteLine("Enter a valid amount");
                }
            }
        }
        if (found == false)
        {
            Console.WriteLine("Account not found");
        }

    }

    static void CheckBalance(int idnumber)
    {
        bool found = false;

        Console.WriteLine(" enter PIN ");
        if (!int.TryParse(Console.ReadLine(), out int pinnum))
        {
            Console.WriteLine(" Invalid PIN Please enter a correct PIN number ");
            return;
        }

        for (int i = 0; i < AccountID.Count; i++)
        {
            if (AccountID[i] == idnumber && PIN [i] == pinnum)
            {
                Console.WriteLine(Balance[i]);
                found = true;
            }
        }
        if (found == false) Console.WriteLine(" account not found or PIN nor correct ");

    }

    static void TransferMoney(int trnsnum)
    {
        bool f1 = false;
        bool f2 = false;

        Console.WriteLine(" enter your AccountID ");

        if (!int.TryParse(Console.ReadLine(), out int idacc))
        {
            Console.WriteLine("Invalid ID Please enter a number ");
            return;
        }

        Console.WriteLine(" Enter the account number of the person you want the money to go to ");
        if (!int.TryParse(Console.ReadLine(), out int tansid))
        {
            Console.WriteLine("Invalid account number Please enter a number ");
            return;
        }

        

        int senderIndex = -1;
        int receiverIndex = -1;

        for (int i = 0; i < AccountID.Count; i++)
        {
            if (AccountID[i] == idacc && trnsnum <= Balance[i])
            {
                senderIndex = i;
                f1 = true;
            }
            if (AccountID[i] == tansid)
            {
                receiverIndex = i;
                f2 = true;
            }
        }
        if (senderIndex == receiverIndex && senderIndex != -1)
        {
            Console.WriteLine("You cannot transfer money to the same account.");
        }

        if (senderIndex != -1 && receiverIndex != -1 )
        {
            Balance[senderIndex] -= trnsnum;
            Balance[receiverIndex] += trnsnum;
        }
        else
        {
            if (f1 == false) Console.WriteLine("acc not found or The amount you want to withdraw is greater than the amount in your account.");
            if (f2 == false) Console.WriteLine("acc not found ");
        }
    }

    static void UpdateAccount()
    {
        Console.WriteLine("enter your account id you want to update ");
        if (!int.TryParse(Console.ReadLine(), out int upacc))
        {
            Console.WriteLine("Invalid account id Please enter a number");
            return;
        }

        bool found = false;

        for (int i = 0; i < AccountID.Count ; i++)
        {
            if (AccountID[i] == upacc)
            {
                Console.WriteLine(" Enter new Name ");
                string nename = Console.ReadLine();
                CustomerName[i] = nename;

                Console.WriteLine(" Enter new PIN ");
                int nepin = int.Parse(Console.ReadLine());
                PIN[i] = nepin;
                found = true;
            }
        }

        if (found == false) Console.WriteLine("account not found");
    }
    
    static void DeleteAccount()
    {
        Console.WriteLine(" enter your account id you want to remove ");
        if (!int.TryParse(Console.ReadLine(), out int reacc))
        {
            Console.WriteLine(" Invalid account id Please enter a number ");
            return;
        }
        bool found = false;

        for (int i = 0; i < AccountID.Count; i++)
        {
            if (AccountID[i] == reacc)
            {
                found = true;
                AccountID.RemoveAt(i);
                CustomerName.RemoveAt(i);
                PIN.RemoveAt(i);
                Balance.RemoveAt(i);
                break;
            }
        }
        if (found == false) Console.WriteLine("account not found");
    }

    static void ExitProgram()
    {
        Console.WriteLine(" Goodbye! ");
        Environment.Exit( 0 );
    }
    
    static void Main()
    {

        while (true)
        {
            Console.WriteLine("===== Welcome to ATM =====\r\n");
            Console.WriteLine("1. Sign In ");
            Console.WriteLine("2. Sign Up ");
            Console.WriteLine("Enter number ");
            int.TryParse(Console.ReadLine(), out int opnum);
            if (opnum == 1) SignIn();
            if (opnum == 2) SignUp();


            Console.WriteLine();

            Console.WriteLine("Enter number of operation \n ");
            Console.WriteLine("===== Bank System =====");

           
            Console.WriteLine("1. Search Account");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Deposit");
            Console.WriteLine("4. Check Balance");
            Console.WriteLine("5. Transfer Money");
            Console.WriteLine("6. Update Account");
            Console.WriteLine("7. Delete Account");
            Console.WriteLine("0. Exit");

            Console.WriteLine("Choose: ");

            if (int.TryParse(Console.ReadLine(), out int numop))
            {
                switch (numop)
                {

                    case 1:
                        Console.WriteLine("Enter the ID you want to search for.\r\n");
                        if ( int.TryParse(Console.ReadLine() , out int num))
                        {
                            SearchAccount(num);
                        }
                        else Console.WriteLine("Please enter a number.");
                        break;

                    case 2:
                        Console.WriteLine("Enter the amount you want to withdraw.\r\n");
                        if (int.TryParse(Console.ReadLine(), out int winum) && winum > 0)
                        {
                            Withdraw(winum);
                        }
                        else
                        {
                            Console.WriteLine(" Invalid amount Please enter a number or check number is postive ");
                        }
                        break;

                    case 3:
                        Console.WriteLine("Enter the amount you want to Deposit it.\r\n");
                        if (int.TryParse(Console.ReadLine(), out int denum))
                        {
                            Deposit(denum);
                        }
                        else
                        {
                            Console.WriteLine("Invalid amount  Please enter a number ");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Enter the account id whose balance you want to check.\r\n");
                        if (int.TryParse(Console.ReadLine(), out int idnumber))
                        {
                            CheckBalance(idnumber);
                        }
                        else
                        {
                            Console.WriteLine("Invalid id Please enter a number ");
                        }
                        break;

                    case 5:
                        Console.WriteLine("Enter the amount you want to transfer.\r\n");
                        if (int.TryParse(Console.ReadLine(), out int trnsnum) && trnsnum > 0 )
                        {
                            TransferMoney(trnsnum);
                        }
                        else
                        {
                            Console.WriteLine(" Invalid amount Please enter a number or check numper is postive ");
                        }
                        break;

                    case 6:
                        UpdateAccount();
                        break;

                    case 7:
                        DeleteAccount();
                        break;

                    case 0:
                        ExitProgram();
                        break;

                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }

        }
    }
}