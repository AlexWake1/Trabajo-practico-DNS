using TPFINAL;

ArbolGeneral<DNS> Nodo_raiz = new ArbolGeneral<DNS>(new DNS("Nodo raiz"));

DNS youtube = new DNS("(www.youtube.com)", "123.221.245.121", "1");
DNS youtubear = new DNS("(www.youtube.com.ar)", "198.156.1.255", "2");
DNS esyoutube = new DNS("(es.youtube.com)", "16.221.25.21", "3");
DNS enyoutube = new DNS("(en.youtube.com)", "13.22.245.221", "4");
DNS google = new DNS("(www.google.com)", "153.123.141.123", "5");
DNS wikipedia = new DNS("(es.wikipedia.org)", "215.231.12.3", "6");

youtube.agregar(Nodo_raiz);
youtubear.agregar(Nodo_raiz);
esyoutube.agregar(Nodo_raiz);
enyoutube.agregar(Nodo_raiz);
google.agregar(Nodo_raiz);
wikipedia.agregar(Nodo_raiz);

//youtubear.eliminar(youtubear, Nodo_raiz);


Console.WriteLine("***RECORRIDO POR NIVELES CON SEPARACION***");
Nodo_raiz.porNivelesConSeparacion();
Console.WriteLine("\n\n***RECORRIDO POSTORDEN***");
Nodo_raiz.postorden();
Console.WriteLine("\n\n");

//punto1("(www.youtube.com)", Nodo_raiz);
//punto1("(www.youtube.com.ar)", Nodo_raiz);
//punto1("(es.youtube.com)", Nodo_raiz);
//punto1("(www.google.com)", Nodo_raiz);

//punto2("(youtube.com)", Nodo_raiz);
//punto2("(youtube.com.ar)", Nodo_raiz);
//punto2("(youtube.com)", Nodo_raiz);
//punto2("(google.com)", Nodo_raiz);

//punto3(1, Nodo_raiz);


//modulo consulta
void punto1(string dominio, ArbolGeneral<DNS> raiz)
{
    string[] etiquetas = dominio.Split(".");
    int contador = etiquetas.Length - 1;
    _punto1(etiquetas, contador, raiz);
}
void _punto1(string[] dominio, int contador, ArbolGeneral<DNS> raiz)
{
    foreach (var hijo in raiz.getHijos())
    {
        if (dominio[contador].Equals(hijo.getDato().getEtiqueta()))
        {
            if (contador >= 0)
            {
                contador--;
                _punto1(dominio, contador, hijo);
            }
        }
        if (hijo.esHoja())
        {
            DNS Aux = hijo.getDato();
            Console.WriteLine("Etiqueta: " + Aux.getEtiqueta() + "\nIP: " + Aux.getIp() + "\nServicios: " + Aux.getServicios());
        }
    }
}//este punto no funciona del todo bien. creo que se debe al agregado

void punto2(string dominio, ArbolGeneral<DNS> raiz)
{
    string[] etiquetas = dominio.Split(".");
    int contador = etiquetas.Length - 1;
    _punto2(etiquetas, contador, raiz);
}
void _punto2(string[] dominio, int contador, ArbolGeneral<DNS> raiz)
{
    foreach (var hijo in raiz.getHijos())
    {
        if (dominio[contador].Equals(hijo.getDato().getEtiqueta()))
        {
            if (contador >= 0)
            {
                contador--;
                _punto1(dominio, contador, hijo);
            }
        }
        if (contador == 0)//acá estoy teniendo problemas con la condicion para comparar y la implementacion no la tengo clara
        {
            hijo.getDato().getPadre().getDato().postorden();
        }
    }
}

void punto3(int nivel, ArbolGeneral<DNS> nodoraiz)
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
                    if (hijo.getDato().getEtiqueta() != null)
                    {
                        if (hijo.getDato().getEsHoja())
                        {
                            ninf++;
                        }
                        if (hijo.getDato().getEsSuperior()==false && hijo.getDato().getEsHoja()== false)
                        {
                            nmed++;
                        }
                        if (hijo.getDato().getEsSuperior())
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

//modulo consulta