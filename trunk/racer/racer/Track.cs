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
    class Track
    {
        #region Variaveis
        private Sprite[] pista;
        private Vector2 originalPosition;
        private int arraySize;
        #endregion 

        #region Construtor
        public Track(int parraySize,Texture2D ptextura,Vector2 ptamanho)
        {
            this.arraySize = parraySize;
            this.pista = new Sprite[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                pista[i] = new Sprite(ptextura,ptamanho/2,ptamanho,i*0.25f,Color.White);
            }
            this.originalPosition = pista[0].Position;
        }
        #endregion

        #region Metodos
        public void moveHorizontally(float incremento)
        {
            for (int i = 0; i < arraySize; i++)
            {
                this.pista[i].Position += new Vector2(-incremento,0);
            }
        }

        public void moveForward(float incremento)
        {
            for (int i = 0; i < arraySize; i++)
            {
                if (pista[i].Scale >= 2)
                    pista[i].Scale -= (2-0.25f);
                this.pista[i].Scale = this.pista[i].Scale + incremento;
                this.pista[i].Origin = this.pista[i].Tamanho / 2;
                this.pista[i].LayerDepth = this.pista[i].Scale / 2; ;
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < arraySize; i++)
            {
                this.pista[i].Draw(spriteBatch);
            }
        }
        #endregion
    }
}
