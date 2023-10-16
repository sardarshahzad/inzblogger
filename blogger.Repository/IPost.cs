using blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blogger.Repository
{
    public interface IPost
    {
        // ------------ Post Methods ----------------
        List<Post> GetPosts { get; }
        Post GetPost(int id);
        void CreatePost(Post post);
        void UpdatePost(Post post);
        void DeletePost(int id);


        // ------------ Category Methods ----------------
        List<Category> GetCategories();
        Category GetCategory(int id);
        void AddupdateCategory(Category category);
        void DetachCategory(int id);

        // ------------ Post Status Methods ----------------
        List<PostStatus> GetPostStatuses();
        PostStatus GetPostStatus(int id);
        void AddUpDatePostStatus(PostStatus postStatus);
        void DeletePostStatus(int id);
        // Methods for Reaction Types
        List<ReactionType> GetReactionTypes();
        ReactionType GetReactionType(int id);
        void AddUpdateReactionType(ReactionType reactionType);
        void DeleteReactionType(int id);
        // Methods for Post Reaction
        List<PostReaction> GetPostReactions();
        PostReaction GetPostReaction(int id);
        void CreatePostReaction(PostReaction postReaction);
        void UpdatePostReaction(PostReaction postReaction);
        void DeletePostReaction(int id);
    }
}
