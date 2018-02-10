using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEst2.Models
{
    public class SerialInfo
    {
        [Key]
        public int Id { get; set; }

        public int ImportFileInfoId { get; set; }

        [Required]
        public string SerialNumber { get; set; }
        [Required]
        public string Model { get; set; }

        public string Reference1 { get; set; }
        public string Reference2 { get; set; }

        public DateTime Date { get; set; }


        public virtual ImportFileInfo ImportFileInfo { get; set; }

    }
}
