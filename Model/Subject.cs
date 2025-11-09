using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Subject : BaseEntity
    {
        private string subject_name;
        public string Subject_name { get => subject_name; set => subject_name = value; }
    }
}
