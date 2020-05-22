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
    public partial class replace_number_form : Form
    {
        public replace_number_form()
        {
            InitializeComponent();
            this.ok_button.DialogResult = DialogResult.OK;
            this.replace_text.MaxLength = 3;
            this.to_text.MaxLength = 3;
        }

        private void cancel_button_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
