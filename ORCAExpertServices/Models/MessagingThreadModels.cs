using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;


namespace ORCAExpertServices.Models
{
    public class MessageThread
    {
        [Key]
        public int MessageThreadID { get; set; }

        public int startDate { get; set; }

        public string subject { get; set;}

        [ForeignKey("ApplicationUser")]
        public string UserID { get; set; }

        [ForeignKey("Expert")]
        public string ExpertID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual Expert Expert { get; set; }

        public virtual ICollection <Message> Message { get; set; }

    }

    public class Message
    {

        [Key]
        [Column (Order = 1)]
        [ForeignKey ("MessageThread")]
        public int MessageThreadID { get; set; }

        [Key]
        [Column (Order = 0)]
        [ForeignKey ("ApplicationUser")]
        public string UserID { get; set; }

        public string text { get; set; }

        [Required, DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime messageDateTime { get; set; }

        public virtual MessageThread MessageThread { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        
    }

}