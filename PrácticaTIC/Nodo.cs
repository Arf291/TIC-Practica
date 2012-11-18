using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrácticaTIC
{
    class Nodo
    {
        private char simbolo;
        private int frecuencia;
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
        public int Frecuencia
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

        public Char Simbolo
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
        public List<bool> Darcodigo(char simbol,List<bool> codigo)
        {
            if (EsHoja())
            {
                if (simbol.Equals(this.Simbolo))
                {
                    return codigo;
                }
                else
                {
                    return null;
                }
            }
            else
            { 
                List <bool> iz=new List<bool>();
                List<bool> der=new List<bool>();
                if(Hijoiz !=null)
                {
                    List<bool> parteiz=new List<bool>();
                    parteiz.AddRange(codigo);
                    parteiz.Add(false);
                    iz=Darcodigo(simbol,parteiz);
                }
                 if(Hijoder !=null)
                {
                    List<bool> parteder=new List<bool>();
                    parteder.AddRange(codigo);
                    parteder.Add(true);
                    der=Darcodigo(simbol,parteder);
                }
                if(iz !=null)
                {
                    return iz;
                }
                else
                {
                    return der;
                }

            
            }
            
        }
        public bool EsHoja()
        {
            return (this.Hijoiz == null && this.Hijoder == null);
        }

    }
}
