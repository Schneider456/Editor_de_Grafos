using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EditordeGrafos {
    [Serializable()]
    public class Arista {

        //Contiene el vértice origen de la arista
        private string origen;          
        //Contiene el vértice destino de la arista
        private string destino;
        //Contiene el tipo de arista que se dibujará
        private string tipoGrafo;
        //Contiene la posición inicial de la arista
        private int posX, posY;
        //Contiene la posición final de la arista
        private int posXF, posYF;

        public Arista() {
            //Cuando creo una arista sus valores iniciales son por defecto
            origen = "";
            destino = "";
            tipoGrafo = "";
            posX = posY = posXF = posYF = 0;
        }

        //Propiedades de una arista para su acceso debido a su encapsulación
        public string Origen {
            set {
                origen = value;
            }
            get {
                return origen;
            }
        }
        public string Destino {
            set {
                destino = value;
            }
            get {
                return destino;
            }
        }
        public string Tipo {
            set {
                tipoGrafo = value;
            }
            get {
                return tipoGrafo;
            }
        }
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
        public int XF {
            get {
                return posXF;
            }
            set {
                posXF = value;
            }
        }
        public int YF {
            get {
                return posYF;
            }
            set {
                posYF = value;
            }
        }
    }
}
