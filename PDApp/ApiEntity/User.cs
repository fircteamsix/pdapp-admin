using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDApp.ApiEntity
{
    public class User
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string estado { get; set; }
        public string rua { get; set; }
        public string cidade { get; set; }
        public int cep { get; set; }
        public string bairro { get; set; }
        public string complemento { get; set; }
        public string tipo_sanguineo { get; set; }
        public string data_nascimento { get; set; }
        public string foto { get; set; }
        public int status { get; set; }
        public string admin { get; set; }

        public User(int id)
        {
            this.id = id;
        }
        public User(int id, int status)
        {
            this.id = id;
            this.status = status;
        }

        public User()
        {
        }
        public override string ToString()
        {
            return nome + " | " + email + " | " + status + " | " + admin;
        }
    }
}
