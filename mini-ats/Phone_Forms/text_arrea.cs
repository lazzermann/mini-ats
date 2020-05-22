using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using mini_ats.Telephone_Line;
namespace mini_ats.Phone_Forms
{
    public partial class text_arrea : Form
    {
        public telephone Phone;
        public text_arrea(telephone Phone)
        {
            InitializeComponent();
            this.Phone = Phone;
            this.Phone.arrea = this;
            this.Text += " : " + Phone._number; 
        }

        private void type_text_box_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == '\n'){
                history_text_box.Text += this.Phone._number.ToString() + ": " + this.type_text_box.Text;
                Phone.send_signal_type_data(this.type_text_box.Text);
                this.type_text_box.Text = "";
            }
        }

        private void text_arrea_FormClosing(object sender, FormClosingEventArgs e)
        {
            Phone.arrea = null;
        }

        private void type_text_box_DoubleClick(object sender, EventArgs e)
        {
            history_text_box.Text += this.Phone._number.ToString() + ": " + this.type_text_box.Text + Environment.NewLine;
            Phone.send_signal_type_data(this.type_text_box.Text);
            this.type_text_box.Text = "";
        }
    }
}
