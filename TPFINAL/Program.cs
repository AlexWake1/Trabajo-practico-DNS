using TPFINAL;

ArbolGeneral<DNS> Nodo_raiz = new ArbolGeneral<DNS>(new DNS("Nodo raiz."));

DNS youtube = new DNS("(www.youtube.com)", "123.221.245.121", "fef");
DNS youtubear = new DNS("(www.youtube.com.ar)", "198.156.1.255", "www");
DNS esyoutube = new DNS("(es.youtube.com)", "16.221.25.21", "4n3");
DNS enyoutube = new DNS("(en.youtube.com)", "13.22.245.221", "4ns");
DNS google = new DNS("(www.google.com)", "153.123.141.123", "asd");
DNS wikipedia = new DNS("(es.wikipedia.org)", "215.231.12.3", "www");

youtube.agregar(Nodo_raiz);
//youtubear.agregar(Nodo_raiz);
esyoutube.agregar(Nodo_raiz);
enyoutube.agregar(Nodo_raiz);
google.agregar(Nodo_raiz);
wikipedia.agregar(Nodo_raiz);

Console.WriteLine("***RECORRIDO POR NIVELES CON SEPARACION***");
Nodo_raiz.porNivelesConSeparacion();
Console.WriteLine("\n\n***RECORRIDO POSTORDEN***");
Nodo_raiz.postorden();
Console.WriteLine("\n\n");



punto1("(www.youtube.com)", Nodo_raiz);
//punto1("(www.youtube.com.ar)", Nodo_raiz);
punto1("(es.youtube.com)", Nodo_raiz);
punto1("(www.google.com)", Nodo_raiz);



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
        if (contador > 0)
        {
            _punto1(dominio, contador--, hijo);
        }
        if (dominio[contador].Equals(hijo.getDato().getEtiqueta()))
        {
            if (hijo.esHoja())
            {
                DNS Aux = hijo.getDato();
                Console.WriteLine("Etiqueta: "+Aux.getEtiqueta()+"\nIP: "+Aux.getIp()+"\nServicios: "+Aux.getServicios());
            }
        }
    }
}
