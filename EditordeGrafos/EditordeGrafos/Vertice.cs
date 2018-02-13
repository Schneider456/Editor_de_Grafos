using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos {
    [Serializable()]
    public class Vertice {

        //Cada vértice tiene su lista de arista que saldrán de él
        private List<Arista> aristas;
        //Posición del vértice
        private int posX;
        private int posY;
        //Nombre del vértice
		private string nombre;

        public Vertice() {
            //Cuando creo un vértice nuevo se crea con sus valores por defecto
            aristas = new List<Arista>();
            nombre = "";
            posX = posY = 0;
        }
		
        //Propiedades para acceder a las variables de cada vértice debido a su encapsulación
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
