using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDApp.ApiEntity
{
    class Hemocentro
    {
        [JsonProperty("id_hemocentro")]
        public long IdHemocentro { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("unidade")]
        public string Unidade { get; set; }

        [JsonProperty("link")]
        public Uri Link { get; set; }
    }
}
