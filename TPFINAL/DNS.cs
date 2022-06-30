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
        }
        public DNS(string etiqueta)
        {
            this.etiqueta = etiqueta;
        }
        public DNS()
        {

        }
        public override string ToString()
        {
            return etiqueta + " ";
            //return " Etiqueta: " + etiqueta + " ip: " + ip + " Servicios: " + servicios + " Es superior: " + esSuperior;
        }


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
            dnsaux.setEsSuperior(true);
            //si es ultima etiqueta
            if (cont == 0)
            {
                dnsaux.setEsSuperior(false);
                dnsaux.setEsHoja(true);
                dnsaux.setIp(dnsraiz.getIp());
                dnsaux.setServicios(dnsraiz.getServicios());
            }
            cont--;

            ArbolGeneral<DNS> arbolaux = new ArbolGeneral<DNS>(dnsaux);

            //si no existe la etiqueta la agrego
            bool existe = _existe(arbolaux, nodoraiz);
            if (!existe)
            {
                nuevoarbol.agregarHijo(arbolaux);
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

        public bool igual(DNS dato)
        {
            if (this.getIp != null && dato.getIp() != null)
            {
                if (this.getIp() == dato.getIp() && this.getEtiqueta() == dato.getEtiqueta())
                {
                    return true;
                }
                else return false;
            }
            if (this.getIp == null || dato.getIp() == null)
            {
                if (this.getEtiqueta() == dato.getEtiqueta())
                {
                    return true;
                }
                else return false;
            }
            return false;
        }

        //metodos
    }
}
