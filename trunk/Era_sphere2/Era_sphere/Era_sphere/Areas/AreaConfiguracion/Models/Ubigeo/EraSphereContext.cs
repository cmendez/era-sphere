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
                new Pais{nombre="Trinidad y Tobago"},
                new Pais{nombre="No definido"}
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
                new Ciudad { nombre = "Ucayali", pais = paises.Find(12) },

                new Ciudad { nombre = "Nueva York", pais = paises.Find(2) },
                new Ciudad { nombre = "Washington D.C.", pais = paises.Find(2) },
                new Ciudad { nombre = "Distrito Federal", pais = paises.Find(3) },
                new Ciudad { nombre = "Buenos Aires", pais = paises.Find(4) },
                new Ciudad { nombre = "Rio de Janeiro", pais = paises.Find(6) },
                new Ciudad { nombre = "Santiago", pais = paises.Find(7) },
                new Ciudad { nombre = "Asunción", pais = paises.Find(11) },
                new Ciudad { nombre = "Caracas", pais = paises.Find(15) },
                new Ciudad { nombre = "La Habana", pais = paises.Find(21) },
                new Ciudad { nombre = "No definido"}

            };

            foreach (Ciudad c in _ciudades) ciudades.Add(c);
            SaveChanges();

            var _provincias = new List<Provincia> {

                //Nueva York
                new Provincia { nombre = "Brooklyn", ciudad = ciudades.Find(39) },
                //Washington
                new Provincia { nombre = "Georgetown", ciudad = ciudades.Find(40) },
                new Provincia { nombre = "Xochimilco", ciudad = ciudades.Find(41) },
                new Provincia { nombre = "Palermo", ciudad = ciudades.Find(42) },
                new Provincia { nombre = "Flamengo", ciudad = ciudades.Find(43) },
                new Provincia { nombre = "Providencia", ciudad = ciudades.Find(44) },
                new Provincia { nombre = "San Lorenzo", ciudad = ciudades.Find(45) },
                new Provincia { nombre = "Sucre", ciudad = ciudades.Find(46) },
                new Provincia { nombre = "La Habana Vieja", ciudad = ciudades.Find(47) },

                //Lima
                new Provincia { nombre = "Barranca", ciudad = ciudades.Find(28) },
                new Provincia { nombre = "Cajatambo", ciudad = ciudades.Find(28) },
                new Provincia { nombre = "Canta", ciudad = ciudades.Find(28) },
                new Provincia { nombre = "Cañete", ciudad = ciudades.Find(28) },
                new Provincia { nombre = "Huaral", ciudad = ciudades.Find(28) },
                new Provincia { nombre = "Huarochirí", ciudad = ciudades.Find(28) },
                new Provincia { nombre = "Huaura", ciudad = ciudades.Find(28) },
                new Provincia { nombre = "Lima", ciudad = ciudades.Find(28) },
                new Provincia { nombre = "Oyón", ciudad = ciudades.Find(28) },
                new Provincia { nombre = "Yauyos", ciudad = ciudades.Find(28) },

                //Amazonas
                new Provincia { nombre = "Chachapoyas", ciudad = ciudades.Find(14) },
                new Provincia { nombre = "Bagua", ciudad = ciudades.Find(14) },
                new Provincia { nombre = "Bongará", ciudad = ciudades.Find(14) },
                new Provincia { nombre = "Condorcanqui", ciudad = ciudades.Find(14) },
                new Provincia { nombre = "Luya", ciudad = ciudades.Find(14) },
                new Provincia { nombre = "Rodríguez de Mendoza", ciudad = ciudades.Find(14) },
                new Provincia { nombre = "Utcubamba", ciudad = ciudades.Find(14) },

                //Ancash
                new Provincia { nombre = "Aija", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Antonio Raymondi", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Asunción", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Bolognesi", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Carhuaz", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Carlos", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Corongo", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Huarmey", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Huaylas", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Mariscal Luzuriaga", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Ocros", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Pallasca", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Pomabamba", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Recuay", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Sihuas", ciudad = ciudades.Find(15) },
                new Provincia { nombre = "Yungay", ciudad = ciudades.Find(15) },

                //Apurimac
                new Provincia { nombre = "Abancay", ciudad = ciudades.Find(16) },
                new Provincia { nombre = "Antabamba", ciudad = ciudades.Find(16) },
                new Provincia { nombre = "Aymaraes", ciudad = ciudades.Find(16) },
                new Provincia { nombre = "Cotabambas", ciudad = ciudades.Find(16) },
                new Provincia { nombre = "Grau", ciudad = ciudades.Find(16) },
                new Provincia { nombre = "Chincheros", ciudad = ciudades.Find(16) },
                new Provincia { nombre = "Andahuaylas", ciudad = ciudades.Find(16) },

                //Arequipa
                new Provincia { nombre = "Arequipa", ciudad = ciudades.Find(17) },
                new Provincia { nombre = "Camaná", ciudad = ciudades.Find(17) },
                new Provincia { nombre = "Caravelí", ciudad = ciudades.Find(17) },
                new Provincia { nombre = "Castilla", ciudad = ciudades.Find(17) },
                new Provincia { nombre = "Caylloma", ciudad = ciudades.Find(17) },
                new Provincia { nombre = "Condesuyos", ciudad = ciudades.Find(17) },
                new Provincia { nombre = "Islay	Mollendo", ciudad = ciudades.Find(17) },
                new Provincia { nombre = "La Unión", ciudad = ciudades.Find(17) },

                //Ayacucho
                new Provincia { nombre = "Cangallo", ciudad = ciudades.Find(18) },
                new Provincia { nombre = "Huanta", ciudad = ciudades.Find(18) },
                new Provincia { nombre = "Huamanga", ciudad = ciudades.Find(18) },
                new Provincia { nombre = "Huancasancos", ciudad = ciudades.Find(18) },
                new Provincia { nombre = "La Mar", ciudad = ciudades.Find(18) },
                new Provincia { nombre = "Lucanas", ciudad = ciudades.Find(18) },
                new Provincia { nombre = "Parinacochas", ciudad = ciudades.Find(18) },
                new Provincia { nombre = "Páucar del Sara Sara", ciudad = ciudades.Find(18) },
                new Provincia { nombre = "Sucre", ciudad = ciudades.Find(18) },
                new Provincia { nombre = "Victor Fajardo", ciudad = ciudades.Find(18) },
                new Provincia { nombre = "Vilcas Huamán", ciudad = ciudades.Find(18) },


                //Cajamarca
                new Provincia { nombre = "Jaén", ciudad = ciudades.Find(19) },
                new Provincia { nombre = "Cutervo", ciudad = ciudades.Find(19) },
                new Provincia { nombre = "Chota", ciudad = ciudades.Find(19) },
                new Provincia { nombre = "Santa Cruz", ciudad = ciudades.Find(19) },
                new Provincia { nombre = "Hualgayoc", ciudad = ciudades.Find(19) },
                new Provincia { nombre = "Celendín", ciudad = ciudades.Find(19) },
                new Provincia { nombre = "San Miguel", ciudad = ciudades.Find(19) },
                new Provincia { nombre = "San Pablo", ciudad = ciudades.Find(19) },
                new Provincia { nombre = "Cajamarca", ciudad = ciudades.Find(19) },
                new Provincia { nombre = "Contumazá", ciudad = ciudades.Find(19) },
                new Provincia { nombre = "Cajabamba", ciudad = ciudades.Find(19) },
                new Provincia { nombre = "San Marcos", ciudad = ciudades.Find(19) },

                //Callao

                //Cuzco
                new Provincia { nombre = "Cuzco", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "Acomayo", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "Anta", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "Calca", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "Canas", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "Canchis", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "Chumbivilcas", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "Espinar", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "La Convención", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "Paruro", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "Paucartambo", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "Quispicanchi", ciudad = ciudades.Find(21) },
                new Provincia { nombre = "Urubamba", ciudad = ciudades.Find(21) },

                //Huancavelica
                new Provincia { nombre = "Huancavelica", ciudad = ciudades.Find(22) },
                new Provincia { nombre = "Acobamba", ciudad = ciudades.Find(22) },
                new Provincia { nombre = "Angaraes", ciudad = ciudades.Find(22) },
                new Provincia { nombre = "Castrovirreyna", ciudad = ciudades.Find(22) },
                new Provincia { nombre = "Churcampa", ciudad = ciudades.Find(22) },
                new Provincia { nombre = "Huaytará", ciudad = ciudades.Find(22) },
                new Provincia { nombre = "Tayacaja", ciudad = ciudades.Find(22) },

                //Huanuco
                new Provincia { nombre = "Huánuco", ciudad = ciudades.Find(23) },
                new Provincia { nombre = "Ambo", ciudad = ciudades.Find(23) },
                new Provincia { nombre = "Dos de Mayo", ciudad = ciudades.Find(23) },
                new Provincia { nombre = "Huacaybamba", ciudad = ciudades.Find(23) },
                new Provincia { nombre = "Huamalíes", ciudad = ciudades.Find(23) },
                new Provincia { nombre = "Leoncio Prado", ciudad = ciudades.Find(23) },
                new Provincia { nombre = "Marañón", ciudad = ciudades.Find(23) },
                new Provincia { nombre = "Pachitea", ciudad = ciudades.Find(23) },
                new Provincia { nombre = "Puerto Inca", ciudad = ciudades.Find(23) },
                new Provincia { nombre = "Lauricocha", ciudad = ciudades.Find(23) },
                new Provincia { nombre = "Yarowilca", ciudad = ciudades.Find(23) },

                //Ica
                new Provincia { nombre = "Huánuco", ciudad = ciudades.Find(24) },
                new Provincia { nombre = "Ica", ciudad = ciudades.Find(24) },
                new Provincia { nombre = "Chincha", ciudad = ciudades.Find(24) },
                new Provincia { nombre = "Nazca", ciudad = ciudades.Find(24) },
                new Provincia { nombre = "Palpa", ciudad = ciudades.Find(24) },
                new Provincia { nombre = "Pisco", ciudad = ciudades.Find(24) },

                //Junin
                new Provincia { nombre = "Chanchamayo", ciudad = ciudades.Find(25) },
                new Provincia { nombre = "Chupaca", ciudad = ciudades.Find(25) },
                new Provincia { nombre = "Concepción", ciudad = ciudades.Find(25) },
                new Provincia { nombre = "Huancayo", ciudad = ciudades.Find(25) },
                new Provincia { nombre = "Jauja", ciudad = ciudades.Find(25) },
                new Provincia { nombre = "Junín", ciudad = ciudades.Find(25) },
                new Provincia { nombre = "Satipo", ciudad = ciudades.Find(25) },
                new Provincia { nombre = "Tarma", ciudad = ciudades.Find(25) },
                new Provincia { nombre = "Yauli", ciudad = ciudades.Find(25) },

                //La libertad
                new Provincia { nombre = "Trujillo", ciudad = ciudades.Find(26) },
                new Provincia { nombre = "Ascope", ciudad = ciudades.Find(26) },
                new Provincia { nombre = "Bolívar", ciudad = ciudades.Find(26) },
                new Provincia { nombre = "Chepén", ciudad = ciudades.Find(26) },
                new Provincia { nombre = "Cascas", ciudad = ciudades.Find(26) },
                new Provincia { nombre = "Julcán", ciudad = ciudades.Find(26) },
                new Provincia { nombre = "Otuzco", ciudad = ciudades.Find(26) },
                new Provincia { nombre = "San Pedro de Lloc", ciudad = ciudades.Find(26) },
                new Provincia { nombre = "Tayabamba", ciudad = ciudades.Find(26) },
                new Provincia { nombre = "Huamachuco", ciudad = ciudades.Find(26) },
                new Provincia { nombre = "Santiago de Chuco", ciudad = ciudades.Find(26) },
                new Provincia { nombre = "Virú", ciudad = ciudades.Find(26) },

                //Lambayeque
                new Provincia { nombre = "Chiclayo", ciudad = ciudades.Find(27) },
                new Provincia { nombre = "Lambayaque", ciudad = ciudades.Find(27) },
                new Provincia { nombre = "Ferreñafe", ciudad = ciudades.Find(27) },

                //Loreto
                new Provincia { nombre = "Maynas", ciudad = ciudades.Find(29) },
                new Provincia { nombre = "Alto Amazonas", ciudad = ciudades.Find(29) },
                new Provincia { nombre = "Datem del Marañón", ciudad = ciudades.Find(29) },
                new Provincia { nombre = "Loreto", ciudad = ciudades.Find(29) },
                new Provincia { nombre = "Mariscal Ramón Castilla", ciudad = ciudades.Find(29) },
                new Provincia { nombre = "Requena", ciudad = ciudades.Find(29) },
                new Provincia { nombre = "Ucayali", ciudad = ciudades.Find(29) },

                //Madre de Dios
                new Provincia { nombre = "Tambopata", ciudad = ciudades.Find(30) },
                new Provincia { nombre = "Manu", ciudad = ciudades.Find(30) },
                new Provincia { nombre = "Tahuamanu", ciudad = ciudades.Find(30) },

                //Moquegua
                new Provincia { nombre = "Mariscal Nieto", ciudad = ciudades.Find(31) },
                new Provincia { nombre = "General Sánchez Cerro", ciudad = ciudades.Find(31) },
                new Provincia { nombre = "Ilo", ciudad = ciudades.Find(31) },

                //Pasco
                new Provincia { nombre = "Pasco", ciudad = ciudades.Find(32) },
                new Provincia { nombre = "Daniel A. Carrión", ciudad = ciudades.Find(32) },
                new Provincia { nombre = "Oxapampa", ciudad = ciudades.Find(32) },

                //Piura
                new Provincia { nombre = "Ayabaca", ciudad = ciudades.Find(33) },
                new Provincia { nombre = "Huancabamba", ciudad = ciudades.Find(33) },
                new Provincia { nombre = "Morropón", ciudad = ciudades.Find(33) },
                new Provincia { nombre = "Paita", ciudad = ciudades.Find(33) },
                new Provincia { nombre = "Piura", ciudad = ciudades.Find(33) },
                new Provincia { nombre = "Sechura", ciudad = ciudades.Find(33) },
                new Provincia { nombre = "Sullana", ciudad = ciudades.Find(33) },
                new Provincia { nombre = "Talara", ciudad = ciudades.Find(33) },

                //Puno
                new Provincia { nombre = "San Roman", ciudad = ciudades.Find(34) },
                new Provincia { nombre = "Puno", ciudad = ciudades.Find(34) },
                new Provincia { nombre = "Azángaro", ciudad = ciudades.Find(34) },	
                new Provincia { nombre = "Chucuito", ciudad = ciudades.Find(34) },	
                new Provincia { nombre = "El Collao", ciudad = ciudades.Find(34) },	
                new Provincia { nombre = "Melgar", ciudad = ciudades.Find(34) },		
                new Provincia { nombre = "Carabaya", ciudad = ciudades.Find(34) },		
                new Provincia { nombre = "Huancané", ciudad = ciudades.Find(34) },		
                new Provincia { nombre = "Sandia", ciudad = ciudades.Find(34) },	
                new Provincia { nombre = "San Antonio de Putina", ciudad = ciudades.Find(34) },	
                new Provincia { nombre = "Lampa", ciudad = ciudades.Find(34) },	
                new Provincia { nombre = "Yunguyo", ciudad = ciudades.Find(34) },		
                new Provincia { nombre = "Moho", ciudad = ciudades.Find(34) },

                //San Martin
                new Provincia { nombre = "Tacna", ciudad = ciudades.Find(35) },
                new Provincia { nombre = "Candarave", ciudad = ciudades.Find(35) },
                new Provincia { nombre = "Jorge Basadre", ciudad = ciudades.Find(35) },
                new Provincia { nombre = "Tarata", ciudad = ciudades.Find(35) },

                //Tacna
                new Provincia { nombre = "Candarave", ciudad = ciudades.Find(36) },
                new Provincia { nombre = "Jorge Basadre", ciudad = ciudades.Find(36) },
                new Provincia { nombre = "Tacna", ciudad = ciudades.Find(36) },
                new Provincia { nombre = "Tarata", ciudad = ciudades.Find(36) },

                //Tumbes
                new Provincia { nombre = "Tumbes", ciudad = ciudades.Find(37) },
                new Provincia { nombre = "Zarumilla", ciudad = ciudades.Find(37) },
                new Provincia { nombre = "Contralmirante Villar", ciudad = ciudades.Find(37) },

                //Ucayali
                new Provincia { nombre = "Coronel Portillo", ciudad = ciudades.Find(38) },
                new Provincia { nombre = "Atalaya", ciudad = ciudades.Find(38) },
                new Provincia { nombre = "Padre Abad", ciudad = ciudades.Find(38) },
                new Provincia { nombre = "Purús", ciudad = ciudades.Find(38) }
            };

            foreach (Provincia p in _provincias)
            {
                provincias.Add(p);
            }
            SaveChanges();

        }
    }
}
