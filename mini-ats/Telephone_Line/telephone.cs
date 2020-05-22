using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mini_ats.Signals;
using mini_ats.Ats_Database;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using mini_ats.Phone_Forms;
namespace mini_ats.Telephone_Line
{
    public class telephone
    {
        public delegate void signal_rescive(object sender, signal _signal);

        public event signal_rescive signal_resciver;

        private communication_line line;

        public phone phone_form;

        public text_arrea arrea;

        private int number;

        public int _number { get { return number; } set { number = value; } }
        
        public int _number_of_interlocutor { get; set; }

        public telephone(int number)
        {
            this._number = number;
            this._number_of_interlocutor = -1;
        }

        public void comutate(communication_line line) {
            this.line = line;
        }

        public void send_signal_type_tube() {
            signal siga = new signal_tube(this._number);
            line.resend_signal_to_ats(siga);
        }

        public void send_signal_type_digit(string digit) {
            int digi = Convert.ToInt32(digit);
            signal siga = new signal_digit(digi, _number);
            line.resend_signal_to_ats(siga);
        }

        public void send_signal_type_end() {
            line.resend_signal_to_ats(new signal_end(_number, _number_of_interlocutor));
            _number_of_interlocutor = -1;
        }

        public void send_signal_type_data(string message){
            line.resend_signal_to_ats(new signal_data(_number, _number_of_interlocutor, message));
        }

        public void receive_signal(signal siga){
            signal_resciver?.Invoke(this, siga); 
        }

        public static bool safe(string file_name, List<telephone> telephones){
            StreamWriter fs = new StreamWriter(file_name);
                
            foreach (var x in telephones)
              fs.WriteLine(x._number);

            fs.Close();

            return true;
        }

        public static List<telephone> load(string file_name){
            List<telephone> phones = new List<telephone>();
            StreamReader fs = new StreamReader(file_name);   
            
            while (!fs.EndOfStream)
              phones.Add(new telephone(Convert.ToInt32(fs.ReadLine())));
         
            fs.Close();
            return phones;
        }
    }
}
