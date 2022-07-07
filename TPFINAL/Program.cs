using TPFINAL;

DNS DNS_raiz = new DNS("Nodo raiz");
ArbolGeneral<DNS> Nodo_raiz = new ArbolGeneral<DNS>(DNS_raiz);

DNS youtube = new DNS("www.youtube.com", "123.221.245.121", "web");
DNS youtubear = new DNS("www.youtube.com.ar", "198.156.1.255", "web");
DNS esyoutube = new DNS("es.youtube.com", "16.221.25.21", "web");
DNS enyoutube = new DNS("en.youtube.com", "13.22.245.221", "web");
DNS google = new DNS("www.google.com", "153.123.141.123", "web");
DNS wikipedia = new DNS("es.wikipedia.org", "215.231.12.3", "web");
DNS gob = new DNS("www.argentina.gob.ar", "198.156.1.255", "web");

youtube.Agregar(Nodo_raiz);
esyoutube.Agregar(Nodo_raiz);
enyoutube.Agregar(Nodo_raiz);
google.Agregar(Nodo_raiz);
wikipedia.Agregar(Nodo_raiz);

Console.WriteLine("             ***RECORRIDO POR NIVELES CON SEPARACION***");
Nodo_raiz.porNivelesConSeparacion();
Console.WriteLine("\n\n                 ***RECORRIDO POR NIVELES***");
Nodo_raiz.porNiveles();
Console.WriteLine("\n\n                 ***RECORRIDO POSTORDEN***");
Nodo_raiz.postorden();
Console.WriteLine("\n\n                 ***RECORRIDO PREORDEN***");
Nodo_raiz.preorden();
Console.WriteLine("\n\n                 ***RECORRIDO INORDEN***");
Nodo_raiz.inorden();
Console.WriteLine("\n\n");

Console.WriteLine("Punto 1: \n");
DNS_raiz.punto1("www.youtube.com", Nodo_raiz);
DNS_raiz.punto1("es.youtube.com", Nodo_raiz);
DNS_raiz.punto1("en.youtube.com", Nodo_raiz);
DNS_raiz.punto1("es.wikipedia.org", Nodo_raiz);

Console.WriteLine("Punto 2: \n");
DNS_raiz.punto2("youtube.com", Nodo_raiz);
DNS_raiz.punto2("google.com", Nodo_raiz);
