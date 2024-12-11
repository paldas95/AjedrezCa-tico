using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AjedrezCaótico
{
    class PiezaTorre : Pieza
    {
        public PiezaTorre(Sprite2D sprite, int row, int col, ChessColor color, Tablero board)
            : base(sprite, row, col, color, board)
        {
            PiezaAjedrez = PiezasAjedrez.Torre;
        }
        public override void CalcularMovimientosLegales()
        {
            legales.Clear();

            // Check vertical movements upwards
            for (int i = Fila - 1; i >= 0; i--)
            {
                // Check if the move is legal
                if (tablero.IsLegalMove(this, i, Columna))
                {
                    // Check if the destination is empty or occupied by an opponent's piece or neutral piece
                    if (tablero.IsEmpty(i, Columna) || tablero.ObtenerPieza(i, Columna).ChessColor != ChessColor.Neutral && tablero.ObtenerPieza(i, Columna).ChessColor != ChessColor)
                    {
                        // Add the legal move to the list
                        AñadirMovimientoLegal(i, Columna);
                    }
                }
                if (!tablero.IsEmpty(i, Columna)) break;
            }

            // Check vertical movements downwards
            for (int i = Fila + 1; i < 8; i++)
            {
                if (tablero.IsLegalMove(this, i, Columna))
                {
                    if (tablero.IsEmpty(i, Columna) || tablero.ObtenerPieza(i, Columna).ChessColor != ChessColor.Neutral && tablero.ObtenerPieza(i, Columna).ChessColor != ChessColor)
                    {
                        AñadirMovimientoLegal(i, Columna);
                    }
                }
                if (!tablero.IsEmpty(i, Columna)) break;
            }

            // Check horizontal movements to the left
            for (int i = Columna - 1; i >= 0; i--)
            {
                if (tablero.IsLegalMove(this, Fila, i))
                {
                    if (tablero.IsEmpty(Fila, i) || tablero.ObtenerPieza(Fila, i).ChessColor != ChessColor.Neutral && tablero.ObtenerPieza(Fila, i).ChessColor != ChessColor)
                    {
                        AñadirMovimientoLegal(Fila, i);
                    }
                }
                if (!tablero.IsEmpty(Fila, i)) break;
            }

            // Check horizontal movements to the right
            for (int i = Columna + 1; i < 8; i++)
            {
                if (tablero.IsLegalMove(this, Fila, i))
                {
                    if (tablero.IsEmpty(Fila, i) || tablero.ObtenerPieza(Fila, i).ChessColor != ChessColor.Neutral && tablero.ObtenerPieza(Fila, i).ChessColor != ChessColor)
                    {
                        AñadirMovimientoLegal(Fila, i);
                    }
                }
                if (!tablero.IsEmpty(Fila, i)) break;
            }
        }


        public override bool EsJaque()
        {
            for (int i = Fila - 1; i >= 0; i--)
            {
                if (tablero.IsEmpty(i, Columna)) continue;
                Pieza p = tablero.ObtenerPieza(i, Columna);
                if (p.ChessColor != ChessColor && p.PiezaAjedrez == PiezasAjedrez.Rey)
                {
                    return true;
                }
                break;
            }
            for (int i = Columna - 1; i >= 0; i--)
            {
                if (tablero.IsEmpty(Fila, i)) continue;
                Pieza p = tablero.ObtenerPieza(Fila, i);
                if (p.ChessColor != ChessColor && p.PiezaAjedrez == PiezasAjedrez.Rey)
                {
                    return true;
                }
                break;
            }
            for (int i = Fila + 1; i < 8; i++)
            {
                if (tablero.IsEmpty(i, Columna)) continue;
                Pieza p = tablero.ObtenerPieza(i, Columna);
                if (p.ChessColor != ChessColor && p.PiezaAjedrez == PiezasAjedrez.Rey)
                {
                    return true;
                }
                break;
            }
            for (int i = Columna + 1; i < 8; i++)
            {
                if (tablero.IsEmpty(Fila, i)) continue;
                Pieza p = tablero.ObtenerPieza(Fila, i);
                if (p.ChessColor != ChessColor && p.PiezaAjedrez == PiezasAjedrez.Rey)
                {
                    return true;
                }
                break;
            }
            return false;
        }
       
    }
}
