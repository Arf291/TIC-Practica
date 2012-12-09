using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace PrácticaTIC
{

    class Huffman
    {
        public Dictionary<byte,int> frecuencias=new Dictionary<byte,int>();
        public List<Nodo> nodos = new List<Nodo>();
        public Dictionary<byte, List<int>> cabezera = new Dictionary<byte, List<int>>();
        public Nodo raiz;

        public void darFrecuencias(List<byte> input)
        {
           
            for (int i = 0; i < input.Count; i++)
            {
                if (!frecuencias.ContainsKey(input[i]))
                {
                    frecuencias.Add(input[i], 0);
                }

                frecuencias[input[i]]++;
            }
            
        }


        public void crearArbol(List<byte> input)
        {
            darFrecuencias(input);
            float tam = input.Count;
            foreach (KeyValuePair<byte, int> simbolo in frecuencias)
            {
                nodos.Add(new Nodo(simbolo.Key, (simbolo.Value / tam)));
            }
            
            int tami=nodos.Count;
            //Vamos a organizar y ordenar para combinarlos por sus frecuencias hasta que nos queden dos he ir creando el árbol
             while (nodos.Count > 1)
            {
                //Ordenamos ascendentemente cada vez que añadimos uno nuevo reformulado 
                List<Nodo> ordenados = nodos.OrderBy(nodo => nodo.Frecuencia).ToList<Nodo>();
                if (ordenados.Count >= 2)
                {
                    // Cogemos los dos primeros que serán los dos con menor frecuencia para unirlos
                    List<Nodo> par = ordenados.Take(2).ToList<Nodo>();

                    // Creamos al padre como combinación
                    Nodo padre = new Nodo(0, par[0].Frecuencia + par[1].Frecuencia);
                        padre.Hijoiz= par[0];
                        padre.Hijoder=par[1];
                   
                    //Borramos de la lista general los dos nodos unidos y añadimos el padre
                    nodos.Remove(par[0]);
                    nodos.Remove(par[1]);
                    nodos.Add(padre);
                }
                 
             }
             raiz = nodos[0];

        }

        //Codificar y descodificar
        public String codifica(List<byte> contenido)
        {
            String texto = "";
            String  buffer="";
            String aux = "";
                                   
            foreach (byte b in contenido)
            {
                if (cabezera.ContainsKey(b))
                {                    
                    List<int> cn =cabezera[b];
                    for(int i=0;i<cn.Count;i++)
                    {
                        buffer += cn[i];                        
                        if (buffer.Length == 8)
                        {                           
                            // aqui declarar un entero y llamar al método a crear y el entero copiarlo al texto                          
                            texto += Convert.ToChar(binarioADecimal(buffer));
                            buffer= "";            
                        }                        
                    }                    
                }
            }

            //Si salimos del bucle y el buffer es menor que 8 añadir 0 delante para que sean ocho bits
            if (buffer.Length < 8)
            {
                for (int i = 0; i < buffer.Length; i++)
                    aux += "0";

                texto += Convert.ToChar(binarioADecimal(buffer));
                buffer = "";
            }

            //MessageBox.Show(texto);
            return texto;
        }


        public void darCodigo(Nodo raiz, List<int> codigo)
        {
            if (raiz.esHoja())
            {
                cabezera.Add(raiz.Simbolo, codigo);
            }
            else
            {
                if (raiz.Hijoiz != null)
                {
                    List<int> iz = new List<int>();
                    iz.AddRange(codigo);
                    iz.Add(0);
                    darCodigo(raiz.Hijoiz,iz);
                }
                if (raiz.Hijoder != null)
                {
                    List<int> de = new List<int>();
                    de.AddRange(codigo);
                    de.Add(1);
                    darCodigo(raiz.Hijoder, de);
                }
            }

        }
        public String copiarCodigo(List<byte> contenido)
        {
            String cab = "";
            crearArbol(contenido);
            darCodigo(raiz,new List<int>());
            
           foreach (KeyValuePair<byte, List<int>> simbolos in cabezera)
           {
                cab +=Convert.ToChar(simbolos.Key)+ "-:";
                cab += aString(simbolos.Value);

                cab += " ";
            }
            cab += "\n--content--\n";

            cab += codifica(contenido);
            return cab;
            
        }

        public int binarioADecimal(string entrada)
        {
            int dec = 0;
            int tam = entrada.Length;

            for (int i = 0; i < entrada.Length; i++)
            {
                if(entrada[i]=='1')
                    dec += (int)Math.Pow(2, tam-1);                               
                tam--;
            }

            return dec;
        }

        public string decimalABinario(string entrada)
        {
            string bin = "";
            int dec = int.Parse(entrada);
            int resto = 0;

            while (dec > 0)
            {
                resto = dec % 2;
                dec /= 2;
                bin += resto;
            }

            return invertir(bin);
        }

        public string invertir(string s)
        {
            string inversa = "";

            for (int i = s.Length-1; i >= 0; i--)
                inversa += s[i];

            return inversa;
        }

        public string aString(List<int> lista)
        {
            string cad = "";

            foreach(int i in lista)
            {
                cad += i;
            }

            return cad;
        }

        public void getCabecera(string[] contenido)
        {
            string s = "", temp = "";
            string[] pares;

            for(int i=0; s!="--content--"; i++)
            {
                s=contenido[i];
                pares = s.Split(' ');

                for (int j = 0; j < pares.Count(); j++)
                {
                    temp = pares[j];
                    MessageBox.Show(temp);
                    /*if (temp[0] == '-')
                    {
                        //MessageBox.Show(temp[0]+"");
                        //temp = " " + temp;
                        MessageBox.Show(temp[0]+"");
                    }*/
                }
            }
        }
    }
}
