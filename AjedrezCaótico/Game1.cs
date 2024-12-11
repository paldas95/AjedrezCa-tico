using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using ProyectoAjedrez;
using System;
using System.Reflection.Emit;

namespace AjedrezCaótico
{
    public class ValoresCompartidos
    {
        public static int modoPartida = 1;
        public static int tiempoBlancas ;
        public static int tiempoNegras;
        public static int tiempoPartida;
        public static bool tempoTurnoBlancas = false;
        public static bool gananBlancas = false;
        public static bool gananNegras= false;
        public static bool victoria = false;
        public static bool tablas = false;
        public static volatile bool turnoBlancas = true;
        public static bool controlador = false;
    }


    public class DriverClass : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public static Random Random = new Random(); 


        ScreenManager screenManager;

        Entrada currentInput;
        Entrada previousInput;
        MenuForms menuForms;
        MenuTempo menuTempo;

        public DriverClass()
        {       
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = Constantes.TAMAÑOCASILLA * 8;
            graphics.PreferredBackBufferHeight = Constantes.TAMAÑOCASILLA * 8;
            graphics.ApplyChanges();

            Window.Title = "AjedrezCaótico";
            IsMouseVisible = true;
            menuForms = new MenuForms();
            menuTempo = new MenuTempo(this);
        }

        protected override void Initialize()
        {
            
            previousInput = new Entrada();
            currentInput = new Entrada();
            menuTempo.Show();
            base.Initialize();

        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ContentService.Instance.LoadContent(this.Content, GraphicsDevice, spriteBatch);
            screenManager = new ScreenManager(new GameScreen(), this);
        }

        protected override void UnloadContent()
        { }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            screenManager.ChangeScreen();          

            previousInput.Raton = currentInput.Raton;

            currentInput.Update();

            screenManager.Update(gameTime, currentInput, previousInput);
           

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            screenManager.Draw(gameTime, spriteBatch);

            base.Draw(gameTime);
        }
        public void RestartGame()
        {
            int modoActual = ValoresCompartidos.modoPartida;
            int tiempoActual = ValoresCompartidos.tiempoPartida;    
          
            screenManager = new ScreenManager(new GameScreen(), this);

            ValoresCompartidos.modoPartida = modoActual;
            ValoresCompartidos.tiempoPartida = tiempoActual;

            menuTempo.RestartForm();
        }


    }
   
}
