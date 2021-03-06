﻿using MVCLabData.Repositories.Interfaces;
using MVCLabData.Tables;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCLabData.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        public bool AddOrUpdate(Comment comment)
        {
            try
            {
                using (var ctx = new MVCLabDataDbContext())
                {
                    var commentToUpdate = ctx.Comments.Where(c => c.id == comment.id)
                        .Include(c => c.Picture)
                        .FirstOrDefault();
                    if (commentToUpdate != null)
                    {
                        commentToUpdate.Title = comment.Title;
                        commentToUpdate.Body = comment.Body;
                        commentToUpdate.DateEdited = comment.DateEdited;
                        ctx.SaveChanges();
                        return true;
                    }
                    else
                    {
                        ctx.Comments.Add(comment);
                        ctx.SaveChanges();
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                //Handle exceptions
            }
            return false;
        }

        public IEnumerable<Comment> All()
        {
            using (var ctx = new MVCLabDataDbContext())
            {
                var comments = ctx.Comments
                    .Include(c => c.Picture);
                return comments.ToList();
            }
        }

        public Comment ByID(Guid id)
        {
            using (var ctx = new MVCLabDataDbContext())
            {
                var comment = ctx.Comments.Where(c => c.id == id)
                        .Include(c => c.Picture)
                            .Include(c => c.Picture.User)
                        .FirstOrDefault();
                return comment;
            }
        }

        public bool Delete(Guid id)
        {
            using (var ctx = new MVCLabDataDbContext())
            {
                var comment = ctx.Comments.Where(c => c.id == id)
                        .Include(c => c.Picture)
                        .FirstOrDefault();
                if (comment != null)
                {
                    ctx.Comments.Remove(comment);
                    ctx.SaveChanges();
                    return true;
                }
            }
            return false;
        }
    }
}