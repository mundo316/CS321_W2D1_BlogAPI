using System;
using System.Collections.Generic;
using System.Linq;
using CS321_W2D1_BlogAPI.Models;

namespace CS321_W2D1_BlogAPI.Services
{
    public class PostService : IPostService
    {
        // seed some initial Post data
        private List<Post> _posts = new List<Post>()
        {
            new Post
            {
                Id = 1,
                Title = "My first blog post",
                Body = "Blah blah blah"
            },
            new Post
            {
                Id = 2,
                Title = "My second blog post",
                Body = "Blah blah blah"
            }
        };
        // keep track of next id number
        private int _nextId = 3;

        public Post Add(Post post)
        {
            // assign an id (and then increment _nextId for next time)
            post.Id = _nextId++;
            // store in the list of Posts
            _posts.Add(post);// add the new post to the list of posts (_posts)
            // return the new Post with Id filled in
            return post;
        }

        public Post Get(int id)
        {
            // return the specified Post or null if not found
            //  use FirstOrDefault() to find the Post by id in _posts and return it
            
            return _posts.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetAll()
        {
            return _posts;
            // return the full list of posts
        }

        public Post Update(Post updatedPost)
        {
            // get the Post object in the current list with this id 
            // find the post to update in the list, using updatedPost.Id, and assign to currentPost
            var currentpost = _posts.FirstOrDefault(p => p.Id == updatedPost.Id);
            // OR this.Get(updatedPost.Id)


            // return null if the Post to update isn't found
            if (currentpost == null) return null;

            // copy the property values from the updated post into the current post object
            // copy the values in updatedPost to the post you found in the list
            currentpost.Body = updatedPost.Body;
            currentpost.Title = updatedPost.Title;
            return currentpost;
        }

        public void Remove(Post post)
        {
            // remove the post from _posts
            var currentPost = _posts.FirstOrDefault(p => p.Id == post.Id);
            if (currentPost != null)
            {
                _posts.Remove(currentPost);
            }
            else
            {
                throw new Exception("Cannot remove current post!");
            }
        }
    }
}
