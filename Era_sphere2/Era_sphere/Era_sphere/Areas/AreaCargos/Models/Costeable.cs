﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Era_sphere.Areas.AreaCargos.Models;
using Era_sphere.Generics;
using Era_sphere.Areas.AreaContable.Models.Recibo;

namespace Era_sphere.Areas.AreaCargos.Models
{
    public abstract class Costeable: DBable
    {
        public abstract List<ReciboLinea> generarReciboLineas();
    }
}