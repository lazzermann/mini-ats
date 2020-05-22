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
using mini_ats.Ats_Database;
using mini_ats.Phone_Forms;
using mini_ats.Admin_Forms;
namespace mini_ats
{
    public partial class authorization_form : Form
    {
        List<int> used_numbers;
        public bool is_admin;
        public authorization_form()
        {
            InitializeComponent();
            used_numbers = new List<int>();
            is_admin = false;
            this.authorizate_text_box.MaxLength = 5;
        }

        private void authorization_form_FormClosing(object sender, FormClosingEventArgs e)
        {
            telephone.safe(test.path, test.data.phones);
        }

        public void remove_phone_from_list(int number){
            used_numbers.Remove(number);
        }

        private void autho_button_Click(object sender, EventArgs e)
        {
            string text = this.authorizate_text_box.Text;
            authorizate_text_box.Text = "";
            
            if(text != "admin"){
                
                try{

                    int number = Convert.ToInt32(text);
                    telephone _phone = test.data.get_phone(number);
                    if (_phone != null){
                        
                        if (used_numbers.Contains(number))
                            MessageBox.Show("This number is used now", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        else{
                            used_numbers.Add(number);
                            phone phone_form = new phone(_phone);
                            phone_form.Show();
                            this.Visible = false;
                        }
                    }

                    else{
                        MessageBox.Show("This number dont exsist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                catch(FormatException ex){
                    MessageBox.Show("This is not nubmer", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            else{
                if (is_admin)
                    MessageBox.Show("There is another admin exsist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                else
                {
                    is_admin = true;
                    admin_form admin = new admin_form();
                    admin.Show();
                }
            }

        }
    }
}
