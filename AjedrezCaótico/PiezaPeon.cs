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
    class PiezaPeon : Pieza
    {
        public PiezaPeon(Sprite2D sprite, int row, int col, ChessColor color, Tablero board)
            : base(sprite, row, col, color, board)
        {
            PiezaAjedrez = PiezasAjedrez.Peon;
        }
        public override void CalcularMovimientosLegales()
        {
            legales.Clear();
            if (NumeroMovimientos == 0)
            {
                if (ChessColor == ChessColor.Blancas && tablero.IsEmpty(5, Columna) && tablero.IsEmpty(4, Columna))
                {
                    if (tablero.IsLegalMove(this, 4, Columna))
                    {
                        AñadirMovimientoLegal(4, Columna);
                    }
                }
                else if (ChessColor == ChessColor.Negras && tablero.IsEmpty(2, Columna) && tablero.IsEmpty(3, Columna))
                {
                    if (tablero.IsLegalMove(this, 3, Columna))
                    {
                        AñadirMovimientoLegal(3, Columna);
                    }
                }
            }
            if (ChessColor == ChessColor.Blancas && tablero.IsEmpty(Fila - 1, Columna))
            {
                if (tablero.IsLegalMove(this, Fila - 1, Columna))
                {
                    AñadirMovimientoLegal(Fila - 1, Columna);
                }
            }
            else if (ChessColor == ChessColor.Negras && tablero.IsEmpty(Fila + 1, Columna))
            {
                if (tablero.IsLegalMove(this, Fila + 1, Columna))
                {
                    AñadirMovimientoLegal(Fila + 1, Columna);
                }
            }
            if (Columna != 0)
            {
                if (ChessColor == ChessColor.Blancas && !tablero.IsEmpty(Fila - 1, Columna - 1) && tablero.ObtenerPieza(Fila - 1, Columna - 1).ChessColor != ChessColor)
                {
                    if (tablero.ObtenerPieza(Fila - 1, Columna - 1).ChessColor != ChessColor.Neutral)
                    {
                        if (tablero.IsLegalMove(this, Fila - 1, Columna - 1))
                        {
                            AñadirMovimientoLegal(Fila - 1, Columna - 1);
                        }
                    }
                }
                else if (ChessColor == ChessColor.Negras && !tablero.IsEmpty(Fila + 1, Columna - 1) && tablero.ObtenerPieza(Fila + 1, Columna - 1).ChessColor != ChessColor )
                {
                    if (tablero.ObtenerPieza(Fila + 1, Columna - 1).ChessColor != ChessColor.Neutral)
                    {
                        if (tablero.IsLegalMove(this, Fila + 1, Columna - 1))
                        {
                            AñadirMovimientoLegal(Fila + 1, Columna - 1);
                        }
                    }
                }
            }
            if (Columna != 7)
            {
                if (ChessColor == ChessColor.Blancas && !tablero.IsEmpty(Fila - 1, Columna + 1) && tablero.ObtenerPieza(Fila - 1, Columna + 1).ChessColor != ChessColor)
                {
                    if (tablero.ObtenerPieza(Fila - 1, Columna + 1).ChessColor != ChessColor.Neutral)
                    {
                        if (tablero.IsLegalMove(this, Fila - 1, Columna + 1))
                        {
                            AñadirMovimientoLegal(Fila - 1, Columna + 1);
                        }
                    }
                }
                else if (ChessColor == ChessColor.Negras && !tablero.IsEmpty(Fila + 1, Columna + 1) && tablero.ObtenerPieza(Fila + 1, Columna + 1).ChessColor != ChessColor)
                {
                    if (tablero.ObtenerPieza(Fila + 1, Columna + 1).ChessColor != ChessColor.Neutral)
                    {
                        if (tablero.IsLegalMove(this, Fila + 1, Columna + 1))
                        {
                            AñadirMovimientoLegal(Fila +  1, Columna + 1);
                        }
                    }
                }
            }
            //En passant
            if (Columna != 0)
            {
                if (Fila == 3 && ChessColor == ChessColor.Blancas && !tablero.IsEmpty(Fila, Columna - 1) && tablero.IsEmpty(Fila - 1, Columna - 1))
                {
                    Pieza p = tablero.ObtenerPieza(Fila, Columna - 1);
                    if (p.ChessColor != ChessColor && p.NumeroMovimientos == 1 && tablero.UltimaPiezaMovimiento == p && p.PiezaAjedrez == PiezasAjedrez.Peon && tablero.EsMovimientoLegal(this, Fila - 1, Columna - 1, p))
                    {
                        AddEnPassantMove(p, Fila - 1, Columna + 1);
                    }
                }
                else if (Fila == 4 && ChessColor == ChessColor.Negras && !tablero.IsEmpty(Fila, Columna - 1) && tablero.IsEmpty(Fila + 1, Columna - 1))
                {
                    Pieza p = tablero.ObtenerPieza(Fila, Columna - 1);
                    if (p.ChessColor != ChessColor && p.NumeroMovimientos == 1 && tablero.UltimaPiezaMovimiento == p && p.PiezaAjedrez == PiezasAjedrez.Peon && tablero.EsMovimientoLegal(this, Fila + 1, Columna - 1, p))
                    {
                        AddEnPassantMove(p, Fila + 1, Columna + 1);
                    }
                }
            }
            if (Columna != 7)
            {
                if (Fila == 3 && ChessColor == ChessColor.Blancas && !tablero.IsEmpty(Fila, Columna + 1) && tablero.IsEmpty(Fila - 1,Columna +1))       
                {
                    Pieza p = tablero.ObtenerPieza(Fila, Columna + 1);
                    if (p.ChessColor != ChessColor && p.NumeroMovimientos == 1 && tablero.UltimaPiezaMovimiento == p && p.PiezaAjedrez == PiezasAjedrez.Peon && tablero.EsMovimientoLegal(this, Fila - 1, Columna + 1, p))
                    {
                        AddEnPassantMove(p, Fila - 1, Columna + 1);
                    }
                }
                else if (Fila == 4 && ChessColor == ChessColor.Negras && !tablero.IsEmpty(Fila, Columna + 1) && tablero.IsEmpty(Fila + 1, Columna + 1))
                {
                    Pieza p = tablero.ObtenerPieza(Fila, Columna + 1);
                    if (p.ChessColor != ChessColor && p.NumeroMovimientos == 1 && tablero.UltimaPiezaMovimiento == p && p.PiezaAjedrez == PiezasAjedrez.Peon && tablero.EsMovimientoLegal(this, Fila + 1, Columna + 1, p))
                    {
                        AddEnPassantMove(p, Fila + 1, Columna + 1);

                    }
                }
            }
        }

        public override bool EsJaque()
        {
            if (Columna != 0)
            {
                if (ChessColor == ChessColor.Blancas && !tablero.IsEmpty(Fila - 1, Columna - 1) && tablero.ObtenerPieza(Fila - 1, Columna - 1).ChessColor != ChessColor && tablero.ObtenerPieza(Fila - 1, Columna - 1).PiezaAjedrez == PiezasAjedrez.Rey)
                {
                    return true;
                }
                else if (ChessColor == ChessColor.Negras && !tablero.IsEmpty(Fila + 1, Columna - 1) && tablero.ObtenerPieza(Fila + 1, Columna - 1).ChessColor != ChessColor && tablero.ObtenerPieza(Fila + 1, Columna - 1).PiezaAjedrez == PiezasAjedrez.Rey)
                {
                    return true;
                }
            }
            if (Columna != 7)
            {
                if (ChessColor == ChessColor.Blancas && !tablero.IsEmpty(Fila - 1, Columna + 1) && tablero.ObtenerPieza(Fila - 1, Columna + 1).ChessColor != ChessColor && tablero.ObtenerPieza(Fila - 1, Columna + 1).PiezaAjedrez == PiezasAjedrez.Rey)
                {
                    return true;
                }
                else if (ChessColor == ChessColor.Negras && !tablero.IsEmpty(Fila + 1, Columna + 1) && tablero.ObtenerPieza(Fila + 1, Columna + 1).ChessColor != ChessColor && tablero.ObtenerPieza(Fila + 1, Columna   + 1).PiezaAjedrez == PiezasAjedrez.Rey)
                {
                    return true;
                }
            }
            return false;
        }

        protected void AddEnPassantMove(Pieza p, int r, int c)
        {
            Boton b = new Boton(new Sprite2D(legalesTexture, new Rectangle(c * Constantes.TAMAÑOCASILLA, r * Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA), Color.DarkSlateGray));
            b.Click += (s, e) => { p.Movimiento(r, c); Movimiento(r, c); };
            b.Hover += (s, e) => { b.Color = Color.Black; };
            b.UnHover += (s, e) => { b.Color = Color.DarkSlateGray; };
            legales.Add(b);
        }
     
    }
}
