namespace TPFINAL
{
    public class DNS
    {
        private string etiqueta;
        private string ip;
        private string servicios;
        private bool esSuperior = false;
        private bool esHoja = false;
        private ArbolGeneral<DNS> padre;
        private List<ArbolGeneral<DNS>> hijos;

        public DNS(string etiqueta, string ip, string servicios)
        {
            this.etiqueta = etiqueta;
            this.ip = ip;
            this.servicios = servicios;
        }//constructor completo
        public DNS(string etiqueta)
        {
            this.etiqueta = etiqueta;
        }//dominio-superior
        public DNS()
        {

        }//nodo raiz
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


        //propiedades-- cuando termine voy a corregir y borrar las propiedades que no use

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

        //metodos
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
            //si es la primer etiqueta
            if (cont == etiquetas.Length - 1)
            {
                dnsaux.setEsSuperior(true);
            }
            //si es ultima etiqueta
            if (cont == 0)
            {
                dnsaux.setEsHoja(true);
                dnsaux.setIp(dnsraiz.getIp());
                dnsaux.setServicios(dnsraiz.getServicios());
            }
            cont--;

            ArbolGeneral<DNS> arbolaux = new ArbolGeneral<DNS>(dnsaux);

            //si no existe la etiqueta la agrego
            bool existe = _existe(arbolaux, nuevoarbol);

            nuevoarbol.agregarHijo(arbolaux);

            if (!existe)
            {
            }
            if (existe)
            {
            }
            if (cont >= 0)
            {
                _agregar(arbolaux, etiquetas, cont, dnsraiz, nodoraiz);
            }
        }
        private bool _existe(ArbolGeneral<DNS> dato, ArbolGeneral<DNS> raizgeneral)
        {
            Cola<ArbolGeneral<DNS>> c = new Cola<ArbolGeneral<DNS>>();
            ArbolGeneral<DNS> arbolAux;
            bool existe = false;
            c.encolar(raizgeneral);
            while (!c.esVacia())
            {
                arbolAux = c.desencolar();
                if (arbolAux.getDato().igual(dato.getDato()))
                {
                    existe = true;
                    break;
                }
                foreach (var hijo in arbolAux.getHijos())
                    c.encolar(hijo);
            }
            return existe;
        }
        private ArbolGeneral<DNS> _buscar(ArbolGeneral<DNS> dato, ArbolGeneral<DNS> raizgeneral)
        {
            Cola<ArbolGeneral<DNS>> c = new Cola<ArbolGeneral<DNS>>();
            ArbolGeneral<DNS> arbolAux;
            bool existe = false;
            c.encolar(raizgeneral);
            while (!c.esVacia())
            {
                arbolAux = c.desencolar();
                if (arbolAux.getDato().igual(dato.getDato()))
                {
                    Console.WriteLine(arbolAux.getDato());
                    return arbolAux;
                }
                foreach (var hijo in arbolAux.getHijos())
                    c.encolar(hijo);
            }
            return null;
        }
        private bool igual(DNS dato)
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
            else
            {
                if (this.getEtiqueta() == dato.getEtiqueta())// si no es superior comparo por etiqueta
                {
                    return true;
                }
                else return false;
            }
            return false;
        }
        //metodos

        //modulo consulta

        public void punto1(string dominio, ArbolGeneral<DNS> raiz)
        {
            string[] etiquetas = dominio.Split(".");
            int contador = etiquetas.Length-1;
            _punto1(dominio,contador, raiz);
        }

        private void _punto1(string dominio,int contador, ArbolGeneral<DNS>raiz)
        {
            contador--;
            // primero los hijos recursivamente
            foreach (var hijo in raiz.getHijos())
            {
                if (dominio[contador].Equals(hijo.getDato().getEtiqueta()))
                {
                    _punto1(dominio, contador, raiz);
                    Console.WriteLine(hijo.getDato().getEtiqueta());
                }
            }
        }


        //public void postorden()
        //{
        //    // primero los hijos recursivamente
        //    foreach (var hijo in this.hijos)
        //        hijo.postorden();

        //    // luego procesamos raiz
        //    Console.Write(this.dato + " ");
        //}
        //modulo consulta

    }
}
