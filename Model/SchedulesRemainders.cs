using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class SchedulesRemainders : BaseEntity
    {
        private string identityCard;
        private Schedules schedulesId;

        public string IdentityCard { get => identityCard; set => identityCard = value; }
        public Schedules SchedulesId { get => schedulesId; set => schedulesId = value; }
    }
}
