using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class CalculatorForm : Form
    {
        public CalculatorForm()
        {
            InitializeComponent();
        }

        // Action Buttons for Numbers
        private void button0_Click(object sender, EventArgs e)
        {
            Answer.Text += "0";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Answer.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Answer.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Answer.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Answer.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Answer.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Answer.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Answer.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Answer.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Answer.Text += "9";
        }

        // End Action Buttons for Numbers

        //

        // Action Buttons ( + , - , × , / )
        private void buttonPlus_Click(object sender, EventArgs e)
        {
            Answer.Text += "+";
        }

        private void buttonSub_Click(object sender, EventArgs e)
        {
            Answer.Text += "-";
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            int len = Answer.Text.Length;

            // -×6 -> System.Data.SyntaxErrorException:
            // 'Syntax error: Missing operand before '*' operator.'

            if (len > 0 && char.IsDigit(Answer.Text[len - 1]))
                Answer.Text += "×";
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            int len = Answer.Text.Length;

            // -/6 -> System.Data.SyntaxErrorException:
            //'Syntax error: Missing operand before '/' operator.'

            if (len > 0 && char.IsDigit(Answer.Text[len - 1]))
                Answer.Text += "/";
        }

        // End Action Buttons ( + , - , × , / )

        //

        // Action Button =

        private void Validator()
        {

            // Make sure the expression is valid and make the expression valid

            int len = Answer.Text.Length;
            char last = Answer.Text[len - 1];
            char first = Answer.Text[0];

            // The last letter is the symbol and this is wrong

            if (char.IsSymbol(last) || char.IsPunctuation(last))
            {
                while (len > 0 && char.IsSymbol(last) || char.IsPunctuation(last))
                {
                    if (len > 1) Answer.Text = Answer.Text.Substring(0, len - 1);
                    else Answer.Text = "0";
                    len = Answer.Text.Length;
                    if (len > 0) last = Answer.Text[len - 1];
                }
            }

            len = Answer.Text.Length;

            // The first letter is the symbol and this is wrong

            if (len > 0 && char.IsSymbol(first))
            {
                while (len > 0 && char.IsSymbol(first))
                {
                    if (len > 1) Answer.Text = Answer.Text.Substring(1, len - 1);
                    else Answer.Text = "0";
                    len = Answer.Text.Length;
                    if (len > 0) first = Answer.Text[0];
                }
            }
        }
        private void buttonEql_Click(object sender, EventArgs e)
        {
            if (Answer.Text.Length == 0) Answer.Text = "0";
            else
            {
                // Make sure the expression is valid and make the expression valid

                Validator();

                // Calculate the answer 

                int len = Answer.Text.Length;
                if (len == 0) Answer.Text = "0";

                string expression = Answer.Text.Replace('×', '*');
                DataTable table = new DataTable();
                var result = table.Compute(expression, "");

                // Check division by zero Befor Answer

                if (double.IsInfinity(Convert.ToDouble(result)))
                {
                    Answer.Text = "";
                }
                else
                {
                    Answer.Text = result.ToString();
                }

                // End Calculate the answer
            }
        }

        // End Action Button =

        //

        // Action Buttons ( Clear , Pop Back )

        private void Clear_Click(object sender, EventArgs e)
        {
            // Clears all text on the answer screen.
            Answer.Clear();
        }

        private void buttonPop_Click(object sender, EventArgs e)
        {
            // Erases the last symbol or number written on the answer screen.
            if (Answer.Text.Length > 0)
                Answer.Text = Answer.Text.Substring(0, Answer.Text.Length - 1);
        }

        // End Action Buttons ( Clear , Pop Back )
    }
}
