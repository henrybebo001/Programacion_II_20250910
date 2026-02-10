using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa_de_Clases.Entities
{
    public class ExAlumno : MiembroDeLaComunidad
    {
        public string graduationYear { get; set; }
        public string degree { get; set; }
        public string currentOccupation { get; set; }
    }
}
