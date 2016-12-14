using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiravProject1
{
    public partial class Form1 : Form
    {
        public enum CalculationType : byte
        {
            Add = 1,
            Subtract = 2,
            Multiply = 3,
            Divide = 4
        }

        public Form1()
        {
            InitializeComponent();
            cmbCalcType.DataSource = Enum.GetValues(typeof(CalculationType));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            segmented_identifier();

        }

        private void segmented_identifier()
        {
            int value1 = 65;
            int value2 = 1;
            int value3 = 119;
            int value4 = 2;
            string str2 = " ";
            string str;
            for (value1 = 65; value1 < 70; value1++)
            {
                for (value2 = 1; value2 < 7; value2 += 2)
                {
                    for (value3 = 119; value3 < 123; value3++)
                    {
                        for (value4 = 2; value4 < 12; value4 += 2)
                        {
                            char seg1 = (char)value1;
                            char seg3 = (char)value3;
                            str = string.Format("{0}{1}{2}{3} ", seg1, value2, seg3, value4);
                            string str3 = str2 + str;
                            textBox1.Text = (str2 += str + "\t \t");
                            str2 = str3;

                        }
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textResults.Text = String.Empty;
            Int16 X = ValidateStringAsNumericX(textX);
            Int16 Y = ValidateStringAsNumericY(textY);
            CalculationType CalcType;
            Enum.TryParse<CalculationType>(cmbCalcType.SelectedItem.ToString(), out CalcType);
            String[,] CalculatedArray = GetCalculatedArray(X, Y, CalcType);
            DisplayCalculatedArray(CalculatedArray);
        }

        private Int16 ValidateStringAsNumericY(TextBox textY)
        {
            try
            {
                Int16 TextY = Convert.ToInt16(textY.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Input for No of rows.", "Entry Error");
                textY.Focus();
                textX.Clear();
            }
            return Int16.Parse(textX.Text);
        }
        private Int16 ValidateStringAsNumericX(TextBox textX)
        {
            try
            {
                Int16 TextX = Convert.ToInt16(textX.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid Input for No of Columns.", "Entry Error");
                textX.Focus();
                textX.Clear();
            }
            return Int16.Parse(textX.Text);
        }       
        private String[,] GetCalculatedArray(Int16 XAxis, Int16 YAxis, CalculationType calcType)
        {
            int Row = int.Parse(textY.Text);
            int Column = int.Parse(textX.Text);
            String[,] rectangularArray = new String[Row, Column];
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Column; j++)
                {
                    switch (calcType)
                    {
                        case CalculationType.Add:
                            rectangularArray[i, j] = (i + j).ToString();
                            break;
                        case CalculationType.Subtract:
                            rectangularArray[i, j] = (i - j).ToString();
                            break;
                        case CalculationType.Multiply:
                            rectangularArray[i, j] = (i * j).ToString();
                            break;
                        case CalculationType.Divide:
                            if (j == 0)
                            {
                                rectangularArray[i, j] = "N/A";
                            }
                            else
                            {
                                rectangularArray[i, j] = (i / j).ToString();
                            }
                            break;
                    }
                }
            }
            return rectangularArray;
        }
        private void DisplayCalculatedArray(String[,] rectangularArray)
        {            
            CalculationType CalcType;
            Enum.TryParse<CalculationType>(cmbCalcType.SelectedValue.ToString(), out CalcType);
            int Row = int.Parse(textY.Text);
            int Column = int.Parse(textX.Text);
            textResults.Text = "";
            for(int x = 0; x < Row; x++)
            {               
                for (int y = 0; y < Column; y ++)
                {
                    if (CalcType == CalculationType.Add)
                    {
                        textResults.Text += x + " + " + y + " = " + rectangularArray[x, y] + "\t \t";
                    }
                    else if (CalcType == CalculationType.Subtract)
                    {
                        textResults.Text += x + " - " + y + " = " + rectangularArray[x, y] + "\t \t";
                    }
                    else if (CalcType == CalculationType.Multiply)
                    {
                        textResults.Text += x + " * " + y + " = " + rectangularArray[x, y] + "\t \t";
                    }
                    else
                    {
                        textResults.Text += x + " / " + y + " = " + rectangularArray[x, y] + "\t \t";
                    }
                }
                textResults.Text += Environment.NewLine;

            }
        }
    }
}
