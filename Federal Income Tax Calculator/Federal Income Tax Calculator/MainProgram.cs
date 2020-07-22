using System;

namespace Federal_Income_Tax_Calculator {
    class MainProgram {
        static void Main(string[] args) {

            var calculator = new CalculatorClass();
            string givenValue;

            Console.WriteLine("Hello, welcome to the Federal Income Tax Calculator\n");

            do {

                Console.WriteLine("Enter your income or 0 to stop entering income: ");
                givenValue = Console.ReadLine();

                calculator.IncrementGrossIncome(Convert.ToDouble(givenValue));

            } while (Convert.ToDouble(givenValue) != 0);

            Console.WriteLine("Do you want to use the standard deduction $12,200 (Y/N): ");
            givenValue = Console.ReadLine();

            if (givenValue == "y" || givenValue == "Y") {

                calculator.UserChoosesStandardDeduction();
            }
            else {

                Console.WriteLine("Do you want to use Itemization (Y/N): ");
                givenValue = Console.ReadLine();

                if (givenValue == "y" || givenValue == "Y") {

                    do {

                        Console.WriteLine("Enter your deductions or 0 to stop entering deductions: ");
                        givenValue = Console.ReadLine();

                        calculator.IncrementTotalDeductions(Convert.ToDouble(givenValue));

                    } while (Convert.ToDouble(givenValue) != 0);
                }
            }

            calculator.SetAdjustedGrossIncome();
            calculator.CalculateTaxesOwedAtEachTaxBracket();

            calculator.DisplayTaxOwedAtEachBracket();
            calculator.DisplayTotalTaxOwed();
            calculator.DisplayTotalTaxesAsPercentOfAdjustedGrossIncome();
            calculator.DisplayTotalTaxesAsPercentOfGrossIncome();
        }
    }
}
