using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ScheduleReminderDB : BaseDB
    {
        public SchedulesRemindersList SelectAll()
        {
            command.CommandText = $"SELECT * FROM Schedule_Reminder";
            SchedulesRemindersList pList = new SchedulesRemindersList(base.Select());
            return pList;
        }


    protected override BaseEntity CreateModel(BaseEntity entity)
        {
            SchedulesRemainders p = entity as SchedulesRemainders;
            p.SchedulesId = SchedulesDB.SelectById((int)reader["SchedulesId"]);
            p.IdentityCard = reader["IdentityCard"].ToString();
            base.CreateModel(entity);
            return p;
        }

        public override BaseEntity NewEntity()
        {
            return new SchedulesRemainders();
        }

        static private SchedulesRemindersList list = new SchedulesRemindersList();
        public static SchedulesRemainders SelectById(int id)
        {
            ScheduleReminderDB db = new ScheduleReminderDB();
            list = db.SelectAll();
            SchedulesRemainders g = list.Find(item => item.Id == id);
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