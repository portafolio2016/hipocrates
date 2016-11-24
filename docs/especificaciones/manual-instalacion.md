# Manual de instalación sistema CMH

## Bases de datos
1. Iniciar el motor de base de datos Oracle
2. Dirigirse a la carpeta ```./modelo-datos```
3. Seguir las instrucciones de ```./modelo-datos/README.txt```

## Webapp
1. Deploy de todo el contenido ```./webapp```en la carpeta servidor web.
2. Reiniciar servidor.


## Servicio de pago
1. El servicio de pago se inicia con el webapp, por lo que si el punto anterior se ejecuta correctamente no es necesario hacer nada más.

## Terminal
1. El terminal no requiere instalación, solo se necesita ejecutar terminal.exe


## Servicio Web
1. Iniciar el servicio IIS en la máquina deseada
2. Hacer deploy en la carpeta designada para el servicio los assemblies, el archivo .SVC y el archivo Web.config
3. Iniciar el servicio desde el menú del IIS.
