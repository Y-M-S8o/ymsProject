using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PeopleDB : BaseDB
    {
        public PeopleList SelectAll()
        {
            command.CommandText = $"SELECT * FROM People";
            PeopleList pList = new PeopleList(base.Select());
            return pList;
        }


    protected override BaseEntity CreateModel(BaseEntity entity)
        {
            People p = entity as People;
            p.Username = reader["userName"].ToString();
            p.Pass = reader["pass"].ToString();
            base.CreateModel(entity);
            return p;
        }

        public override BaseEntity NewEntity()
        {
            return new People();
        }

        static private PeopleList list = new PeopleList();
        public static People SelectById(int id)
        {
            PeopleDB db = new PeopleDB();
            list = db.SelectAll();
            People g = list.Find(item => item.Id == id);
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
