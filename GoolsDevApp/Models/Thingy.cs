using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GoolsDevApp.Models
{
    public class Thingy
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ThingyId { get; set; }
        public int Count { get; set; }
        public string Text { get; set; }
    }
}
