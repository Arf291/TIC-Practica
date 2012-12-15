using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PrácticaTIC
{

    class Huffman
    {
        public Dictionary<string,int> frecuencias=new Dictionary<string,int>();
        public List<Nodo> nodos = new List<Nodo>();
        public Dictionary<string, List<int>> cabecera = new Dictionary<string, List<int>>();
        public Nodo raiz;

        public void darFrecuencias(List<byte> input)
        {
           
            for (int i = 0; i < input.Count; i++)
            {
                if (!frecuencias.ContainsKey(Convert.ToChar(input[i]).ToString()))
                {
                    frecuencias.Add(Convert.ToChar(input[i]).ToString(), 0);
                }

                frecuencias[Convert.ToChar(input[i]).ToString()]++;
            }
            frecuencias.Add("EOF", 0);
   
            
        }


        public void crearArbol(List<byte> input)
        {
            darFrecuencias(input);
            float tam = input.Count;
            foreach (KeyValuePair<string, int> simbolo in frecuencias)
            {
                nodos.Add(new Nodo(simbolo.Key, (simbolo.Value / tam)));
            }
            
            int tami=nodos.Count;
            //Vamos a organizar y ordenar para combinarlos por sus frecuencias hasta que nos queden dos e ir creando el árbol
             while (nodos.Count > 1)
            {
                //Ordenamos ascendentemente cada vez que añadimos uno nuevo reformulado 
                List<Nodo> ordenados = nodos.OrderBy(nodo => nodo.Frecuencia).ToList<Nodo>();
                if (ordenados.Count >= 2)
                {
                    // Cogemos los dos primeros que serán los dos con menor frecuencia para unirlos
                    List<Nodo> par = ordenados.Take(2).ToList<Nodo>();

                    // Creamos al padre como combinación
                    Nodo padre = new Nodo("0", par[0].Frecuencia + par[1].Frecuencia);
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

        public void darCodigo(Nodo raiz, List<int> codigo)
        {
            if (raiz.esHoja())
            {
                cabecera.Add(raiz.Simbolo, codigo);
            }
            else
            {
                if (raiz.Hijoiz != null)
                {
                    List<int> iz = new List<int>();
                    iz.AddRange(codigo);
                    iz.Add(0);
                    darCodigo(raiz.Hijoiz, iz);
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

        //Codificar
        public string codifica(List<byte> contenido)
        {
            String texto = "";
            String  buffer="";
            byte[] byteSA;
            List<byte> bytes=new List<byte>();
            foreach (byte b in contenido)
            {
                if (cabecera.ContainsKey(Convert.ToChar(b).ToString()))
                {                  
                    List<int> cn =cabecera[Convert.ToChar(b).ToString()];
                    for(int i=0;i<cn.Count;i++)
                    {
                        buffer += cn[i];                        
                        if (buffer.Length == 8)
                        {

                            texto+=Convert.ToChar(binarioADecimal(buffer));                        
                            buffer= "";            
                        }                        
                    }                    
                }
            }            
            buffer += listaAString(cabecera["EOF"]);
            
            if (buffer.Length < 8)
            {               
                while (buffer.Length < 8)
                    buffer += "0";               
            }
            texto+=Convert.ToChar(binarioADecimal(buffer));                        
            buffer= "";
            //MessageBox.Show(texto);
            return texto;
        }



        public string  copiarCodigo(List<byte> contenido)
        {
            String cab = "";
            crearArbol(contenido);
            darCodigo(raiz,new List<int>());
            int tam = 0;
           foreach (KeyValuePair<string, List<int>> simbolos in cabecera)
           {
                cab+=simbolos.Key+"-:";
                cab += listaAString(simbolos.Value);
                tam++;
               
                cab += " ";
               
            }
            cab += "\n--c\n";

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
           
            while (bin.Length < 8)            
                bin += "0";            

            return invertir(bin);
        }

        public string invertir(string s)
        {
            string inversa = "";

            for (int i = s.Length - 1; i >= 0; i--)
            {
                inversa += s[i];
            }
            //MessageBox.Show(inversa);
            return inversa;
        }

        public string listaAString(List<int> lista)
        {
            string cad = "";

            foreach(int i in lista)
            {
                cad += i;
            }

            return cad;
        }

        public List<int> stringALista(string s)
        {
            List<int> lista=new List<int>();

            foreach(char c in s)
            {
                lista.Add(int.Parse(c.ToString()));
            }
          
            return lista;
        }

        public int getCabecera(List<Byte> contenido)
        {
            string tem = "";
            int cont = 0;
            bool fin = false;

            while(!fin)
            {
                if(contenido[cont]=='-' && contenido[cont+1]==':')
                {
                    cont=cont+2;
                    String simbol=tem;
                    
                    tem="";
                    
                    while (contenido[cont] != ' ' && contenido[cont] != '\n')
                    {
                            tem += Convert.ToChar(contenido[cont]);
                            cont++;                            
                    }                   
                    cabecera.Add(simbol,stringALista(tem));                   
                    cont++;
                    tem="";                                       
                }
                else if (contenido[cont] == '-' && contenido[cont+1] == '-' && contenido[cont + 2] == 'c' && contenido[cont + 3]=='\n' )
                {
                    cont = cont + 4;
                    //MessageBox.Show("Termina");
                    string aux = "";
                    for (int i = cont-1; i < contenido.Count(); i++)
                        aux += contenido[i];
                    //MessageBox.Show(aux);
                    fin = true;
                   
                }
                else
                {
                    tem += Convert.ToChar(contenido[cont]);                    
                    cont++;
                }
               
            }

            //MessageBox.Show(cabecera.Count()+"");
            return cont;
        }
        
        public string descodificar(List<Byte> contenido, int indice)
        {

            string texto = "";
            string codigos = "";
            string temp="";
            bool salir = false;
            string aux = "";
            string ti = "";
            for (int i = indice; i < contenido.Count(); i++)
            {
                //MessageBox.Show();
                aux=decimalABinario(contenido[i].ToString());
                codigos += aux;                                
            }
           
            for (int i = 0; i < codigos.Length && !salir; i ++)
            {
                //MessageBox.Show(codigos[i]+"");
                temp+=codigos[i];
               
                foreach (KeyValuePair<string, List<int>> simbolo in cabecera)
                {                    
                    if (listaAString(simbolo.Value) == temp)
                    {
                        //MessageBox.Show(temp);

                        if (temp == listaAString(cabecera["EOF"]))
                        {
                            MessageBox.Show("entro");
                            salir = true;
                            break;
                        }

                        texto += simbolo.Key;
                        //MessageBox.Show("Texto: "+texto);
                        temp = "";                        
                    }
                }
                
            }
            return texto;
        }
    }
}
