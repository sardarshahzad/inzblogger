using blogger.Data;
using blogger.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace blogger.Repository.Implementation
{
    public class PostRepository : IPost
    {
        private readonly inzBloggerContext? _db;
        private object return_db;

        public PostRepository(inzBloggerContext db)
        {
            _db = db;
        }

        // ------------ Post Methods ----------------
        public List<Post> GetPosts
        {
            get { return _db.Posts.Include(x => x.Category).Include(x => x.PostStatus).ToList(); }
        }
        public Post GetPost(int id)
        {
            return _db.Posts.Where(x => x.Id == id).Include(x => x.PostStatus).Include(x => x.User).FirstOrDefault();
        }

        // ------------ Categories Methods ----------------
        public void AddupdateCategory(Category category)
        {
            _db.Categories.Update(category);
            _db.SaveChanges();
        }

        public void DetachCategory(int id)
        {
            Category category = _db.Categories.Where(x => x.Id == id).FirstOrDefault();
            _db.Remove(category);
            _db.SaveChanges();
        }

        public List<Category> GetCategories()
        {
            return _db.Categories.ToList();
        }

        public Category GetCategory(int id)
        {
            return _db.Categories.Where(x => x.Id == id).FirstOrDefault();
        }

        // ------------ Post Status Methods ----------------

        public List<PostStatus> GetPostStatuses()
        {
            return _db.PostStatues.ToList();
        }
        public PostStatus GetPostStatus(int id)
        {
            return _db.PostStatues.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddUpDatePostStatus(PostStatus postStatus)
        {
            _db.PostStatues.Update(postStatus);
            _db.SaveChanges();

        }

        public void DeletePostStatus(int id)
        {
            PostStatus postStatus = _db.PostStatues.Where(x => x.Id == id).FirstOrDefault();
            _db.SaveChanges();
        }
        //..............create post.....
        public void CreatePost(Post post)
        {
            _db.Posts.Update(post);
            _db.SaveChanges();
        }
        //------- update post-----
        public void UpdatePost(Post post)
        {

            _db.Posts.Update(post);
            _db.SaveChanges();
        }
        //------ delete post-------
        public void DeletePost(int id)
        {
            Post post = _db.Posts.Where(x => x.Id == id).FirstOrDefault();
            _db.Posts.Remove(post);
            _db.SaveChanges();
        }

        // Reaction Type Methods

        public List<ReactionType> GetReactionTypes()
        {
            return _db.ReactionsTypes.ToList();
        }

        public ReactionType GetReactionType(int id)
        {
            return _db.ReactionsTypes.Where(x => x.Id == id).FirstOrDefault();
        }

        public void AddUpdateReactionType(ReactionType reactionType)
        {
            _db.ReactionsTypes.Update(reactionType);
            _db.SaveChanges();
        }

        public void DeleteReactionType(int id)
        {
            ReactionType reactionType = _db.ReactionsTypes.Where(x => x.Id == id).FirstOrDefault();
            _db.ReactionsTypes.Remove(reactionType);
            _db.SaveChanges();
        }
        //----post reaction----
        public List<PostReaction> GetPostReactions()
        {
            return _db.PostReactions.Include(x => x.User).Include(x => x.Post).Include(x => x.ReactionType).ToList();
        }

        public PostReaction GetPostReaction(int id)
        {
            return _db.PostReactions.Where(x => x.Id == id).Include(x => x.User).Include(x => x.Post).Include(x => x.ReactionType).FirstOrDefault();
        }

        public void CreatePostReaction(PostReaction postReaction)
        {
            _db.PostReactions.Add(postReaction);
            _db.SaveChanges();
        }

        public void UpdatePostReaction(PostReaction postReaction)
        {
            _db.PostReactions.Update(postReaction);
            _db.SaveChanges();
        }

        public void DeletePostReaction(int id)
        {
            PostReaction postReaction = _db.PostReactions.Where(x => x.Id == id).FirstOrDefault();

            _db.PostReactions.Remove(postReaction);
            _db.SaveChanges();
        }
    }
}

