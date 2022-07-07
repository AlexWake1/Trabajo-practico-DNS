namespace TPFINAL
{
    public class DNS
    {
        private string etiqueta;
        private string ip = null;
        private string servicios = null;
        private bool esSuperior = false;
        private bool esHoja = false;
        private ArbolGeneral<DNS> padre;
        private List<ArbolGeneral<DNS>> hijos = new List<ArbolGeneral<DNS>>();

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
        public DNS()//nodo raiz
        {

        }
        public override string ToString()
        {
            //if (this.getIp() != null)
            //{
            //    return etiqueta + " " + ip + " ";
            //}
            //else
            return etiqueta + " ";


            //return " Etiqueta: " + etiqueta + " ip: " + ip + " Servicios: " + servicios + " Es superior: " + esSuperior;
            //if (getEsHoja())
            //    return "Hoja";
            //if (getEsSuperior())
            //    return "superior";
            //else return etiqueta + " ";
        }

        //cuando termine voy a corregir, implementar, arreglar y borrar las propiedades que no use


        //propiedades
        public string getEtiqueta()
        {
            return etiqueta;
        }
        public void setEtiqueta(string nuevaEtiqueta)
        {
            this.etiqueta = nuevaEtiqueta;
        }
        public string getIp()
        {
            return ip;
        }
        public void setIp(string nuevaIP)
        {
            this.ip = nuevaIP;
        }
        public string getServicios()
        {
            return servicios;
        }
        public void setServicios(string listaservicios)
        {
            servicios = listaservicios;
        }
        public bool getEsSuperior()
        {
            return esSuperior;
        }
        public void setEsSuperior(bool x)
        {
            esSuperior = x;
        }
        public bool getEsHoja()
        {
            return esHoja;
        }
        public void setEsHoja(bool x)
        {
            esHoja = x;
        }
        public bool Hoja()
        {
            return hijos.Count == 0;
        }
        public ArbolGeneral<DNS> getPadre()
        {
            return padre;
        }
        public void setPadre(ArbolGeneral<DNS> nuevopadre)
        {
            padre = nuevopadre;
        }
        public List<ArbolGeneral<DNS>> getHijos()
        {
            return hijos;
        }
        public void agregarHijos(ArbolGeneral<DNS> nuevohijo)
        {
            hijos.Add(nuevohijo);
        }

        //propiedades

        //modulo de administración
        public void agregar(ArbolGeneral<DNS> raiz)
        {
            string[] etiquetas = this.etiqueta.Split('.');
            int cont = etiquetas.Length - 1;
            _agregar(raiz, etiquetas, cont, this, raiz);
        }
        private void _agregar(ArbolGeneral<DNS> nuevoarbol, string[] etiquetas, int cont, DNS dnsraiz, ArbolGeneral<DNS> nodoraiz)
        {
            DNS dnsaux = new DNS(etiquetas[cont]);
            dnsaux.setPadre(nuevoarbol);
            //si es la primer etiqueta es de orden superior
            if (cont == etiquetas.Length - 1)
            {
                dnsaux.setEsSuperior(true);
            }
            //si es ultima etiqueta es un nodo hoja
            if (cont == 0)
            {
                dnsaux.setEsHoja(true);
                dnsaux.setIp(dnsraiz.getIp());
                dnsaux.setServicios(dnsraiz.getServicios());
            }
            ArbolGeneral<DNS> arbolaux = new ArbolGeneral<DNS>(dnsaux);

            cont--;

            if (cont >= 0)
            {
                _agregar(arbolaux, etiquetas, cont, dnsraiz, nodoraiz);
            }

            //esta parte es la que no quiere salir
            bool existe = _existe(arbolaux, nuevoarbol);
            nuevoarbol.agregarHijo(arbolaux);

            if (!existe)
            {

            }
            if (existe)
            {
                ArbolGeneral<DNS> arbaux = _buscar(arbolaux, nodoraiz);
                arbaux.getDato().getPadre().agregarHijo(arbolaux);
            }
        }

        public void eliminar(DNS nodo, ArbolGeneral<DNS> nodoraiz)//funciona bien solamente si hay un dns 
        {
            string[] etiqueta = nodo.getEtiqueta().Split('.');
            int cont = etiqueta.Length - 1;
            _eliminar(etiqueta, cont, nodo, nodoraiz);
        }
        private void _eliminar(string[] etiqueta, int cont, DNS dnsraiz, ArbolGeneral<DNS> nodoraiz)
        {

            DNS dnsaux = new DNS(etiqueta[cont]);
            if (cont == etiqueta.Length - 1)
            {
                dnsaux.setEsSuperior(true);
            }
            if (cont == 0)
            {
                dnsaux.setEsHoja(true);
                dnsaux.setIp(dnsraiz.getIp());
                dnsaux.setServicios(dnsraiz.getServicios());
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
                    arbaux.getDato().getPadre().eliminarHijo(arbaux);
                }
            }
        }
        //modulo de administración

        //metodos auxiliares
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
        private bool igual(DNS dato)//hice este método porque estuve teniendo problemas con el .Equals();
        {
            if (this.getEsHoja() && dato.getEsHoja())//si es hoja comparo por ip
            {
                if (this.getIp() == dato.getIp())
                {
                    return true;
                }
                else return false;
            }
            if (this.getEsSuperior() && dato.getEsSuperior())//si es superior comparo por etiqueta
            {
                if (this.getEtiqueta() == dato.getEtiqueta())
                {
                    return true;
                }
                else return false;
            }
            if (this.getEsSuperior() == false && dato.getEsSuperior() == false && this.getEsHoja() == false && dato.getEsHoja() == false)//si no es superior ni hoja
            {
                if (this.getEtiqueta() == dato.getEtiqueta())
                {
                    return true;
                }
                else return false;
            }
            return false;
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
        public void postorden()//es para recorrer los hijos del modulo de consulta punto 2
        {
            // primero los hijos recursivamente
            foreach (var hijo in this.hijos)
                hijo.getDato().postorden();

            // luego procesamos raiz
            if (this.getEsHoja())
            {
                Console.Write(this + " ");
            }
        }
        //metodos auxiliares
    }
}
