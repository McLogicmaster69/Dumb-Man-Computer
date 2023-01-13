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
    public partial class traceTable : Form
    {
        public traceTable()
        {
            InitializeComponent();
        }
        public void SetupTraceTable(List<string> labels, MemoryTracker tracker) // Jensen can eat a taco
        {
            this.Width = labels.Count * 50 + 10;
            for (int i = 0; i < labels.Count; i++)
            {
                ListBox list = CreateList(i);
                this.Controls.Add(list);
                list.Items.Add(labels[i]);
                for (int j = 0; j < tracker.Log[i].List.Count; j++)
                {
                    list.Items.Add(tracker.Log[i].List[j]);
                }
            }
        }
        private ListBox CreateList(int x)
        {
            ListBox list = new ListBox();
            list.Width = 50;
            list.Height = 300;
            list.Location = new Point(50 * x, 0);
            return list;
        }
    }
}
