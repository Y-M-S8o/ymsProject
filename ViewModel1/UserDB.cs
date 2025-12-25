using Model;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class UserDB : PeopleDB
    {
        public UserList SelectAll()
        {
            command.CommandText = $"SELECT People.*, [User].username AS Expr1, [User].email, [User].goal FROM" +
                $" (People INNER JOIN [User] ON People.Id = [User].id)";
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

        public override void Update(BaseEntity entity)
        {
            User user = entity as User;
            if (user != null)
            {
                updated.Add(new ChangeEntity(this.CreateUpdatedSQL, entity));
                updated.Add(new ChangeEntity(base.CreateUpdatedSQL, entity));
            }
        }

        protected override void CreateUpdatedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User c = entity as User;
            if (c != null)
            {
                string sqlStr = $"UPDATE [User] SET Username=@cUsername, Email=@cEmail, " +
                    $"Goal=@cGoal WHERE ID=@id";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cUsername", c.Username));
                command.Parameters.Add(new OleDbParameter("@cEmail", c.Email));
                command.Parameters.Add(new OleDbParameter("@cGoal", c.Goal));
                command.Parameters.Add(new OleDbParameter("@id", c.Id));
            }
        }
        protected override void CreateInsertdSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User c = entity as User;
            if (c != null)
            {
                string sqlStr = $"Insert INTO  [User] (Email,Username,Goal) VALUES (@Email,@Username,@Goal)";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@cUsername", c.Username));
                command.Parameters.Add(new OleDbParameter("@cEmail", c.Email));
                command.Parameters.Add(new OleDbParameter("@cGoal", c.Goal));


            }
        }
        protected override void CreateDeletedSQL(BaseEntity entity, OleDbCommand cmd)
        {
            User c = entity as User;
            if (c != null)
            {
                string sqlStr = $"DELETE FROM [User] where id=@pid";

                command.CommandText = sqlStr;
                command.Parameters.Add(new OleDbParameter("@pid", c.Id));
            }
        }





    }


}
