using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Xml.Linq;

class program
{
    static List<int> AccountID = new List<int>();
    static List<String> CustomerName = new List<String>();
    static List<int> PIN = new List<int>();
    static List<double> Balance = new List<double>();

    static void AddAccount()
    {
        Console.WriteLine("enter ID ");
        int ID = int.Parse(Console.ReadLine());
        AccountID.Add(ID);

        Console.WriteLine("enter CustomerName ");
        string cname = (Console.ReadLine());
        CustomerName.Add(cname);

        Console.WriteLine("enter PIN ");
        int pin = int.Parse(Console.ReadLine());
        PIN.Add(pin);

        Console.WriteLine("enter Balance ");
        int balance = int.Parse(Console.ReadLine());
        Balance.Add(balance);
    }

    static void DisplayAccounts()
    {
        for (int i = 0; i < AccountID.Count; i++)
        {
            Console.WriteLine(AccountID[i]);
            Console.WriteLine(CustomerName[i]);
            Console.WriteLine(PIN[i]);
            Console.WriteLine(Balance[i]);
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
        Console.WriteLine("Enter ID person you want to withdraw from");
        int idnum = int.Parse(Console.ReadLine());

        bool found = false;

        for (int i = 0; i < AccountID.Count; i++)
        {
            if (AccountID[i] == idnum)
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
            Console.WriteLine("Account not found");
        }
    }

    static void Deposit(int denum)
    {
        Console.WriteLine(" Enter ID person you want to Deposit to ");
        int idnum = int.Parse(Console.ReadLine());
        bool found = false;


        for (int i = 0; i < AccountID.Count; i++)
        {

            if (AccountID[i] == idnum )
            {
                found = true;

                if (denum > 0)
                {
                    Balance[i] += denum;
                    Console.WriteLine(" DONE ");
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
        for (int i = 0; i < AccountID.Count; i++)
        {
            if (AccountID[i] == idnumber)
            {
                Console.WriteLine(Balance[i]);
            }
        }

    }

    static void TransferMoney(int trnsnum)
    {
        Console.WriteLine("enter your AccountID ");
        int idacc = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the account number of the person you want the money to go to ");
        int tansid = int.Parse(Console.ReadLine());

        int senderIndex = -1;
        int receiverIndex = -1;

        for (int i = 0; i < AccountID.Count; i++)
        {
            if (AccountID[i] == idacc && trnsnum <= Balance[i])
            {
                senderIndex = i;
            }
            if (AccountID[i] == tansid)
            {
                receiverIndex = i;
            }
        }
        if (senderIndex != -1 && receiverIndex != -1)
        {
            Balance[senderIndex] -= trnsnum;
            Balance[receiverIndex] += trnsnum;
        }
        else
        {
            Console.WriteLine(" ERROR ");
        }
    }

    static void UpdateAccount()
    {
        Console.WriteLine("enter your account id you want to update ");
        int upacc = int.Parse(Console.ReadLine());

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

                Console.WriteLine(" Enter new Balance ");
                int neblance = int.Parse(Console.ReadLine());
                Balance[i] = neblance;
            }
        }
    }
    //
    //
    static void DeleteAccount()
    {
        Console.WriteLine(" enter your account id you want to remove ");
        int reacc = int.Parse(Console.ReadLine());

        for (int i = 0; i < AccountID.Count; i++)
        {
            if (AccountID[i] == reacc)
            {
                AccountID.RemoveAt(i);
                CustomerName.RemoveAt(i);
                PIN.RemoveAt(i);
                Balance.RemoveAt(i);
                break;
            }
        }

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


            Console.WriteLine("Enter number of operation ");
            Console.WriteLine("===== Bank System =====");

            Console.WriteLine("1. Add Account");
            Console.WriteLine("2. Display Accounts");
            Console.WriteLine("3. Search Account");
            Console.WriteLine("4. Deposit");
            Console.WriteLine("5. Withdraw");
            Console.WriteLine("6. Check Balance");
            Console.WriteLine("7. Transfer Money");
            Console.WriteLine("8. Update Account");
            Console.WriteLine("9. Delete Account");
            Console.WriteLine("0. Exit");

            Console.WriteLine("Choose:");
            int numop = int.Parse(Console.ReadLine());


            switch (numop)
            {
                case 1:
                    AddAccount();
                    break;

                case 2:
                    DisplayAccounts();
                    break;

                case 3:
                    Console.WriteLine("Enter the ID you want to search for.\r\n");
                    int num = int.Parse(Console.ReadLine());
                    SearchAccount(num);
                    break;

                case 4:
                    Console.WriteLine("Enter the amount you want to withdraw.\r\n");
                    int winum = int.Parse(Console.ReadLine());
                    Withdraw(winum);
                    break;

                case 5:
                    Console.WriteLine("Enter the amount you want to Deposit it.\r\n");
                    int denum = int.Parse(Console.ReadLine());
                    Deposit(denum);
                    break;

                case 6:
                    Console.WriteLine("Enter the account id whose balance you want to check.\r\n");
                    int idnumber = int.Parse(Console.ReadLine());
                    CheckBalance(idnumber);
                    break;

                case 7:
                    Console.WriteLine("Enter the amount you want to transfer.\r\n");
                    int trnsnum = int.Parse(Console.ReadLine());
                    TransferMoney(trnsnum);
                    break;

                case 8:
                    UpdateAccount();
                    break;

                case 9:
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
    }
}