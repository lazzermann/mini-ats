using mini_ats.Ats_Database;
using mini_ats.Telephone_Line;
using mini_ats.Controlers;
namespace mini_ats
{
    static class test{
        public static string path = "heh.bin";
        public static database data = new database(telephone.load(path));
        public static ats mini = data.get_ats;
        public static external_ats town_ats = new external_ats(mini);
        public static phone_controller controller = new phone_controller();
        public static admin_controller ad_controller = new admin_controller();
        public static authorization_form main_form = new authorization_form();
    }
}
