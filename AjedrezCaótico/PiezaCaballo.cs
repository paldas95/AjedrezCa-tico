using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AjedrezCaótico
{
    class PiezaCaballo : Pieza
    {
        public PiezaCaballo(Sprite2D sprite, int row, int col, ChessColor color, Tablero board)
            : base(sprite, row, col, color, board)
        {
            PiezaAjedrez = PiezasAjedrez.Caballo;
        }
        public override void CalcularMovimientosLegales()
        {
            legales.Clear();

            int[] desplazamientosFilas = { -2, -1, 1, 2, 2, 1, -1, -2 };
            int[] desplazamientosColumnas = { 1, 2, 2, 1, -1, -2, -2, -1 };

            for (int k = 0; k < 8; k++)
            {
                int nuevaFila = Fila + desplazamientosFilas[k];
                int nuevaColumna = Columna + desplazamientosColumnas[k];


                if (tablero.InGrid(nuevaFila, nuevaColumna))
                {
                    if (tablero.IsLegalMove(this, nuevaFila, nuevaColumna))
                    {
                        if (tablero.IsEmpty(nuevaFila, nuevaColumna) || tablero.ObtenerPieza(nuevaFila, nuevaColumna).ChessColor != ChessColor.Neutral && tablero.ObtenerPieza(nuevaFila, nuevaColumna).ChessColor != ChessColor)
                        {
                            AñadirMovimientoLegal(nuevaFila, nuevaColumna);
                        }
                    }
                }
            }
        }

        public override bool EsJaque()
        {
            for (int i = Fila - 2; i <= Fila + 2; i += 4)
            {
                for (int j = Columna - 1; j <= Columna + 1; j += 2)
                {
                    if (tablero.InGrid(i, j) && !tablero.IsEmpty(i, j))
                    {
                        Pieza p = tablero.ObtenerPieza(i, j);
                        if (p.ChessColor != ChessColor && p.PiezaAjedrez == PiezasAjedrez.Rey)
                        {
                            return true;
                        }
                    }
                }
            }
            for (int j = Columna - 2; j <= Columna + 2; j += 4)
            {
                for (int i = Fila - 1; i <= Fila + 1; i += 2)
                {
                    if (tablero.InGrid(i, j) && !tablero.IsEmpty(i, j))
                    {
                        Pieza p = tablero.ObtenerPieza(i, j);
                        if (p.ChessColor != ChessColor && p.PiezaAjedrez == PiezasAjedrez.Rey)
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
    }
}

