Main
======

Esto se entrega el 2016-08-29
Presentación del caso: cuenta con la presentación de la empresa, la descripción del modelo de negocios, la problemática y el alcance del proyecto.
ERS: requerimientos de software en formato IEEE830
PPT: presentación de todo lo anterior.


Cambiar puerto GlassFish
------

1. Abrir Netbeans
2. Ir a pestaña Services
3. Abrir la sección de Servers
4. Cerrar Glassfish (En caso de que esté corriendo)
5. Eliminar Glassfish
6. Cerrar Netbeans
7. Ir a la ruta C:\Program Files\glassfish-4.1.1\glassfish\domains\domain1\config
8. Abrir archivo domains.xml
9. Buscar con CTRL+F el número 8080 y cambiarlo por 8090
10. Guardar configuración
11. Abrir Netbeans
12. Ir a pestaña Services
13. Abrir con botón secundario la sección de Servers
14. Presionar Add server
15. Seleccionar Glassfish Server (Viene predefinido)
16. Presionar Next
17. Dar como direccion de instalación C:\Program Files\glassfish-4.1.1\glassfish
18. Presionar Next
19. Cambiar HTTP Port a 8090
20. Cambiar User Name a admin
21. Presionar finish