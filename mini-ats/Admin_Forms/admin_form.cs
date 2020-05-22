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
    public partial class admin_form : Form
    {
        public admin_form()
        {
            InitializeComponent();
            this.Text = "Admin";
            test.ad_controller.refresh_telephone_list(this);
            test.ad_controller.refresh_session_list(this);
       
        }

        private void add_button_Click(object sender, EventArgs e)
        {
            test.ad_controller.add_new_number(this);
        }

        private void delete_button_Click(object sender, EventArgs e)
        {
            test.ad_controller.delete_number(this);
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            test.ad_controller.replace(this);
        }

        private void refresh_button_Click(object sender, EventArgs e)
        {
            test.ad_controller.refresh_session_list(this);
            test.ad_controller.refresh_telephone_list(this);
        }

        private void autho_button_Click(object sender, EventArgs e)
        {
            test.main_form.Visible = true;
        }

        private void admin_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            test.main_form.is_admin = false;
        }
    }
}
