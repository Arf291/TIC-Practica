using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PrácticaTIC
{
    class Huffman
    {
        public Dictionary<char,int> frecuencias=new Dictionary<char,int>();
        public List<Nodo> nodos = new List<Nodo>();
        public Nodo raiz;
        public void darFrecuencias(String input)
        {
           
            for (int i = 0; i < input.Length; i++)
            {
                if (!frecuencias.ContainsKey(input[i]))
                {
                    frecuencias.Add(input[i], 0);
                }

                frecuencias[input[i]]++;
            }
            
        }
        public void cons_Arbol(String input)
        {
            darFrecuencias(input);
            float tam=input.Length;
            foreach (KeyValuePair<char, int> simbolo in frecuencias)
            {
                nodos.Add(new Nodo(simbolo.Key, (simbolo.Value / tam)));
            }
            //Vamos a organizar y ordenar para combinarlos por sus frecuencias hasta que nos queden dos he ir creando el árbol
             while (nodos.Count > 1)
            {
                //Ordenamos ascendentemente cada vez que añadimos uno nuevo reformulado 
                List<Nodo> nodosor = nodos.OrderBy(nodo => nodo.Frecuencia).ToList<Nodo>();
                if (nodosor.Count >= 2)
                {
                    // Cogemos los dos primeros que serán los dos con menor frecuencia para unirlos
                    List<Nodo> par = nodosor.Take(2).ToList<Nodo>();

                    // Creamos al padre como combinación
                    Nodo padre = new Nodo('*', par[0].Frecuencia + par[1].Frecuencia);
                        padre.Hijoiz= par[0];
                        padre.Hijoder=par[1];
                   
                    //Borramos de la lista general los dos nodos unidos y añadimos el padre
                    nodos.Remove(par[0]);
                    nodos.Remove(par[1]);
                    nodos.Add(padre);
                }
                 
             }
             raiz = nodos.FirstOrDefault();

        }
        //Codificar y descodificar
        public String escribir()
        {
            String fre = "";
            foreach (Nodo simbolo in nodos)
            {
               fre+="Valor: " + simbolo.Simbolo + " Frecuencia: " + simbolo.Frecuencia+'\n';
            }
            return fre;
            
        }
    }
}
