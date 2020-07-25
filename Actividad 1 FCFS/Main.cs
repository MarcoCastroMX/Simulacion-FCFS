using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Actividad_1_FCFS
{
    public partial class Main : Form
    {
        Bitmap Picture = global::Actividad_1_FCFS.Properties.Resources.Pasto,Animacion;
        Image Caballo = Image.FromFile(Application.StartupPath + "\\Caballo.png");
        List<Caballo> Procesos = new List<Caballo>();
        List<Caballo> Lista = new List<Caballo>();
        List<Caballo> Terminados = new List<Caballo>();
        int Semilla = Environment.TickCount;
        int Identificador = 0;
        int Pos = 1;
        int Y = 0;
        public Main()
        {
            InitializeComponent();
            Preparacion();
        }
        private void Preparacion()
        {
            Identificador = 0;
            Pos = 1;
            Y = 0;
            Semilla = Environment.TickCount;
            Procesos.Clear();
            Lista.Clear();
            Terminados.Clear();
            TablaPocisiones.Rows.Clear();
            TablaPocisiones.Refresh();
            Picture = global::Actividad_1_FCFS.Properties.Resources.Pasto;
            TablaPocisiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            Rectangle Dimensiones = new Rectangle(0, 0, Picture.Width, Picture.Height);
            System.Drawing.Imaging.PixelFormat Formato = Picture.PixelFormat;
            Animacion = Picture.Clone(Dimensiones, Formato);
            Animacion.MakeTransparent();
            pictureBox1.Image = Animacion;
            pictureBox1.BackgroundImage = Picture;
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            Graphics Grafico = Graphics.FromImage(Animacion);
            Grafico.DrawImage(Caballo, 10, 0);
            Grafico.DrawImage(Caballo, 10, 100);
            Grafico.DrawImage(Caballo, 10, 200);
            Grafico.DrawImage(Caballo, 10, 300);
            Grafico.DrawImage(Caballo, 10, 400);
            pictureBox1.Refresh();
        }

        private void BtnIniciar_Click(object sender, EventArgs e)
        {
            Preparacion();
            Random Numero = new Random(Semilla);
            while (Procesos.Count != 5)
            {
                int NumeroAleatorio = Numero.Next(1, 100);
                Caballo NuevoCaballo = new Caballo(Identificador, NumeroAleatorio,10);
                Procesos.Add(NuevoCaballo);
                Identificador++;
            }
            Random Llegada = new Random(Semilla);
            while (Lista.Count != 5)
            {
                int Elegido = Llegada.Next(0, Procesos.Count);
                Procesos[Elegido].SetPosicion(Pos);
                Procesos[Elegido].SetValorY(Y);
                Lista.Add(Procesos[Elegido]);
                Procesos.RemoveAt(Elegido);
                Pos++;
                Y = Y + 100;
            }
            foreach(Caballo i in Lista)
            {
                Graphics Posicion = Graphics.FromImage(Picture);
                Font Letra = new Font("Arial", 20);
                Brush Brocha = new SolidBrush(Color.Black);
                Point Punto = new Point(0, i.GetValorY());
                Posicion.DrawString(i.GetID().ToString(), Letra, Brocha, Punto);
                pictureBox1.Refresh();
            }
            Random NuevaVelocidad = new Random(Semilla);
            Graphics Grafico = Graphics.FromImage(Animacion);
            Grafico.Clear(Color.Transparent);
            while (Lista.Count != 0)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    int ActualX = Lista[i].GetValorX();
                    int ActualY = Lista[i].GetValorY();
                    int Velocidad = Lista[i].GetVelocidad();
                    int NuevaX = ActualX + Velocidad;
                    if (NuevaX >= 1100)
                    {
                        Graphics Finalizado = Graphics.FromImage(Picture);
                        Finalizado.DrawImage(Caballo, 1100, ActualY);
                        Terminados.Add(Lista[i]);
                        DataGridViewRow Fila = new DataGridViewRow();
                        this.TablaPocisiones.DefaultCellStyle.Font = new Font("Arial", 14);
                        Fila.CreateCells(TablaPocisiones);
                        Fila.Cells[0].Value = Lista[i].GetID();
                        Fila.Cells[1].Value = Terminados.Count;
                        TablaPocisiones.Rows.Add(Fila);
                        TablaPocisiones.Update();
                        Lista.Remove(Lista[i]);
                        i--;
                    }
                    else {
                        Grafico.DrawImage(Caballo, NuevaX, ActualY);
                        Lista[i].SetValorX(NuevaX);
                        
                        Lista[i].SetVelocidad(NuevaVelocidad.Next(1, 100));
                    }
                }
                pictureBox1.Refresh();
                Grafico.Clear(Color.Transparent);
                Thread.Sleep(150);
            }
        }

        private void BtnReiniciar_Click(object sender, EventArgs e)
        {
            Preparacion();
            Random Numero = new Random(Semilla);
            while (Procesos.Count != 5)
            {
                int NumeroAleatorio = Numero.Next(1, 100);
                Caballo NuevoCaballo = new Caballo(Identificador, NumeroAleatorio, 10);
                Procesos.Add(NuevoCaballo);
                Identificador++;

            }
            Random Llegada = new Random(Semilla);
            while (Lista.Count != 5)
            {
                int Elegido = Llegada.Next(0, Procesos.Count);
                Procesos[Elegido].SetPosicion(Pos);
                Procesos[Elegido].SetValorY(Y);
                Lista.Add(Procesos[Elegido]);
                Procesos.RemoveAt(Elegido);
                Pos++;
                Y = Y + 100;
            }
            foreach (Caballo i in Lista)
            {
                Graphics Posicion = Graphics.FromImage(Picture);
                Font Letra = new Font("Arial", 20);
                Brush Brocha = new SolidBrush(Color.Black);
                Point Punto = new Point(0, i.GetValorY());
                Posicion.DrawString(i.GetID().ToString(), Letra, Brocha, Punto);
                pictureBox1.Refresh();
            }
            Random NuevaVelocidad = new Random(Semilla);
            Graphics Grafico = Graphics.FromImage(Animacion);
            Grafico.Clear(Color.Transparent);
            while (Lista.Count != 0)
            {
                for (int i = 0; i < Lista.Count; i++)
                {
                    int ActualX = Lista[i].GetValorX();
                    int ActualY = Lista[i].GetValorY();
                    int Velocidad = Lista[i].GetVelocidad();
                    int NuevaX = ActualX + Velocidad;
                    if (NuevaX >= 1100)
                    {
                        Graphics Finalizado = Graphics.FromImage(Picture);
                        Finalizado.DrawImage(Caballo, 1100, ActualY);
                        Terminados.Add(Lista[i]);
                        DataGridViewRow Fila = new DataGridViewRow();
                        this.TablaPocisiones.DefaultCellStyle.Font = new Font("Arial", 14);
                        Fila.CreateCells(TablaPocisiones);
                        Fila.Cells[0].Value = Lista[i].GetID();
                        Fila.Cells[1].Value = Terminados.Count;
                        TablaPocisiones.Rows.Add(Fila);
                        TablaPocisiones.Update();
                        Lista.Remove(Lista[i]);
                        i--;
                    }
                    else
                    {
                        Grafico.DrawImage(Caballo, NuevaX, ActualY);
                        Lista[i].SetValorX(NuevaX);

                        Lista[i].SetVelocidad(NuevaVelocidad.Next(1, 100));
                    }
                }
                pictureBox1.Refresh();
                Grafico.Clear(Color.Transparent);
                Thread.Sleep(150);
            }
        }

        private void BtnSalir_Click(object sender, EventArgs e)
        {
            Application.ExitThread();
        }
    }
}
