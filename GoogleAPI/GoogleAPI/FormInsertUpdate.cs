using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleAPI
{
    public partial class FormInsertUpdate : Form
    {
        public string Summary
        {
            get { return tbSummary.Text; }
            set { tbSummary.Text = value; }
        }

        public new string Location
        {
            get { return tbLocation.Text; }
        }

        public string Description
        {
            get { return tbDescription.Text; }
        }
        public DateTime StartTime
        {
            get { return dtpStartTime.Value; }
        }
        public DateTime EndTime
        {
            get { return dtpEndTime.Value; }
        }
        public DateTime StartHour
        {
            get { return dtpStartHour.Value; }
        }
        public DateTime EndHour
        {
            get { return dtpEndHour.Value; }
        }

        public FormInsertUpdate(string name)
        {
            InitializeComponent();

            btInsertUpdate.Text = name;
            if (name == "Insert")
                btInsertUpdate.Enabled = false;
        }

        private void tbSummary_TextChanged(object sender, EventArgs e)
        {
            if (tbSummary.Text != "")
                btInsertUpdate.Enabled = true;
            else
                btInsertUpdate.Enabled = false;

        }

        private void dtpStartTime_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartTime.Value > dtpEndTime.Value)
                dtpStartTime.Value = dtpEndTime.Value;
        }

        private void dtpStartHour_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartTime.Value == dtpEndTime.Value && dtpStartHour.Value > dtpEndHour.Value)
                dtpStartHour.Value = dtpEndHour.Value;
        }
        
        private void dtpEndTime_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEndTime.Value < dtpStartTime.Value)
                dtpEndTime.Value = dtpStartTime.Value;
        }

        private void dtpEndHour_ValueChanged(object sender, EventArgs e)
        {
            if (dtpStartTime.Value == dtpEndTime.Value && dtpEndHour.Value < dtpStartHour.Value)
                dtpEndHour.Value = dtpStartHour.Value;
        }
        
    }
}
