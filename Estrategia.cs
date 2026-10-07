
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using tp1;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tpfinal
{

	public class Estrategia
	{
		
		public string GetUrlSeoPorId(ArbolGeneral<ItemCat> arbol, int id)
        {
            return BuscarUrlPorIdRecursivo(arbol, "tienda.com", id);
        }

        private string BuscarUrlPorIdRecursivo(ArbolGeneral<ItemCat> nodo, string rutaActual, int idBuscado)
        {
            string nuevaRuta = rutaActual + "/" + nodo.getDatoRaiz().Nombre.ToLower();

            if (nodo.getDatoRaiz().Id == idBuscado)
            {
                return nuevaRuta;
            }

            foreach (var hijo in nodo.getHijos())
            {
                string urlEncontrada = BuscarUrlPorIdRecursivo(hijo, nuevaRuta, idBuscado);
                if (urlEncontrada != null) return urlEncontrada;
            }

            return null;
        }
        

        public List<string> GetURLsSEO(ArbolGeneral<ItemCat> arbol)
		{
			return ["Implementar"];
		}
        

              

        public List<List<string>> ConsultaNiveles(ArbolGeneral<ItemCat> arbol)
		{
            return [["Implementar"]];
        }


        public List<ItemCat> Todos(ArbolGeneral<ItemCat> arbol)
        {
            List<ItemCat> resultado = new List<ItemCat>();

            RecorrerTodos(arbol, resultado); //metodo auxiliar que recorre el arbol y 
            //agrega todo lo que encuentre a la lista

            return  resultado;
        }

        private void RecorrerTodos(ArbolGeneral<ItemCat> arbol, List<ItemCat> resultado)
        {
            resultado.Add(arbol.getDatoRaiz()); //Agregamos el elemento del nodo actual

            foreach(ArbolGeneral<ItemCat> hijo in arbol.getHijos()) //Recorremos los hijos de ese nodo 
            {
                RecorrerTodos(hijo, resultado);
            }

        }

        public void Agregar(ArbolGeneral<ItemCat> arbol, ItemCat dato, string rutaAlPadre)
		{
             string[] segmentos = rutaAlPadre.Split('/');
             int inicio = 0;
             if (segmentos.Length > 0)
             {
            	if (segmentos[0].Equals(arbol.getDatoRaiz().Nombre))
                {
					inicio = 1;
				}
             }  //vemos cantidad de segmentos
			ArbolGeneral<ItemCat> actual = arbol;

			for(int i = inicio; i < segmentos.Length; i++) //si cantidad de segmentos > valor de inicio, recorre
            {
				ArbolGeneral<ItemCat> siguiente = null;   //auxiliar

			foreach (ArbolGeneral<ItemCat> hijo in actual.getHijos())
            {
				if (hijo.getDatoRaiz().Nombre.Equals(segmentos[i]))
                {
					siguiente = hijo;
					break;
				}
			}
			if (siguiente == null)   //si siguiente no cuenta con dato, crea un nuevo Arbol
            {
				siguiente = new ArbolGeneral<ItemCat>(new ItemCat(segmentos[i], TipoElemento.Categoria));
				actual.agregarHijo(siguiente);
			}

			actual = siguiente;
		 }
          actual.agregarHijo(new ArbolGeneral<ItemCat>(dato));
			
		}

        public List<ItemCat> Buscar(ArbolGeneral<ItemCat> arbol, string elementoABuscar)
		{
            List<ItemCat> resultado = new List<ItemCat>();

            BuscarRecursivo(arbol, elementoABuscar, resultado); //metodo auxiliar

			return resultado;
		}

        private void BuscarRecursivo(ArbolGeneral<ItemCat> arbol, string elementoABuscar, List<ItemCat> resultado)
        {
            if(arbol.getDatoRaiz().Nombre.Contains(elementoABuscar))
            {
                resultado.Add(arbol.getDatoRaiz());
            }

        foreach (ArbolGeneral<ItemCat> hijo in arbol.getHijos())
           {
            BuscarRecursivo(hijo, elementoABuscar, resultado);
           }   

        }
            
    }
}
