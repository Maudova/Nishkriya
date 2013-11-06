﻿using Nishkriya.Models.ViewModels;
using System;
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

        public PostViewModel ToViewModel(ThreadViewModel thread)
        {
            return new PostViewModel
            {
                Account = this.ForumAccount,
                Content = this.Content,
                PostDate = this.PostDate,
                Thread = thread
            };
        }
    }
}