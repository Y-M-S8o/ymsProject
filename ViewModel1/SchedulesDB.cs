using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class SchedulesDB : BaseDB
    {
        public SchedulesList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Schedules";
            SchedulesList pList = new SchedulesList(base.Select());
            return pList;
        }


        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Schedules p = entity as Schedules;
            p.User_id = UserDB.SelectById((int)reader["user_id"]);
            p.Subject_id = SubjectDB.SelectById((int)reader["subject_id"]);
            p.Day_of_the_week = reader["day_of_week"].ToString();
            p.Hour = Convert.ToInt32(reader["hour"]);
            base.CreateModel(entity);
            return p;
        }

        public override BaseEntity NewEntity()
        {
            return new Schedules();
        }

        static private SchedulesList list = new SchedulesList();
        public static Schedules SelectById(int id)
        {
            SchedulesDB db = new SchedulesDB();
            list = db.SelectAll();
            Schedules g = list.Find(item => item.Id == id);
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
