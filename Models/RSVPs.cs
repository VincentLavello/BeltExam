using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace BeltExam.Models
{
public class RSVP
        {
                [Key]
                [Required]
                public int RSVP_ID{get;set;}
                 [ForeignKey("User")]
                public int UserId {get;set;}
                 [ForeignKey("RecActivity")]
                public int RecActivityID {get;set;}

                
                //navigation properties
                 public RecActivity ThisActivity {get;set;}
                public User Participant {get;set;}
                public RSVP(){}
                public RSVP(int _RecActivityId, int userid)
                {
                        RecActivityID=_RecActivityId;
                        UserId=userid;
                }
        }      

}