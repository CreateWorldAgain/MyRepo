using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TEst2.Models
{
    public class ImportFileInfo
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public DateTime DateFile { get; set; }

        [Required]
        public DateTime ImportDate { get; set; }


        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<SerialInfo> SerialInfo { get; set; }
    

}
