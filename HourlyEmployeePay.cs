using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project3_KSS_HourlyEmployeePay
{
    public partial class HourlyEmployeePayForm : Form
    {
        public HourlyEmployeePayForm()
        {
            InitializeComponent();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Clear();
            payRateTextBox.Clear();
            hoursWorkedTextBox.Clear();
            overtimeHoursLabel.Text = "";
            overtimePayLabel.Text = "";
            totalPayLabel.Text = "";
            nameTextBox.Focus();
            
        }

        private void calculateButton_Click(object sender, EventArgs e)
        {
            //prep
            string name;
            double payRate;
            double hoursWorked;
            double overtimeHours;
            decimal overtimePay;
            decimal totalPay;
            
            //reading is good :)
            name = Convert.ToString(nameTextBox);
            payRate = Convert.ToDouble(payRateTextBox.Text);
            hoursWorked = Convert.ToDouble(hoursWorkedTextBox.Text);

            payRate = Convert.ToDouble(payRateTextBox.Text);
            //calc & if stat


            if (hoursWorked <= 40)
            {
                totalPay = Convert.ToDecimal(hoursWorked * payRate);
                totalPayLabel.Text = totalPay.ToString("C");
                overtimeHoursLabel.Text = "None for you!";
                overtimePayLabel.Text = "Trying to take extra money?";
                overtimeHoursLabel.ForeColor = Color.IndianRed;
                overtimePayLabel.ForeColor = Color.IndianRed;
            }
            else
            {
                //this is driving me craaaaaazy
                overtimeHours = Convert.ToDouble(hoursWorked - 40);
                overtimePay = Convert.ToDecimal(overtimeHours * payRate * 1.5);
                totalPay = Convert.ToDecimal((overtimeHours * payRate * 1.5) + (payRate * 40));
                totalPayLabel.Text = totalPay.ToString("C");
                overtimePayLabel.ForeColor = Color.Green;
                overtimePayLabel.Text = overtimePay.ToString("C");
                overtimeHoursLabel.Text = Convert.ToString(overtimeHours);
            }

            hoursWorkedTextBox.Focus();
            hoursWorkedTextBox.SelectAll();
            //practice your converts!

        }
    }
}
