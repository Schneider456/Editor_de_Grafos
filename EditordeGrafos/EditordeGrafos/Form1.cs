using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace EditordeGrafos {

    public partial class Form1 : Form {

        //Lista de grafos que contiene el editor debido a que puedo tener más de un grafo a la vez
        private List<Grafo> grafos;
        //Bandera que controla si deseo agregar un nuevo vértice
        bool nuevoVer = false;
        //Bandera que me dice si ya inserté el vértice en el grafo
        bool insertado = true;
        //Bandera que controla si deseo borrar un vértice ya existente
        bool eliminaVer = false;
        //Bandera que controla si deseo agregar una nueva arista
        bool nuevoAri = false;
        //Bandera que controla si deseo eliminar una arista ya existente
        bool eliminaAri = false;
        //Bandera auxiliar que controla si deseo eliminar una arista ya existente
        bool eliminaAri1 = false;
        //Bandera que controla si presioné un vértice para borrarlo
        bool clicado = false;
        bool mueveVer = false;
        bool presionado = false;
        bool guardado = false;
        bool abierto = false;
        bool mueveGraf = false;
        //Variables auxiliares para borrar aristas
        string ori, des;
        //Fuente que se usa para los nombres de los vértices
        Font font = new Font("arial", 12);
        //Pluma para las aristas no dirigidas
        Pen pen = new Pen(Color.Black, 5);
        //Pluma para las aristas dirigidas
        Pen pen1 = new Pen(Color.Black, 5);
        //Brocha para rellenar los vértices
        Brush brush = new SolidBrush(Color.White);
        //Variable auxiliar que ayuda a controlar el vértice que borré
        int numArista = 0;
        List<int> dvx, dvy, daxO, dayO, daxF, dayF;

        public Form1() {
            InitializeComponent();
            
            //Inicializo la lista de grafos
            this.grafos = new List<Grafo>();
            //Al momento de crear la ventana de la forma oculto los botones para la edición de grafo
            agregarVérticeToolStripMenuItem.Enabled = false;
            eliminarVérticeToolStripMenuItem.Enabled = false;
            agregarAristaToolStripMenuItem.Enabled = false;
            eliminarAristaToolStripMenuItem.Enabled = false;
            //Oculto la caja para escribir el nombre del vértice
            textBox1.Hide();
            //Limpio el mensaje del editor
            label1.Text = "";
        }

        //Control para crear un grafo dirigido
        private void dirigidoToolStripMenuItem_Click(object sender, EventArgs e) {
            //Creo un nuevo grafo y lo añado a la lista de grafos
            grafos.Clear();
            Invalidate();
            Grafo grafo = new Grafo("Dirigido");
            grafos.Add(grafo);
            //Habilito los demás controles para la edición del grafo
            agregarVérticeToolStripMenuItem.Enabled = true;
            eliminarVérticeToolStripMenuItem.Enabled = true;
            agregarAristaToolStripMenuItem.Enabled = true;
            eliminarAristaToolStripMenuItem.Enabled = true;
            textBox1.Show();
            this.Text = "Editor de Grafos | Grafo Dirigido";
        }

        //Control para crear un grafo no dirigido
        private void noDirigidoToolStripMenuItem_Click(object sender, EventArgs e) {
            //Creo un nuevo grafo y lo añado a la lista de grafos
            grafos.Clear();
            Invalidate();
            Grafo grafo = new Grafo("No Dirigido");
            grafos.Add(grafo);
            //Habilito los demás controles para la edición del grafo
            agregarVérticeToolStripMenuItem.Enabled = true;
            eliminarVérticeToolStripMenuItem.Enabled = true;
            agregarAristaToolStripMenuItem.Enabled = true;
            eliminarAristaToolStripMenuItem.Enabled = true;
            textBox1.Show();
            this.Text = "Editor de Grafos | No Dirigido";
        }

        //Control para agregar un vértice nuevo
        private void agregarVérticeToolStripMenuItem_Click(object sender, EventArgs e) {
            //Solo me dejará agregar uno nuevo si no hay otro vértice por insertar,
            //y que también la caja para el nombre no esté vacía, debido a que no puedo tener
            //un vértice sin nombre
            //Si estoy eliminando un vértice también me restringe la posibilidad de agregar uno nuevo
            if (insertado && textBox1.Text != "" && !eliminaVer) {
                nuevoVer = true;
                insertado = false;
                //Mensaje para que el usuario tenga claro lo que está en proceso
                label1.Text = "Insertando Nuevo Vértice";
            }
        }

        //Control para eliminar un vértice
        private void eliminarVérticeToolStripMenuItem_Click(object sender, EventArgs e) {
            //Si no estoy creando un vértice puedo eliminar uno que ya exista
            if (!nuevoVer) {
                eliminaVer = true;
                //Mensaje para el usuario de qué está haciendo
                label1.Text = "Eliminando Vértice";
            }
        }

        //Control para agregar una nueva arista
        private void agregarAristaToolStripMenuItem_Click(object sender, EventArgs e) {
            //Solo podré agregar una arista si al menos hay dos vértices en el grafo
            if (grafos[0].Vertices.Count >= 2) {
                nuevoAri = true;
                //Mensaje para el usuario acerca de lo que hace
                label1.Text = "Insertando Nueva Arista";
            }
        }

        //Control para eliminar una arista
        private void eliminarAristaToolStripMenuItem_Click(object sender, EventArgs e) {
            eliminaAri = true;
            //Mensaje para el usuario de la acción que realiza
            label1.Text = "Eliminando Arista";
        }

        //Evento de la forma para dibujar los vértices y las aristas
        private void Form1_Paint(object sender, PaintEventArgs e) {
            //Primero asigno el tipo de flecha que tendrá los grafos dirigidos
            pen1.EndCap = System.Drawing.Drawing2D.LineCap.ArrowAnchor;
            //Solo pinto los elementos cuando haya al menos un grafo
            if (grafos.Count > 0) {
                //Accedo a cada vértice para dibujarlos
                foreach (Vertice v in grafos[0].Vertices) {
                    //Primero dibujo el círculo y después el nombre del vértice
                    e.Graphics.FillEllipse(brush, v.X - 35, v.Y - 35, 70, 70);
                    e.Graphics.DrawString(v.Nombre, font, Brushes.Blue, v.X - 8, v.Y - 8);
                    //Accedo a cada arista de cada vértice para dibujarla
                    foreach(Arista a in v.Aristas) {
                        //Verifico de qué tipo es el grafo para dibujarlas de manera separada
                        switch(a.Tipo) {
                            case "No Dirigido":
                                if(a.XF > a.X && a.YF > a.Y) {
                                    e.Graphics.DrawLine(pen, a.X + 25, a.Y + 25, a.XF - 25, a.YF - 25);
                                }
                                if(a.XF > a.X && a.YF < a.Y) {
                                    e.Graphics.DrawLine(pen, a.X + 25, a.Y - 25, a.XF - 25, a.YF + 25);
                                }
                                if (a.XF < a.X && a.YF < a.Y) {
                                    e.Graphics.DrawLine(pen, a.X - 25, a.Y - 25, a.XF + 25, a.YF + 25);
                                }
                                if (a.XF < a.X && a.YF > a.Y) {
                                    e.Graphics.DrawLine(pen, a.X - 25, a.Y + 25, a.XF + 25, a.YF - 25);
                                }
                                break;
                            case "Dirigido":
                                if (a.XF > a.X && a.YF > a.Y) {
                                    e.Graphics.DrawLine(pen1, a.X + 25, a.Y + 25, a.XF - 25, a.YF - 25);
                                }
                                if (a.XF > a.X && a.YF < a.Y) {
                                    e.Graphics.DrawLine(pen1, a.X + 25, a.Y - 25, a.XF - 25, a.YF + 25);
                                }
                                if (a.XF < a.X && a.YF < a.Y) {
                                    e.Graphics.DrawLine(pen1, a.X - 25, a.Y - 25, a.XF + 25, a.YF + 25);
                                }
                                if (a.XF < a.X && a.YF > a.Y) {
                                    e.Graphics.DrawLine(pen1, a.X - 25, a.Y + 25, a.XF + 25, a.YF - 25);
                                }
                                break;
                        }
                    }
                }
            }
        }

        private void Form1_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (nuevoVer) {
                string nombre = textBox1.Text;
                grafos[0].Vertices.Add(new Vertice());
                grafos[0].Vertices[grafos[0].Vertices.Count - 1].Nombre = nombre;
                grafos[0].Vertices[grafos[0].Vertices.Count - 1].X = e.X;
                grafos[0].Vertices[grafos[0].Vertices.Count - 1].Y = e.Y;
                textBox1.Text = "";
                Invalidate();
            }
            /*if (eliminaAri1) {
                for (int i = 0; i < grafos[0].Vertices.Count; i++) {
                    if (e.X > grafos[0].Vertices[i].X - 35 && e.X < grafos[0].Vertices[i].X + 35 && e.Y > grafos[0].Vertices[i].Y - 35 && e.Y < grafos[0].Vertices[i].Y + 35) {
                        des = grafos[0].Vertices[i].Nombre;
                        eliminaAri = false;
                        eliminaAri1 = false;
                    }
                }
                switch (grafos[0].Tipo) {
                    case "Dirigido":
                        for (int i = 0; i < grafos[0].Vertices.Count; i++) {
                            if (ori == grafos[0].Vertices[i].Nombre) {
                                for (int j = 0; i < grafos[0].Vertices[i].Aristas.Count; j++) {
                                    if (des == grafos[0].Vertices[i].Aristas[j].Destino) {
                                        grafos[0].Vertices[i].Aristas.RemoveAt(j);
                                        ori = "";
                                        des = "";
                                        eliminaAri1 = false;
                                        label1.Text = "";
                                        //Invalidate();
                                    }
                                }
                            }
                        }
                        break;
                    case "No Dirigido":
                        for (int i = 0; i < grafos[0].Vertices.Count; i++) {
                            if (ori == grafos[0].Vertices[i].Nombre) {
                                for (int j = 0; i < grafos[0].Vertices[i].Aristas.Count; j++) {
                                    if (des == grafos[0].Vertices[i].Aristas[j].Destino) {
                                        grafos[0].Vertices[i].Aristas.RemoveAt(j);
                                        ori = "";
                                        des = "";
                                        eliminaAri1 = false;
                                        label1.Text = "";
                                        //Invalidate();
                                    }
                                }
                            }
                        }
                        break;
                }
            }*/
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e) {
            string vert = "";
            if (eliminaVer && !eliminaAri) {
                for(int i = 0; i < grafos[0].Vertices.Count; i++) {
                    if (e.X > grafos[0].Vertices[i].X - 35 && e.X < grafos[0].Vertices[i].X + 35 && e.Y > grafos[0].Vertices[i].Y - 35 && e.Y < grafos[0].Vertices[i].Y + 35) {
                        vert = grafos[0].Vertices[i].Nombre;
                        grafos[0].Vertices.RemoveAt(i);
                        i--;
                        eliminaVer = false;
                        Invalidate();
                        label1.Text = "";
                    }
                }
                for(int i = 0; i < grafos[0].Vertices.Count; i++) {
                    for(int j = 0; j < grafos[0].Vertices[i].Aristas.Count; j++) {
                        if (vert == grafos[0].Vertices[i].Aristas[j].Destino) {
                            grafos[0].Vertices[i].Aristas.RemoveAt(j);
                            j--;
                        }
                    }
                }
            }
            if(eliminaAri && !eliminaVer) {
                ori = "";
                des = "";
                for (int i = 0; i < grafos[0].Vertices.Count; i++) {
                    if (e.X > grafos[0].Vertices[i].X - 35 && e.X < grafos[0].Vertices[i].X + 35 && e.Y > grafos[0].Vertices[i].Y - 35 && e.Y < grafos[0].Vertices[i].Y + 35) {
                        ori = grafos[0].Vertices[i].Nombre;
                        eliminaAri1 = true;
                        eliminaAri = false;
                    }
                }
            } else if(eliminaAri1 && !eliminaVer) {
                for (int i = 0; i < grafos[0].Vertices.Count; i++) {
                    if (e.X > grafos[0].Vertices[i].X - 35 && e.X < grafos[0].Vertices[i].X + 35 && e.Y > grafos[0].Vertices[i].Y - 35 && e.Y < grafos[0].Vertices[i].Y + 35) {
                        des = grafos[0].Vertices[i].Nombre;
                        eliminaAri1 = false;
                        eliminaAri = false;
                    }
                }
                for (int i = 0; i < grafos[0].Vertices.Count; i++) {
                    if (ori == grafos[0].Vertices[i].Nombre) {
                        for (int j = 0; i < grafos[0].Vertices[i].Aristas.Count; j++) {
                            if (des == grafos[0].Vertices[i].Aristas[j].Destino) {
                                grafos[0].Vertices[i].Aristas.RemoveAt(j);
                                label1.Text = "";
                                ori = "";
                                des = "";
                                eliminaAri1 = false;
                            }
                        }
                    }
                }
            }
        }

        int dx, dy;
        bool presionado2 = false;
        string movido = "";
        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            if (nuevoAri) {
                for (int i = 0; i < grafos[0].Vertices.Count; i++) {
                    if (e.X > grafos[0].Vertices[i].X - 35 && e.X < grafos[0].Vertices[i].X + 35 && e.Y > grafos[0].Vertices[i].Y - 35 && e.Y < grafos[0].Vertices[i].Y + 35) {
                        Arista arista = new Arista();
                        grafos[0].Vertices[i].Aristas.Add(arista);
                        grafos[0].Vertices[i].Aristas[grafos[0].Vertices[i].Aristas.Count - 1].Origen = grafos[0].Vertices[i].Nombre;
                        grafos[0].Vertices[i].Aristas[grafos[0].Vertices[i].Aristas.Count - 1].X = grafos[0].Vertices[i].X;
                        grafos[0].Vertices[i].Aristas[grafos[0].Vertices[i].Aristas.Count - 1].Y = grafos[0].Vertices[i].Y;
                        grafos[0].Vertices[i].Aristas[grafos[0].Vertices[i].Aristas.Count - 1].Tipo = grafos[0].Tipo;
                        numArista = i;
                        clicado = true;
                    }
                }
            }
            if(mueveVer) {
                dx = 0;
                dy = 0;
                foreach(Vertice v in grafos[0].Vertices) {
                    if (e.X > v.X - 35 && e.X < v.X + 35 && e.Y > v.Y - 35 && e.Y < v.Y + 35 && !soltado) {
                        dx = e.X - v.X;
                        dy = e.Y - v.Y;
                        movido = v.Nombre;
                        soltado = true;
                        presionado = true;
                    }
                }
            }
            if(mueveGraf) {
                dvx = new List<int>();
                dvy = new List<int>();
                daxO = new List<int>();
                dayO = new List<int>();
                daxF = new List<int>();
                dayF = new List<int>();
                foreach (Vertice v in grafos[0].Vertices) {
                    dvx.Add(e.X - v.X);
                    dvy.Add(e.Y - v.Y);
                    foreach(Arista a in v.Aristas) {
                        daxO.Add(e.X - a.X);
                        dayO.Add(e.Y - a.Y);
                        daxF.Add(e.X - a.XF);
                        dayF.Add(e.Y - a.YF);
                    }
                }
                presionado2 = true;
            }
        }

        string mueve;
        bool soltado = false;
        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            if (nuevoAri && clicado) {
                grafos[0].Vertices[numArista].Aristas[grafos[0].Vertices[numArista].Aristas.Count - 1].XF = e.X;
                grafos[0].Vertices[numArista].Aristas[grafos[0].Vertices[numArista].Aristas.Count - 1].YF = e.Y;
            }
            if (presionado) {
                foreach (Vertice v in grafos[0].Vertices) {
                    if (e.X > v.X - 35 && e.X < v.X + 35 && e.Y > v.Y - 35 && e.Y < v.Y + 35 && movido == v.Nombre) {
                        v.X = e.X - dx;
                        v.Y = e.Y - dy;
                        soltado = true;
                        mueve = v.Nombre;
                        foreach(Arista a in v.Aristas) {
                            a.X = v.X;
                            a.Y = v.Y;
                        }
                    }
                }
                foreach (Vertice x in grafos[0].Vertices) {
                    foreach (Arista a in x.Aristas) {
                        if (mueve == a.Destino) {
                            a.XF = e.X - dx;
                            a.YF = e.Y - dy;
                        }
                    }
                }
            }
            if(presionado2) {
                int cont = 0;
                int cont2 = 0;
                foreach (Vertice v in grafos[0].Vertices) {
                    v.X = e.X - dvx[cont2];
                    v.Y = e.Y - dvy[cont2];
                    cont2++;
                    foreach (Arista a in v.Aristas) {
                        a.X = e.X - daxO[cont];
                        a.Y = e.Y - dayO[cont];
                        a.XF = e.X - daxF[cont];
                        a.YF = e.Y - dayF[cont];
                        cont++;
                    }
                }
            }
            Invalidate();
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) {
            if (nuevoAri) {
                for (int i = 0; i < grafos[0].Vertices.Count; i++) {
                    if (e.X > grafos[0].Vertices[i].X - 35 && e.X < grafos[0].Vertices[i].X + 35 && e.Y > grafos[0].Vertices[i].Y - 35 && e.Y < grafos[0].Vertices[i].Y + 35) {
                        grafos[0].Vertices[numArista].Aristas[grafos[0].Vertices[numArista].Aristas.Count - 1].Destino = grafos[0].Vertices[i].Nombre;
                        grafos[0].Vertices[numArista].Aristas[grafos[0].Vertices[numArista].Aristas.Count - 1].XF = grafos[0].Vertices[i].X;
                        grafos[0].Vertices[numArista].Aristas[grafos[0].Vertices[numArista].Aristas.Count - 1].YF = grafos[0].Vertices[i].Y;
                        nuevoAri = false;
                        clicado = false;
                        label1.Text = "";
                    }
                }
            }
            if (mueveVer) {
                mueveVer = false;
                presionado = false;
                soltado = false;
                dx = 0;
                dy = 0;
            }
            if (mueveGraf) {
                mueveGraf = false;
                presionado2 = false;
                dx = 0;
                dy = 0;
            }
        }

        string nombreArchivo = "";
        private void guardarToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog guardar = new SaveFileDialog();
            if (!guardado && !abierto) {
                if (guardar.ShowDialog() == DialogResult.OK) {
                    Stream stream = File.Open(guardar.FileName, FileMode.Create);
                    nombreArchivo = guardar.FileName;
                    BinaryFormatter binary = new BinaryFormatter();
                    binary.Serialize(stream, grafos);
                    guardado = true;
                    return;
                }
            }
            if (guardado) {
                Stream stream = File.Open(nombreArchivo, FileMode.Create);
                BinaryFormatter binary = new BinaryFormatter();
                binary.Serialize(stream, grafos);
                guardado = true;

            }
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e) {
            OpenFileDialog abrir = new OpenFileDialog();
            if ((guardado && !abierto) || (guardado && abierto)) {
                grafos.Clear();
                if(abrir.ShowDialog() == DialogResult.OK) {
                    Stream stream = File.Open(nombreArchivo, FileMode.Open);
                    BinaryFormatter binary = new BinaryFormatter();
                    grafos = (List<Grafo>)binary.Deserialize(stream);
                }
            }
            if (!guardado) {
                grafos.Clear();
                if (abrir.ShowDialog() == DialogResult.OK) {
                    Stream stream = File.Open(abrir.FileName, FileMode.Open);
                    nombreArchivo = abrir.FileName;
                    label1.Text = nombreArchivo;
                    BinaryFormatter binary = new BinaryFormatter();
                    grafos = (List<Grafo>)binary.Deserialize(stream);
                }
                abierto = true;
            }
            agregarVérticeToolStripMenuItem.Enabled = true;
            eliminarVérticeToolStripMenuItem.Enabled = true;
            agregarAristaToolStripMenuItem.Enabled = true;
            eliminarAristaToolStripMenuItem.Enabled = true;
            textBox1.Show();
        }

        private void moverGrafoToolStripMenuItem_Click(object sender, EventArgs e) {
            mueveGraf = true;
            nuevoVer = false;
            insertado = true;
            eliminaVer = false;
            eliminaAri = false;
            eliminaAri1 = false;
        }

        private void moverVérticeToolStripMenuItem_Click(object sender, EventArgs e) {
            mueveVer = true;
            nuevoVer = false;
            insertado = true;
            eliminaVer = false;
            eliminaAri = false;
            eliminaAri1 = false;
        }

        private void cancelarAcciónToolStripMenuItem_Click(object sender, EventArgs e) {
            nuevoVer = false;
            insertado = true;
            eliminaVer = false;
            eliminaAri = false;
            eliminaAri1 = false;
            label1.Text = "";
        }
    }
}
