﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nishkriya.Models
{
    public class YafPost
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Content { get; set; }
        public string Hash { get; set; }
        public virtual ForumAccount ForumAccount { get; set; }
        public virtual YafThread Thread { get; set; }
        public DateTime PostDate { get; set; }
        
        public override bool Equals(object obj)
        {
            return (obj is YafPost) && (obj as YafPost).Hash.Equals(Hash);
        }

        public override int GetHashCode()
        {
            return (Hash != null ? Hash.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return Content;
        }

        public  string TimeSincePost()
        {
            //The forum account used to scrape should be set to the UTC timezone.
            var timeDifference = (DateTime.UtcNow - PostDate);
            
            string result;
            if (timeDifference.TotalHours < 1)
            {
                result = Math.Round(timeDifference.TotalMinutes) == 1 ? "1 Minute Ago" : string.Format("{0} Minutes ago", Math.Round(timeDifference.TotalMinutes));                
            }else if (timeDifference.TotalDays < 1)
            {
                result = Math.Round(timeDifference.TotalHours) == 1 ? "1 Hour Ago" : string.Format("{0} Hours ago", Math.Round(timeDifference.TotalHours));  
            }
            else if (timeDifference.TotalDays < 7)
            {
                result = Math.Round(timeDifference.TotalDays) == 1 ?  "1 Day Ago" : string.Format("{0} Days ago", Math.Round(timeDifference.TotalDays));  
            }
            else
            {
                result = PostDate.ToShortDateString();
            }

            return result;
        }
    }
}