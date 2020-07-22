using System;
using System.Collections.Generic;
using System.Text;

namespace Federal_Income_Tax_Calculator {
    public class CalculatorClass {

        private double _grossIncome = 0;
        private double _adjustedGrossIncome = 0;
        private double _totalDeductions = 0;
        
        private double _totalTaxes = 0;

        private double[] _taxesOwedAtEachTaxBracket = new double[7] { 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0 };
        private readonly int[] _taxBracketPercentages = new int[7] { 10, 12, 22, 24, 32, 35, 37 };

        public const int standardDeduction = 12200;

        private void CalculateTotalTaxes() {

            foreach (var value in _taxesOwedAtEachTaxBracket) {

                _totalTaxes += value;
            }
        }

        public void IncrementGrossIncome(double numberToIncrementBy) {

            _grossIncome += numberToIncrementBy;
        }

        public void IncrementTotalDeductions(double numberToIncrementBy) {

            _totalDeductions += numberToIncrementBy;
        }

        public void UserChoosesStandardDeduction() {

            _totalDeductions = standardDeduction;
        }

        public void SetAdjustedGrossIncome() {

            _adjustedGrossIncome = (_grossIncome - _totalDeductions);
        }

        public void CalculateTaxesOwedAtEachTaxBracket() {

            if (_adjustedGrossIncome < 9_700) {
                _taxesOwedAtEachTaxBracket[0] = _adjustedGrossIncome * .10;
            }
            else if (_adjustedGrossIncome < 39_475) {
                _taxesOwedAtEachTaxBracket[0] = 970;
                _taxesOwedAtEachTaxBracket[1] = (_adjustedGrossIncome - 9_700) * .12;
            }
            else if (_adjustedGrossIncome < 84_200) {
                _taxesOwedAtEachTaxBracket[0] = 970;
                _taxesOwedAtEachTaxBracket[1] = 3_573;
                _taxesOwedAtEachTaxBracket[2] = (_adjustedGrossIncome - 39_475) * .22;
            }
            else if (_adjustedGrossIncome < 160_725) {
                _taxesOwedAtEachTaxBracket[0] = 970;
                _taxesOwedAtEachTaxBracket[1] = 3_573;
                _taxesOwedAtEachTaxBracket[2] = 9_839.5;
                _taxesOwedAtEachTaxBracket[3] = (_adjustedGrossIncome - 84_200) * .24;
            }
            else if (_adjustedGrossIncome < 204_100) {
                _taxesOwedAtEachTaxBracket[0] = 970;
                _taxesOwedAtEachTaxBracket[1] = 3_573;
                _taxesOwedAtEachTaxBracket[2] = 9_839.5;
                _taxesOwedAtEachTaxBracket[3] = 18_366;
                _taxesOwedAtEachTaxBracket[4] = (_adjustedGrossIncome - 160_725) * .32;
            }
            else if (_adjustedGrossIncome < 510_300) {
                _taxesOwedAtEachTaxBracket[0] = 970;
                _taxesOwedAtEachTaxBracket[1] = 3_573;
                _taxesOwedAtEachTaxBracket[2] = 9_839.5;
                _taxesOwedAtEachTaxBracket[3] = 18_366;
                _taxesOwedAtEachTaxBracket[4] = 13_880;
                _taxesOwedAtEachTaxBracket[5] = (_adjustedGrossIncome - 204_100) * .35;
            }
            else {
                _taxesOwedAtEachTaxBracket[0] = 970;
                _taxesOwedAtEachTaxBracket[1] = 3_573;
                _taxesOwedAtEachTaxBracket[2] = 9_839.5;
                _taxesOwedAtEachTaxBracket[3] = 18_366;
                _taxesOwedAtEachTaxBracket[4] = 13_880;
                _taxesOwedAtEachTaxBracket[5] = 107_170;
                _taxesOwedAtEachTaxBracket[6] = (_adjustedGrossIncome - 510_300) * .37;
            }

            CalculateTotalTaxes();
        }

        public void DisplayTaxOwedAtEachBracket() {

            for (int x = 0; x < 7; x++) {

                Console.WriteLine($"Taxes at {_taxBracketPercentages[x]}%: ${_taxesOwedAtEachTaxBracket[x]}");
            }
        }

        public void DisplayTotalTaxOwed() {

            Console.WriteLine($"Total Taxes Owed: ${Math.Round(_totalTaxes, 1)} ");
        }

        public void DisplayTotalTaxesAsPercentOfAdjustedGrossIncome() {

            Console.WriteLine($"Taxes as a percentage of Adjusted Gross Income: {Math.Round((_totalTaxes / _adjustedGrossIncome) * 100, 1)}");
        }

        public void DisplayTotalTaxesAsPercentOfGrossIncome() {

            Console.WriteLine($"Taxes as a percentage of Gross Income: {Math.Round((_totalTaxes / _grossIncome) * 100, 1)}");
        }
    }
}
