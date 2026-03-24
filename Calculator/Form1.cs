using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnDot_Click(object sender, EventArgs e)
        {
            txtStore.Text += ".";
        }

        private void btnOne_Click(object sender, EventArgs e)
        {
            txtStore.Text += "1";
        }

        private void btnTwo_Click(object sender, EventArgs e)
        {
            txtStore.Text += "2";
        }

        private void btnThree_Click(object sender, EventArgs e)
        {
            txtStore.Text += "3";
        }

        private void btnSix_Click(object sender, EventArgs e)
        {
            txtStore.Text += "6";
        }

        private void btnFive_Click(object sender, EventArgs e)
        {
            txtStore.Text += "5";
        }

        private void btnFour_Click(object sender, EventArgs e)
        {
            txtStore.Text += "4";
        }

        private void btnSeven_Click(object sender, EventArgs e)
        {
            txtStore.Text += "7";
        }

        private void btnEight_Click(object sender, EventArgs e)
        {
            txtStore.Text += "8";
        }

        private void btnNine_Click(object sender, EventArgs e)
        {
            txtStore.Text += "9";
        }

        private void btnZero_Click(object sender, EventArgs e)
        {
            char lastChar = txtStore.Text.Last();
            char[] operators = { '+', '-', '*', '/' };
            if (txtStore.Text != "" && !operators.Contains(lastChar) )
                txtStore.Text += "0";
        }

        float num;
        int count = 0;
        private void btnClear_Click(object sender, EventArgs e)
        {
            txtResult.Clear();
            txtStore.Clear();
            num = 0;
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            if(txtStore.Text != "")
            {
                string input = txtStore.Text.StartsWith(".") ? "0" + txtStore.Text : txtStore.Text;
                input = txtStore.Text.EndsWith(".") ? txtStore.Text.Substring(0, txtStore.Text.Length - 1) : txtStore.Text;
                input = txtStore.Text.Contains(".") ? txtStore.Text.TrimEnd('0').TrimEnd('.') : txtStore.Text;
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal))
                {
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                    }

                    txtResult.Text += input + "-";
                    txtStore.Clear();
                    count = 1;
                }
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "")
            {
                string input = txtStore.Text.StartsWith(".") ? "0" + txtStore.Text : txtStore.Text;
                input = txtStore.Text.EndsWith(".") ? txtStore.Text.Substring(0, txtStore.Text.Length - 1) : txtStore.Text;
                input = txtStore.Text.Contains(".") ? txtStore.Text.TrimEnd('0').TrimEnd('.') : txtStore.Text;
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal))
                {
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                    }

                    txtResult.Text += input + "+";
                    txtStore.Clear();
                    count = 2;
                }              
            }
        }

        private void btnMultiple_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "")
            {
                string input = txtStore.Text.StartsWith(".") ? "0" + txtStore.Text : txtStore.Text;
                input = txtStore.Text.EndsWith(".") ? txtStore.Text.Substring(0, txtStore.Text.Length - 1) : txtStore.Text;
                input = txtStore.Text.Contains(".") ? txtStore.Text.TrimEnd('0').TrimEnd('.') : txtStore.Text;
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal))
                {
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                    }

                    txtResult.Text += input + "x";
                    txtStore.Clear();
                    count = 3;
                }
            }
        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "")
            {
                string input = txtStore.Text.StartsWith(".") ? "0" + txtStore.Text : txtStore.Text;
                input = txtStore.Text.EndsWith(".") ? txtStore.Text.Substring(0, txtStore.Text.Length - 1) : txtStore.Text;
                input = txtStore.Text.Contains(".") ? txtStore.Text.TrimEnd('0').TrimEnd('.') : txtStore.Text;
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal))
                {
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                    }

                    txtResult.Text += input + "/";
                    txtStore.Clear();
                    count = 4;
                }
            }
        }

        private void btnrd_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "")
            {
                string input = txtStore.Text.StartsWith(".") ? "0" + txtStore.Text : txtStore.Text;
                input = txtStore.Text.EndsWith(".") ? txtStore.Text.Substring(0, txtStore.Text.Length - 1) : txtStore.Text;
                input = txtStore.Text.Contains(".") ? txtStore.Text.TrimEnd('0').TrimEnd('.') : txtStore.Text;
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal))
                {
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear() ; break;
                    }

                    txtResult.Text += input + "%";
                    txtStore.Clear();
                    count = 5;
                }
            }
        }

        private void btnEqual_Click(object sender, EventArgs e)
        {
            float ans = 0;
            switch (count)
            {
                case 1:
                    if (float.TryParse(txtStore.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal1))
                        ans = num - currentVal1;
                    txtResult.Text += txtStore.Text + " = " + ans;
                    txtStore.Text = ans.ToString();
                    break;
                case 2:
                    if (float.TryParse(txtStore.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal2))
                        ans = num + currentVal2;
                    txtResult.Text += txtStore.Text + " = " + ans;
                    txtStore.Text = ans.ToString();
                    break;
                case 3:
                    if(float.TryParse(txtStore.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal3))
                        ans = num * currentVal3;
                    txtResult.Text += txtStore.Text + " = " + ans;
                    txtStore.Text = ans.ToString();
                    break;
                case 4:
                    if (float.TryParse(txtStore.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal4))
                        ans = num / currentVal4;
                    txtResult.Text += txtStore.Text + " = " + ans;
                    txtStore.Text = ans.ToString();
                    break;
                case 5:
                    if (float.TryParse(txtStore.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal5))
                        ans = num % currentVal5;
                    txtResult.Text += txtStore.Text + " = " + ans;
                    txtStore.Text = ans.ToString();
                    break;
            }
            count = 6;
            num = ans;
        }
    }
}
