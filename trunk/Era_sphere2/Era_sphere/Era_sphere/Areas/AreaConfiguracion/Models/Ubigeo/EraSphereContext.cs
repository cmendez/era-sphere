using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Era_sphere.Areas.AreaConfiguracion.Models.Ubigeo;

namespace Era_sphere.Generics
{
    public partial class EraSphereContext : DbContext
    {
        public DbSet<Pais> paises { get; set; }
        public DbSet<Ciudad> ciudades { get; set; }
        public DbSet<Provincia> provincias { get; set; }

        public void seedUbigeo(){
            var _paises = new List<Pais>
            {
                new Pais{nombre="Canadá"},
                new Pais{nombre="Estados Unidos"},
                new Pais{nombre="México"},
                new Pais{nombre="Argentina"},
                new Pais{nombre="Bolivia"},
                new Pais{nombre="Brasil"},
                new Pais{nombre="Chile"},
                new Pais{nombre="Colombia"},
                new Pais{nombre="Ecuador"},
                new Pais{nombre="Guyana"},
                new Pais{nombre="Paraguay"},
                new Pais{nombre="Perú"},
                new Pais{nombre="Surinam"},
                new Pais{nombre="Uruguay"},
                new Pais{nombre="Venezuela"},
                new Pais{nombre="Antigua y Barbuda"},
                new Pais{nombre="Bahamas"},
                new Pais{nombre="Barbados"},
                new Pais{nombre="Bélice"},
                new Pais{nombre="Costa Rica"},
                new Pais{nombre="Cuba"},
                new Pais{nombre="Dominica"},
                new Pais{nombre="El Salvador"},
                new Pais{nombre="Granada"},
                new Pais{nombre="Guatemala"},
                new Pais{nombre="Haití"},
                new Pais{nombre="Honduras"},
                new Pais{nombre="Jamaica"},
                new Pais{nombre="Nicaragua"},
                new Pais{nombre="Panamá"},
                new Pais{nombre="Puerto Rico"},
                new Pais{nombre="República Dominicana"},
                new Pais{nombre="San Cristóbal y Nevis"},
                new Pais{nombre="Santa Lucía"},
                new Pais{nombre="San Vicente y las Granadinas"},
                new Pais{nombre="Trinidad y Tobago"}
            };
            foreach (var p in _paises)
                paises.Add(p);
            SaveChanges();

            var _ciudades = new List<Ciudad> {
                new Ciudad { nombre = "Ontario", pais = paises.Find(1) },
                new Ciudad { nombre = "Quebec", pais = paises.Find(1) },
                new Ciudad { nombre = "Nueva Escocia", pais = paises.Find(1) },
                new Ciudad { nombre = "Nuevo Brunswick", pais = paises.Find(1) },
                new Ciudad { nombre = "Manitoba", pais = paises.Find(1) },
                new Ciudad { nombre = "Columbia Británica", pais = paises.Find(1) },
                new Ciudad { nombre = "Isla del Príncipe", pais = paises.Find(1) },
                new Ciudad { nombre = "Saskatchewan", pais = paises.Find(1) },
                new Ciudad { nombre = "Alberta", pais = paises.Find(1) },
                new Ciudad { nombre = "Terranova y Labrador", pais = paises.Find(1) },
                new Ciudad { nombre = "Territorios del Noroeste", pais = paises.Find(1) },
                new Ciudad { nombre = "Yukón", pais = paises.Find(1) },
                new Ciudad { nombre = "Nunavut", pais = paises.Find(1) },


                new Ciudad { nombre = "Amazonas", pais = paises.Find(12) },
                new Ciudad { nombre = "Áncash", pais = paises.Find(12) },
                new Ciudad { nombre = "Apurímac", pais = paises.Find(12) },
                new Ciudad { nombre = "Arequipa", pais = paises.Find(12) },
                new Ciudad { nombre = "Ayacucho", pais = paises.Find(12) },
                new Ciudad { nombre = "Cajamarca", pais = paises.Find(12) },
                new Ciudad { nombre = "Callao", pais = paises.Find(12) },
                new Ciudad { nombre = "Cuzco", pais = paises.Find(12) },
                new Ciudad { nombre = "Huancavelica", pais = paises.Find(12) },
                new Ciudad { nombre = "Huánuco", pais = paises.Find(12) },
                new Ciudad { nombre = "Ica", pais = paises.Find(12) },
                new Ciudad { nombre = "Junín", pais = paises.Find(12) },
                new Ciudad { nombre = "La Libertad", pais = paises.Find(12) },
                new Ciudad { nombre = "Lambayeque", pais = paises.Find(12) },
                new Ciudad { nombre = "Lima", pais = paises.Find(12) },
                new Ciudad { nombre = "Loreto", pais = paises.Find(12) },
                new Ciudad { nombre = "Madre de Dios", pais = paises.Find(12) },
                new Ciudad { nombre = "Moquegua", pais = paises.Find(12) },
                new Ciudad { nombre = "Pasco", pais = paises.Find(12) },
                new Ciudad { nombre = "Piura", pais = paises.Find(12) },
                new Ciudad { nombre = "Puno", pais = paises.Find(12) },
                new Ciudad { nombre = "San Martín", pais = paises.Find(12) },
                new Ciudad { nombre = "Tacna", pais = paises.Find(12) },
                new Ciudad { nombre = "Tumbes", pais = paises.Find(12) },
                new Ciudad { nombre = "Ucayali", pais = paises.Find(12) }
            };

            foreach (Ciudad c in _ciudades) ciudades.Add(c);
            SaveChanges();

            var _provincias = new List<Provincia> {

                //Lima
                new Provincia { Nombre = "Barranca", ciudad = ciudades.Find(28) },
                new Provincia { Nombre = "Cajatambo", ciudad = ciudades.Find(28) },
                new Provincia { Nombre = "Canta", ciudad = ciudades.Find(28) },
                new Provincia { Nombre = "Cañete", ciudad = ciudades.Find(28) },
                new Provincia { Nombre = "Huaral", ciudad = ciudades.Find(28) },
                new Provincia { Nombre = "Huarochirí", ciudad = ciudades.Find(28) },
                new Provincia { Nombre = "Huaura", ciudad = ciudades.Find(28) },
                new Provincia { Nombre = "Lima", ciudad = ciudades.Find(28) },
                new Provincia { Nombre = "Oyón", ciudad = ciudades.Find(28) },
                new Provincia { Nombre = "Yauyos", ciudad = ciudades.Find(28) },

                //Amazonas
                new Provincia { Nombre = "Chachapoyas", ciudad = ciudades.Find(14) },
                new Provincia { Nombre = "Bagua", ciudad = ciudades.Find(14) },
                new Provincia { Nombre = "Bongará", ciudad = ciudades.Find(14) },
                new Provincia { Nombre = "Condorcanqui", ciudad = ciudades.Find(14) },
                new Provincia { Nombre = "Luya", ciudad = ciudades.Find(14) },
                new Provincia { Nombre = "Rodríguez de Mendoza", ciudad = ciudades.Find(14) },
                new Provincia { Nombre = "Utcubamba", ciudad = ciudades.Find(14) },

                //Ancash
                new Provincia { Nombre = "Aija", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Antonio Raymondi", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Asunción", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Bolognesi", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Carhuaz", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Carlos", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Corongo", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Huarmey", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Huaylas", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Mariscal Luzuriaga", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Ocros", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Pallasca", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Pomabamba", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Recuay", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Sihuas", ciudad = ciudades.Find(15) },
                new Provincia { Nombre = "Yungay", ciudad = ciudades.Find(15) },

                //Apurimac
                new Provincia { Nombre = "Abancay", ciudad = ciudades.Find(16) },
                new Provincia { Nombre = "Antabamba", ciudad = ciudades.Find(16) },
                new Provincia { Nombre = "Aymaraes", ciudad = ciudades.Find(16) },
                new Provincia { Nombre = "Cotabambas", ciudad = ciudades.Find(16) },
                new Provincia { Nombre = "Grau", ciudad = ciudades.Find(16) },
                new Provincia { Nombre = "Chincheros", ciudad = ciudades.Find(16) },
                new Provincia { Nombre = "Andahuaylas", ciudad = ciudades.Find(16) },

                //Arequipa
                new Provincia { Nombre = "Arequipa", ciudad = ciudades.Find(17) },
                new Provincia { Nombre = "Camaná", ciudad = ciudades.Find(17) },
                new Provincia { Nombre = "Caravelí", ciudad = ciudades.Find(17) },
                new Provincia { Nombre = "Castilla", ciudad = ciudades.Find(17) },
                new Provincia { Nombre = "Caylloma", ciudad = ciudades.Find(17) },
                new Provincia { Nombre = "Condesuyos", ciudad = ciudades.Find(17) },
                new Provincia { Nombre = "Islay	Mollendo", ciudad = ciudades.Find(17) },
                new Provincia { Nombre = "La Unión", ciudad = ciudades.Find(17) },

                //Ayacucho
                new Provincia { Nombre = "Cangallo", ciudad = ciudades.Find(18) },
                new Provincia { Nombre = "Huanta", ciudad = ciudades.Find(18) },
                new Provincia { Nombre = "Huamanga", ciudad = ciudades.Find(18) },
                new Provincia { Nombre = "Huancasancos", ciudad = ciudades.Find(18) },
                new Provincia { Nombre = "La Mar", ciudad = ciudades.Find(18) },
                new Provincia { Nombre = "Lucanas", ciudad = ciudades.Find(18) },
                new Provincia { Nombre = "Parinacochas", ciudad = ciudades.Find(18) },
                new Provincia { Nombre = "Páucar del Sara Sara", ciudad = ciudades.Find(18) },
                new Provincia { Nombre = "Sucre", ciudad = ciudades.Find(18) },
                new Provincia { Nombre = "Victor Fajardo", ciudad = ciudades.Find(18) },
                new Provincia { Nombre = "Vilcas Huamán", ciudad = ciudades.Find(18) },


                //Cajamarca
                new Provincia { Nombre = "Jaén", ciudad = ciudades.Find(19) },
                new Provincia { Nombre = "Cutervo", ciudad = ciudades.Find(19) },
                new Provincia { Nombre = "Chota", ciudad = ciudades.Find(19) },
                new Provincia { Nombre = "Santa Cruz", ciudad = ciudades.Find(19) },
                new Provincia { Nombre = "Hualgayoc", ciudad = ciudades.Find(19) },
                new Provincia { Nombre = "Celendín", ciudad = ciudades.Find(19) },
                new Provincia { Nombre = "San Miguel", ciudad = ciudades.Find(19) },
                new Provincia { Nombre = "San Pablo", ciudad = ciudades.Find(19) },
                new Provincia { Nombre = "Cajamarca", ciudad = ciudades.Find(19) },
                new Provincia { Nombre = "Contumazá", ciudad = ciudades.Find(19) },
                new Provincia { Nombre = "Cajabamba", ciudad = ciudades.Find(19) },
                new Provincia { Nombre = "San Marcos", ciudad = ciudades.Find(19) },

                //Callao

                //Cuzco
                new Provincia { Nombre = "Cuzco", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "Acomayo", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "Anta", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "Calca", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "Canas", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "Canchis", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "Chumbivilcas", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "Espinar", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "La Convención", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "Paruro", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "Paucartambo", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "Quispicanchi", ciudad = ciudades.Find(21) },
                new Provincia { Nombre = "Urubamba", ciudad = ciudades.Find(21) },

                //Huancavelica
                new Provincia { Nombre = "Huancavelica", ciudad = ciudades.Find(22) },
                new Provincia { Nombre = "Acobamba", ciudad = ciudades.Find(22) },
                new Provincia { Nombre = "Angaraes", ciudad = ciudades.Find(22) },
                new Provincia { Nombre = "Castrovirreyna", ciudad = ciudades.Find(22) },
                new Provincia { Nombre = "Churcampa", ciudad = ciudades.Find(22) },
                new Provincia { Nombre = "Huaytará", ciudad = ciudades.Find(22) },
                new Provincia { Nombre = "Tayacaja", ciudad = ciudades.Find(22) },

                //Huanuco
                new Provincia { Nombre = "Huánuco", ciudad = ciudades.Find(23) },
                new Provincia { Nombre = "Ambo", ciudad = ciudades.Find(23) },
                new Provincia { Nombre = "Dos de Mayo", ciudad = ciudades.Find(23) },
                new Provincia { Nombre = "Huacaybamba", ciudad = ciudades.Find(23) },
                new Provincia { Nombre = "Huamalíes", ciudad = ciudades.Find(23) },
                new Provincia { Nombre = "Leoncio Prado", ciudad = ciudades.Find(23) },
                new Provincia { Nombre = "Marañón", ciudad = ciudades.Find(23) },
                new Provincia { Nombre = "Pachitea", ciudad = ciudades.Find(23) },
                new Provincia { Nombre = "Puerto Inca", ciudad = ciudades.Find(23) },
                new Provincia { Nombre = "Lauricocha", ciudad = ciudades.Find(23) },
                new Provincia { Nombre = "Yarowilca", ciudad = ciudades.Find(23) },

                //Ica
                new Provincia { Nombre = "Huánuco", ciudad = ciudades.Find(24) },
                new Provincia { Nombre = "Ica", ciudad = ciudades.Find(24) },
                new Provincia { Nombre = "Chincha", ciudad = ciudades.Find(24) },
                new Provincia { Nombre = "Nazca", ciudad = ciudades.Find(24) },
                new Provincia { Nombre = "Palpa", ciudad = ciudades.Find(24) },
                new Provincia { Nombre = "Pisco", ciudad = ciudades.Find(24) },

                //Junin
                new Provincia { Nombre = "Chanchamayo", ciudad = ciudades.Find(25) },
                new Provincia { Nombre = "Chupaca", ciudad = ciudades.Find(25) },
                new Provincia { Nombre = "Concepción", ciudad = ciudades.Find(25) },
                new Provincia { Nombre = "Huancayo", ciudad = ciudades.Find(25) },
                new Provincia { Nombre = "Jauja", ciudad = ciudades.Find(25) },
                new Provincia { Nombre = "Junín", ciudad = ciudades.Find(25) },
                new Provincia { Nombre = "Satipo", ciudad = ciudades.Find(25) },
                new Provincia { Nombre = "Tarma", ciudad = ciudades.Find(25) },
                new Provincia { Nombre = "Yauli", ciudad = ciudades.Find(25) },

                //La libertad
                new Provincia { Nombre = "Trujillo", ciudad = ciudades.Find(26) },
                new Provincia { Nombre = "Ascope", ciudad = ciudades.Find(26) },
                new Provincia { Nombre = "Bolívar", ciudad = ciudades.Find(26) },
                new Provincia { Nombre = "Chepén", ciudad = ciudades.Find(26) },
                new Provincia { Nombre = "Cascas", ciudad = ciudades.Find(26) },
                new Provincia { Nombre = "Julcán", ciudad = ciudades.Find(26) },
                new Provincia { Nombre = "Otuzco", ciudad = ciudades.Find(26) },
                new Provincia { Nombre = "San Pedro de Lloc", ciudad = ciudades.Find(26) },
                new Provincia { Nombre = "Tayabamba", ciudad = ciudades.Find(26) },
                new Provincia { Nombre = "Huamachuco", ciudad = ciudades.Find(26) },
                new Provincia { Nombre = "Santiago de Chuco", ciudad = ciudades.Find(26) },
                new Provincia { Nombre = "Virú", ciudad = ciudades.Find(26) },

                //Lambayeque
                new Provincia { Nombre = "Chiclayo", ciudad = ciudades.Find(27) },
                new Provincia { Nombre = "Lambayaque", ciudad = ciudades.Find(27) },
                new Provincia { Nombre = "Ferreñafe", ciudad = ciudades.Find(27) },

                //Loreto
                new Provincia { Nombre = "Maynas", ciudad = ciudades.Find(29) },
                new Provincia { Nombre = "Alto Amazonas", ciudad = ciudades.Find(29) },
                new Provincia { Nombre = "Datem del Marañón", ciudad = ciudades.Find(29) },
                new Provincia { Nombre = "Loreto", ciudad = ciudades.Find(29) },
                new Provincia { Nombre = "Mariscal Ramón Castilla", ciudad = ciudades.Find(29) },
                new Provincia { Nombre = "Requena", ciudad = ciudades.Find(29) },
                new Provincia { Nombre = "Ucayali", ciudad = ciudades.Find(29) },

                //Madre de Dios
                new Provincia { Nombre = "Tambopata", ciudad = ciudades.Find(30) },
                new Provincia { Nombre = "Manu", ciudad = ciudades.Find(30) },
                new Provincia { Nombre = "Tahuamanu", ciudad = ciudades.Find(30) },

                //Moquegua
                new Provincia { Nombre = "Mariscal Nieto", ciudad = ciudades.Find(31) },
                new Provincia { Nombre = "General Sánchez Cerro", ciudad = ciudades.Find(31) },
                new Provincia { Nombre = "Ilo", ciudad = ciudades.Find(31) },

                //Pasco
                new Provincia { Nombre = "Pasco", ciudad = ciudades.Find(32) },
                new Provincia { Nombre = "Daniel A. Carrión", ciudad = ciudades.Find(32) },
                new Provincia { Nombre = "Oxapampa", ciudad = ciudades.Find(32) },

                //Piura
                new Provincia { Nombre = "Ayabaca", ciudad = ciudades.Find(33) },
                new Provincia { Nombre = "Huancabamba", ciudad = ciudades.Find(33) },
                new Provincia { Nombre = "Morropón", ciudad = ciudades.Find(33) },
                new Provincia { Nombre = "Paita", ciudad = ciudades.Find(33) },
                new Provincia { Nombre = "Piura", ciudad = ciudades.Find(33) },
                new Provincia { Nombre = "Sechura", ciudad = ciudades.Find(33) },
                new Provincia { Nombre = "Sullana", ciudad = ciudades.Find(33) },
                new Provincia { Nombre = "Talara", ciudad = ciudades.Find(33) },

                //Puno
                new Provincia { Nombre = "San Roman", ciudad = ciudades.Find(34) },
                new Provincia { Nombre = "Puno", ciudad = ciudades.Find(34) },
                new Provincia { Nombre = "Azángaro", ciudad = ciudades.Find(34) },	
                new Provincia { Nombre = "Chucuito", ciudad = ciudades.Find(34) },	
                new Provincia { Nombre = "El Collao", ciudad = ciudades.Find(34) },	
                new Provincia { Nombre = "Melgar", ciudad = ciudades.Find(34) },		
                new Provincia { Nombre = "Carabaya", ciudad = ciudades.Find(34) },		
                new Provincia { Nombre = "Huancané", ciudad = ciudades.Find(34) },		
                new Provincia { Nombre = "Sandia", ciudad = ciudades.Find(34) },	
                new Provincia { Nombre = "San Antonio de Putina", ciudad = ciudades.Find(34) },	
                new Provincia { Nombre = "Lampa", ciudad = ciudades.Find(34) },	
                new Provincia { Nombre = "Yunguyo", ciudad = ciudades.Find(34) },		
                new Provincia { Nombre = "Moho", ciudad = ciudades.Find(34) },

                //San Martin
                new Provincia { Nombre = "Tacna", ciudad = ciudades.Find(35) },
                new Provincia { Nombre = "Candarave", ciudad = ciudades.Find(35) },
                new Provincia { Nombre = "Jorge Basadre", ciudad = ciudades.Find(35) },
                new Provincia { Nombre = "Tarata", ciudad = ciudades.Find(35) },

                //Tacna
                new Provincia { Nombre = "Candarave", ciudad = ciudades.Find(36) },
                new Provincia { Nombre = "Jorge Basadre", ciudad = ciudades.Find(36) },
                new Provincia { Nombre = "Tacna", ciudad = ciudades.Find(36) },
                new Provincia { Nombre = "Tarata", ciudad = ciudades.Find(36) },

                //Tumbes
                new Provincia { Nombre = "Tumbes", ciudad = ciudades.Find(37) },
                new Provincia { Nombre = "Zarumilla", ciudad = ciudades.Find(37) },
                new Provincia { Nombre = "Contralmirante Villar", ciudad = ciudades.Find(37) },

                //Ucayali
                new Provincia { Nombre = "Coronel Portillo", ciudad = ciudades.Find(38) },
                new Provincia { Nombre = "Atalaya", ciudad = ciudades.Find(38) },
                new Provincia { Nombre = "Padre Abad", ciudad = ciudades.Find(38) },
                new Provincia { Nombre = "Purús", ciudad = ciudades.Find(38) }
            };

            foreach (Provincia p in _provincias)
            {
                provincias.Add(p);
            }
            SaveChanges();

        }
    }
}
