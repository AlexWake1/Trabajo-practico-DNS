using TPFINAL;

#region Estructura del árbol

DNS DNS_raiz = new DNS("Nodo raiz");
ArbolGeneral<DNS> Nodo_raiz = new ArbolGeneral<DNS>(DNS_raiz);

DNS youtube = new DNS("www.youtube.com", "123.221.245.121", "WWW");
DNS esyoutube = new DNS("es.youtube.com", "16.221.25.21", "DNS");
DNS enyoutube = new DNS("en.youtube.com", "13.22.245.221", "ROUTING");
DNS google = new DNS("www.google.com", "153.123.141.123", "FTP");
DNS wikipedia = new DNS("es.wikipedia.org", "215.231.12.3", "FPT,DNS,WWW");

youtube.Agregarse(Nodo_raiz);
esyoutube.Agregarse(Nodo_raiz);
enyoutube.Agregarse(Nodo_raiz);
google.Agregarse(Nodo_raiz);
wikipedia.Agregarse(Nodo_raiz);

Console.WriteLine("             ***RECORRIDO POR NIVELES CON SEPARACION***");
Nodo_raiz.porNivelesConSeparacion();

#endregion

#region Módulo consulta: Punto 1.

Console.WriteLine("\nPunto 1: \n");
DNS_raiz.punto1("www.youtube.com", Nodo_raiz);
DNS_raiz.punto1("es.youtube.com", Nodo_raiz);
DNS_raiz.punto1("en.youtube.com", Nodo_raiz);
DNS_raiz.punto1("www.google.com", Nodo_raiz);
DNS_raiz.punto1("es.wikipedia.org", Nodo_raiz);
DNS_raiz.punto1("ez.youtube.com", Nodo_raiz);//no existe

#endregion

#region Módulo consulta: Punto 2.
Console.WriteLine("\nPunto 2: \n");
DNS_raiz.punto2("youtube.com", Nodo_raiz);// www,es,en
DNS_raiz.punto2("google.com", Nodo_raiz);//www
DNS_raiz.punto2("wikipedia.org", Nodo_raiz);//es
DNS_raiz.punto2("google.com.ar", Nodo_raiz);//no existe
#endregion

#region Módulo consulta: Punto 3.
Console.WriteLine("\nPunto 3: \n");
DNS_raiz.punto3(1, Nodo_raiz);
Console.WriteLine("");
DNS_raiz.punto3(2, Nodo_raiz);
Console.WriteLine("");
DNS_raiz.punto3(3, Nodo_raiz);
#endregion

#region Recorridos.
//Console.WriteLine("\n\n                 ***RECORRIDO POR NIVELES***");
//Nodo_raiz.porNiveles();
//Console.WriteLine("\n\n                 ***RECORRIDO POSTORDEN***");
//Nodo_raiz.postorden();
//Console.WriteLine("\n\n                 ***RECORRIDO PREORDEN***");
//Nodo_raiz.preorden();
//Console.WriteLine("\n\n                 ***RECORRIDO INORDEN***");
//Nodo_raiz.inorden();
//Console.WriteLine("\n\n");
#endregion