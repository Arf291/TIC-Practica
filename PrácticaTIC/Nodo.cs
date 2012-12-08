using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrácticaTIC
{
    class Nodo
    {
        private byte simbolo;
        private float frecuencia;
        private Nodo hijoder;
        private Nodo hijoiz;

        public Nodo Hijoder
        {
            get
            {
                return hijoder;
            }
            set
            {
                hijoder=value;
            }
        }
        public Nodo Hijoiz
        {
            get
            {
                return hijoiz;
            }
            set
            {
                hijoiz = value;
            }
        }
        public float Frecuencia
        {
            get
            {
                return frecuencia;
            }
            set
            {
                frecuencia = value;
            }
        }

        public Byte Simbolo
        {
            get 
            {
                return simbolo;
            }
            set
            {
                simbolo = value;
            }
        }
        public Nodo(byte sim, float fre)
        {
            simbolo = sim;
            frecuencia = fre;
        }

        public bool esHoja()
        {
            return (this.Hijoiz == null && this.Hijoder == null);
        }

    }
}
