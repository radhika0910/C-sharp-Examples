using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationSystem
{
    

    public delegate void BalanceExceededHandler(int withdrawalAmount, decimal currentBalance);

    public class BankAccount
    {
        public event BalanceExceededHandler OnBalanceExceeded;

        public decimal Balance { get; private set; }

        public BankAccount(decimal initialBalance)
        {
            Balance = initialBalance;
        }

        public void Withdraw(int amount)
        {
            if (amount > Balance)
            {
                if (OnBalanceExceeded != null)
                {
                    OnBalanceExceeded(amount, Balance);
                }
            }
            else
            {
                Balance -= amount;
                Console.WriteLine($"Withdrawal of {amount} successful. New balance: {Balance:C}");
            }
        }
    }

    public class NotificationSystem
    {
        public static void Main(string[] args)
        {
            BankAccount account = new BankAccount(1000m);

            account.OnBalanceExceeded += Account_OnBalanceExceeded;

            account.Withdraw(500);
            account.Withdraw(1200);
            account.Withdraw(200);

            Console.ReadKey();
        }

        private static void Account_OnBalanceExceeded(int withdrawalAmount, decimal currentBalance)
        {
            Console.WriteLine($"ERROR: Insufficient funds. Withdrawal amount: {withdrawalAmount}, Current balance: {currentBalance:C}");
        }
    }
}
