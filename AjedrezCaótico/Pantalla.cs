using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;


namespace AjedrezCaótico
{
        class GameScreen : IScreen
         {
        ScreenManager screenManager;

        Tablero tablero;

        public void Initialize(ScreenManager screenManager)
        {
            this.screenManager = screenManager;

            tablero = new Tablero();
        }

        public void Update(GameTime gameTime, Entrada curInput, Entrada prevInput)
        {
            tablero.Update(gameTime, curInput, prevInput);
        }

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            tablero.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
