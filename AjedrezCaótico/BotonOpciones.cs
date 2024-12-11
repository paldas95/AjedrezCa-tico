
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;

namespace AjedrezCaótico
{
    enum BotonEstadoPosible
    {
        Unmarked,
        Marked
    }
    class BotonOpciones : Boton
    {
        public BotonEstadoPosible Estado { get; private set; }

        public BotonAnimacion AnimacionMarcar { get; set; }
        public BotonAnimacion AnimacionDesmcarcar { get; set; }

        public event EventHandler Marked;
        public event EventHandler UnMarked;

        public bool PermitirClickUnMark = true;

        public BotonOpciones(Sprite2D sprite) : base(sprite)
        {
        }

        public override void Update(Entrada currentInput, Entrada previousInput)
        {
            if (Contains(currentInput.ObtenerLocalizacionVirtual()))
            {
                if (currentInput.Raton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                    previousInput.Raton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    State = BotonPosible.Pressed;
                    if (ClickAnimation != null) Animaccion(ClickAnimation);
                    if (PermitirClickUnMark && Estado == BotonEstadoPosible.Marked)
                    {
                        Desmarcar();
                    }
                    else if (Estado != BotonEstadoPosible.Marked)
                    {
                        Marcar();
                    }
                    OnClick(EventArgs.Empty);
                }
                else if (State != BotonPosible.Hovered && Estado != BotonEstadoPosible.Marked)
                {
                    if (State == BotonPosible.None)
                    {
                        if (HoverAnimation != null) Animaccion(HoverAnimation);
                        OnHover(EventArgs.Empty);
                    }
                    State = BotonPosible.Hovered;
                }
            }
            else if (State != BotonPosible.None && Estado != BotonEstadoPosible.Marked)
            {
                if (UnHoverAnimation != null) Animaccion(UnHoverAnimation);
                OnUnHover(EventArgs.Empty);
                State = BotonPosible.None;
            }
        }

        public override void Update(MouseState currentInput, Entrada previousInput)
        {
            if (Contains(currentInput.Position))
            {
                if (currentInput.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Released &&
                    previousInput.Raton.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
                {
                    State = BotonPosible.Pressed;
                    if (ClickAnimation != null) Animaccion(ClickAnimation);
                    if (PermitirClickUnMark && Estado == BotonEstadoPosible.Marked)
                    {
                        Desmarcar();
                    }
                    else if (Estado != BotonEstadoPosible.Marked)
                    {
                        Marcar();
                    }
                    OnClick(EventArgs.Empty);
                }
                else if (State != BotonPosible.Hovered && Estado != BotonEstadoPosible.Marked)
                {
                    if (State == BotonPosible.None)
                    {
                        if (HoverAnimation != null) Animaccion(HoverAnimation);
                        OnHover(EventArgs.Empty);
                    }
                    State = BotonPosible.Hovered;
                }
            }
            else if (State != BotonPosible.None && Estado != BotonEstadoPosible.Marked)
            {
                if (UnHoverAnimation != null) Animaccion(UnHoverAnimation);
                OnUnHover(EventArgs.Empty);
                State = BotonPosible.None;
            }
        }

        public void Marcar()
        {
            if (AnimacionMarcar != null) Animaccion(AnimacionMarcar);
            Estado = BotonEstadoPosible.Marked;
            EnMarcado(EventArgs.Empty);

        }

        public void Desmarcar()
        {
            if (AnimacionDesmcarcar != null) Animaccion(AnimacionDesmcarcar);
            Estado = BotonEstadoPosible.Unmarked;
            EnDesmarcado(EventArgs.Empty);
        }

        protected virtual void EnMarcado(EventArgs e)
        {
            EventHandler handler = Marked;
            handler?.Invoke(this, e);
        }

        protected virtual void EnDesmarcado(EventArgs e)
        {
            EventHandler handler = UnMarked;
            handler?.Invoke(this, e);
        }
    }
}
