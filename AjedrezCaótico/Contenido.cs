using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezCaótico
{
    class ContentService
    {
        public Dictionary<string, Texture2D> Texturas { get; private set; }
        private static ContentService _instance;
        private ContentManager _content;

        private ContentService()
        {
            Texturas = new Dictionary<string, Texture2D>();
           
        }

        public static ContentService Instance //No es óptimo, singleton class
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ContentService();
                }
                return _instance;
            }
        }

        public void LoadContent(ContentManager Content, GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            if (_content != null)
            {
                throw new Exception($"Metodo '{System.Reflection.MethodBase.GetCurrentMethod().Name}' solo puede llamarse una vez");
            }
            _content = Content;

            AddTexture("cuadradoBlanco", "Empty");
            AddTexture("seleccion", "Circle");
            AddTexture("NeutralDemonio");
            AddTexture("NeutralPato");



            Texture2D texture = _content.Load<Texture2D>("PiezasAjedrez");

            Texture2D target = new Texture2D(graphicsDevice, 100, 100);
            Color[] data = new Color[100 * 100];

            Rectangle sourceRectangle = new Rectangle(32, 67, 100, 100);
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "NegroRey");
            target = new Texture2D(graphicsDevice, 100, 100);

            sourceRectangle.X = 210;
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "NegroReina");
            target = new Texture2D(graphicsDevice, 100, 100);

            sourceRectangle.X = 388;
            sourceRectangle.Y = 71;
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "NegroTorre");
            target = new Texture2D(graphicsDevice, 100, 100);

            sourceRectangle.X = 565;
            sourceRectangle.Y = 67;
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "NegroAlfil");
            target = new Texture2D(graphicsDevice, 100, 100);

            sourceRectangle.X = 745;
            sourceRectangle.Y = 72;
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "NegroCaballo");
            target = new Texture2D(graphicsDevice, 100, 100);

            sourceRectangle.X = 920;
            sourceRectangle.Y = 71;
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "NegroPeon");
            target = new Texture2D(graphicsDevice, 100, 100);

            sourceRectangle.Y = 216;
            sourceRectangle.X = 32;
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "BlancoRey");
            target = new Texture2D(graphicsDevice, 100, 100);

            sourceRectangle.X = 211;
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "BlancoReina");
            target = new Texture2D(graphicsDevice, 100, 100);

            sourceRectangle.X = 389;
            sourceRectangle.Y = 219;
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "BlancoTorre");
            target = new Texture2D(graphicsDevice, 100, 100);

            sourceRectangle.X = 566;
            sourceRectangle.Y = 215;
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "BlancoAlfil");
            target = new Texture2D(graphicsDevice, 100, 100);

            sourceRectangle.X = 745;
            sourceRectangle.Y = 221;
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "BlancoCaballo");
            target = new Texture2D(graphicsDevice, 100, 100);

            sourceRectangle.X = 920;
            sourceRectangle.Y = 220;
            texture.GetData(0, sourceRectangle, data, 0, data.Length);
            target.SetData(data);
            AddTexture(target, "BlancoPeon");         
        }

        private void AddTexture(Texture2D texture, string key)
        {
            Texturas.Add(key, texture);
        }

        private void AddTexture(string fileDirectory, string key = null)
        {
            if (key == null)
            {
                Texturas.Add(fileDirectory, _content.Load<Texture2D>(fileDirectory));
            }
            else
            {
                Texturas.Add(key, _content.Load<Texture2D>(fileDirectory));
            }
        }    
    }
}

