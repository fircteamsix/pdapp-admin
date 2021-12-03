using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDApp.ApiEntity
{
    class Campanha
    {
        [JsonProperty("id_campanha")]
        public long IdCampanha { get; set; }

        [JsonProperty("titulo_paciente")]
        public string TituloPaciente { get; set; }

        [JsonProperty("data_inicio")]
        public string DataInicio { get; set; }

        [JsonProperty("data_termino")]
        public string DataTermino { get; set; }

        [JsonProperty("local_doacao")]
        public string LocalDoacao { get; set; }

        [JsonProperty("tipo_sanguineo")]
        public string TipoSanguineo { get; set; }

        [JsonProperty("foto")]
        public object Foto { get; set; }

        [JsonProperty("estado")]
        public string Estado { get; set; }

        [JsonProperty("cd_usuario")]
        public long CdUsuario { get; set; }
    }
}
