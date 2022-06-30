using TPFINAL;

ArbolGeneral<DNS> Nodo_raiz = new ArbolGeneral<DNS>(new DNS("Nodo raiz."));




DNS youtubear = new DNS("www.youtube.com.ar", "198.156.1.255", "www");
DNS google = new DNS("www.google.com", "153.123.141.123", "asd");
DNS youtube = new DNS("www.youtube.com", "123.221.245.111", "fef");
youtube.agregar(Nodo_raiz);
google.agregar(Nodo_raiz);
youtubear.agregar(Nodo_raiz);


Nodo_raiz.porNivelesConSeparacion();
//Nodo_raiz.postorden();

