using Calc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WFCalc
{
    public partial class Form1 : Form
    {
        private ICalculator calc { get; set; }
        public Form1()
        {
            InitializeComponent();

            calc = new Calculator();

            cbOperation.DataSource = Calculator.GetOperations(); ;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            var oper = cbOperation.SelectedItem as Operation;
            if (oper == null)
            {
                return;
            }

            var method = typeof(Calculator).GetMethod(oper.Name);
            if (method == null)
            {
                lbResult.Text = "method not found";
                return;
            }

            if (tbX.Text == "") tbX.Text = "0";
            if (tbY.Text == "") tbY.Text = "0";

            tbX.Text = tbX.Text.Replace(".", ",");
            tbY.Text = tbY.Text.Replace(".", ",");

            var x = Convert.ToDouble(tbX.Text);
            var y = Convert.ToDouble(tbY.Text);

            var typeCalc = typeof(Calculator);

            var args = new object[] { x, y };
            if (oper.ParameterCount == 1)
            {
                args = new object[] { x };
            }
            object result;
            try
            {
                result = method.Invoke(calc, args);
            }
            catch (Exception ex)
            {
                lbResult.Text = ex.Message;
                return;
            }
            lbResult.Text = string.Format("Result {0}({1}, {2}) = {3}", oper, x, y, result);
            //lbResult.Text = $"Result {oper}(({x}, {y}) = {result}";

        }

        private void lbResult_Click(object sender, EventArgs e)
        {

        }
    }
}
