using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AjedrezCaótico
{
    interface IScreen
    {
        void Initialize(ScreenManager screenManager);

        void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        void Update(GameTime gameTime, Entrada curInput, Entrada prevInput);
    }

    interface IScreenManager
    {
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        void Update(GameTime gameTime, Entrada curInput, Entrada prevInput);

        void ChangeScreen();

        void RemoveAllScreens();

        void PopScreen();

        void PushScreen(IScreen screen);

        void ExitGame();
    }
}
