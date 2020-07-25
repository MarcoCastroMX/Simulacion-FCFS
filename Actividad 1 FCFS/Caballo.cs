using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_1_FCFS
{
    class Caballo
    {
        int ID;
        int Velocidad;
        int Posicion;
        int ValorX;
        int ValorY;

        public Caballo(int ID,int Velocidad,int ValorX)
        {
            this.ID = ID;
            this.Velocidad = Velocidad;
            this.ValorX = ValorX;
        }
        public int GetID()
        {
            return ID;
        }

        public int GetVelocidad()
        {
            return Velocidad;
        }
        public void SetVelocidad(int Nueva)
        {
            Velocidad = Nueva;
        }

        public int GetPosicion()
        {
            return Posicion;
        }

        public void SetPosicion(int Posicion)
        {
            this.Posicion = Posicion;
        }

        public int GetValorX()
        {
            return ValorX;
        }

        public void SetValorX(int X)
        {
            this.ValorX = X;
        }

        public int GetValorY()
        {
            return ValorY;
        }

        public void SetValorY(int Y)
        {
            this.ValorY = Y;
        }
    }
}
