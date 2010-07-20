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
    class Player
    {
        #region Variaveis
        private Carro car;
        #endregion

        #region Construtor
        public Player(Carro pcar)
        {
            this.car = pcar;
        }
        #endregion

        #region Propeties
        internal Carro Car
        {
          get { return car; }
          set { car = value; }
        }
        #endregion

        #region Metodos
        public void control(KeyboardState keyboardState)
        {
            if (keyboardState.IsKeyDown(Keys.Up))
                this.car.Acel += this.car.Torque;
            if (keyboardState.IsKeyUp(Keys.Up))
                this.car.Acel = this.car.Acel/2;
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this.car.Volante--;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.car.Volante++;
            }
            if (keyboardState.IsKeyUp(Keys.Left) &&
                keyboardState.IsKeyUp(Keys.Right))
                this.car.Volante = this.car.Volante/2;
            if (keyboardState.IsKeyDown(Keys.Down))
                this.car.Veloc = this.car.Veloc/this.car.Freio;

            this.car.Veloc += this.car.Acel;
            this.car.Veloc = this.car.Veloc / 1.01f;
        }

        public void Draw(SpriteBatch spritebatch)
        {
            this.car.textura.Draw(spritebatch);
        }
        #endregion
    }
}
