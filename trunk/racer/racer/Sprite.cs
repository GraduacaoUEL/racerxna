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
        #region Variaveis 
        private Vector2 position;
        private Vector2 tamanho;
        private Vector2 origin;
        private Texture2D textura;
        private Color cor;
        private Rectangle sourceRectangle;
        private bool underMouse;
        private float rotation;
        private float scale;
        private float layerDepth;
        private SpriteEffects effect;
        #endregion

        #region Construtor
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
        public void mouseInteraction(MouseState mouseState)
        {
            BoundingSphere mouse = new BoundingSphere(new Vector3((float)mouseState.X, (float)mouseState.Y, 0.0f), 0.1f);
            if (mouse.Intersects(this.GetBox()))
                this.underMouse = true;
            else
                this.underMouse = false;
        }
        //public void aproach(float incremento)
        //{
        //    this.scale = this.scale + incremento;
        //    this.origin = this.tamanho / 2;
        //    this.layerDepth = this.scale / 2;
        //}

        public BoundingBox GetBox()
        {
            return
                new BoundingBox(
                    new Vector3(this.position - this.origin*this.scale, 0.0f),
                    new Vector3(this.position - this.origin*this.scale + this.tamanho*this.scale, 0.0f));
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(this.textura, this.position, this.sourceRectangle, this.cor,
                this.rotation, this.origin, this.scale, this.effect, this.layerDepth);
        }
        #endregion
    }
}
