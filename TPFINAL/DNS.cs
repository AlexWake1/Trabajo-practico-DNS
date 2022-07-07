namespace TPFINAL
{
    public class DNS
    {
        #region Variables
        private string etiqueta;
        private string ip = null;
        private string servicios = null;
        private bool esSuperior = false;
        private bool esHoja = false;
        private ArbolGeneral<DNS> padre;
        #endregion 

        #region Constructores
        public DNS(string etiqueta, string ip, string servicios)//constructor completo 
        {
            this.etiqueta = etiqueta;
            this.ip = ip;
            this.servicios = servicios;
        }
        public DNS(string etiqueta)//dominio-superior
        {
            this.etiqueta = etiqueta;
        }
        #endregion

        #region Propiedades
        public string Etiqueta
        {
            set { etiqueta = value; }
            get { return etiqueta; }
        }
        public string IP
        {
            set { ip = value; }
            get { return ip; }
        }
        public string Servicios
        {
            set { servicios = value; }
            get { return servicios; }
        }
        public bool EsSuperior
        {
            set { esSuperior = value; }
            get { return esSuperior; }
        }
        public bool EsHoja
        {
            set { esHoja = value; }
            get { return esHoja; }
        }
        public ArbolGeneral<DNS> Padre
        {
            set { padre = value; }
            get { return padre; }
        }
        #endregion

        #region Modulo de administración
        public void Agregar(ArbolGeneral<DNS> raiz)
        {
            string[] etiquetas = this.etiqueta.Split('.');
            int cont = etiquetas.Length - 1;
            _agregar(raiz, etiquetas, cont, this, raiz);
        }
        private void _agregar(ArbolGeneral<DNS> nuevoarbol, string[] etiquetas, int cont, DNS dnsraiz, ArbolGeneral<DNS> nodoraiz)
        {
            DNS dnsaux = new DNS(etiquetas[cont]);
            if (cont == etiquetas.Length - 1)//si es la última etiqueta es de orden superior
            {
                dnsaux.EsSuperior = true;
            }
            if (cont == 0)//si es la primer etiqueta es un nodo hoja
            {
                dnsaux.EsHoja = true;
                dnsaux.IP = dnsraiz.IP;
                dnsaux.Servicios = dnsraiz.Servicios;
            }
            dnsaux.Padre = nuevoarbol;
            ArbolGeneral<DNS> arbolaux = new ArbolGeneral<DNS>(dnsaux);

            cont--;

            bool existe = _existe(arbolaux, nodoraiz);

            if (!existe)
            {
                nuevoarbol.agregarHijo(arbolaux);
            }
            if (existe && cont >= 0)
            {
                ArbolGeneral<DNS> a1 = _buscar(arbolaux, nodoraiz);
                _agregar(a1, etiquetas, cont, dnsraiz, nodoraiz);
            }
            if (cont >= 0)
            {
                _agregar(arbolaux, etiquetas, cont, dnsraiz, nodoraiz);
            }
        }
        public void Eliminar(DNS nodo, ArbolGeneral<DNS> nodoraiz)
        {
            string[] etiqueta = nodo.Etiqueta.Split('.');
            int cont = etiqueta.Length - 1;
            _eliminar(etiqueta, cont, nodo, nodoraiz);
        }
        private void _eliminar(string[] etiqueta, int cont, DNS dnsraiz, ArbolGeneral<DNS> nodoraiz)
        {
            DNS dnsaux = new DNS(etiqueta[cont]);
            if (cont == etiqueta.Length - 1)
            {
                dnsaux.EsSuperior = true;
            }
            if (cont == 0)
            {
                dnsaux.esHoja = true;
                dnsaux.IP = dnsraiz.IP;
                dnsaux.Servicios = dnsraiz.Servicios;
            }
            ArbolGeneral<DNS> arbolaux = new ArbolGeneral<DNS>(dnsaux);
            cont--;

            if (cont >= 0)
            {
                _eliminar(etiqueta, cont, dnsraiz, nodoraiz);
            }

            ArbolGeneral<DNS> arbaux = _buscar(arbolaux, nodoraiz);
            if (arbaux != null)
            {
                if (arbaux.getHijos().Count == 0)
                {
                    arbaux.getDato().Padre.eliminarHijo(arbaux);
                }
            }
        }//funciona bien
        #endregion

        #region Módulo de consulta
        public void punto1(string dominio, ArbolGeneral<DNS> raiz)
        {
            string[] etiquetas = dominio.Split(".");
            int contador = etiquetas.Length - 1;
            _punto1(etiquetas, contador, raiz);
        }
        public void _punto1(string[] dominio, int contador, ArbolGeneral<DNS> raiz)
        {
            foreach (var hijo in raiz.getHijos())
            {
                if (dominio[contador].Equals(hijo.getDato().Etiqueta))
                {
                    if (contador > 0)
                    {
                        contador--;
                        _punto1(dominio, contador, hijo);
                    }
                    if (hijo.esHoja())
                    {
                        DNS Aux = hijo.getDato();
                        Console.WriteLine($"Etiqueta: {Aux.Etiqueta}\nIP: {Aux.IP}\nServicios: {Aux.Servicios}\n");
                        break;
                    }
                }
            }
        }//este punto no funciona del todo bien. se debe al agregado
        public void punto2(string dominio, ArbolGeneral<DNS> raiz)
        {
            string[] etiquetas = dominio.Split(".");
            int contador = etiquetas.Length - 1;
            _punto2(etiquetas, contador, raiz);
        }
        public void _punto2(string[] dominio, int contador, ArbolGeneral<DNS> raiz)
        {
            foreach (var hijo in raiz.getHijos())
            {
                if (dominio[contador].Equals(hijo.getDato().Etiqueta))
                {
                    if (contador > 0)
                    {
                        contador--;
                        _punto2(dominio, contador, hijo);
                    }
                    if (contador == 0)
                    {
                        foreach (var item in hijo.getHijos())
                        {
                            if (item.getDato().EsHoja==true)
                            {
                                DNS Aux = item.getDato();
                                Console.WriteLine($"Etiqueta: {Aux.Etiqueta}\nIP: {Aux.IP}\nServicios: {Aux.Servicios}\n");
                            }
                        }
                    }
                }
            }
        }//funciona bien
        public void punto3(int nivel, ArbolGeneral<DNS> nodoraiz)//funciona bien
        {
            int naux = 1;
            int nsup = 0;//nivel superior
            int nmed = 0;//nivel medio
            int ninf = 0;//nivel inferior
            Cola<ArbolGeneral<DNS>> colaaux = new Cola<ArbolGeneral<DNS>>();
            ArbolGeneral<DNS> arbolAux;

            colaaux.encolar(nodoraiz);
            colaaux.encolar(null);

            while (!colaaux.esVacia())
            {
                arbolAux = colaaux.desencolar();

                if (arbolAux == null)
                {
                    if (!colaaux.esVacia())
                    {
                        naux++;
                        colaaux.encolar(null);
                    }
                }
                else
                {
                    foreach (var hijo in arbolAux.getHijos())
                    {
                        DNS DATOAUX = hijo.getDato();
                        if (naux == nivel)
                        {
                            if (hijo.getDato().Etiqueta != null)
                            {
                                if (hijo.getDato().EsHoja)
                                {
                                    ninf++;
                                }
                                if (!hijo.getDato().EsSuperior && !hijo.getDato().EsHoja)
                                {
                                    nmed++;
                                }
                                if (hijo.getDato().EsSuperior)
                                {
                                    nsup++;
                                }
                            }
                        }
                        colaaux.encolar(hijo);
                    }
                }
            }
            Console.WriteLine($"En en nivel:{nivel}\nNodos de nivel superior:{nsup}\nNodos intermedios:{nmed} \nNodos hojas:{ninf} ");
        }//funciona bien
        #endregion

        #region Métodos auxiliares
        private bool _existe(ArbolGeneral<DNS> dato, ArbolGeneral<DNS> raizgeneral)//devuelve true o false si encuentra el dato en la raiz
        {
            Cola<ArbolGeneral<DNS>> c = new Cola<ArbolGeneral<DNS>>();
            ArbolGeneral<DNS> arbolAux;
            bool existe = false;
            c.encolar(raizgeneral);
            while (!c.esVacia())
            {
                arbolAux = c.desencolar();

                if (dato.getDato().igual(arbolAux.getDato()))
                {
                    existe = true;
                    break;
                }

                foreach (var hijo in arbolAux.getHijos())
                    c.encolar(hijo);
            }
            return existe;
        }
        private ArbolGeneral<DNS> _buscar(ArbolGeneral<DNS> dato, ArbolGeneral<DNS> raizgeneral)//devuelve una referencia a un nodo en la raiz si la encuentra
        {
            Cola<ArbolGeneral<DNS>> c = new Cola<ArbolGeneral<DNS>>();
            ArbolGeneral<DNS> arbolAux;
            bool existe = false;
            c.encolar(raizgeneral);
            while (!c.esVacia())
            {
                arbolAux = c.desencolar();

                if (dato.getDato().igual(arbolAux.getDato()))
                {
                    return arbolAux;
                }

                foreach (var hijo in arbolAux.getHijos())
                    c.encolar(hijo);
            }
            return null;
        }
        private bool igual(DNS dato)//hice este método porque estuve teniendo problemas con el .Equals();
        {   //si es hoja comparo por IP
            if (this.EsHoja && dato.EsHoja)
            {
                if (this.IP == dato.IP)
                {
                    return true;
                }
                else return false;
            }
            //si es superior comparo por etiqueta
            if (this.EsSuperior && dato.EsSuperior)
            {
                if (this.Etiqueta == dato.Etiqueta)
                {
                    return true;
                }
                else return false;
            }
            //si no es superior ni hoja comparo por etiqueta
            if (!this.EsSuperior && !dato.EsSuperior && !this.EsHoja && !dato.EsHoja)
            {
                if (this.Etiqueta == dato.Etiqueta)
                {
                    return true;
                }
                else return false;
            }
            if (this.Equals(dato))
            {
                return true;
            }
            return false;
        }
        public override string ToString()
        {
            return etiqueta + " ";
        }
        #endregion
    }
}
