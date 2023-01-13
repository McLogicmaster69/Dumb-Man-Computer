using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dumb_Man_Computer
{
    public partial class mainFrm : Form
    {
        private Interpreter Interpreter = new Interpreter();
        private Executer Executer = new Executer();
        public static mainFrm main;
        public mainFrm()
        {
            main = this;
            InitializeComponent();
        }

        private void loadToRamBtn_Click(object sender, EventArgs e)
        {
            codeTxt.Text = codeTxt.Text.ToUpper();
            trackedLabels.Text = trackedLabels.Text.ToUpper();
            List<string> commands = Interpreter.ConvertToCommands(codeTxt.Text, trackedLabels.Text, out Exceptions.Exception exception, out List<LabelledAddress> tracked);
            RAMCommandsTxt.Text = "";
            RAMBinaryTxt.Text = "";
            if(exception == null)
            {
                MemoryByte[] bytes = Interpreter.Interpret(commands);
                if(tracked.Count == 0)
                    Executer.LoadIntoMemory(bytes);
                else
                    Executer.LoadIntoMemory(bytes, tracked);
                foreach (MemoryByte mb in bytes)
                {
                    RAMBinaryTxt.Text += mb.Value + "\r\n";
                }

                foreach (string command in commands)
                {
                    RAMCommandsTxt.Text += command + "\r\n";
                }
            }
            else
            {
                MessageBox.Show($"CRITICAL ERROR: {exception.Type} on line {exception.Line}");
            }
        }

        private void runBtn_Click(object sender, EventArgs e)
        {
            output.Items.Clear();
            Executer.Execute(out Exceptions.Exception exception);
            if(exception != null)
            {
                MessageBox.Show($"CRITICAL ERROR: {exception.Type}");
            }
        }
        private void enterBtn_Click(object sender, EventArgs e)
        {
            enterBtn.Enabled = false;
            Executer.Input((int)inputNum.Value, out Exceptions.Exception exception); 
            if (exception != null)
            {
                MessageBox.Show($"CRITICAL ERROR: {exception.Type}");
            }
        }

        public void Output(int o)
        {
            output.Items.Add(o.ToString());
        }
        public void Input()
        {
            enterBtn.Enabled = true;
        }

        private void mainFrm_Load(object sender, EventArgs e)
        {
            inputNum.Maximum = OSConstants.MaxValue - 1;
            inputNum.Minimum = OSConstants.MinValue + 1;
        }
    }
}
