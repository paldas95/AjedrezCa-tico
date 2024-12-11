using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AjedrezCaótico
{
    class PiezaDemonio : Pieza
    {
       
        private Random random;
        public PiezaDemonio(Sprite2D sprite, int row, int col, ChessColor color, Tablero board)
            : base(sprite, row, col, color, board)
        {
            PiezaAjedrez = PiezasAjedrez.Demonio;
            this.random = new Random();
        }
        public override void CalcularMovimientosLegales()
        {
            legales.Clear();
            List<Tuple<int, int>> movimientosLegales = new List<Tuple<int, int>>();

            for (int i = Math.Max(0, Fila - 1); i <= Math.Min(7, Fila + 1); i++)
            {
                for (int j = Math.Max(0, Columna - 1); j <= Math.Min(7, Columna + 1); j++)
                {
                    if (i == Fila && Columna == j) continue; // Evita la posición actual
                    if (tablero.IsLegalMove(this, i, j) && tablero.IsEmpty(i,j))
                    {
                        movimientosLegales.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            if (movimientosLegales.Count > 0)
            {
                Random random = new Random();
                int index = random.Next(movimientosLegales.Count);
                Tuple<int, int> movimientoSeleccionado = movimientosLegales[index];

                AñadirMovimientoLegal(movimientoSeleccionado.Item1, movimientoSeleccionado.Item2);
            }
        }

        public override bool EsJaque()
        {
            return false;
        }
       
    }
}

