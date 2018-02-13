using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos {
    [Serializable()]
    public class Vertice {

        //Cada v�rtice tiene su lista de arista que saldr�n de �l
        private List<Arista> aristas;
        //Posici�n del v�rtice
        private int posX;
        private int posY;
        //Nombre del v�rtice
		private string nombre;

        public Vertice() {
            //Cuando creo un v�rtice nuevo se crea con sus valores por defecto
            aristas = new List<Arista>();
            nombre = "";
            posX = posY = 0;
        }
		
        //Propiedades para acceder a las variables de cada v�rtice debido a su encapsulaci�n
		public int X {
			get {
				return posX;
			}
			set {
				posX = value;
			}
		}
		public int Y {
			get {
				return posY;
			}
			set {
				posY = value;
			}
		}
        public string Nombre {
            get {
                return nombre;
            }
            set {
                nombre = value;
            }
        }
        public List<Arista> Aristas {
            get {
                return aristas;
            }
        }
    }
}
