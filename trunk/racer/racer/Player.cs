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
        private int position;
        private Keys Esquerda;
        private Keys Direita;
        private Keys Acelera;
        private Keys Freia;
        #endregion

        #region Construtor
        public Player(Carro pcar)
        {
            this.car = pcar;
            this.position = 0;
            this.Acelera = Keys.Up;
            this.Freia = Keys.Down;
            this.Esquerda = Keys.Left;
            this.Direita = Keys.Right;
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

        //controles do jogador
        public void control(KeyboardState keyboardState)
        {
            // ações do controle - talvéz seja melhor passar parte disso pra dentro da classe Carro,
            // eu não gosto de como esse metodo tá agora, só fiz assim pra testar
            //aceleração
            #region Acelerar
            if (keyboardState.IsKeyDown(this.Acelera))
                this.car.Accelerate();
            //desasceleração
            if (keyboardState.IsKeyUp(this.Acelera))
                this.car.NAccelerate();
            #endregion
            // direção
            #region Esquerda
            if (keyboardState.IsKeyDown(this.Esquerda))
                this.car.TurnLeft();
            //if (keyboardState.IsKeyUp(this.Esquerda))
            //    this.car.NTurnLeft();
            #endregion

            #region Direita
            if (keyboardState.IsKeyDown(this.Direita))
                this.car.TurnRight();
            //if (keyboardState.IsKeyUp(this.Direita))
            //    this.car.NTurnRight();
            #endregion
            //retorno do volante a posição normal
            #region Freio
            if (keyboardState.IsKeyDown(this.Freia))
                this.car.Brake();
            #endregion

            if (keyboardState.IsKeyUp(this.Esquerda) &&
                keyboardState.IsKeyUp(this.Direita))
            {
                this.car.NTurnLeft();
                this.car.NTurnRight();
            }
            //    this.car.Volante = this.car.Volante/2;
            //freio
            
            // aumento de velocidade em função da aceleração
            this.car.Update();
            //a "física" aqui foi totalmente baeada em instinto ^^, o resultado foi melhor do qu eeu esperava
        }

        //public void vizualize(ref Track pista)
        //{ 
            
        //}
        public void Draw(SpriteBatch spritebatch)
        {
            this.car.textura.Draw(spritebatch);
        }
        #endregion
    }
}
