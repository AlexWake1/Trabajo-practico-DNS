using TPFINAL;

#region Estructura del árbol

DNS DNS_raiz = new DNS("Nodo raiz");
ArbolGeneral<DNS> Nodo_raiz = new ArbolGeneral<DNS>(DNS_raiz);

DNS esyoutubear = new DNS("es.youtube.com.ar", "123.158.147.139", "DNS");
DNS wwwyoutubecomar = new DNS("www.youtube.com.ar", "211.174.123.5", "ROUTING");
DNS youtube = new DNS("www.youtube.com", "123.221.245.121", "WWW");
DNS esyoutube = new DNS("es.youtube.com", "16.221.25.21", "DNS");
DNS enyoutube = new DNS("en.youtube.com", "13.22.245.221", "ROUTING");
DNS google = new DNS("www.google.com", "153.123.141.123", "FTP");
DNS wikipedia = new DNS("es.wikipedia.org", "215.231.12.3", "FPT,DNS,WWW");
DNS googlear = new DNS("www.google.com.ar", "211.231.144.26", "WWW");

youtube.Agregarse(Nodo_raiz);
esyoutube.Agregarse(Nodo_raiz);
enyoutube.Agregarse(Nodo_raiz);
esyoutubear.Agregarse(Nodo_raiz);
wwwyoutubecomar.Agregarse(Nodo_raiz);
google.Agregarse(Nodo_raiz);
wikipedia.Agregarse(Nodo_raiz);
googlear.Agregarse(Nodo_raiz);

#endregion

#region Módulo consulta: Punto 1.

//Console.WriteLine("\nPunto 1: \n");
//DNS_raiz.punto1("www.youtube.com", Nodo_raiz);
//DNS_raiz.punto1("es.youtube.com", Nodo_raiz);
//DNS_raiz.punto1("en.youtube.com", Nodo_raiz);
//DNS_raiz.punto1("www.google.com", Nodo_raiz);
//DNS_raiz.punto1("es.wikipedia.org", Nodo_raiz);
//DNS_raiz.punto1("ez.youtube.com", Nodo_raiz);//no existe

#endregion

#region Módulo consulta: Punto 2.
//Console.WriteLine("\nPunto 2: \n");
//DNS_raiz.punto2("youtube.com", Nodo_raiz);// www,es,en
//DNS_raiz.punto2("google.com", Nodo_raiz);//www
//DNS_raiz.punto2("wikipedia.org", Nodo_raiz);//es
//DNS_raiz.punto2("google.com.ar", Nodo_raiz);//no existe
#endregion

#region Módulo consulta: Punto 3.
//Console.WriteLine("\nPunto 3: \n");
//DNS_raiz.punto3(1, Nodo_raiz);
//Console.WriteLine("");
//DNS_raiz.punto3(2, Nodo_raiz);
//Console.WriteLine("");
//DNS_raiz.punto3(3, Nodo_raiz);
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

#region Menú

bool bucle = true;

while (bucle)
{
    opciones();
    int respuesta = int.Parse(Console.ReadLine());
    switch (respuesta)
    {
        case 0:
            bucle = false;
            break;
        case 1:
            Console.Clear();
            Console.WriteLine("Indique la url completa");
            string url = Console.ReadLine();
            Console.WriteLine("Indique la dirección IP completa");
            string dip = Console.ReadLine();
            Console.WriteLine("Indique los servicios de la página");
            string servicios = Console.ReadLine();
            DNS nuevoNodo=new DNS(url, dip, servicios);
            nuevoNodo.Agregarse(Nodo_raiz);
            break;
        case 2:
            Console.Clear();
            Console.WriteLine("Indique la url completa");
            string URL = Console.ReadLine();
            Console.WriteLine("Indique la dirección IP completa");
            string DIP = Console.ReadLine();
            Console.WriteLine("Indique los servicios de la página");
            string SERVICIOS = Console.ReadLine();
            DNS nuevoNodo1 = new DNS(URL, DIP, SERVICIOS);
            DNS_raiz.Eliminar(nuevoNodo1,Nodo_raiz);
            break;
        case 3:
            Console.Clear();
            Console.WriteLine("Indique un dominio completo.");
            string aux2 = Console.ReadLine();
            Console.WriteLine();
            DNS_raiz.punto1(aux2,Nodo_raiz);
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("Indique un dominio.");
            string aux1 = Console.ReadLine();
            Console.WriteLine();
            DNS_raiz.punto2(aux1,Nodo_raiz);
            break;
        case 5:
            Console.Clear();
            Console.WriteLine("Indique el nivel de profundidad del árbol.\n");
            int aux = int.Parse(Console.ReadLine());
            Console.WriteLine();
            DNS_raiz.punto3(aux,Nodo_raiz);
            Console.WriteLine();
            break;
        case 6:
            Console.Clear();
            Console.WriteLine("Recorrido Por Niveles con Separación:\n");
            Nodo_raiz.porNivelesConSeparacion();
            Console.WriteLine("\n");
            break;
        case 7:
            Console.Clear();
            Console.WriteLine("Recorrido Por Niveles:\n");
            Nodo_raiz.porNiveles();
            Console.WriteLine("\n");
            break;
        case 8:
            Console.Clear();
            Console.WriteLine("Recorrido Postorden:\n");
            Nodo_raiz.postorden();
            Console.WriteLine("\n");
            break;
        case 9:
            Console.Clear();
            Console.WriteLine("Recorrido Inorden:\n");
            Nodo_raiz.inorden();
            Console.WriteLine("\n");
            break;
        case 10:
            Console.Clear();
            Console.WriteLine("Recorrido Preorden:\n");
            Nodo_raiz.preorden();
            Console.WriteLine("\n");
            break;
    }
}
void opciones()
{
    Console.WriteLine("0-Salir.");
    Console.WriteLine("1-Agregar DNS.");
    Console.WriteLine("2-Eliminar DNS.");
    Console.WriteLine("3-Módulo consulta: Punto1.");
    Console.WriteLine("4-Módulo consulta: Punto2.");
    Console.WriteLine("5-Módulo consulta: Punto3.");
    Console.WriteLine("6-Recorrido por Niveles con separación.");
    Console.WriteLine("7-Recorrido por Niveles.");
    Console.WriteLine("8-Recorrido Postorden.");
    Console.WriteLine("9-Recorrido Inorden.");
    Console.WriteLine("10-Recorrido Preorden.");
    Console.WriteLine();
}

#endregion