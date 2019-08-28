using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Threading;

namespace BeltExam.Models
{
public class RecActivity
    {
        [Key]
        [Required]
        public int RecActivityID  {get;set;}
        [Required]
        public string ActivityTitle{get;set;}
        [Required]
        public string Description{get;set;}
        [FutureDate]
        [Required(ErrorMessage="Activity dates must be future.")]
        public DateTime ActivityDate {get;set;}
        [Required(ErrorMessage="Invalid Time")]
        public DateTime Time {get;set;}
        [Required]
        public int DurationTypeID {get;set;}
        [Required(ErrorMessage="Duration must be more than zero hero.")]
        public int Duration {get;set;}
        public List<RSVP> Particpants {get;set;}
        //COORDINATOR
        public int UserId {get;set;}
        public User Coordinator {get;set;}

        public RecActivity(){}
        public RecActivity(int _RecActivityID , int _CoordinatorID  , string _RecActivityTitle, string _Description, DateTime _Date, int _DurationTypeID) {
                RecActivityID =_RecActivityID;
                UserId  =_CoordinatorID;
                ActivityTitle=_RecActivityTitle;
                Description=_Description;
                ActivityDate=_Date;
                DurationTypeID=_DurationTypeID;
            }  
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
            {
                // List<ValidationResult> results = new List<ValidationResult>();

                    if (ActivityDate <= DateTime.Now)
                    {
                        // results.Add(new ValidationResult("Dates must be future.", new []{"ActivityDate"}));
                        yield return new ValidationResult("Dates must be future.", new[] { "ActivityDate" });
                        //https://stackoverflow.com/questions/10105279/yield-return-when-appending-values-on-to-the-end-of-an-existing-ienumerable
                    }

                    // return results;
            }                   
    }//class
}//namespace