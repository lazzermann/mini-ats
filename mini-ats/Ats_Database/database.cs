using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mini_ats.Signals;
using mini_ats.Telephone_Line;
using mini_ats.Comparators;
namespace mini_ats.Ats_Database
{
    public class database
    {
        ats mini_ats;
        List<telephone> phones_list { get; set; }
        List<session> session_list { get; set; }

        public List<telephone> phones { get { return phones_list; } set => throw new NotImplementedException(); }
        public List<session> sessions { get { return session_list; } set => throw new NotImplementedException(); }
        public ats get_ats { get { return mini_ats; } set => throw new NotImplementedException(); }
        public database(ref ats mini_ats){
            phones_list = new List<telephone>();
            session_list = new List<session>();
            this.mini_ats = mini_ats;
            this.mini_ats.commutate(this);
        }

        public database(){
            phones_list = new List<telephone>();
            session_list = new List<session>();
            mini_ats = new ats();
            mini_ats.commutate(this);
        }

        public database(List<telephone> telephones){
            phones_list = telephones;
            session_list = new List<session>();
            mini_ats = new ats(phones_list);
            mini_ats.commutate(this);
        }


        public void add_session(session _session){
            session_list.Add(_session);
            session_list.Sort(new session_comparator());
        }

        public bool is_on_session(telephone _phone){
            return session_list.Contains(session_list.Find(x => x._first == _phone || x._second == _phone));
        }

        public bool is_on_session(int _phone){
            return session_list.Contains(session_list.Find(x => x._first._number == _phone || x._second._number == _phone));
        }

        public telephone get_phone(int number){
            return phones_list.Find(x => x._number == number);
        }

        public void delete_session(int number){
            session_list.Remove(session_list.Find(x => x._first._number == number || x._second._number == number));
        }

        public void add_telephone(telephone phone){
            if (!phones_list.Contains(phone)){
                mini_ats.add_line(phone);
                phones_list.Add(phone);
            }
            phones_list.Sort(new telephone_comparator());
        }

        public bool phone_exsist(int number) {
            return phones_list.Contains(phones_list.Find(x => x._number == number));
        }

        public void change_number_of_phone(int changer_number, int change_on_number) {
                phones_list[phones_list.FindIndex(x => x._number == changer_number)]._number = change_on_number;
                phones_list.Sort(new telephone_comparator());   
        }

        public bool delete_phone(int number) {
            if(phones_list.Contains(phones_list.Find(x => x._number == number))){
                phones_list.Remove(phones_list.Find(x => x._number == number));
                return true;
            }

            return false;
        }
    }
}
