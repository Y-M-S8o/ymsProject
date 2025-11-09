using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserExamDB : BaseDB
    {
        public UserExamList SelectAll()
        {
            command.CommandText = $"SELECT * FROM UserE";
            UserExamList pList = new UserExamList(base.Select());
            return pList;
        }


        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            UserExam p = entity as UserExam;
            p.User_id = UserDB.SelectById((int)reader["User_id"]);
            p.Exam_id = ExamsDB.SelectById((int)reader["Exam_id"]);
            base.CreateModel(entity);
            return p;
        }

        public override BaseEntity NewEntity()
        {
            return new UserExam();
        }

        static private UserExamList list = new UserExamList();
        public static UserExam SelectById(int id)
        {
            UserExamDB db = new UserExamDB();
            list = db.SelectAll();
            UserExam g = list.Find(item => item.Id == id);
            return g;
        }
    }


}
//שלב ב
//protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
//{
//    Person c = entity as Person;
//    if (c != null)
//    {
//        string sqlStr = $"DELETE FROM PersonTbl where id=@pid";

//        command.CommandText = sqlStr;
//        command.Parameters.Add(new OleDbParameter("@pid", c.Id));
//    }
//}
//protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
//{
//    Person c = entity as Person;
//    if (c != null)
//    {
//        string sqlStr = $"Insert INTO  PersonTbl (PersonName) VALUES (@cName)";

//        command.CommandText = sqlStr;
//        command.Parameters.Add(new OleDbParameter("@cName", c.PersonName));
//    }
//}

//protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
//{
//    Person c = entity as Person;
//    if (c != null)
//    {
//        string sqlStr = $"UPDATE PersonTbl  SET PersonName=@cName WHERE ID=@id";

//        command.CommandText = sqlStr;
//        command.Parameters.Add(new OleDbParameter("@cName", c.PersonName));
//        command.Parameters.Add(new OleDbParameter("@id", c.Id));
//    }
//}
