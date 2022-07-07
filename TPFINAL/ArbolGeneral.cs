namespace TPFINAL
{
    public class ArbolGeneral<T>
    {
        private List<ArbolGeneral<T>> hijos = new List<ArbolGeneral<T>>();
        private T dato;
        public ArbolGeneral(T dato)
        {
            this.dato = dato;
        }
        public T getDato()
        {
            return dato;
        }
        public List<ArbolGeneral<T>> getHijos()
        {
            return hijos;
        }
        public void agregarHijo(ArbolGeneral<T> hijo)
        {
            this.getHijos().Add(hijo);
        }
        public void eliminarHijo(ArbolGeneral<T> hijo)
        {
            this.getHijos().Remove(hijo);
        }
        public bool esHoja()
        {
            return this.getHijos().Count == 0;
        }
        public int altura()
        {
            if (this.esHoja())
                return 0;
            else
            {
                int maxAltura = 0;
                foreach (var hijo in this.hijos)
                    if (hijo.altura() > maxAltura)
                        maxAltura = hijo.altura();

                return maxAltura + 1;
            }
        }
        public int nivel(T dato)
        {
            int nivel = 0;
            if (this.dato.Equals(dato))
            {
                return 0;
            }
            else
            {
                Cola<ArbolGeneral<T>> colaaux = new Cola<ArbolGeneral<T>>();
                ArbolGeneral<T> arbolAux;

                colaaux.encolar(this);
                colaaux.encolar(null);

                while (!colaaux.esVacia())
                {
                    arbolAux = colaaux.desencolar();

                    if (arbolAux == null)
                    {
                        if (!colaaux.esVacia())
                        {
                            nivel++;
                            colaaux.encolar(null);
                        }
                    }
                    else
                    {
                        foreach (var hijo in arbolAux.hijos)
                        {
                            if (hijo.dato.Equals(dato))
                            {
                                return nivel + 1;
                            }
                            colaaux.encolar(hijo);
                        }
                    }
                }
            }
            return nivel;
        }
        public int ancho()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;

            int nivel = 0;
            int nodosxnivel = 0;
            int nodosxnivelmax = 0;
            c.encolar(this);
            c.encolar(null);

            while (!c.esVacia())
            {
                arbolAux = c.desencolar();

                if (arbolAux == null)
                {
                    if (!c.esVacia())
                    {
                        nodosxnivel = 0;
                        nivel++;
                        c.encolar(null);
                    }
                }
                else
                {
                    foreach (var hijo in arbolAux.hijos)
                    {
                        nodosxnivel++;
                        c.encolar(hijo);
                    }
                }
                if (nodosxnivel > nodosxnivelmax)
                {
                    nodosxnivelmax = nodosxnivel;
                }
            }
            return nodosxnivelmax;
        }
        public void preorden()
        {
            // primero procesamos raiz
            Console.Write(this.dato + " ");

            // luego los hijos recursivamente
            foreach (var hijo in this.hijos)
                hijo.preorden();
        }
        public void postorden()
        {
            // primero los hijos recursivamente
            foreach (var hijo in this.hijos)
                hijo.postorden();

            // luego procesamos raiz
            Console.Write(this.dato + " ");
        }
        public void inorden()
        {
            // primero hijo izquierdo recursivamente
            if (!this.esHoja())
                this.hijos[0].inorden();

            // luego raiz (caso base)
            Console.Write(this.dato + " ");

            // por ultimo, los restantes hijos recursivamente
            for (int i = 1; i <= this.hijos.Count - 1; i++)
                this.hijos[i].inorden();
        }
        public void porNiveles()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;

            c.encolar(this);
            while (!c.esVacia())
            {
                arbolAux = c.desencolar();

                Console.Write(arbolAux.dato + " ");

                foreach (var hijo in arbolAux.hijos)
                    c.encolar(hijo);
            }
        }
        public void porNivelesConSeparacion()
        {
            Cola<ArbolGeneral<T>> c = new Cola<ArbolGeneral<T>>();
            ArbolGeneral<T> arbolAux;

            int nivel = 0;

            c.encolar(this);
            c.encolar(null);

            Console.Write("Nivel " + nivel + ": ");

            while (!c.esVacia())
            {
                arbolAux = c.desencolar();

                if (arbolAux == null)
                {
                    if (!c.esVacia())
                    {
                        nivel++;
                        Console.Write("\nNivel " + nivel + ": ");
                        c.encolar(null);
                    }
                }
                else
                {
                    Console.Write(arbolAux.dato + " ");

                    foreach (var hijo in arbolAux.hijos)
                        c.encolar(hijo);
                }
            }
        }
    }
}
