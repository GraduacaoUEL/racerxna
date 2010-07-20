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
    class Testes
    {
        #region Variaveis
        private SpriteBatch spriteBatch;
        private Track pista;
        private Player player1;
        private int nCarros;
        private Carro[] carros;
        #endregion

        #region Contrutor
        public Testes(ContentManager Content, SpriteBatch pspriteBatch)
        {
            this.spriteBatch = pspriteBatch;
            this.pista = new Track(10,
                Content.Load<Texture2D>(@"images\Pista"),
                new Vector2(800, 600));
            this.nCarros = 1;
            this.carros = new Carro[nCarros];
            for (int i = 0; i < nCarros; i++)
            {
                this.carros[i] = 
                    new Carro(
                        new Sprite(Content.Load<Texture2D>(@"images\Carro"), new Vector2(400, 450), 
                            new Vector2(200, 120),0.9f,1f,Color.White),
                        i);
            }
            this.player1 = new Player(this.carros[0]);
        }
        #endregion

        #region Metodos
        public void Update(MouseState mouseState,KeyboardState keyboardState)
        {
            this.player1.control(keyboardState);
            this.pista.moveHorizontally(player1.Car.Volante*player1.Car.Veloc);
            this.pista.moveForward(player1.Car.Veloc);
        }

        public void Draw()
        {
            
            this.pista.Draw(spriteBatch);
            this.player1.Draw(spriteBatch);

        }
        #endregion
    }
}
