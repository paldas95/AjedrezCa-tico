using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AjedrezCaótico
{
    class PiezaRey : Pieza
    {
        public PiezaRey(Sprite2D sprite, int row, int col, ChessColor color, Tablero board)
            : base(sprite, row, col, color, board)
        {
            PiezaAjedrez = PiezasAjedrez.Rey;
        }
        public override void CalcularMovimientosLegales()
        {
            legales.Clear();

            for (int i = Math.Max(0, Fila - 1); i <= Math.Min(7, Fila + 1); i++)
            {
                for (int j = Math.Max(0, Columna - 1); j <= Math.Min(7, Columna + 1); j++)
                {
                    if (i == Fila && Columna == j) continue;
                    
                    if (tablero.IsLegalMove(this, i, j))
                    {                       
                        if (tablero.IsEmpty(i, j) || tablero.ObtenerPieza(i, j).ChessColor != ChessColor.Neutral && tablero.ObtenerPieza(i, j).ChessColor != ChessColor)
                        {
                            AñadirMovimientoLegal(i, j);
                        }
                    }
                }
            }

            // Enroque a la izquierda
            if (NumeroMovimientos == 0 && tablero.IsEmpty(Fila, 1) && tablero.IsEmpty(Fila, 2) && tablero.IsEmpty(Fila, 3)
                && tablero.IsLegalMove(this, Fila, 4) && tablero.IsLegalMove(this, Fila, 3) && tablero.IsLegalMove(this, Fila, 2) && !tablero.IsEmpty(Fila, 0))
            {
                Pieza p = tablero.ObtenerPieza(Fila, 0);
                if (p.NumeroMovimientos == 0)
                {
                    AñadirEnroque(p, 2, 3);
                }
            }
            // Enroque a la derecha
            if (NumeroMovimientos == 0 && tablero.IsEmpty(Fila, 5) && tablero.IsEmpty(Fila, 6)
                && tablero.IsLegalMove(this, Fila, 4) && tablero.IsLegalMove(this, Fila, 5) && tablero.IsLegalMove(this, Fila, 6) && !tablero.IsEmpty(Fila, 7))
            {
                Pieza p = tablero.ObtenerPieza(Fila, 7);
                if (p.NumeroMovimientos == 0)
                {
                    AñadirEnroque(p, 6, 5);
                }
            }
        }


        public override bool EsJaque()
        {
            for (int i = Math.Max(0, Fila - 1); i <= Math.Min(7, Fila + 1); i++)
            {
                for (int j = Math.Max(0, Columna - 1); j <= Math.Min(7, Columna + 1); j++)
                {
                    if (i == Fila && Columna == j) continue;
                    if (tablero.IsEmpty(i, j)) continue;
                    Pieza p = tablero.ObtenerPieza(i, j);
                    if (p.ChessColor != ChessColor && p.PiezaAjedrez == PiezasAjedrez.Rey)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        protected void AñadirEnroque(Pieza p, int col, int secol)
        {
            Boton b = new Boton(new Sprite2D(legalesTexture, new Rectangle(col * Constantes.TAMAÑOCASILLA, Fila * Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA), Color.DarkSlateGray));
            b.Click += (s, e) => { Movimiento(Fila, col); p.Movimiento(Fila, secol); };
            b.Hover += (s, e) => { b.Color = Color.Black; };
            b.UnHover += (s, e) => { b.Color = Color.DarkSlateGray; };
            legales.Add(b);
        }


    }
}

