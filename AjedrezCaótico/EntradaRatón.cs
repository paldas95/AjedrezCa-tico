using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AjedrezCaótico
{
    class Entrada
    {
        public MouseState Raton;

        public static Entrada Empty
        {
            get
            {
                return new Entrada();
            }
        }
        public Entrada(MouseState raton)
        {           
            Raton = raton;
        }

        public Entrada()
        {
            Raton = new MouseState();
        }



        public void Add(Entrada input)
        {
            ButtonState btnIzquierda = Raton.LeftButton;
            if (input.Raton.LeftButton == ButtonState.Pressed)
            {
                btnIzquierda = ButtonState.Pressed;
            }
            ButtonState btnDerecha = Raton.RightButton;
            if (input.Raton.RightButton == ButtonState.Pressed)
            {
                btnDerecha = ButtonState.Pressed;
            }
            ButtonState btnCentro = Raton.MiddleButton;
            if (input.Raton.MiddleButton == ButtonState.Pressed)
            {
                btnCentro = ButtonState.Pressed;
            }
        }

        public bool Contains(Entrada compararEntrada)
        {
            if ((compararEntrada.Raton.LeftButton == ButtonState.Pressed && Raton.LeftButton != ButtonState.Pressed))
            {
                return false;
            }
            if ((compararEntrada.Raton.RightButton == ButtonState.Pressed && Raton.RightButton != ButtonState.Pressed))
            {
                return false;
            }
            if ((compararEntrada.Raton.MiddleButton == ButtonState.Pressed && Raton.MiddleButton != ButtonState.Pressed))
            {
                return false;
            }

            return true;
        }

        public void Update()
        {
            Raton = Microsoft.Xna.Framework.Input.Mouse.GetState();
        }

        public Vector2 ObtenerLocalizacionVirtual()
        {
            return /*Vector2.Transform(*/Raton.Position.ToVector2()/*, Matrix.Invert(OptionsManager.Instance.Graphics.ResolutionMatrix))*/;
        }


        public static bool operator ==(Entrada inp1, Entrada inp2)
        {
            if (inp1.Raton.LeftButton != inp2.Raton.LeftButton)
            {
                return false;
            }
            if (inp1.Raton.RightButton != inp2.Raton.RightButton)
            {
                return false;
            }
            if (inp1.Raton.MiddleButton != inp2.Raton.MiddleButton)
            {
                return false;
            }

            return true;
        }

        public static bool operator !=(Entrada inp1, Entrada inp2)
        {
            if (inp1.Raton.LeftButton != inp2.Raton.LeftButton)
            {
                return true;
            }
            if (inp1.Raton.RightButton != inp2.Raton.RightButton)
            {
                return true;
            }
            if (inp1.Raton.MiddleButton != inp2.Raton.MiddleButton)
            {
                return true;
            }

            return false;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            return base.Equals(obj);
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();

            if (Raton.LeftButton == ButtonState.Pressed)
            {
                str.Append("BtnIZQrtn+");
            }
            if (Raton.RightButton == ButtonState.Pressed)
            {
                str.Append("BtnDERrtn+");
            }
            if (Raton.MiddleButton == ButtonState.Pressed)
            {
                str.Append("BtnCNTrtn");
            }

            return str.ToString().Trim(' ', '+');
        }
    }
}
