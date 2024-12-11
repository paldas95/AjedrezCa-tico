using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


namespace AjedrezCaótico
{
    class BotonAnimacion
    {
        public float? Angle = null;
        public Rectangle? Limites { get; set; } = null;
        public Color? Color { get; set; } = null;
        public bool SoloTamañoImpacto { get; set; } = false;

        public BotonAnimacion(float? angle, Rectangle? limites, Color? color)
        {
            Angle = angle;
            Limites = limites;
            Color = color;
        }

        public BotonAnimacion(float? angle, Rectangle? limites, Color? color, bool soloTamañoImpacto)
        {
            Angle = angle;
            Limites = limites;
            Color = color;
            SoloTamañoImpacto = soloTamañoImpacto;
        }
    }
    enum BotonPosible
    {
        None,
        Hovered,
        Pressed
    }

    class Boton
    {       
        public BotonPosible State { get; protected set; }

        protected Sprite2D sprite;
        public Text TextMessege { get; set; }

        public event EventHandler Click;
        public event EventHandler Hover;
        public event EventHandler UnHover;

        public Color Color
        {
            get { return sprite.Color; }
            set { sprite.Color = value; }
        }

        public Rectangle Limites
        {
            get { return sprite.Limites; }
            set { sprite.Limites = value; }
        }

        public float Angle
        {
            get { return sprite.Angle; }
            set { sprite.Angle = value; }
        }
        public Texture2D Texture
        {
            set
            {
                sprite.Textura = value;
            }
        }


        public BotonAnimacion HoverAnimation { get; set; }
        public BotonAnimacion ClickAnimation { get; set; }
        public BotonAnimacion UnHoverAnimation { get; set; }
        public Boton(Sprite2D sprite)
        {
            this.sprite = sprite;
        }
        public virtual void Update(Entrada currentInput, Entrada previousInput)
        {
            if (Contains(currentInput.ObtenerLocalizacionVirtual()))
            {
                if (currentInput.Raton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                    previousInput.Raton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
                    State != BotonPosible.None)
                {

                    State = BotonPosible.Pressed;
                    OnClick(EventArgs.Empty);
                }
                else if (State != BotonPosible.Hovered)
                {
                    if (State == BotonPosible.None)
                    {
                        OnHover(EventArgs.Empty);
                    }
                    State = BotonPosible.Hovered;
                }

            }
            else if (State != BotonPosible.None)
            {
                OnUnHover(EventArgs.Empty);
                State = BotonPosible.None;
            }
        }

        public virtual void Update(MouseState currentInput, Entrada previousInput)
        {
            if (Contains(currentInput.Position))
            {
                if (currentInput.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                    previousInput.Raton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed &&
                    State != BotonPosible.None)
                {
                    State = BotonPosible.Pressed;
                    OnClick(EventArgs.Empty);
                }
                else if (State != BotonPosible.Hovered)
                {
                    if (State == BotonPosible.None)
                    {
                        OnHover(EventArgs.Empty);
                    }
                    State = BotonPosible.Hovered;
                }

            }
            else if (State != BotonPosible.None)
            {
                OnUnHover(EventArgs.Empty);
                State = BotonPosible.None;
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(spriteBatch);
            if (TextMessege != null)
            {
                TextMessege.Draw(spriteBatch);
            }
        }
        public void Animaccion(BotonAnimacion animation)
        {
            if (animation.Angle.HasValue)
                Angle = (float)animation.Angle;
            if (animation.Color.HasValue)
                Color = (Color)animation.Color;
            if (animation.Limites.HasValue)
            {
                if (animation.SoloTamañoImpacto)
                {
                    Rectangle temp = (Rectangle)animation.Limites;
                    Limites = new Rectangle(Limites.X, Limites.Y, temp.Width, temp.Height);
                }
                else
                {
                    Limites = (Rectangle)animation.Limites;
                }
            }
        }

        protected virtual void OnClick(EventArgs e)
        {
            if (ClickAnimation != null) Animaccion(ClickAnimation);
            EventHandler handler = Click;
            handler?.Invoke(this, e);
        }

        protected virtual void OnHover(EventArgs e)
        {
            if (HoverAnimation != null) Animaccion(HoverAnimation);
            EventHandler handler = Hover;
            handler?.Invoke(this, e);
        }

        protected virtual void OnUnHover(EventArgs e)
        {
            if (UnHoverAnimation != null) Animaccion(UnHoverAnimation);
            EventHandler handler = UnHover;
            handler?.Invoke(this, e);
        }

        public bool Contains(Vector2 pos)
        {
            return sprite.Contains(pos);
        }

        public bool Contains(Point pos)
        {
            return sprite.Contains(pos);
        }

        public void Center(Rectangle limites)
        {
            sprite.Center(limites);
        }

        public void Center(Rectangle limites, Vector2 offset)
        {
            sprite.Center(limites, offset);
        }      
    }
}