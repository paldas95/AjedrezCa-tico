using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace AjedrezCaótico
{
    class BotonPanelMarcable
    {
        private List<BotonOpciones> _panel;

        public BotonPanelMarcable()
        {
            _panel = new List<BotonOpciones>();
        }

        public int GetMarkedIndex()
        {
            for (int i = 0; i < _panel.Count; i++)
            {
                if (_panel[i].Estado == BotonEstadoPosible.Marked)
                {
                    return i;
                }
            }
            return -1;
        }

        public void SetColor(int idx, Color clr)
        {
            _panel[idx].Color = clr;
        }

        public void SetMarked(int idx)
        {
            if (idx >= _panel.Count)
                throw new IndexOutOfRangeException();
            for (int i = 0; i < _panel.Count; i++)
            {
                if (i != idx)
                {
                    _panel[i].Desmarcar();
                }
            }
            _panel[idx].Marcar();
        }

        public void DesmarcarTodos()
        {
            for (int i = 0; i < _panel.Count; i++)
            {
                _panel[i].Desmarcar();
            }
        }

        public Boton GetMarked()
        {
            int idx = GetMarkedIndex();
            if (idx == -1)
            {
                return _panel[0];
            }
            return _panel[idx];
        }

        public void Add(BotonOpciones button)
        {
            _panel.Add(button);
            _panel[_panel.Count - 1].PermitirClickUnMark = false;
        }

        public void Remove(BotonOpciones ob)
        {
            _panel.Remove(ob);
            DesmarcarTodos();
        }

        public BotonOpciones this[int index]
        {
            get
            {
                if (_panel.Count <= index)
                {
                    throw new IndexOutOfRangeException();
                }
                return _panel[index];
            }
            set
            {
                if (_panel.Count >= index)
                {
                    throw new IndexOutOfRangeException();
                }
                _panel[index] = value;
                _panel[index].PermitirClickUnMark = false;
            }
        }

        public int Count
        {
            get
            {
                return _panel.Count;
            }
        }


        public void Update(Entrada current, Entrada previous)
        {
            int marked = -1;
            for (int i = 0; i < _panel.Count; i++)
            {
                BotonOpciones btn = _panel[i];
                BotonEstadoPosible state = btn.Estado;
                btn.Update(current, previous);
                if (btn.Estado != state)
                {
                    marked = i;
                }
            }
            if (marked != -1)
            {
                for (int i = 0; i < _panel.Count; i++)
                {
                    if (i != marked)
                    {
                        _panel[i].Desmarcar();
                    }
                }
            }

        }//Borrado 1 entrada extra

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var btn in _panel)
            {
                btn.Draw(spriteBatch);
            }
        }
    }
}