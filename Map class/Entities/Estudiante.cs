using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mapa_de_Clases.Entities

{
    public class Estudiante : MiembroDeLaComunidad
    {
        string grade { get; set; }
        string major { get; set; }
        string university { get; set; }
    }
}
