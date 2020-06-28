using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EFSQLite.Models
{
    public class ObjectTypeModel
    {
        [Key]
        public int TypeId { get; set; }
        public String Name { get; set; }
        public String PreviewImage { get; set; }
        public String TagName { get; set; }

        public ICollection<ObjectModel> Objects { get; set; }
    }
}
