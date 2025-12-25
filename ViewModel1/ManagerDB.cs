using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class ManagerDB : PeopleDB
    {
        public ManagerList SelectAll()
        {
            command.CommandText = $"SELECT People.* FROM (Manager INNER JOIN People ON Manager.id = People.Id)";
            ManagerList pList = new ManagerList(base.Select());
            return pList;
        }

        protected override BaseEntity CreateModel(BaseEntity entity)
        {
            Manager p = entity as Manager;
            base.CreateModel(entity);
            return p;
        }

        public override BaseEntity NewEntity()
        {
            return new Manager();
        }

        static private ManagerList list = new ManagerList();
        public static Manager SelectById(int id)
        {
            ManagerDB db = new ManagerDB();
            list = db.SelectAll();
            Manager g = list.Find(item => item.Id == id);
            return g;
        }
        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Manager c = entity as Manager;
            if (c != null)
            {
                string sqlStr = $"UPDATE Manager SET Id=@id WHERE ID=@id";

                command.CommandText = sqlStr;

                command.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }
        
        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
           Manager c = entity as Manager;
            if (c != null)
            {
                string sqlStr = $"Insert INTO  Manager (Id) VALUES (@id)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }

        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            Manager c = entity as Manager;
            if (c != null)
            {
                string sqlStr = $"DELETE FROM Manager where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", c.Id));
            }

        }
    }
}



