using PDApp.ApiEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDApp
{
    public partial class UserResponse
    {
        public string mensagem { get; set; }
        public User usuario { get; set; }
    }
}
