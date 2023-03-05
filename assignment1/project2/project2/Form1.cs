using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textBox1.Text, out double number1) &&
                double.TryParse(textBox2.Text, out double number2))
            {
                switch (comboBox1.SelectedItem)
                {
                    case "+":
                        label1.Text = (number1 + number2).ToString();
                        break;
                    case "-":
                        label1.Text = (number1 - number2).ToString();
                        break;
                    case "*":
                        label1.Text = (number1 * number2).ToString();
                        break;
                    case "/":
                        if (number2 != 0)
                            label1.Text = (number1 / number2).ToString();
                        else
                            label1.Text = "Cannot divide by zero";
                        break;
                    default:
                        label1.Text = "Invalid operator";
                        break;
                }
            }
            else
            {
                label1.Text = "Invalid input";
            }
        }
    }
}
