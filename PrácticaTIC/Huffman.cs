using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace PrácticaTIC
{

    class Huffman
    {
        public Dictionary<byte,int> frecuencias=new Dictionary<byte,int>();
        public List<Nodo> nodos = new List<Nodo>();
        public Dictionary<byte, List<bool>> cabezera = new Dictionary<byte, List<bool>>();
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


        public void cons_Arbol(List<byte> input)
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
                List<Nodo> nodosor = nodos.OrderBy(nodo => nodo.Frecuencia).ToList<Nodo>();
                if (nodosor.Count >= 2)
                {
                    // Cogemos los dos primeros que serán los dos con menor frecuencia para unirlos
                    List<Nodo> par = nodosor.Take(2).ToList<Nodo>();

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
        public String Codifica(List<byte> contenido)
        {
            String texto = "";
            String  buffer="";
            
            foreach (byte b in contenido)
            {
                if (cabezera.ContainsKey(b))
                {
                    List<bool> cn =cabezera[b];
                    for(int i=0;i<cn.Count;i++)
                    {
                        if (buffer.Length== 8)
                        {

                           
                            // aqui declarar un entero y llamar al método a crear y el entero copiarlo al texto
                            buffer= "";
                        }
                        buffer += cn[i];
                    }
                    //Si salimos del bucle y el buffer es menor que 8 añadir 0 delante para que sean ocho bits
                }
            }
            return texto;
        }


        public void Darcodigo(Nodo raiz, List<bool> codigo)
        {
            if (raiz.EsHoja())
            {

                cabezera.Add(raiz.Simbolo, codigo);
            }
            else
            {
                if (raiz.Hijoiz != null)
                {
                    List<bool> iz = new List<bool>();
                    iz.AddRange(codigo);
                    iz.Add(false);
                    Darcodigo(raiz.Hijoiz,iz);
                }
                if (raiz.Hijoder != null)
                {
                    List<bool> de = new List<bool>();
                    de.AddRange(codigo);
                    de.Add(true);
                    Darcodigo(raiz.Hijoder, de);
                }
            }

        }
        public String copiarcod(List<byte> contenido)
        {
            String cab = "";
            cons_Arbol(contenido);
            Darcodigo(raiz,new List<bool>());
            
           foreach (KeyValuePair<byte, List<bool>> simbolos in cabezera)
            {
                cab +=Convert.ToChar(simbolos.Key)+ ":";
                for (int i = 0; i < simbolos.Value.Count; i++)
                {
                    cab += (simbolos.Value[i]? 1 : 0) + "";
                }
                cab += " ";
            }
            cab += '\n';

            cab += Codifica(contenido);
            return cab;
            
        }
    }
}
