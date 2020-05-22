using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mini_ats.Admin_Forms
{
    public partial class add_or_delete_telephone_form : Form
    {
        public add_or_delete_telephone_form()
        {
            InitializeComponent();
            this.ok_button.DialogResult = DialogResult.OK;
            this.new_number.MaxLength = 3;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
