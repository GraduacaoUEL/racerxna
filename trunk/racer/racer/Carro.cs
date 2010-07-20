using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace racer
{
    class Carro
    {
        #region Variaveis
        public Sprite textura;
        private int gear;
        private float torque;
        private float acel;
        private float freio;
        private float veloc;
        private int volante;
        private int position;
        #endregion

        #region Properties
        public int Gear
        {
            get { return gear; }
            set { gear = value; }
        }
        public float Torque
        {
            get { return torque; }
            set { torque = value; }
        }
        public float Acel
        {
            get { return acel; }
            set { acel = value; }
        }
        public float Freio
        {
            get { return freio; }
            set 
            { 
                freio = value;
                if (freio < 1)
                    freio = 1;
            }
        }
        public float Veloc
        {
            get { return veloc; }
            set 
            { 
                veloc = value;
                if (veloc < 0)
                    veloc = 0;
            }
        }
        public int Volante
        {
            get { return volante; }
            set 
            { 
                volante = value;
                //if (volante > 50)
                //    volante = 50;
                //if (volante < -50)
                //    volante = -50;
            }
        }
        public int Position
        {
            get { return position; }
            set { position = value; }
        }
        #endregion

        #region Construtor
        public Carro(Sprite ptextura, int pposition)
        {
            this.textura = ptextura;
            this.textura.Origin = this.textura.Tamanho / 2;
            this.position = pposition;
            this.torque = 0.0001f;
            this.acel = 0f;
            this.veloc = 0f;
            this.freio = 1.2f;
        }
        #endregion
    }
}
