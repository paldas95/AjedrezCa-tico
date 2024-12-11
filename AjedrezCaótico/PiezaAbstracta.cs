using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AjedrezCaótico
{
    enum PiezasAjedrez
    {
        Peon,
        Alfil,
        Caballo,
        Torre,
        Reina,
        Rey,
        Pato,
        Demonio
    }

    abstract class Pieza : BotonOpciones
    {
        public int NumeroMovimientos { get; private set; } = 0;
        public List<Boton> legales;
        protected Texture2D legalesTexture;
        public int Fila { get; set; }
        public int Columna { get; set; }
        public PiezasAjedrez PiezaAjedrez { get; protected set; }
        protected Tablero tablero;
        ChessColor color;
        internal ChessColor ChessColor { get => color; private set => color = value; }

        public Pieza(Sprite2D sprite, int fila, int columna, ChessColor color, Tablero tablero)
            : base(sprite)
        {
            legales = new List<Boton>();
            this.Fila = fila;
            this.Columna = columna;
            legalesTexture = ContentService.Instance.Texturas["Circle"];
            this.ChessColor = color;
            this.tablero = tablero;
            Marked += (s, e) => { Center(new Rectangle(Columna * Constantes.TAMAÑOCASILLA, Fila * Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA)); };
            UnMarked += (s, e) => { Center(new Rectangle(Columna * Constantes.TAMAÑOCASILLA, Fila * Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA)); };
        }

        public override void Update(Entrada entradaActual, Entrada entradaPrevia)
        {
            if (Estado == BotonEstadoPosible.Marked)
            {
                for (int i = 0; i < legales.Count; i++)
                {
                    legales[i].Update(entradaActual, entradaPrevia);
                }
            }
            base.Update(entradaActual, entradaPrevia);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (this.Estado == BotonEstadoPosible.Marked)
            {
                DibujarMovimientosLegales(spriteBatch);
            }
            base.Draw(spriteBatch);
        }

        public void Movimiento(int fila, int columna)
        {
            NumeroMovimientos++;
            tablero.Move(this, fila, columna);
            Limites = new Rectangle(columna * Constantes.TAMAÑOCASILLA, fila * Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOPIEZA, Constantes.TAMAÑOPIEZA);
            Center(new Rectangle(columna * Constantes.TAMAÑOCASILLA, fila * Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA));
        }

        protected void AñadirMovimientoLegal(int r, int c)
        {
            Boton b = new Boton(new Sprite2D(legalesTexture, new Rectangle(c * Constantes.TAMAÑOCASILLA, r * Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA), Color.DarkSlateGray));
            b.Click += (s, e) => { Movimiento(r, c); };
            b.Hover += (s, e) => { b.Color = Color.Black; };
            b.UnHover += (s, e) => { b.Color = Color.DarkSlateGray; };
            legales.Add(b);
        }

        public abstract void CalcularMovimientosLegales();

        public abstract bool EsJaque();

        public void DibujarMovimientosLegales(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < legales.Count; i++)
            {
                legales[i].Draw(spriteBatch);
            }
        }
    }
}

