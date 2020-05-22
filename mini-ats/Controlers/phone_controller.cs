using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using mini_ats.Phone_Forms;
using mini_ats.Signals;
using mini_ats.Telephone_Line;

namespace mini_ats.Controlers
{
    public class phone_controller{

        const string DATA = "DATA";
        const string TUBE = "TUBE";
        const string TON = "TON";
        const string DIGIT = "DIGIT";
        const string END = "END";
        const string BEGIN = "BEGIN";
        const string BUSY = "BUSY";
        const string CALL = "CALL";
        const string BEEP = "beep.wav";
        const string RING = "call.wav";
        const int external_numbers_range = 900;


        public phone_controller(){
            
        }
        
        public void tube_up_down(phone phone)
        {
            if(phone.Phone._number >= external_numbers_range){
                if (phone.check())
                    phone.default_form_state();
                else
                    phone.change_enable_mode_for_external_phone();
            }

            else
                phone.change_enable_mode();

            if (phone.check())
                phone.Phone.send_signal_type_tube();
        }

        public void signal_analizier(object sender, signal signal){
            if ((sender as telephone).phone_form == null)
                return;

            if(signal.type == TON){
                (sender as telephone).phone_form.number_text_box.Enabled = true;
                if ((signal as signal_ton).is_ready){
                    
                    (sender as telephone).phone_form.number_text_box.Text = "";
                    (sender as telephone).phone_form.default_form_state();
                    (sender as telephone).phone_form.Phone._number_of_interlocutor = -1;

                    if((sender as telephone).phone_form.Phone.arrea != null)
                        (sender as telephone).phone_form.Phone.arrea.Close();
                }
            }

            if(signal.type == BUSY){
                (sender as telephone).phone_form.label_.Text = "This number is busy or this number dont exsist";
                (sender as telephone).phone_form.number_text_box.Text = "";
            }

            if(signal.type == CALL){
                (sender as telephone)._number_of_interlocutor = (signal as signal_call).number_of_interlocutor;
                
                if((signal as signal_call).is_ringing){
                    (sender as telephone).phone_form.number_text_box.Enabled = false;

                    //(sender as telephone).phone_form.player.SoundLocation = RING;
                    //(sender as telephone).phone_form.player.PlayLooping();

                    (sender as telephone).phone_form.change_enable_to_false();
                }

                else{
                    //(sender as telephone).phone_form.player.SoundLocation = BEEP;
                    //(sender as telephone).phone_form.player.PlayLooping();
                }
            }

            if(signal.type == BEGIN){
                (sender as telephone).arrea = new text_arrea((sender as telephone));
                (sender as telephone).arrea.Show();
            }

            if(signal.type == DATA){
                (sender as telephone).arrea.history_text_box.Text += (sender as telephone)._number_of_interlocutor.ToString() + ": " + (signal as signal_data).data + Environment.NewLine;
            }

        }



        public void push_num1(phone phone)
        {
            phone.label_.Text = "";
            phone.number_text_box.Text += "1";
            phone.Phone.send_signal_type_digit("1");
        }

        public void push_num2(phone phone)
        {
            phone.label_.Text = "";
            phone.number_text_box.Text += "2";
            phone.Phone.send_signal_type_digit("2");
        }

        public void push_num3(phone phone)
        {
            phone.label_.Text = "";
            phone.number_text_box.Text += "3";
            phone.Phone.send_signal_type_digit("3");
        }
        public void push_num4(phone phone)
        {
            phone.label_.Text = "";
            phone.number_text_box.Text += "4";
            phone.Phone.send_signal_type_digit("4");
        }

        public void push_num5(phone phone)
        {
            phone.label_.Text = "";
            phone.number_text_box.Text += "5";
            phone.Phone.send_signal_type_digit("5");
            
        }
        public void push_num6(phone phone)
        {
            phone.label_.Text = "";
            phone.number_text_box.Text += "6";
            phone.Phone.send_signal_type_digit("6");
            
        }
        public void push_num7(phone phone)
        {
            phone.label_.Text = "";
            phone.number_text_box.Text += "7";
            phone.Phone.send_signal_type_digit("7");
        }
        public void push_num8(phone phone)
        {
            phone.label_.Text = "";
            phone.number_text_box.Text += "8";
            phone.Phone.send_signal_type_digit("8");
            
        }

        public void push_num9(phone phone)
        {
            phone.label_.Text = "";
            phone.number_text_box.Text += "9";
            phone.Phone.send_signal_type_digit("9");
            
        }

        public void push_num0(phone phone)
        {
            phone.label_.Text = "";
            phone.number_text_box.Text += "0";
            phone.Phone.send_signal_type_digit("0");
        }

        public void send_call_signal(phone phone){
            phone.Phone.send_signal_type_tube();
        }
        public void send_cancel_signal(phone phone){
            phone.Phone.send_signal_type_end(); 
            phone.default_form_state();
        }

        public void authorizate_another_phone(){
            test.main_form.Visible = true;
        }
    }
}
