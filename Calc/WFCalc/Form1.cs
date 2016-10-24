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
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            var calc = new Calculator();


            var x = Convert.ToInt32(tbX.Text);
            var y = Convert.ToInt32(tbY.Text);

            var oper = cbOperation.SelectedItem.ToString();

            var typeCalc = typeof(Calculator);

            var method = typeCalc.GetMethod(oper);
            var result = method.Invoke(calc, new object[] {x, y});

            lbResult.Text = string.Format("Result {0}(({1}, {2}) = {3}", oper, x, y, result);
            //lbResult.Text = $"Result {oper}(({x}, {y}) = {result}";
        }
    }
}
