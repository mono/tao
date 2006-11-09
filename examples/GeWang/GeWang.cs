using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;

namespace GeWangExamples
{
    public partial class GeWang : Form
    {
        public GeWang()
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
            }
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            SelectExample();
        }

        private void SelectExample()
        {
            Type example = Assembly.GetExecutingAssembly().GetType("GeWangExamples." + lstExamples.SelectedItem.ToString(), true, true);
            example.InvokeMember("Run", BindingFlags.InvokeMethod, null, null, null);
        }

        private void lstExamples_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectExample();
        }
    }
}