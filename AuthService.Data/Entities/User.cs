using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService.Data.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        
        public string UserName { get; set; }

        public ICollection<SessionToken> SessionTokens { get; set; } = new List<SessionToken>();
    }
}
