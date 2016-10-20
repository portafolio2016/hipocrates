--****** ATENCION!!! DEBE SER EJECUTADO COMO SYSTEM
@@crear_dev.sql -- crea usuario DEV
ALTER SESSION SET CURRENT_SCHEMA = dev;
@@cmh.sql -- DDL CMHDB
-- aqui va el script de insercion de datos

@@crear_devseguro.sql -- crea usuario DEVSEGURO
ALTER SESSION SET CURRENT_SCHEMA = devseguro;
@@seguroWS.sql -- DDL SeguroWS
-- aqui va el script de insercion de datos