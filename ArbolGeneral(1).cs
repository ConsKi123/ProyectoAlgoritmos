using System;
using System.Collections.Generic;

namespace Nuevo
{
	public class ArbolGeneral<T>
	{
		
		private T dato;
		private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();

		public ArbolGeneral(T dato) {
			this.dato = dato;
		}
	
		public T getDatoRaiz() {
			return this.dato;
		}
	
		public List<ArbolGeneral<T>> getHijos() {
			return hijos;
		}
	
		public void agregarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Add(hijo);
		}
	
		public void eliminarHijo(ArbolGeneral<T> hijo) {
			this.getHijos().Remove(hijo);
		}
	
		public bool esHoja() {
			return this.getHijos().Count == 0;
		}
	
		public int altura() {
			if (this.esHoja()){
				return 0;
				}
			int mayor = 0;
			foreach(ArbolGeneral<t> hijo in this.getHijos()){
				int alturaHijos = hijo.altura();
				if(alturaHijo > mayor){
					mayor = alturaHijo;
				}
			}
			return mayor+1;
		}
	
		
		public int nivel(T dato) {
			if(((Icomparable)this.dato).CompareTo(dato)==0){
				return;
			}
			foreach(ArbolGeneral<T>hijo in this.getHijos()){
				int nivelhijo = hijonivel(dato);
				if (nivelHijo !=-1){
					return nivelhijo+1;
				}
			}
			return-1;
		}
	
	}
}
