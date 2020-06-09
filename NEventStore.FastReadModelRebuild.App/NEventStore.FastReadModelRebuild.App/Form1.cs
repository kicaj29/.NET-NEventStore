using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NEventStore.FastReadModelRebuild.Standard20;

namespace NEventStore.FastReadModelRebuild.App
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnStartNEventStoreStandard20_Click(object sender, EventArgs e)
        {
            SqlBulkCopy bulkCopy = new SqlBulkCopy("");
            bulkCopy.WriteToServer();

            new NEventStoreSample().Start();

        }
    }
}
