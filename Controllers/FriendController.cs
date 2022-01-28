using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiPractice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FriendController : ControllerBase
    {
        List<Friend> friends = new List<Friend>
        {
            new Friend(1, "Kindson", "Munonye", "Budapest", DateTime.Today),
            new Friend(2, "Helen", "Grosko", "Australia", DateTime.Today),
            new Friend(3, "Klowee", "Malakowsky", "Arizona", DateTime.Today),
            new Friend(4, "Ellie", "Huth", "New York", DateTime.Today),
            new Friend(5, "Kada", "Malakowsky", "Minnesota", DateTime.Today)
        };



        // GET: api/Friend
        [HttpGet]
        public List<Friend> Get()
        {
            return friends;
        }

        // GET: api/Friend/5
        // return Friend of specified id
        [HttpGet("{id}", Name = "Get")]
        public Friend Get(int id)
        {
            Friend friend = friends.Find(f => f.id == id);
            return friend;
        }

        // POST: api/Friend
        [HttpPost]
        public List<Friend> Post([FromBody] Friend friend)
        {
            friends.Add(friend);
            return friends;
        }

        // PUT: api/Friend/5
        // edit Friend of specified id
        [HttpPut("{id}")]
        public List<Friend> Put(int id, [FromBody] Friend friend)
        {
            Friend friendToUpdate = friends.Find(f => f.id == id);
            int index = friends.IndexOf(friendToUpdate);

            friends[index].firstname = friend.firstname;
            friends[index].lastname = friend.lastname;
            friends[index].location = friend.location;
            friends[index].dateOfHire = friend.dateOfHire;

            return friends;
        }


        // DELETE: api/Friend/5
        // delete Friend of specified id
        [HttpDelete("{id}")]
        public List<Friend> Delete(int id)
        {
            Friend friend = friends.Find(f => f.id == id);
            friends.Remove(friend);
            return friends;
        }
    }
}
