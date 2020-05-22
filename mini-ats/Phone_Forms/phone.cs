using System;
using System.Windows.Forms;
using System.Media;
using mini_ats.Telephone_Line;
namespace mini_ats.Phone_Forms
{
    public partial class phone : Form
    {
        const int external_numbers_range = 900;

        public telephone Phone;
        //public SoundPlayer player;
        public phone(telephone Phone)
        {
            InitializeComponent();

            //this.player = new SoundPlayer();
            this.Phone = Phone;
            this.Phone.phone_form = this;
            this.Phone.signal_resciver += test.controller.signal_analizier;
            this.number_text_box.Enabled = false;

            if (Phone._number_of_interlocutor >= external_numbers_range)
                change_enable_mode_for_external_phone();
            
            else
                default_form_state();

            this.Text = "Phone : " + Convert.ToString(Phone._number);
        }

        private void num_1_Click(object sender, EventArgs e){
            test.controller.push_num1(this);
        }

        private void num_2_Click(object sender, EventArgs e){
            test.controller.push_num2(this);
        }

        private void num_3_Click(object sender, EventArgs e){
            test.controller.push_num3(this);
        }

        private void num_4_Click(object sender, EventArgs e){
            test.controller.push_num4(this);
        }

        private void num_5_Click(object sender, EventArgs e){
            test.controller.push_num5(this);
        }

        private void num_6_Click(object sender, EventArgs e){
            test.controller.push_num6(this);
        }

        private void num_7_Click(object sender, EventArgs e){
            test.controller.push_num7(this);
        }

        private void num_8_Click(object sender, EventArgs e){
            test.controller.push_num8(this);
        }

        private void num_9_Click(object sender, EventArgs e){
            test.controller.push_num9(this);
        }

        private void num_0_Click(object sender, EventArgs e){
            test.controller.push_num0(this);
        }

        private void phone_Load(object sender, EventArgs e){

        }

        private void ok_button_Click(object sender, EventArgs e){
            test.controller.send_call_signal(this);
        }

        private void tube_button_Click(object sender, EventArgs e){
            test.controller.tube_up_down(this);
        }

        private void cancel_button_Click(object sender, EventArgs e){
            
            if (Phone.arrea != null)
                Phone.arrea.Close();

            test.controller.send_cancel_signal(this);
        }

        public void change_enable_mode(){
            this.num_0.Enabled = !this.num_0.Enabled;
            this.num_1.Enabled = !this.num_1.Enabled;
            this.num_2.Enabled = !this.num_2.Enabled;
            this.num_3.Enabled = !this.num_3.Enabled;
            this.num_4.Enabled = !this.num_4.Enabled;
            this.num_5.Enabled = !this.num_5.Enabled;
            this.num_6.Enabled = !this.num_6.Enabled;
            this.num_7.Enabled = !this.num_7.Enabled;
            this.num_8.Enabled = !this.num_8.Enabled;
            this.num_9.Enabled = !this.num_9.Enabled;
            this.cancel_button.Enabled = !this.cancel_button.Enabled;
        }

        public void change_enable_mode_for_external_phone(){
            this.num_0.Enabled = true;
            this.num_1.Enabled = false;
            this.num_2.Enabled = false;
            this.num_3.Enabled = false;
            this.num_4.Enabled = false;
            this.num_5.Enabled = false;
            this.num_6.Enabled = false;
            this.num_7.Enabled = false;
            this.num_8.Enabled = false;
            this.num_9.Enabled = false;
            this.ok_button.Enabled = false;
            this.cancel_button.Enabled = true;
            this.tube_button.Enabled = true;
            this.number_text_box.Text = "";
            this.label_.Text = "";
        }

        public void change_enable_to_false(){
            this.num_0.Enabled = false;
            this.num_1.Enabled = false;
            this.num_2.Enabled = false;
            this.num_3.Enabled = false;
            this.num_4.Enabled = false;
            this.num_5.Enabled = false;
            this.num_6.Enabled = false;
            this.num_7.Enabled = false;
            this.num_8.Enabled = false;
            this.num_9.Enabled = false;
            this.tube_button.Enabled = false;
            this.cancel_button.Enabled = true;
            this.ok_button.Enabled = true;
        }

        public void default_form_state(){
            this.num_0.Enabled = false;
            this.num_1.Enabled = false;
            this.num_2.Enabled = false;
            this.num_3.Enabled = false;
            this.num_4.Enabled = false;
            this.num_5.Enabled = false;
            this.num_6.Enabled = false;
            this.num_7.Enabled = false;
            this.num_8.Enabled = false;
            this.num_9.Enabled = false;
            this.ok_button.Enabled = false;
            this.cancel_button.Enabled = false;
            this.tube_button.Enabled = true;
            this.number_text_box.Text = "";
            this.label_.Text = "";
        }

        public bool check(){
            return num_0.Enabled;
        }

        private void autho_button_Click(object sender, EventArgs e)
        {
            test.controller.authorizate_another_phone();
        }

        private void phone_FormClosing(object sender, FormClosingEventArgs e)
        {
            Phone.signal_resciver -= test.controller.signal_analizier;
            test.main_form.remove_phone_from_list(Phone._number);
        }
    }
}
