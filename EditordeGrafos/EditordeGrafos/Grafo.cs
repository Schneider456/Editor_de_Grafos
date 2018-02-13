using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos {
    [Serializable()]
    public class Grafo {

        //Cada grafo contiene una lista de vértices
        private List<Vertice> vertices;
        //El grafo solo podrá contener aristas de un mismo tipo
        private string tipoGrafo;

        public Grafo(string tipo) {
            //Cuando creo un grafo se inicializan sus valores por defecto
            vertices = new List<Vertice>();
            tipoGrafo = tipo;
        }

        //Propiedades que me permiten el acceso a los atributos del grafo
        public List<Vertice> Vertices {
            get {
                return vertices;
            }
        }
        public string Tipo {
            get {
                return tipoGrafo;
            }
        }
    }
}
