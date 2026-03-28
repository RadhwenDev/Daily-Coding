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
            count = 0;
        }

        private void isPow()
        {
            if (txtResult.Text.EndsWith("²"))
            {
                string input1 = txtResult.Text.Substring(0, txtResult.Text.Length - 1);
                if (float.TryParse(input1, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal2))
                {
                    num = (float)Math.Pow(currentVal2, 2);
                    count = -1;
                }
            }
        }
        private string improveDisplayOfFloatNumber()
        {
            string input = txtStore.Text.StartsWith(".") ? "0" + txtStore.Text : txtStore.Text;
            input = txtStore.Text.EndsWith(".") ? txtStore.Text.Substring(0, txtStore.Text.Length - 1) : txtStore.Text;
            input = txtStore.Text.Contains(".") ? txtStore.Text.TrimEnd('0').TrimEnd('.') : txtStore.Text;
            return input;
        }
        private void btnMin_Click(object sender, EventArgs e)
        {
            if(txtStore.Text != "" || txtResult.Text.EndsWith("²") || count == 7)
            {
                string input = improveDisplayOfFloatNumber();
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal) || txtResult.Text.EndsWith("²") || count == 7)
                {
                    if (count == 7)
                        num = prev;
                    isPow();
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                        case 8: num = (float)Math.Sqrt(currentVal); break;
                        case 10: num = (float)Math.Log10(currentVal); break;
                        case 11: num = (float)Math.Log(currentVal); break;
                    }

                    txtResult.Text += input + "-";
                    txtStore.Clear();
                    count = 1;
                }
            }
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "" || txtResult.Text.EndsWith("²")  || count == 7)
            {
                string input = improveDisplayOfFloatNumber();
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal) || txtResult.Text.EndsWith("²") || count == 7)
                {
                    if (count == 7)
                        num = prev;
                    isPow();

                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                        case 8: num = (float)Math.Sqrt(currentVal); break;
                        case 10: num = (float)Math.Log10(currentVal); break;
                        case 11: num = (float)Math.Log(currentVal); break;
                    }

                    txtResult.Text += input + "+";
                    txtStore.Clear();
                    count = 2;
                }              
            }
        }

        private void btnMultiple_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "" || txtResult.Text.EndsWith("²") || count == 7)
            {
                string input = improveDisplayOfFloatNumber();
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal) || txtResult.Text.EndsWith("²") || count == 7)
                {
                    if (count == 7)
                        num = prev;
                    isPow();
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                        case 8: num = (float)Math.Sqrt(currentVal); break;
                        case 10: num = (float)Math.Log10(currentVal); break;
                        case 11: num = (float)Math.Log(currentVal); break;
                    }

                    txtResult.Text += input + "x";
                    txtStore.Clear();
                    count = 3;
                }
            }
        }
        private void btnDivide_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "" || txtResult.Text.EndsWith("²") || count == 7)
            {
                string input = improveDisplayOfFloatNumber();
                if (float.TryParse(improveDisplayOfFloatNumber(), NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal) || txtResult.Text.EndsWith("²") || count == 7)
                {
                    if (count == 7)
                        num = prev;
                    isPow();
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                        case 8: num = (float)Math.Sqrt(currentVal); break;
                        case 10: num = (float)Math.Log10(currentVal); break;
                        case 11: num = (float)Math.Log(currentVal); break;
                    }

                    txtResult.Text += input + "/";
                    txtStore.Clear();
                    count = 4;
                }
            }
        }

        private void btnrd_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "" || txtResult.Text.EndsWith("²") || count == 7)
            {
                string input = improveDisplayOfFloatNumber();
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal) || txtResult.Text.EndsWith("²") || count == 7)
                {
                    if (count == 7)
                        num = prev;
                    isPow();
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear() ; break;
                        case 8: num = (float)Math.Sqrt(currentVal); break;
                        case 10: num = (float)Math.Log10(currentVal); break;
                        case 11: num = (float)Math.Log(currentVal); break;
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
                case 8:
                    ans = (float)Math.Sqrt(num);
                    txtResult.Text += txtStore.Text + " = " + ans;
                    txtStore.Text = ans.ToString();
                    break;
                case 9:
                    ans = num;
                    txtResult.Text += txtStore.Text + " = " + ans;
                    txtStore.Text = ans.ToString();
                    break;
                case 10:
                    ans = (float)Math.Log10(num);
                    txtResult.Text += txtStore.Text + " = " + ans;
                    txtStore.Text = ans.ToString();
                    break;
                case 11:
                    ans = (float)Math.Log(num);
                    txtResult.Text += txtStore.Text + " = " + ans;
                    txtStore.Text = ans.ToString();
                    break;
            }
            count = 6;
            num = ans;
        }
        float prev;

        private void btnDelet_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "" && count != 6)
            {
                txtStore.Text = txtStore.Text.Remove(txtStore.Text.Length - 1);
                num /= 10;
                count = 7;
            }
                
            if (txtResult.Text != "" && count != 6)
            {
                txtResult.Text = txtResult.Text.Remove(txtResult.Text.Length - 1);
                count = 7;
                prev = num;
            }
                
        }

        private void btnsqrt_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "" || count == 7)
            {
                string input = txtStore.Text.StartsWith(".") ? "0" + txtStore.Text : txtStore.Text;
                input = txtStore.Text.EndsWith(".") ? txtStore.Text.Substring(0, txtStore.Text.Length - 1) : txtStore.Text;
                input = txtStore.Text.Contains(".") ? txtStore.Text.TrimEnd('0').TrimEnd('.') : txtStore.Text;
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal) || count == 7)
                {
                    if (count == 7)
                        num = prev;
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                        case 8: num = (float)Math.Sqrt(currentVal); break;
                        case 9: num = (float)Math.Pow(currentVal, 2); break;
                        case 10: num = (float)Math.Log10(currentVal); break;
                        case 11: num = (float)Math.Log(currentVal); break;
                    }

                    txtResult.Text += input + "√";
                    txtStore.Clear();
                    count = 8;
                }
            }
        }

        private void btnsquare_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "" || count == 7)
            {
                string input = improveDisplayOfFloatNumber();
                bool test;
                if ((test = float.TryParse(input, NumberStyles.Float, CultureInfo.InvariantCulture, out float currentVal)) || count == 6 || count == 7)
                {
                    if (test)
                        currentVal = (float)Math.Pow(currentVal, 2);
                    else
                        currentVal = (float)Math.Pow(float.Parse(input), 2);
                    if (count == 7)
                        num = prev;
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                        case 8: num = (float)Math.Sqrt(currentVal); break;
                        case 9: num = (float)Math.Pow(currentVal, 2); break;
                        case 10: num = (float)Math.Log10(currentVal); break;
                        case 11: num = (float)Math.Log(currentVal); break;
                    }
                    if (count == 6)
                        num = currentVal;
                    txtResult.Text += input + "²";
                    txtStore.Clear();
                    count = 9;
                }
            }
        }

        private void btnln_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "" || count == 7)
            {
                string input = txtStore.Text.StartsWith(".") ? "0" + txtStore.Text : txtStore.Text;
                input = txtStore.Text.EndsWith(".") ? txtStore.Text.Substring(0, txtStore.Text.Length - 1) : txtStore.Text;
                input = txtStore.Text.Contains(".") ? txtStore.Text.TrimEnd('0').TrimEnd('.') : txtStore.Text;
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal) || count == 7)
                {
                    if (count == 7)
                        num = prev;
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                        case 8: num = (float)Math.Sqrt(currentVal); break;
                        case 9: num = (float)Math.Pow(currentVal, 2); break;
                        case 10: num = (float)Math.Log10(currentVal); break;
                        case 11: num = (float)Math.Log(currentVal); break;
                    }

                    txtResult.Text += input + "ln";
                    txtStore.Clear();
                    count = 10;
                }
            }
        }

        private void btnlog2_Click(object sender, EventArgs e)
        {
            if (txtStore.Text != "" || count == 7)
            {
                string input = txtStore.Text.StartsWith(".") ? "0" + txtStore.Text : txtStore.Text;
                input = txtStore.Text.EndsWith(".") ? txtStore.Text.Substring(0, txtStore.Text.Length - 1) : txtStore.Text;
                input = txtStore.Text.Contains(".") ? txtStore.Text.TrimEnd('0').TrimEnd('.') : txtStore.Text;
                if (float.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out float currentVal) || count == 7)
                {
                    if (count == 7)
                        num = prev;
                    switch (count)
                    {
                        case 0: num = currentVal; break;
                        case 1: num -= currentVal; break;
                        case 2: num += currentVal; break;
                        case 3: num *= currentVal; break;
                        case 4: num /= currentVal; break;
                        case 5: num %= currentVal; break;
                        case 6: txtResult.Clear(); break;
                        case 8: num = (float)Math.Sqrt(currentVal); break;
                        case 9: num = (float)Math.Pow(currentVal, 2); break;
                        case 10: num = (float)Math.Log10(currentVal); break;
                        case 11: num = (float)Math.Log(currentVal); break;
                    }

                    txtResult.Text += input + "log";
                    txtStore.Clear();
                    count = 11;
                }
            }
        }
    }
}
