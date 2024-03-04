using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARFHomeBudi.Services
{
    [SQLite.Table("User")]
    public class User
    {
        [PrimaryKey]
        [AutoIncrement]
        [SQLite.Column("U_ID")]
        public int U_ID { get; set; }

        [SQLite.Column("U_Email")]
        public string U_Email { get; set; }

        [SQLite.Column("U_Pass")]
        public string U_Pass { get; set; }

        [SQLite.Column("U_FName")]
        public string U_FName { get; set; }

        [SQLite.Column("U_LName")]
        public string U_LName { get; set; }

        [SQLite.Column("U_Cntry")]
        public string U_Cntry { get; set; }

        [SQLite.Column("U_City")]
        public string U_City { get; set; }

        [SQLite.Column("U_Prov")]
        public string U_Prov { get; set; }

        [SQLite.Column("U_Town")]
        public string U_Town { get; set; }

        [SQLite.Column("U_HNum")]
        public string U_HNum { get; set; }

        [SQLite.Column("U_Role")]
        public int U_Role { get; set; }

        [SQLite.Column("U_IsRequesting")]
        public bool U_IsRequesting { get; set; }

        [SQLite.Column("U_Clearance")]
        public string U_Clearance { get; set; }

        [SQLite.Column("U_FB")]
        public string? U_FB { get; set; }

        [SQLite.Column("U_LIn")]
        public string? U_LIn { get; set; }

        [SQLite.Column("U_Resume")]
        public string? U_Resume { get; set; }

        [SQLite.Column("U_Stat")]
        public int U_Stat { get; set; }
    }
}