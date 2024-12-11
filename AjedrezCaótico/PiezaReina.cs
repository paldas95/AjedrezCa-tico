using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AjedrezCaótico
{
    class PiezaReina : Pieza
    {
        public PiezaReina(Sprite2D sprite, int row, int col, ChessColor color, Tablero board)
            : base(sprite, row, col, color, board)
        {
            PiezaAjedrez = PiezasAjedrez.Reina;
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

            for (int i = Fila - 1; i >= 0; i--)
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
                Pieza p = tablero.ObtenerPieza(Fila , i);
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

