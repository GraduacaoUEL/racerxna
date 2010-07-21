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
            // ações do controle - talvéz seja melhor passar parte disso pra dentro da classe Carro,
            // eu não gosto de como esse metodo tá agora, só fiz assim pra testar
            //aceleração em função do torque
            if (keyboardState.IsKeyDown(Keys.Up))
                this.car.Acel += this.car.Torque;
            //desasceleração
            if (keyboardState.IsKeyUp(Keys.Up))
                this.car.Acel = this.car.Acel/2;
            //volante, obvio
            if (keyboardState.IsKeyDown(Keys.Left))
            {
                this.car.Volante--;
            }
            if (keyboardState.IsKeyDown(Keys.Right))
            {
                this.car.Volante++;
            }
            //retorno do volante a posição normal
            if (keyboardState.IsKeyUp(Keys.Left) &&
                keyboardState.IsKeyUp(Keys.Right))
                this.car.Volante = this.car.Volante/2;
            //freio
            if (keyboardState.IsKeyDown(Keys.Down))
                this.car.Veloc = this.car.Veloc/this.car.Freio;
            // aumento de velocidade em função da aceleração
            this.car.Veloc += this.car.Acel;
            //fricção ou sei lá o que 
            this.car.Veloc = this.car.Veloc / 1.01f;
            //a "física" aqui foi totalmente baeada em instinto ^^, o resultado foi melhor do qu eeu esperava
        }

        public void Draw(SpriteBatch spritebatch)
        {
            this.car.textura.Draw(spritebatch);
        }
        #endregion
    }
}
