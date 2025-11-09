using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserSubjectDB : BaseDB
    {
        public UserSubjectList SelectAll()
        {
            command.CommandText = $"SELECT * FROM User_Subject";
            UserSubjectList pList = new UserSubjectList(base.Select());
            return pList;
        }


        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            UserSubject p = entity as UserSubject;
            p.User_id = UserDB.SelectById((int)reader["User_id"]);
            p.Subject_id = SubjectDB.SelectById((int)reader["Subject_id"]);
            base.CreateModel(entity);
            return p;
        }

        public override BaseEntity NewEntity()
        {
            return new UserSubject();
        }

        static private UserSubjectList list = new UserSubjectList();
        public static UserSubject SelectById(int id)
        {
            UserSubjectDB db = new UserSubjectDB();
            list = db.SelectAll();
            UserSubject g = list.Find(item => item.Id == id);
            return g;
        }
    }
}
