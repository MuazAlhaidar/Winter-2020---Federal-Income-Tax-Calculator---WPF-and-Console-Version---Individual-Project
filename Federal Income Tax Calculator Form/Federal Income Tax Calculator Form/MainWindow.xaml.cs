using System;
using System.Windows;

namespace Federal_Income_Tax_Calculator_Form {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        CalculatorClass calculator = new CalculatorClass();

        public MainWindow() {
            InitializeComponent();
            radiobtnStandardDeduction.IsChecked = true;
        }

        private void BtnAddIncome_Click(object sender, RoutedEventArgs e) {

            if (!string.IsNullOrWhiteSpace(txtbxIncome.Text)) {
                calculator.IncrementGrossIncome(Convert.ToDouble(txtbxIncome.Text));
                txtbxTotalIncome.Text = calculator.GetGrossIncome().ToString();
            }
            else {
                MessageBox.Show("Failed to add Income\nPlease enter a value into the feilds");
            }
        }

        private void BtnAddItemization_Click(object sender, RoutedEventArgs e) {

            if (!string.IsNullOrWhiteSpace(txtbxItemization.Text)) {
                calculator.IncrementTotalDeductions(Convert.ToDouble(txtbxItemization.Text));
                txtbxTotalItemization.Text = calculator.GetTotalDeductions().ToString();
            }
            else {
                MessageBox.Show("Failed to add Itemization\nPlease enter a value into the feilds");
            }
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e) {

            if (radiobtnStandardDeduction.IsChecked == true) {

                calculator.UserChoosesStandardDeduction();
            }

            calculator.SetTotalTaxes(0);
            calculator.SetAdjustedGrossIncome();
            calculator.CalculateTaxesOwedAtEachTaxBracket();

            txtblkDisplayBlock.Text = "";

            for (int x = 0; x < 7; x++) {

                txtblkDisplayBlock.Text += $"Taxes at {calculator.GetTaxBracketPercentage(x)}%: {calculator.GetTaxOwedAtEachBracket(x)}{Environment.NewLine}";
            }

            txtblkDisplayBlock.Text += $"Total Taxes: {calculator.GetTotalTaxesOwed()}{Environment.NewLine}";
            txtblkDisplayBlock.Text += $"Taxes as a percentage of Adjusted Gross Income: {calculator.GetTotalTaxesAsPercentOfAdjustedGrossIncome()}{Environment.NewLine}";
            txtblkDisplayBlock.Text += $"Taxes as a percentage of Gross Income: {calculator.GetTotalTaxesAsPercentOfGrossIncome()}{Environment.NewLine}";
        }

        private void BtnClearItemization_Click(object sender, RoutedEventArgs e) {

            calculator.SetTotalDeducions(0);
            txtbxTotalItemization.Text = "";
        }

        private void BtnClearIncome_Click(object sender, RoutedEventArgs e) {

            calculator.SetGrossIncome(0);
            txtbxTotalIncome.Text = "";
        }

        private void RadiobtnItemization_Checked(object sender, RoutedEventArgs e) {

            txtbxItemization.IsReadOnly = false;
            btnAddItemization.IsEnabled = true;
            calculator.SetTotalDeducions(0);
            txtbxTotalItemization.Text = "";
        }

        private void RadiobtnStandardDeduction_Checked(object sender, RoutedEventArgs e) {

            txtbxItemization.IsReadOnly = true;
            btnAddItemization.IsEnabled = false;
            calculator.SetTotalDeducions(0);
            txtbxTotalItemization.Text = "";
            txtbxItemization.Text = "";
        }
    }
}
