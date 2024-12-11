using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace AjedrezCaótico
{
     class PiezaPato: Pieza
     {
        public PiezaPato(Sprite2D sprite, int row, int col, ChessColor color, Tablero board)
            : base(sprite, row, col, color, board)
        {
            PiezaAjedrez = PiezasAjedrez.Pato;
        }
        public override void CalcularMovimientosLegales()
        {
            legales.Clear();

            for (int i = 0; i < 8; i++) // Iterate over rows
            {
                for (int j = 0; j < 8; j++) // Iterate over columns
                {
                    if (tablero.IsEmpty(i, j))
                    {
                        AñadirMovimientoLegal(i, j);
                    }
                }
            }
        }
        public override bool EsJaque()
        {
            return false;
        }

    }
}
