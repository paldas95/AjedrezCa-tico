using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezCaótico
{
    class Sprite2D
    {
        
        public Color Color;
        public Texture2D Textura;

        float _angle;
        public float Angle
        {
            get { return _angle; }
            set
            {
                _angle = value;
            }
        }
        private Vector2 _location;
        public Vector2 Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
                _rectangle.X = (int)_location.X;
                _rectangle.Y = (int)_location.Y;
            }
        }
        private Rectangle _rectangle;
        public Rectangle Limites

        {
            get
            {
                return _rectangle;
            }
            set
            {
                _rectangle = value;
                _location = _rectangle.Location.ToVector2();
            }
        }

        public int Width { get => _rectangle.Width; set => _rectangle.Width = value; }

        public int Height { get => _rectangle.Height; set => _rectangle.Height = value; }

        public bool Show { get; set; } = true;
        

      
        public Sprite2D(Texture2D texture) : this(texture, Rectangle.Empty)
        { }

        public Sprite2D(Texture2D texture, Rectangle rectangle) : this(texture, rectangle, Color.White)
        { }

        public Sprite2D(Texture2D texture, Vector2 location)
        {
            this.Textura = texture;
            this._rectangle = Rectangle.Empty;
            this.Location = location;
            this.Color = Color.White;
        }

        public Sprite2D(Texture2D texture, Rectangle rectangle, Color color)
        {
            this.Textura = texture;
            this._location = Vector2.Zero;
            this.Limites = rectangle;
            this.Color = color;
        }
       
        public void Draw(SpriteBatch spriteBatch)
        {
            if (Show)
            {
                Vector2 origin = new Vector2(Textura.Width / 2, Textura.Height / 2);
                Rectangle destRect = new Rectangle(_rectangle.X + _rectangle.Width / 2, _rectangle.Y + _rectangle.Height / 2, _rectangle.Width, _rectangle.Height);
                spriteBatch.Draw(Textura, destRect, null, Color, Angle, origin, SpriteEffects.None, 0f);
            }
        }

        public void HorizontallyCenter(Rectangle limites, float yLocation)
        {
            Location = new Vector2((limites.Width / 2) - (Limites.Width / 2) + limites.X, yLocation);
        }

        public void VerticallyCenter(Rectangle limites, float xLocation)
        {
            Location = new Vector2(xLocation, (limites.Height / 2) - (Limites.Height / 2) + limites.Y);
        }

        public void Center(Rectangle limites)
        {
            Location = new Vector2(
            (limites.Width / 2) - (Limites.Width / 2) + limites.X,
            (limites.Height / 2) - (Limites.Height / 2) + limites.Y);

        }

        public void Center(Rectangle limites, Vector2 offSet)
        {
            Location = new Vector2(
            (limites.Width / 2) - (Limites.Width / 2) + limites.X,
            (limites.Height / 2) - (Limites.Height / 2) + limites.Y);
            Location += offSet;
        }

        public bool Contains(Vector2 pos)
        {
            if (Angle == 0)
                return Limites.Contains(pos);
            Vector2 origin = _rectangle.Center.ToVector2();
            Vector2 virtualPos = Vector2.Transform(pos - origin, Matrix.CreateRotationZ(-Angle)) + origin;

            if (_rectangle.Contains(virtualPos))
                return true;
            return false;
        }

        public bool Contains(Point pos)
        {
            return Contains(pos.ToVector2());
        }       
    }
}
