using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AjedrezCaótico
{
    class PiezaAlfil : Pieza
    {
        public PiezaAlfil(Sprite2D sprite, int fila, int columna, ChessColor color, Tablero tablero)
            : base(sprite, fila, columna, color, tablero)
        {
            PiezaAjedrez = PiezasAjedrez.Alfil;
        }


        public override void CalcularMovimientosLegales()
        {
            legales.Clear();

            for (int i = 1; i <= Math.Min(Fila, Columna); i++)
            {
                int nuevaFila = Fila - i;
                int nuevaColumna = Columna - i;
            
                if (tablero.IsLegalMove(this, nuevaFila, nuevaColumna))
                {
                    if (tablero.IsEmpty(nuevaFila, nuevaColumna) || tablero.ObtenerPieza(nuevaFila, nuevaColumna).ChessColor != ChessColor.Neutral && tablero.ObtenerPieza(nuevaFila, nuevaColumna).ChessColor != ChessColor)
                    {
                        AñadirMovimientoLegal(nuevaFila, nuevaColumna);
                    }
                }

                if (!tablero.IsEmpty(nuevaFila, nuevaColumna)) break;
            }

            for (int i = 1; i <= 7 - Math.Max(Fila, Columna); i++)
            {
                int nuevaFila = Fila + i;
                int nuevaColumna = Columna + i;

                if (tablero.IsLegalMove(this, nuevaFila, nuevaColumna))
                {
                    if (tablero.IsEmpty(nuevaFila, nuevaColumna) || tablero.ObtenerPieza(nuevaFila, nuevaColumna).ChessColor != ChessColor.Neutral && tablero.ObtenerPieza(nuevaFila, nuevaColumna).ChessColor != ChessColor)
                    {
                        AñadirMovimientoLegal(nuevaFila, nuevaColumna);
                    }
                }

                if (!tablero.IsEmpty(nuevaFila, nuevaColumna)) break;
            }

            for (int i = 1; i <= Math.Min(Fila, 7 - Columna); i++)
            {
                int nuevaFila = Fila - i;
                int nuevaColumna = Columna + i;

                if (tablero.IsLegalMove(this, nuevaFila, nuevaColumna))
                {
                    if (tablero.IsEmpty(nuevaFila, nuevaColumna) || tablero.ObtenerPieza(nuevaFila, nuevaColumna).ChessColor != ChessColor.Neutral && tablero.ObtenerPieza(nuevaFila, nuevaColumna).ChessColor != ChessColor)
                    {
                        AñadirMovimientoLegal(nuevaFila, nuevaColumna);
                    }
                }

                if (!tablero.IsEmpty(nuevaFila, nuevaColumna)) break;
            }

            for (int i = 1; i <= Math.Min(7 - Fila, Columna); i++)
            {
                int nuevaFila = Fila + i;
                int nuevaColumna = Columna - i;

                if (tablero.IsLegalMove(this, nuevaFila, nuevaColumna))
                {
                    if (tablero.IsEmpty(nuevaFila, nuevaColumna) || tablero.ObtenerPieza(nuevaFila, nuevaColumna).ChessColor != ChessColor.Neutral && tablero.ObtenerPieza(nuevaFila, nuevaColumna).ChessColor != ChessColor)
                    {
                        AñadirMovimientoLegal(nuevaFila, nuevaColumna);
                    }
                }

                if (!tablero.IsEmpty(nuevaFila, nuevaColumna)) break;
            }
        }


        public override bool EsJaque()
        {
            for (int i = 1; i <= Math.Min(Fila, Columna); i++)
            {
                if (tablero.IsEmpty(Fila - i, Columna - i)) continue;
                Pieza p = tablero.ObtenerPieza(Fila - i, Columna - i);
                if (p.ChessColor != ChessColor && p.PiezaAjedrez == PiezasAjedrez.Rey) return true;
                break;
            }
            for (int i = 1; i <= 7 - Math.Max(Fila, Columna); i++)
            {
                if (tablero.IsEmpty(Fila + i, Columna + i)) continue;
                Pieza p = tablero.ObtenerPieza(Fila + i, Columna + i);
                if (p.ChessColor != ChessColor && p.PiezaAjedrez == PiezasAjedrez.Rey) return true;
                break;
            }
            for (int i = 1; i <= Math.Min(Fila, 7 - Columna); i++)
            {
                if (tablero.IsEmpty(Fila - i, Columna + i)) continue;
                Pieza p = tablero.ObtenerPieza(Fila - i, Columna + i);
                if (p.ChessColor != ChessColor && p.PiezaAjedrez == PiezasAjedrez.Rey) return true;
                break;
            }
            for (int i = 1; i <= Math.Min(7 - Fila, Columna); i++)
            {
                if (tablero.IsEmpty(Fila + i, Columna - i)) continue;
                Pieza p = tablero.ObtenerPieza(Fila + i, Columna - i);
                if (p.ChessColor != ChessColor && p.PiezaAjedrez == PiezasAjedrez.Rey) return true;
                break;
            }
            return false;
        }
        
    }
}

