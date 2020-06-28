using System;

namespace EFSQLite.Models
{
    public class BaseEntity
    {
        public DateTime ModifiedOn { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}
