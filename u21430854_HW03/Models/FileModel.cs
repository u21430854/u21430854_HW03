using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations; //for text decorators

namespace u21430854_HW03.Models
{
    public class FileModel
    {
        [Display(Name = "File name")]
        public string FileName { get; set; }
    }
}