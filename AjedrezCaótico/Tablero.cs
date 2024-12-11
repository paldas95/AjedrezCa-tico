
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AjedrezCaótico
{
   
        enum Turno
        {
            Jugador1,
            Jugador2,
            Neutral
        }
        enum ChessColor
        {
            Blancas,
            Negras,
            Neutral
        }
    class Tablero
    {
        BotonPanelMarcable blancas;
        BotonPanelMarcable negras;
        BotonPanelMarcable neutral;
        
        Sprite2D[,] grid;

        Pieza[,] board;
        public Turno Turno { get; private set; } = Turno.Jugador1;
        private Turno prevTurn = Turno.Jugador2;

        public Pieza UltimaPiezaMovimiento;
        private int contadorMovimientos = 0;

        public delegate void GameOverEventHandler(object sender, EventArgs e);
     
        public event GameOverEventHandler GameOverEvent;

        public Tablero()
        {
            Texture2D gridSquares = ContentService.Instance.Texturas["Empty"];
            grid = new Sprite2D[8, 8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grid[i, j] = new Sprite2D(gridSquares, new Rectangle(j * Constantes.TAMAÑOCASILLA, i * Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOCASILLA), Color.DarkGray);
                    if ((i + j) % 2 == 0) grid[i, j].Color = Color.White;
                }
            }

            ManejadorTablero();
           

        }
        public void ManejadorTablero()
        {
            switch (ValoresCompartidos.modoPartida)
            {
                case 1:
                    {
                        ColocarPiezas();
                        break;
                    }
                case 2:
                    {
                        ColocarPiezas2();
                        break;
                    }
                case 3:
                    {
                        ColocarPiezas3();
                        break;
                    }
                case 4:
                    {
                        ColocarPiezas4();
                        break;
                    }

            }
        }
        public int ObtenerContadorMovimientos()
        {
            return contadorMovimientos;
        }
        public void IncrementarContadorMovimientos() 
        {
            contadorMovimientos++;
        }
        public int ContarPiezasNeutrales()
        {
            int count = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Pieza p = board[i, j];
                    if (p != null && p.ChessColor == ChessColor.Neutral)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void ColocarPiezas()
        {
            board = new Pieza[8, 8];

            blancas = new BotonPanelMarcable();
            negras = new BotonPanelMarcable();
            neutral = new BotonPanelMarcable();

            int tamañoPieza = Constantes.TAMAÑOPIEZA;
            int tamañoMarca = Constantes.PIEZAMARCADATAMAÑO;
            for (int i = 0; i < 8; i++)
            {
                Pieza temp = new PiezaPeon(new Sprite2D(ContentService.Instance.Texturas["BlancoPeon"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 6, i, ChessColor.Blancas, this);
                temp.Center(grid[6, i].Limites);
                board[6, i] = temp;
            }
            Pieza x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["BlancoTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 0, ChessColor.Blancas, this);
            x.Center(grid[7, 0].Limites);
            board[7, 0] = x;
            x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["BlancoTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 7, ChessColor.Blancas, this);
            x.Center(grid[7, 7].Limites);
            board[7, 7] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["BlancoCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 1, ChessColor.Blancas, this);
            x.Center(grid[7, 1].Limites);
            board[7, 1] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["BlancoCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 6, ChessColor.Blancas, this);
            x.Center(grid[7, 6].Limites);
            board[7, 6] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["BlancoAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 2, ChessColor.Blancas, this);
            x.Center(grid[7, 2].Limites);
            board[7, 2] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["BlancoAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 5, ChessColor.Blancas, this);
            x.Center(grid[7, 5].Limites);
            board[7, 5] = x;
            x = new PiezaReina(new Sprite2D(ContentService.Instance.Texturas["BlancoReina"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 3, ChessColor.Blancas, this);
            x.Center(grid[7, 3].Limites);
            board[7, 3] = x;
            x = new PiezaRey(new Sprite2D(ContentService.Instance.Texturas["BlancoRey"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 4, ChessColor.Blancas, this);
            x.Center(grid[7, 4].Limites);
            board[7, 4] = x;






            for (int i = 0; i < 8; i++)
            {
                Pieza temp = new PiezaPeon(new Sprite2D(ContentService.Instance.Texturas["NegroPeon"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 1, i, ChessColor.Negras, this);
                temp.Center(grid[1, i].Limites);
                board[1, i] = temp;
            }
            x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["NegroTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 0, ChessColor.Negras, this);
            x.Center(grid[0, 0].Limites);
            board[0, 0] = x;
            x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["NegroTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 7, ChessColor.Negras, this);
            x.Center(grid[0, 7].Limites);
            board[0, 7] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["NegroCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 1, ChessColor.Negras, this);
            x.Center(grid[0, 1].Limites);
            board[0, 1] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["NegroCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 6, ChessColor.Negras, this);
            x.Center(grid[0, 6].Limites);
            board[0, 6] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["NegroAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 2, ChessColor.Negras, this);
            x.Center(grid[0, 2].Limites);
            board[0, 2] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["NegroAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 5, ChessColor.Negras, this);
            x.Center(grid[0, 5].Limites);
            board[0, 5] = x;
            x = new PiezaReina(new Sprite2D(ContentService.Instance.Texturas["NegroReina"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 3, ChessColor.Negras, this);
            x.Center(grid[0, 3].Limites);
            board[0, 3] = x;
            x = new PiezaRey(new Sprite2D(ContentService.Instance.Texturas["NegroRey"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 4, ChessColor.Negras, this);
            x.Center(grid[0, 4].Limites);
            board[0, 4] = x;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == null) continue;
                    board[i, j].AnimacionMarcar = new BotonAnimacion(null, new Rectangle(board[i, j].Limites.Location, new Point(tamañoMarca, tamañoMarca)), null, true);
                    board[i, j].AnimacionDesmcarcar = new BotonAnimacion(null, new Rectangle(board[i, j].Limites.Location, new Point(tamañoPieza, tamañoPieza)), null, true);
                    if (board[i, j].ChessColor == ChessColor.Negras) negras.Add(board[i, j]);
                    else if (board[i, j].ChessColor == ChessColor.Blancas) blancas.Add(board[i, j]);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null) board[i, j].CalcularMovimientosLegales();
                }
            }
        }
        private void ColocarPiezas2()
        {
            board = new Pieza[8, 8];

            blancas = new BotonPanelMarcable();
            negras = new BotonPanelMarcable();
            neutral = new BotonPanelMarcable();

            int tamañoPieza = Constantes.TAMAÑOPIEZA;
            int tamañoMarca = Constantes.PIEZAMARCADATAMAÑO;

            Random posAleatoria = new Random();
            
            for (int i = 0; i < 8; i++)
            {
                Pieza temp = new PiezaPeon(new Sprite2D(ContentService.Instance.Texturas["BlancoPeon"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 6, i, ChessColor.Blancas, this);
                temp.Center(grid[6, i].Limites);
                board[6, i] = temp;
            }
            for (int Fila = 7; Fila > 6; Fila--)
            {
                List<int> colAleatoriaBlancas = new List<int>();
                for (int column = 0; column < 8; column++)
                {
                    if (board[Fila, column] == null)
                    {
                        colAleatoriaBlancas.Add(column);
                    }
                }

                for (int i = 0; i < 8; i++)
                {
                    int randomIndex = posAleatoria.Next(colAleatoriaBlancas.Count);
                    int colAleatoriaB = colAleatoriaBlancas[randomIndex];
                   
                    switch (i)
                    {
                        case 0:
                            board[Fila, colAleatoriaB] = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["BlancoTorre"], new Rectangle(Fila, colAleatoriaB, tamañoPieza, tamañoPieza)), Fila, colAleatoriaB, ChessColor.Blancas, this);
                            break;
                        case 1:
                            board[Fila, colAleatoriaB] = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["BlancoCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaB, ChessColor.Blancas, this);
                            break;
                        case 2:
                            board[Fila, colAleatoriaB] = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["BlancoAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaB, ChessColor.Blancas, this);
                            break;
                        case 3:
                            board[Fila, colAleatoriaB] = new PiezaReina(new Sprite2D(ContentService.Instance.Texturas["BlancoReina"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaB, ChessColor.Blancas, this);
                            break;
                        case 4:
                            board[Fila, colAleatoriaB] = new PiezaRey(new Sprite2D(ContentService.Instance.Texturas["BlancoRey"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaB, ChessColor.Blancas, this);
                            break;
                        case 5:
                            board[Fila, colAleatoriaB] = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["BlancoAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaB, ChessColor.Blancas, this);
                            break;
                        case 6:
                            board[Fila, colAleatoriaB] = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["BlancoCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaB, ChessColor.Blancas, this);
                            break;
                        case 7:
                            board[Fila, colAleatoriaB] = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["BlancoTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaB, ChessColor.Blancas, this);
                            break;
                    }
                    colAleatoriaBlancas.RemoveAt(randomIndex); 

                }
            }


            for (int i = 0; i < 8; i++)
            {
                Pieza temp = new PiezaPeon(new Sprite2D(ContentService.Instance.Texturas["NegroPeon"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 1, i, ChessColor.Negras, this);
                temp.Center(grid[1, i].Limites);
                board[1, i] = temp;
            }
            for (int Fila = 0; Fila < 1; Fila++) 
            {
                List<int> colAleatoriaNegras = new List<int>();
                for (int column = 0; column < 8; column++)
                {
                    if (board[Fila, column] == null)
                    {
                        colAleatoriaNegras.Add(column);
                    }
                }

                for (int i = 0; i < 8; i++)
                {
                    int randomIndex = posAleatoria.Next(colAleatoriaNegras.Count);
                    int colAleatoriaN = colAleatoriaNegras[randomIndex];
               
                    switch (i)
                    {
                        case 0:
                            board[Fila, colAleatoriaN] = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["NegroTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaN, ChessColor.Negras, this);
                            break;
                        case 1:
                            board[Fila, colAleatoriaN] = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["NegroCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaN, ChessColor.Negras, this);
                            break;
                        case 2:
                            board[Fila, colAleatoriaN] = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["NegroAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaN, ChessColor.Negras, this);
                            break;
                        case 3:
                            board[Fila, colAleatoriaN] = new PiezaReina(new Sprite2D(ContentService.Instance.Texturas["NegroReina"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaN, ChessColor.Negras, this);
                            break;
                        case 4:
                            board[Fila, colAleatoriaN] = new PiezaRey(new Sprite2D(ContentService.Instance.Texturas["NegroRey"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaN, ChessColor.Negras, this);
                            break;
                        case 5:
                            board[Fila, colAleatoriaN] = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["NegroAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaN, ChessColor.Negras, this);
                            break;
                        case 6:
                            board[Fila, colAleatoriaN] = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["NegroCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaN, ChessColor.Negras, this);
                            break;
                        case 7:
                            board[Fila, colAleatoriaN] = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["NegroTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), Fila, colAleatoriaN, ChessColor.Negras, this);
                            break;
                    }
                    colAleatoriaNegras.RemoveAt(randomIndex);
                    
                }
            }


            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == null) continue;
                    board[i, j].AnimacionMarcar = new BotonAnimacion(null, new Rectangle(board[i, j].Limites.Location, new Point(tamañoMarca, tamañoMarca)), null, true);
                    board[i, j].AnimacionDesmcarcar = new BotonAnimacion(null, new Rectangle(board[i, j].Limites.Location, new Point(tamañoPieza, tamañoPieza)), null, true);
                    if (board[i, j].ChessColor == ChessColor.Negras) negras.Add(board[i, j]);
                    else if (board[i, j].ChessColor == ChessColor.Blancas) blancas.Add(board[i, j]);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null) board[i, j].CalcularMovimientosLegales();
                }
            }
        }

        private void ColocarPiezas3()
        {
            board = new Pieza[8, 8];

            blancas = new BotonPanelMarcable();
            negras = new BotonPanelMarcable();
            neutral = new BotonPanelMarcable();

            int tamañoPieza = Constantes.TAMAÑOPIEZA;
            int tamañoMarca = Constantes.PIEZAMARCADATAMAÑO;
            for (int i = 0; i < 8; i++)
            {
                Pieza temp = new PiezaPeon(new Sprite2D(ContentService.Instance.Texturas["BlancoPeon"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 6, i, ChessColor.Blancas, this);
                temp.Center(grid[6, i].Limites);
                board[6, i] = temp;
            }
            Pieza x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["BlancoTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 0, ChessColor.Blancas, this);
            x.Center(grid[7, 0].Limites);
            board[7, 0] = x;
            x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["BlancoTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 7, ChessColor.Blancas, this);
            x.Center(grid[7, 7].Limites);
            board[7, 7] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["BlancoCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 1, ChessColor.Blancas, this);
            x.Center(grid[7, 1].Limites);
            board[7, 1] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["BlancoCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 6, ChessColor.Blancas, this);
            x.Center(grid[7, 6].Limites);
            board[7, 6] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["BlancoAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 2, ChessColor.Blancas, this);
            x.Center(grid[7, 2].Limites);
            board[7, 2] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["BlancoAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 5, ChessColor.Blancas, this);
            x.Center(grid[7, 5].Limites);
            board[7, 5] = x;
            x = new PiezaReina(new Sprite2D(ContentService.Instance.Texturas["BlancoReina"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 3, ChessColor.Blancas, this);
            x.Center(grid[7, 3].Limites);
            board[7, 3] = x;
            x = new PiezaRey(new Sprite2D(ContentService.Instance.Texturas["BlancoRey"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 4, ChessColor.Blancas, this);
            x.Center(grid[7, 4].Limites);
            board[7, 4] = x;
            x = new PiezaPato(new Sprite2D(ContentService.Instance.Texturas["NeutralPato"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 3, 3, ChessColor.Neutral, this);
            x.Center(grid[3, 3].Limites);
            board[3, 3] = x;







            for (int i = 0; i < 8; i++)
            {
                Pieza temp = new PiezaPeon(new Sprite2D(ContentService.Instance.Texturas["NegroPeon"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 1, i, ChessColor.Negras, this);
                temp.Center(grid[1, i].Limites);
                board[1, i] = temp;
            }
            x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["NegroTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 0, ChessColor.Negras, this);
            x.Center(grid[0, 0].Limites);
            board[0, 0] = x;
            x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["NegroTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 7, ChessColor.Negras, this);
            x.Center(grid[0, 7].Limites);
            board[0, 7] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["NegroCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 1, ChessColor.Negras, this);
            x.Center(grid[0, 1].Limites);
            board[0, 1] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["NegroCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 6, ChessColor.Negras, this);
            x.Center(grid[0, 6].Limites);
            board[0, 6] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["NegroAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 2, ChessColor.Negras, this);
            x.Center(grid[0, 2].Limites);
            board[0, 2] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["NegroAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 5, ChessColor.Negras, this);
            x.Center(grid[0, 5].Limites);
            board[0, 5] = x;
            x = new PiezaReina(new Sprite2D(ContentService.Instance.Texturas["NegroReina"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 3, ChessColor.Negras, this);
            x.Center(grid[0, 3].Limites);
            board[0, 3] = x;
            x = new PiezaRey(new Sprite2D(ContentService.Instance.Texturas["NegroRey"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 4, ChessColor.Negras, this);
            x.Center(grid[0, 4].Limites);
            board[0, 4] = x;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == null) continue;
                    board[i, j].AnimacionMarcar = new BotonAnimacion(null, new Rectangle(board[i, j].Limites.Location, new Point(tamañoMarca, tamañoMarca)), null, true);
                    board[i, j].AnimacionDesmcarcar = new BotonAnimacion(null, new Rectangle(board[i, j].Limites.Location, new Point(tamañoPieza, tamañoPieza)), null, true);
                    if (board[i, j].ChessColor == ChessColor.Negras) negras.Add(board[i, j]);
                    else if (board[i, j].ChessColor == ChessColor.Blancas) blancas.Add(board[i, j]);
                    else neutral.Add(board[i, j]);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null) board[i, j].CalcularMovimientosLegales();
                }
            }
        }
        private void ColocarPiezas4()
        {
            board = new Pieza[8, 8];

            blancas = new BotonPanelMarcable();
            negras = new BotonPanelMarcable();
            neutral = new BotonPanelMarcable();

            int tamañoPieza = Constantes.TAMAÑOPIEZA;
            int tamañoMarca = Constantes.PIEZAMARCADATAMAÑO;
            for (int i = 0; i < 8; i++)
            {
                Pieza temp = new PiezaPeon(new Sprite2D(ContentService.Instance.Texturas["BlancoPeon"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 6, i, ChessColor.Blancas, this);
                temp.Center(grid[6, i].Limites);
                board[6, i] = temp;
            }
            Pieza x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["BlancoTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 0, ChessColor.Blancas, this);
            x.Center(grid[7, 0].Limites);
            board[7, 0] = x;
            x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["BlancoTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 7, ChessColor.Blancas, this);
            x.Center(grid[7, 7].Limites);
            board[7, 7] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["BlancoCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 1, ChessColor.Blancas, this);
            x.Center(grid[7, 1].Limites);
            board[7, 1] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["BlancoCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 6, ChessColor.Blancas, this);
            x.Center(grid[7, 6].Limites);
            board[7, 6] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["BlancoAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 2, ChessColor.Blancas, this);
            x.Center(grid[7, 2].Limites);
            board[7, 2] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["BlancoAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 5, ChessColor.Blancas, this);
            x.Center(grid[7, 5].Limites);
            board[7, 5] = x;
            x = new PiezaReina(new Sprite2D(ContentService.Instance.Texturas["BlancoReina"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 3, ChessColor.Blancas, this);
            x.Center(grid[7, 3].Limites);
            board[7, 3] = x;
            x = new PiezaRey(new Sprite2D(ContentService.Instance.Texturas["BlancoRey"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 7, 4, ChessColor.Blancas, this);
            x.Center(grid[7, 4].Limites);
            board[7, 4] = x;
            x = new PiezaDemonio(new Sprite2D(ContentService.Instance.Texturas["NeutralDemonio"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 3, 3, ChessColor.Neutral, this);
            x.Center(grid[3, 3].Limites);
            board[3, 3] = x;







            for (int i = 0; i < 8; i++)
            {
                Pieza temp = new PiezaPeon(new Sprite2D(ContentService.Instance.Texturas["NegroPeon"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 1, i, ChessColor.Negras, this);
                temp.Center(grid[1, i].Limites);
                board[1, i] = temp;
            }
            x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["NegroTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 0, ChessColor.Negras, this);
            x.Center(grid[0, 0].Limites);
            board[0, 0] = x;
            x = new PiezaTorre(new Sprite2D(ContentService.Instance.Texturas["NegroTorre"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 7, ChessColor.Negras, this);
            x.Center(grid[0, 7].Limites);
            board[0, 7] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["NegroCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 1, ChessColor.Negras, this);
            x.Center(grid[0, 1].Limites);
            board[0, 1] = x;
            x = new PiezaCaballo(new Sprite2D(ContentService.Instance.Texturas["NegroCaballo"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 6, ChessColor.Negras, this);
            x.Center(grid[0, 6].Limites);
            board[0, 6] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["NegroAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 2, ChessColor.Negras, this);
            x.Center(grid[0, 2].Limites);
            board[0, 2] = x;
            x = new PiezaAlfil(new Sprite2D(ContentService.Instance.Texturas["NegroAlfil"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 5, ChessColor.Negras, this);
            x.Center(grid[0, 5].Limites);
            board[0, 5] = x;
            x = new PiezaReina(new Sprite2D(ContentService.Instance.Texturas["NegroReina"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 3, ChessColor.Negras, this);
            x.Center(grid[0, 3].Limites);
            board[0, 3] = x;
            x = new PiezaRey(new Sprite2D(ContentService.Instance.Texturas["NegroRey"], new Rectangle(0, 0, tamañoPieza, tamañoPieza)), 0, 4, ChessColor.Negras, this);
            x.Center(grid[0, 4].Limites);
            board[0, 4] = x;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] == null) continue;
                    board[i, j].AnimacionMarcar = new BotonAnimacion(null, new Rectangle(board[i, j].Limites.Location, new Point(tamañoMarca, tamañoMarca)), null, true);
                    board[i, j].AnimacionDesmcarcar = new BotonAnimacion(null, new Rectangle(board[i, j].Limites.Location, new Point(tamañoPieza, tamañoPieza)), null, true);
                    if (board[i, j].ChessColor == ChessColor.Negras) negras.Add(board[i, j]);
                    else if (board[i, j].ChessColor == ChessColor.Blancas) blancas.Add(board[i, j]);
                    else neutral.Add(board[i, j]);
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null) board[i, j].CalcularMovimientosLegales();
                }
            }
        }

        bool hacerMovimiento = false;


        internal void Update(GameTime gameTime, Entrada curInput, Entrada prevInput)
        {
            switch (Turno)
            {
                case Turno.Jugador1:
                    blancas.Update(curInput, prevInput);
                    ValoresCompartidos.turnoBlancas = true;
                       
                    break;
                case Turno.Neutral:
                    neutral.Update(curInput, prevInput);
                    break;
                case Turno.Jugador2:
                    negras.Update(curInput, prevInput);
                    ValoresCompartidos.turnoBlancas = false;
                    break;
            }

            if (hacerMovimiento)
            {
                blancas.DesmarcarTodos();
                negras.DesmarcarTodos();
                neutral.DesmarcarTodos();


                int contadorPiezasNeutrales = ContarPiezasNeutrales();
                if (contadorPiezasNeutrales > 0)
                    switch (Turno)
                {
                    case Turno.Jugador1:
                           
                            Turno = Turno.Neutral;
                            prevTurn = Turno.Jugador1;
                            ValoresCompartidos.turnoBlancas = true;
                            break;
                    case Turno.Neutral:
                        if (prevTurn == Turno.Jugador2)
                            Turno = Turno.Jugador1;
                        else
                            Turno = Turno.Jugador2;
                        break;
                    case Turno.Jugador2:
                           
                            Turno = Turno.Neutral;
                            prevTurn = Turno.Jugador2;
                            ValoresCompartidos.turnoBlancas = false;
                            break;
                }
                else 
                    switch (Turno)
                    {
                    case Turno.Jugador1:
                          
                            Turno = Turno.Jugador2;
                            ValoresCompartidos.turnoBlancas = true;
                            break;
                    case Turno.Jugador2:
                            
                            Turno = Turno.Jugador1;
                            ValoresCompartidos.turnoBlancas = false;
                            break;
                }
              
                hacerMovimiento = false;
                IncrementarContadorMovimientos();
               
            }
        }  

        internal void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    grid[i, j].Draw(spriteBatch);
                }
            }
            blancas.Draw(spriteBatch);
            negras.Draw(spriteBatch);
            neutral.Draw(spriteBatch);
        }

        public bool IsEmpty(int r, int c)
        {
            return board[r, c] == null;
        }
        
        // Comprueba si el movimiento es legal 
        public bool IsLegalMove(Pieza p, int tR, int tC)
        {
            bool ret = false;
            if (IsEmpty(tR, tC) || board[tR, tC].ChessColor != p.ChessColor || board[tR, tC] == p)
            {
                Pieza temp = board[tR, tC];
                board[tR, tC] = p;
                board[p.Fila, p.Columna] = null;
                ret = true;
                for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (board[i, j] == null) continue;
                        if (board[i, j].ChessColor != p.ChessColor && board[i, j].EsJaque())
                        {
                            ret = false;
                        }
                    }
                }
                board[p.Fila, p.Columna] = p;
                board[tR, tC] = temp;
            }
            return ret;
        }

        public bool EsMovimientoLegal(Pieza p, int tR, int tC, Pieza p2)
        {
            board[p2.Fila, p2.Columna] = null;
            bool ret = IsLegalMove(p, tR, tC);
            board[p2.Fila, p2.Columna] = p2;
            return ret;
        }
        public bool EsJaque(ChessColor color)
        {
            // Encuentra la posición del rey
            int reyFila = -1, reyColumna = -1;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Pieza pieza = board[i, j];
                    if (pieza != null && pieza.ChessColor == color && pieza is PiezaRey)
                    {
                        reyFila = i;
                        reyColumna = j;
                        break;
                    }
                }
                if (reyFila != -1) break;
            }

            // Si no encontramos el rey, algo salió mal
            if (reyFila == -1) return false;

            // Recorre todas las piezas en el tablero
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Pieza pieza = board[i, j];
                    if (pieza != null && pieza.ChessColor != color)
                    {
                        // Calcula los movimientos legales de la pieza
                        pieza.CalcularMovimientosLegales();

                        // Si alguna de las piezas del color opuesto puede moverse a la posición del rey, entonces es jaque
                        if (pieza.legales.Contains(board[reyFila, reyColumna]))
                        {
                            return true;
                        }
                    }
                }
            }

           
            return false;
        }
        public bool JaqueMate()
        {
            // Obtén el color de la última pieza movida
            ChessColor colorUltimaPiezaMovida = UltimaPiezaMovimiento.ChessColor;

            // Recorre todas las piezas en el tablero
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Pieza pieza = board[i, j];
                    if (pieza != null)
                    {

                        if (pieza.ChessColor != colorUltimaPiezaMovida)
                        {

                            pieza.CalcularMovimientosLegales();

                            
                            if (pieza.legales.Count > 0)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            if (colorUltimaPiezaMovida == ChessColor.Blancas)
            {
                ValoresCompartidos.gananBlancas = true;
                ValoresCompartidos.gananNegras = false;
            }
            else if (colorUltimaPiezaMovida == ChessColor.Negras)
            {
                ValoresCompartidos.gananNegras = true;
                ValoresCompartidos.gananBlancas = false;
            }
            else if (colorUltimaPiezaMovida == ChessColor.Neutral)
            {
                ValoresCompartidos.victoria = true;
            }


            return true;
        }

        public bool ReyAhogado()
        {
            // Obtén el color del jugador que tiene el turno actualmente
            ChessColor colorJugadorActual = ValoresCompartidos.turnoBlancas ? ChessColor.Blancas : ChessColor.Negras;

            // Recorre todas las piezas en el tablero
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Pieza pieza = board[i, j];
                    if (pieza != null && pieza.ChessColor == colorJugadorActual)
                    {
                        pieza.CalcularMovimientosLegales();

                        if (pieza.legales.Count > 0)
                        {
                            return false;
                        }
                    }
                }
            }

            // Si no hay movimientos legales y el rey no está en jaque, es un rey ahogado
            if (!EsJaque(colorJugadorActual))
            {
                ValoresCompartidos.tablas = true;
                return true;
            }

            return false;
        }
        public bool EmpatePorMaterialInsuficiente()
        {
            // Contadores para las piezas en el tablero
            int conteoReyes = 0;
            int conteoCaballos = 0;
            int conteoAlfiles = 0;
            int otrasPiezas = 0;

            // Recorre todas las piezas en el tablero
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Pieza pieza = board[i, j];
                    if (pieza != null && pieza.ChessColor != ChessColor.Neutral)
                    {
                        if (pieza is PiezaRey)
                        {
                            conteoReyes++;
                        }
                        else if (pieza is PiezaCaballo)
                        {
                            conteoCaballos++;
                        }
                        else if (pieza is PiezaAlfil)
                        {
                            conteoAlfiles++;
                        }
                        else
                        {
                            otrasPiezas++;
                        }
                    }
                }
            }

            // Verifica si solo quedan los reyes
            if (conteoReyes == 2 && conteoCaballos == 0 && conteoAlfiles == 0 && otrasPiezas == 0)
            {
                ValoresCompartidos.tablas = true;
                return true;
            }

            // Verifica si solo quedan los reyes y un caballo
            if (conteoReyes == 2 && conteoCaballos == 1 && conteoAlfiles == 0 && otrasPiezas == 0)
            {
                ValoresCompartidos.tablas = true;
                return true;
            }

            // Verifica si solo quedan los reyes y un alfil
            if (conteoReyes == 2 && conteoCaballos == 0 && conteoAlfiles == 1 && otrasPiezas == 0)
            {
                ValoresCompartidos.tablas = true;
                return true;
            }

            return false;
        }

        public void Move(Pieza p, int tr, int tc)
        {
            int r = p.Fila;
            int c = p.Columna;
            UltimaPiezaMovimiento = p;
            if (!IsEmpty(tr, tc))
            {
                if (p.ChessColor == ChessColor.Negras)
                {
                    if (board[tr, tc].ChessColor != ChessColor.Negras)
                    {
                        blancas.Remove(board[tr, tc]);
                    }
                }
                else if (p.ChessColor == ChessColor.Blancas)
                {
                    if (board[tr, tc].ChessColor != ChessColor.Blancas)
                    {
                        negras.Remove(board[tr, tc]);
                    }
                } 
            }
            board[tr, tc] = board[r, c];
            board[r, c] = null;
            board[tr, tc].Columna = tc;
            board[tr, tc].Fila = tr;
            if (board[tr, tc].PiezaAjedrez == PiezasAjedrez.Peon && (board[tr, tc].Fila == 0 || board[tr, tc].Fila == 7))
            {
                int col = tc;
                int row = tr;
                if (p.ChessColor == ChessColor.Negras)
                {
                    PiezaReina piece = new PiezaReina(
                        new Sprite2D(
                            ContentService.Instance.Texturas["NegroReina"],
                            new Rectangle(col * Constantes.TAMAÑOCASILLA, row * Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOPIEZA, Constantes.TAMAÑOPIEZA)
                            ), row, col, p.ChessColor, this);
                    negras.Add(piece);
                    negras.Remove(board[row, col]);
                    board[row, col] = piece;
                    piece.AnimacionMarcar = new BotonAnimacion(null, new Rectangle(board[row, col].Limites.Location, new Point(Constantes.PIEZAMARCADATAMAÑO, Constantes.PIEZAMARCADATAMAÑO)), null, true);
                    piece.AnimacionDesmcarcar = new BotonAnimacion(null, new Rectangle(board[row, col].Limites.Location, new Point(Constantes.TAMAÑOPIEZA, Constantes.TAMAÑOPIEZA)), null, true);
                }
                else
                {
                    PiezaReina piece = new PiezaReina(
                        new Sprite2D(
                            ContentService.Instance.Texturas["BlancoReina"],
                            new Rectangle(col * Constantes.TAMAÑOCASILLA, row * Constantes.TAMAÑOCASILLA, Constantes.TAMAÑOPIEZA, Constantes.TAMAÑOPIEZA)
                            ), row, col, p.ChessColor, this);
                    blancas.Add(piece);
                    blancas.Remove(board[row, col]);
                    board[row, col] = piece;
                    piece.AnimacionMarcar = new BotonAnimacion(null, new Rectangle(board[row, col].Limites.Location, new Point(Constantes.PIEZAMARCADATAMAÑO, Constantes.PIEZAMARCADATAMAÑO)), null, true);
                    piece.AnimacionDesmcarcar = new BotonAnimacion(null, new Rectangle(board[row, col].Limites.Location, new Point(Constantes.TAMAÑOPIEZA, Constantes.TAMAÑOPIEZA)), null, true);
                }
            }
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (board[i, j] != null)
                    {
                        board[i, j].CalcularMovimientosLegales();
                    }
                }
            }
            if (JaqueMate())
            {
                GameOverEvent?.Invoke(this, EventArgs.Empty);
            }
            if (ReyAhogado())
            {
                ValoresCompartidos.tablas = true;
                GameOverEvent?.Invoke(this, EventArgs.Empty);
                return;
            }

          
            if (EmpatePorMaterialInsuficiente())
            {
                ValoresCompartidos.tablas = true;
                GameOverEvent?.Invoke(this, EventArgs.Empty);
                return; 
            }

            hacerMovimiento = true;

        }


        public bool InGrid(int r, int c)
        {
            return r >= 0 && r < 8 && c >= 0 && c < 8;
        }

        public Pieza ObtenerPieza(int r, int c)
        {
            return board[r, c];
        }
    }
}
    

