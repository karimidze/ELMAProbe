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
        public Form1()
        {
            InitializeComponent();
            var methods = new Calculator().Methods();
            cbOperation.DataSource = methods;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            var calc = new Calculator();

            if (tbX.Text == "") tbX.Text = "0";
            if (tbY.Text == "") tbY.Text = "0";

            tbX.Text = tbX.Text.Replace(".", ",");
            tbY.Text = tbY.Text.Replace(".", ",");

            var x = Convert.ToDouble(tbX.Text);
            var y = Convert.ToDouble(tbY.Text);

            var oper = cbOperation.SelectedItem.ToString();

            var typeCalc = typeof(Calculator);

            var method = typeCalc.GetMethod(oper);
                if (method.Name != "Fact" && method.Name != "Sqrt")
                {
                    var result = method.Invoke(calc, new object[] { x, y });

                    lbResult.Text = string.Format("Result {0} ({1}, {2}) = {3}", oper, x, y, result);
                }
                else
                {
                    var result = method.Invoke(calc, new object[] { x });

                    lbResult.Text = string.Format("Result {0} ({1}) = {2}", oper, x, result);
                }
            //lbResult.Text = $"Result {oper}(({x}, {y}) = {result}";
            
        }

        private void lbResult_Click(object sender, EventArgs e)
        {

        }
    }
}
