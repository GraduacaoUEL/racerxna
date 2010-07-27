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
    class Sprite
    {
        //fiz a classe Sprite diferente de como foi feito no space invaders, por que achei que nesse caso, os elementos do jogo
        // e as imagens são menos relacionados do que lá.
        // prefi que as outas classes contivessem spites, porque, por exemplo, não me parece que um carro seja uma imagem que 
        //possui aceleração movimento etc, me parece mais algo que ente outras coisas, possui uma imagem.
        //mas isso é só a minha opinião u_u
        #region Variaveis 
        private Vector2 position;
        private Vector2 tamanho;
        private Vector2 origin;
        private Texture2D textura;
        private Color cor;
        private Rectangle sourceRectangle;
        private bool underMouse;
        private bool active;
        private float rotation;
        private float scale;
        private float layerDepth;
        private SpriteEffects effect;
        #endregion

        #region Construtor
        //fui criando construtores conforme a necessidade foi surgindo ._. ...
        public Sprite(Texture2D ptextura ,Vector2 pposition, Vector2 ptamanho, Color pcor)
        {
            this.textura = ptextura;
            this.position = pposition;
            this.tamanho = ptamanho;
            this.cor = pcor;
            this.sourceRectangle = new Rectangle(0,0, (int)tamanho.X, (int)tamanho.Y);
            this.rotation = 0.0f;
            this.scale = 1f;
            this.layerDepth = 0;
            this.effect = SpriteEffects.None;
            this.origin = Vector2.Zero;

        }
        public Sprite(Texture2D ptextura, Vector2 pposition, Vector2 ptamanho,float pscale, Color pcor)
        {
            this.textura = ptextura;
            this.position = pposition;
            this.tamanho = ptamanho;
            this.cor = pcor;
            this.sourceRectangle = new Rectangle(0, 0, (int)tamanho.X, (int)tamanho.Y);
            this.rotation = 0.0f;
            this.scale = pscale;
            this.layerDepth = 0;
            this.effect = SpriteEffects.None;
            this.origin = Vector2.Zero;

        }
        public Sprite(Texture2D ptextura, Vector2 pposition, Vector2 ptamanho, float pscale,float playerDepth, Color pcor)
        {
            this.textura = ptextura;
            this.position = pposition;
            this.tamanho = ptamanho;
            this.cor = pcor;
            this.sourceRectangle = new Rectangle(0, 0, (int)tamanho.X, (int)tamanho.Y);
            this.rotation = 0.0f;
            this.scale = pscale;
            this.layerDepth = playerDepth;
            this.effect = SpriteEffects.None;
            this.origin = Vector2.Zero;
;
        }
        #endregion

        #region Properties
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vector2 Tamanho
        {
            get { return tamanho; }
            set { tamanho = value; }
        }
        public Texture2D Textura
        {
            get { return textura; }
            set { textura = value; }
        }
        public Color Cor
        {
            get { return cor; }
            set { cor = value; }
        }
        public bool UnderMouse
        {
            get { return underMouse; }
            set { underMouse = value; }
        }
        public bool Active
        {
            get { return active; }
            set { active = value; }
        }
        public Rectangle SourceRectangle
        {
            get { return sourceRectangle; }
            set { sourceRectangle = value; }
        }
        public float Rotation
        {
          get { return rotation; }
          set { rotation = value; }
        }
        public float Scale
        {
          get { return scale; }
          set { scale = value; }
        }
        public float LayerDepth
        {
          get { return layerDepth; }
          set { layerDepth = value; }
        }      
        public Vector2 Origin
        {
          get { return origin; }
          set { origin = value; }
        }
        public SpriteEffects Effect
        {
          get { return effect; }
          set { effect = value; }
        }
        #endregion

        #region Metodos
        //esse método foi criado pra interação com o mouse, acabei tirando a parte que utilizava, mas realmente gostei do método
        public void mouseInteraction(MouseState mouseState)
        {
            BoundingSphere mouse = new BoundingSphere(new Vector3((float)mouseState.X, (float)mouseState.Y, 0.0f), 0.1f);
            if (mouse.Intersects(this.GetBox()))
                this.underMouse = true;
            else
                this.underMouse = false;
        }

        //chamei o metodo de GetBox, porque imaginei também colocar um GetSphere e GetFrustrun...
        public BoundingBox GetBox()
        {
            return
                new BoundingBox(
                    new Vector3(this.position - this.origin*this.scale, 0.0f),
                    new Vector3(this.position - this.origin*this.scale + this.tamanho*this.scale, 0.0f));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.active)
            {
                spriteBatch.Draw(this.textura, this.position, this.sourceRectangle, this.cor,
                    this.rotation, this.origin, this.scale, this.effect, this.layerDepth);
            }
        }
        #endregion
    }
}
