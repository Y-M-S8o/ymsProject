using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : BaseDB
    {
        public UserList SelectAll()
        {
            command.CommandText = $"SELECT * FROM [User]";
            UserList pList = new UserList(base.Select());
            return pList;
        }


        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            User p = entity as User;          
            p.Username = reader["username"].ToString();
            p.Email = reader["email"].ToString();
            p.Goal =int.Parse( reader["goal"].ToString());
            base.CreateModel(entity);
            return p;
        }

        public override BaseEntity NewEntity()
        {
            return new User();
        }

        static private UserList list = new UserList();
        public static User SelectById(int id)
        {
            UserDB db = new UserDB();
            list = db.SelectAll();
            User g = list.Find(item => item.Id == id);
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
