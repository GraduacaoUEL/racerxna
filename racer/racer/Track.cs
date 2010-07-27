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
        private Sprite[] pista; // array de sprites que representarão a pista
        private Vector2[] deslocamento; //deslocamento em relação a posição anterior da pista, usado em curvas, ainda não implementei
                                        //essa variavel determina o desenho da pista
                                        //X>0 - curva pra esquerda; X<0 - curva pra direita; Y>0 descida; Y<0 - subida
        private Vector2 originalPosition;//posição inicial da pista, ainda não usei, masimaginei que iria precisar
        private int vizualize; // determina o ponto a partir do qual a pista será vista, posição do veículo do jogador
        private int arraySize;// tamanho do vetor/pista
        #endregion 

        #region Construtor
        public Track(int parraySize,Texture2D ptextura,Vector2 ptamanho)
        {
            this.arraySize = parraySize;
            this.pista = new Sprite[arraySize];
            this.deslocamento = new Vector2[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                pista[i] = new Sprite(ptextura,ptamanho/2,ptamanho,1,Color.White);
                this.pista[i].Origin = this.pista[i].Tamanho / 2;
                deslocamento[i] = Vector2.Zero;
                deslocamento[i] = new Vector2(-i, 0); 
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

        public void moveForward(float velocidade)
        {
            for (int i = 0; i < arraySize; i++)
            {
                this.pista[i].Active = false;
            }
            this.pista[vizualize].Scale += velocidade;
            if (this.pista[vizualize].Scale >= 2)
            {
                vizualize++;
                if (vizualize == arraySize)
                    vizualize = 0;
                this.pista[vizualize].Scale = 1;
                pista[vizualize].Position = new Vector2(1, 0) * pista[vizualize].Position + //deixa o carro no chão numa subida/descida
                    this.originalPosition * new Vector2(0, 1);
            }
            ShowTrack(vizualize,7,0.5f);   //primeiro parametro, posição do carro em relação a pista
                                            //segundo parametro, posições da pista visíveis
                                            //terceiro parametro, distancia que cada parte esta em relação a anterior

        }

         private void ShowTrack(int position, int alcance, float distancia)
        {
            #region Correção dos parametros
            if (alcance < 1)
                alcance = 1;
            if (distancia < 0)
                distancia = 0.5f;
            #endregion
            for (int i = 0 ; i < alcance ; i++)
            {
                #region Correção do escopo ao array de Sprites
                int j = position + i;
                if (j >= arraySize)
                    j = j - arraySize;
                int k;
                if (j + 1 == arraySize)
                    k = 0;
                else
                    k = j + 1;
                #endregion 

                this.pista[j].Active = true;
                pista[k].Scale = pista[j].Scale * distancia;
                pista[k].Position = pista[j].Position + deslocamento[k]*distancia;
                this.pista[j].LayerDepth = this.pista[j].Scale / 2;//melhorar isso aqui
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
