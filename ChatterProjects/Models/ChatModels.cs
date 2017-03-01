using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ChatterProjects.Models
{
    public class ChatModels
    {
        [Key]
        public int ChatID { get; set; }

        public string ChatInput { get; set; }
                
        public string ChatDate { get; set; }

        public string Email { get; set; }
    }
}