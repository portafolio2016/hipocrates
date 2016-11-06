-- Crea el usuario DEV (Debe estar conectado con el usuario system)
CREATE USER dev IDENTIFIED BY dev;
-- Le da persmisos de desarrollador, conectarse y tablespace al usuario dev.
grant connect, resource, unlimited tablespace to dev;
-- le da permisos de crear vistas al usuario dev (Por si salta algún error al crear una vista)
grant create view to dev;
-- Sentencia que cambia el formato que mostrará el tipo de dato DATE a Mes/Dia/Año Hora:Minutos:Segundo
-- IMPORTANTE: EJECUTAR EN EL USUARIO DEV PARA QUE LOS CAMPOS FECHOR TOMEN FORMA
alter session set nls_date_format = 'MM/DD/YYYY HH24:MI:SS';


