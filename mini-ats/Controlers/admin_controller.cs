using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms;
using mini_ats.Admin_Forms;
using mini_ats.Telephone_Line;
namespace mini_ats.Controlers
{
    class admin_controller
    {
        public admin_controller() { }
        const int external_phones_range = 900;
        public void refresh_telephone_list(admin_form form){
            form.phones_view.Rows.Clear();
            foreach (var x in test.data.phones)
                form.phones_view.Rows.Add(new string[] { x._number.ToString() });
        }

        public void refresh_session_list(admin_form form){
            int i = 0;
            form.session_view.Rows.Clear();
            foreach (var x in test.data.sessions){
                form.session_view.Rows.Add();
                form.session_view.Rows[i].Cells[0].Value = x._first._number.ToString();
                form.session_view.Rows[i].Cells[1].Value = x._second._number.ToString();
                i++;
            }
        }

        public void add_new_number(admin_form form){
            add_or_delete_telephone_form _form = new add_or_delete_telephone_form();
            if(_form.ShowDialog() == DialogResult.OK){
                int text = 0;

                if (_form.new_number.Text.Length != 3)
                {
                    MessageBox.Show("This is number has not 3 symbols", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }


                try
                {
                    text = Convert.ToInt32(_form.new_number.Text);
                }

                catch(FormatException ex){
                    MessageBox.Show("This is not number", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (test.data.phone_exsist(text))
                    MessageBox.Show("This number is exsist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else{
                    test.data.add_telephone(new telephone(text));
                    refresh_telephone_list(form);
                }

            }
         
        }

        public void delete_number(admin_form form){
            add_or_delete_telephone_form _form = new add_or_delete_telephone_form();
            if(_form.ShowDialog() == DialogResult.OK){
                int text = 0;

                if(_form.new_number.Text.Length != 3){
                    MessageBox.Show("This is number has not 3 symbols", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try{
                    text = Convert.ToInt32(_form.new_number.Text);
                }

                catch(FormatException ex){
                    MessageBox.Show("This is not number", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (!test.data.phone_exsist(text))
                    MessageBox.Show("This number does not exsist", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                else{

                    if (test.data.is_on_session(text))
                        MessageBox.Show("This number on session cannot delete now", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else{
                        test.data.delete_phone(text);
                        refresh_telephone_list(form);
                    }
                }

            }
        }

       public void replace(admin_form form){
            replace_number_form _form = new replace_number_form();
            
            if(_form.ShowDialog() == DialogResult.OK){
                int text_to = 0;
                int text_replace = 0;

                if (_form.replace_text.Text.Length != 3 && _form.to_text.Text.Length != 3)
                {
                    MessageBox.Show("One of the numbers has not 3 symbols", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                try {
                    text_replace = Convert.ToInt32(_form.replace_text.Text);
                    text_to = Convert.ToInt32(_form.to_text.Text);
                }

                catch (FormatException ex) {
                    MessageBox.Show("One of this or both are not numbers", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (test.data.phone_exsist(text_replace))
                {
                    if(text_replace >= external_phones_range){
                        if (text_to < external_phones_range)
                        {
                            MessageBox.Show("If replace external number, number must be in external range 900 - 999", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    if (test.data.is_on_session(text_replace))
                        MessageBox.Show("This number on session cannot replace now", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    else if (test.data.phone_exsist(text_to))
                        MessageBox.Show("Cannot replace on exsist number", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    else
                    {
                        test.data.change_number_of_phone(text_replace, text_to);
                        refresh_telephone_list(form);
                    }
                }

                else
                    MessageBox.Show("This number does not exsist cannot replace", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
        }
    }
}
