using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARFHomeBudi.Services
{
    [Table("JobOffer")]
    public class JobOffer
    {
        [PrimaryKey]
        [AutoIncrement]
        [SQLite.Column("Job_ID")]
        public int Job_ID { get; set; }

        [SQLite.Column("U_UD")]
        public int U_ID { get; set; }

        [SQLite.Column("Job_Title")]
        public string? Job_Title { get; set; }

        [SQLite.Column("Cat_ID")]
        public int Cat_ID { get; set; }

        [SQLite.Column("Job_Desc")]
        public string? Job_Desc { get; set; }

        [SQLite.Column("Job_Len")]
        public int? Job_Len { get; set; }

        [SQLite.Column("Job_Sched")]
        public DateTime Job_Sched { get; set; }

        [SQLite.Column("Job_Cut")]
        public float Job_Cut { get; set; }

        [SQLite.Column("Job_AddPay")]
        public float Job_AddPay { get; set; }

    }
}
