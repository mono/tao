using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace NateRobins
{
    public partial class NateRobins : Form
    {
        public NateRobins()
        {
            InitializeComponent();
        }

        private void frmExamples_Load(object sender, EventArgs e)
        {
            Type[] types = Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type type in types)
            {
                MemberInfo[] runMethods = type.GetMember("Run");
                foreach (MemberInfo run in runMethods)
                {
                    lstExamples.Items.Add(type.Name);
                }
                if (lstExamples.Items.Count > 0)
                {
                    this.lstExamples.SelectedIndex = 0;
                }
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            SelectExample();
        }

        private void SelectExample()
        {
            if (lstExamples.SelectedItem != null)
            {
                Type example = Assembly.GetExecutingAssembly().GetType("NateRobins." + lstExamples.SelectedItem.ToString(), true, true);
                example.InvokeMember("Run", BindingFlags.InvokeMethod, null, null, null);
            }
        }

        private void lstExamples_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectExample();
        }
    }
}