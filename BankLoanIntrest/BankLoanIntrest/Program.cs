using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankLoanIntrest
{

    public class LoanCalculator
    {
        // Personal Loan Calculation
        public double CalculateInterest(double principal, double annualInterestRate, int loanTermYears)
        {
            double monthlyInterestRate = annualInterestRate / 1200; // Convert annual rate to monthly
            int loanTermMonths = loanTermYears * 12;

            return principal * monthlyInterestRate * loanTermMonths;
        }

        // Home Loan Calculation with Discount
        public double CalculateInterest(double principal, double annualInterestRate, int loanTermYears, double discountPercentage)
        {
            double monthlyInterestRate = annualInterestRate / 1200;
            int loanTermMonths = loanTermYears * 12;

            double interest = principal * monthlyInterestRate * loanTermMonths;
            double discountAmount = interest * (discountPercentage / 100);

            return interest - discountAmount;
        }

        // Custom Loan Calculation with Extra Parameters
        public double CalculateInterest(double principal, double annualInterestRate, int loanTermYears, double extraFee, bool applyCompoundInterest)
        {
            double monthlyInterestRate = annualInterestRate / 1200;
            int loanTermMonths = loanTermYears * 12;

            double interest = principal * monthlyInterestRate * loanTermMonths;

            if (applyCompoundInterest)
            {
                double compoundInterest = 0;
                double currentPrincipal = principal;

                for (int i = 0; i < loanTermMonths; i++)
                {
                    double monthlyInterest = currentPrincipal * monthlyInterestRate;
                    compoundInterest += monthlyInterest;
                    currentPrincipal += monthlyInterest;
                }
                interest = compoundInterest;
            }

            return interest + extraFee;
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            LoanCalculator calculator = new LoanCalculator();

            // Personal Loan
            double personalLoanInterest = calculator.CalculateInterest(10000, 5.0, 5);
            Console.WriteLine($"Personal Loan Interest:{personalLoanInterest:C2}");

            // Home Loan with Discount
            double homeLoanInterest = calculator.CalculateInterest(200000, 3.5, 30, 1.0); // 1% discount
            Console.WriteLine($"Home Loan Interest with Discount:{homeLoanInterest:C2}");

            // Custom Loan with Extra Parameters
            double customLoanInterest = calculator.CalculateInterest(5000, 7.0, 3, 100, true); 
            Console.WriteLine($"Custom Loan Interest:{customLoanInterest:C2}");
        }
    }
}
