using TPFINAL;

ArbolGeneral<string> a1 = new ArbolGeneral<string>("www.");
ArbolGeneral<string> a2 = new ArbolGeneral<string>(".google");
ArbolGeneral<string> a3 = new ArbolGeneral<string>(".com");


ArbolGeneral<string> DominioDeNivelSuperior = new ArbolGeneral<string>("org");
ArbolGeneral<string> SubDominio = new ArbolGeneral<string>(".wikipedia");
ArbolGeneral<string> NombreDelEquipo = new ArbolGeneral<string>("es.");




a1.agregarHijo(a2);
a2.agregarHijo(a3);

