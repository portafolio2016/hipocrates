CREATE TABLE ARCHIVO
(
	ID_ARCHIVO             NUMBER(8) NOT NULL,
	ARCHIVO_B64            CLOB NOT NULL,
	ID_RESULTADO_ATENCION  NUMBER(8),
	EXTENSION              VARCHAR2(16) NOT NULL
)
;


CREATE TABLE ASEGURADORA
(
	ID_ASEGURADORA   NUMBER(8) NOT NULL,
	NOM_ASEGURADORA  VARCHAR2(128)
)
;


CREATE TABLE ATENCION_AGEN
(
	ID_ATENCION_AGEN    NUMBER(8) NOT NULL,
	OBSERVACIONES       VARCHAR2(256),
	ID_PACIENTE         NUMBER(8),
	ID_PERSONAL_MEDICO  NUMBER(8),
	ID_PAGO             NUMBER(8),
	ID_PRESTACION       NUMBER(8),
	FECHOR              DATE,
	ID_ESTADO_ATEN      NUMBER(8)
)
;


CREATE TABLE BANCO
(
	ID_BANCO  NUMBER(8) NOT NULL,
	NOMBRE    VARCHAR2(64)
)
;


CREATE TABLE BONO
(
	ID_BONO          NUMBER(8) NOT NULL,
	CANT_BONO        NUMBER(8),
	COD_ASEGURADORA  VARCHAR2(50),
	ID_ASEGURADORA   NUMBER(8)
)
;


CREATE TABLE CAJA
(
	ID_CAJA          NUMBER(8) NOT NULL,
	FECHOR_APERTURA  DATE,
	FECHOR_CIERRE    DATE,
	ID_FUNCIONARIO   NUMBER(8)
)
;


CREATE TABLE CARGO
(
	ID_CARGO_FUNCI  NUMBER(8) NOT NULL,
	NOMBRE_CARGO    VARCHAR2(64)
)
;


CREATE TABLE CUEN_BANCARIA
(
	ID_CUEN_BANCARIA    NUMBER(8) NOT NULL,
	ID_PERS_MEDICO      NUMBER(8),
	ID_TIPO_C_BANCARIA  NUMBER(8),
	NUM_C_BANCARIA      VARCHAR2(64),
	ID_BANCO            NUMBER(8)
)
;


CREATE TABLE DEVOLUCION
(
	ID_DEVOLUCION  NUMBER(8) NOT NULL,
	NOM_TIPO_DEV   VARCHAR2(128)
)
;


CREATE TABLE ENTRADA_FICHA
(
	ID_ENTRADA_FICHA   NUMBER(8) NOT NULL,
	NOMBRE_ENTRADA     VARCHAR2(64),
	CONTENIDO_ENTRADA  VARCHAR2(1028),
	FECHA_ENTRADA      DATE,
	ID_FICHA           NUMBER(8)
)
;


CREATE TABLE EQUIPO_REQ
(
	ID_EQUIPO_REQ   NUMBER(8) NOT NULL,
	CANTIDAD        NUMBER(8),
	ID_TIPO_EQUIPO  NUMBER(8),
	ID_PRESTACION   NUMBER(8)
)
;


CREATE TABLE ESPECIALIDAD
(
	ID_ESPECIALIDAD   NUMBER(8) NOT NULL,
	NOM_ESPECIALIDAD  VARCHAR2(64)
)
;


CREATE TABLE ESTADO_ATEN
(
	ID_ESTADO_ATEN   NUMBER(8) NOT NULL,
	NOM_ESTADO_ATEN  VARCHAR2(64)
)
;


CREATE TABLE FICHA
(
	ID_FICHA     NUMBER(8) NOT NULL,
	FEC_NAC      DATE,
	SEXO         CHAR(1),
	ID_PACIENTE  NUMBER(8)
)
;


CREATE TABLE FUNCIONARIO
(
	ID_FUNCIONARIO  NUMBER(8) NOT NULL,
	ID_CARGO_FUNCI  NUMBER(8) NOT NULL,
	ID_PERSONAL     NUMBER(8) NOT NULL
)
;


CREATE TABLE INVENTARIO
(
	ID_INVENTARIO_EQUIPO  NUMBER(8) NOT NULL,
	CANT_BODEGA           NUMBER(8),
	ID_TIPO_EQUIPO        NUMBER(8)
)
;


CREATE TABLE ORDEN_ANALISIS
(
	ID_ORDEN_ANALISIS  NUMBER(8) NOT NULL,
	FECHOR_EMISION     DATE,
	FECHOR_RECEP       DATE
)
;


CREATE TABLE PACIENTE
(
	ID_PACIENTE         NUMBER(8) NOT NULL,
	NOMBRES_PACIENTE    VARCHAR2(64),
	APELLIDOS_PACIENTE  VARCHAR2(64),
	RUT                 NUMBER(9) NOT NULL,
	DIGITO_VERIFICADOR  CHAR(1) NOT NULL,
	HASHED_PASS         VARCHAR2(1080),
	EMAIL_PACIENTE      VARCHAR2(512)
)
;


CREATE TABLE PAGO
(
	ID_PAGO        NUMBER(8) NOT NULL,
	FECHOR         DATE,
	ID_BONO        NUMBER(8),
	ID_CAJA        NUMBER(8),
	ID_DEVOLUCION  NUMBER(8),
	MONTO_PAGO     NUMBER(8)
)
;


CREATE TABLE PERS_MEDICO
(
	ID_PERSONAL_MEDICO  NUMBER(8) NOT NULL,
	ID_ESPECIALIDAD     NUMBER(8),
	ID_PERSONAL         NUMBER(8),
	ID_TURNO            NUMBER(8)
)
;


CREATE TABLE PERSONAL
(
	ID_PERSONAL        NUMBER(8) NOT NULL,
	NOMBRES            VARCHAR2(64),
	APELLIDOS          VARCHAR2(64),
	REMUNERACION       NUMBER(8),
	HASHED_PASS        VARCHAR2(1080),
	PORCENT_DESCUENTO  NUMBER(3),
	RUT                NUMBER(9) NOT NULL,
	VERIFICADOR        CHAR(1) NOT NULL,
	EMAIL              VARCHAR2(512)
)
;


CREATE TABLE PRESTACION
(
	ID_PRESTACION       NUMBER(8) NOT NULL,
	NOM_PRESTACION      VARCHAR2(256),
	PRECIO_PRESTACION   NUMBER(8),
	CODIGO_PRESTACION   VARCHAR2(64),
	ID_ESPECIALIDAD     NUMBER(8),
	ID_TIPO_PRESTACION  NUMBER(8)
)
;


CREATE TABLE RES_ATENCION
(
	ID_RESULTADO_ATENCION  NUMBER(8) NOT NULL,
	ATENCION_ABIERTA       NUMBER(1),
	COMENTARIO             VARCHAR2(256),
	ID_ATENCION_AGEN       NUMBER(8),
	ID_ORDEN_ANALISIS      NUMBER(8),
	ID_PERSONAL_MEDICO     NUMBER(8)
)
;


CREATE TABLE TIPO_C_BANCARIA
(
	ID_TIPO_C_BANCARIA  NUMBER(8) NOT NULL,
	NOM_C_BANCARIA      VARCHAR2(64)
)
;


CREATE TABLE TIPO_EQUIPO
(
	ID_TIPO_EQUIPO      NUMBER(8) NOT NULL,
	NOMBRE_TIPO_EQUIPO  VARCHAR2(256)
)
;


CREATE TABLE TIPO_PRES
(
	ID_TIPO_PRESTACION  NUMBER(8) NOT NULL,
	NOM_TIPO_PREST      VARCHAR2(256)
)
;


CREATE TABLE TURNO
(
	ID_TURNO      NUMBER(8) NOT NULL,
	NOMBRE_TURNO  VARCHAR2(64),
	NUMHORA_INI   NUMBER(2),
	NUMMINU_INI   NUMBER(2),
	NUMHORA_FIN   NUMBER(2),
	NUMMINU_FIN   NUMBER(2)
)
;



ALTER TABLE ARCHIVO ADD CONSTRAINT PK_ARCHIVO 
	PRIMARY KEY (ID_ARCHIVO)
;

ALTER TABLE ASEGURADORA ADD CONSTRAINT PK_ASEGURADORA 
	PRIMARY KEY (ID_ASEGURADORA)
;

ALTER TABLE ATENCION_AGEN ADD CONSTRAINT PK_ATENCION_AGEN 
	PRIMARY KEY (ID_ATENCION_AGEN)
;

ALTER TABLE BANCO ADD CONSTRAINT PK_BANCO 
	PRIMARY KEY (ID_BANCO)
;

ALTER TABLE BONO ADD CONSTRAINT PK_BONO 
	PRIMARY KEY (ID_BONO)
;

ALTER TABLE CAJA ADD CONSTRAINT PK_CAJA 
	PRIMARY KEY (ID_CAJA)
;

ALTER TABLE CARGO ADD CONSTRAINT PK_CARGO 
	PRIMARY KEY (ID_CARGO_FUNCI)
;

ALTER TABLE CUEN_BANCARIA ADD CONSTRAINT PK_CUEN_BANCARIA 
	PRIMARY KEY (ID_CUEN_BANCARIA)
;

ALTER TABLE DEVOLUCION ADD CONSTRAINT PK_DEVOLUCION 
	PRIMARY KEY (ID_DEVOLUCION)
;

ALTER TABLE ENTRADA_FICHA ADD CONSTRAINT PK_ENTRADA_FICHA 
	PRIMARY KEY (ID_ENTRADA_FICHA)
;

ALTER TABLE EQUIPO_REQ ADD CONSTRAINT PK_EQUIPO_REQ 
	PRIMARY KEY (ID_EQUIPO_REQ)
;

ALTER TABLE ESPECIALIDAD ADD CONSTRAINT PK_ESPECIALIDAD 
	PRIMARY KEY (ID_ESPECIALIDAD)
;

ALTER TABLE ESTADO_ATEN ADD CONSTRAINT PK_ESTADO_ATEN 
	PRIMARY KEY (ID_ESTADO_ATEN)
;

ALTER TABLE FICHA ADD CONSTRAINT PK_FICHA 
	PRIMARY KEY (ID_FICHA)
;

ALTER TABLE FUNCIONARIO ADD CONSTRAINT PK_FUNCIONARIO 
	PRIMARY KEY (ID_FUNCIONARIO)
;

ALTER TABLE INVENTARIO ADD CONSTRAINT PK_INVENTARIO 
	PRIMARY KEY (ID_INVENTARIO_EQUIPO)
;

ALTER TABLE ORDEN_ANALISIS ADD CONSTRAINT PK_ORDEN_ANALISIS 
	PRIMARY KEY (ID_ORDEN_ANALISIS)
;

ALTER TABLE PACIENTE ADD CONSTRAINT PK_PACIENTE 
	PRIMARY KEY (ID_PACIENTE)
;

ALTER TABLE PAGO ADD CONSTRAINT PK_PAGO 
	PRIMARY KEY (ID_PAGO)
;

ALTER TABLE PERS_MEDICO ADD CONSTRAINT PK_PERS_MEDICO 
	PRIMARY KEY (ID_PERSONAL_MEDICO)
;

ALTER TABLE PERSONAL ADD CONSTRAINT PK_PERSONAL 
	PRIMARY KEY (ID_PERSONAL)
;

ALTER TABLE PRESTACION ADD CONSTRAINT PK_PRESTACION 
	PRIMARY KEY (ID_PRESTACION)
;

ALTER TABLE RES_ATENCION ADD CONSTRAINT PK_RES_ATENCION 
	PRIMARY KEY (ID_RESULTADO_ATENCION)
;

ALTER TABLE TIPO_C_BANCARIA ADD CONSTRAINT PK_TIPO_C_BANCARIA 
	PRIMARY KEY (ID_TIPO_C_BANCARIA)
;

ALTER TABLE TIPO_EQUIPO ADD CONSTRAINT PK_TIPO_EQUIPO 
	PRIMARY KEY (ID_TIPO_EQUIPO)
;

ALTER TABLE TIPO_PRES ADD CONSTRAINT PK_TIPO_PRES 
	PRIMARY KEY (ID_TIPO_PRESTACION)
;

ALTER TABLE TURNO ADD CONSTRAINT PK_TURNO 
	PRIMARY KEY (ID_TURNO)
;



ALTER TABLE ARCHIVO ADD CONSTRAINT FK_RES_ATENCION_ARCHIVO 
	FOREIGN KEY (ID_RESULTADO_ATENCION) REFERENCES RES_ATENCION (ID_RESULTADO_ATENCION) ON DELETE CASCADE
;

ALTER TABLE ATENCION_AGEN ADD CONSTRAINT FK_PACIENTE_ATENCION_AGEN 
	FOREIGN KEY (ID_PACIENTE) REFERENCES PACIENTE (ID_PACIENTE) ON DELETE CASCADE
;

ALTER TABLE ATENCION_AGEN ADD CONSTRAINT FK_SOLICITA_ATENCION_AGEN 
	FOREIGN KEY (ID_PERSONAL_MEDICO) REFERENCES PERS_MEDICO (ID_PERSONAL_MEDICO) ON DELETE CASCADE
;

ALTER TABLE ATENCION_AGEN ADD CONSTRAINT FK_PAGO_ATENCION_AGEN 
	FOREIGN KEY (ID_PAGO) REFERENCES PAGO (ID_PAGO) ON DELETE CASCADE
;

ALTER TABLE ATENCION_AGEN ADD CONSTRAINT FK_ATENCION_AGEN_PRESTACION 
	FOREIGN KEY (ID_PRESTACION) REFERENCES PRESTACION (ID_PRESTACION) ON DELETE CASCADE
;

ALTER TABLE ATENCION_AGEN ADD CONSTRAINT FK_ESTADO_ATEN_ATENCION_AGEN 
	FOREIGN KEY (ID_ESTADO_ATEN) REFERENCES ESTADO_ATEN (ID_ESTADO_ATEN) ON DELETE CASCADE
;

ALTER TABLE BONO ADD CONSTRAINT FK_ASEGURADORA_BONO 
	FOREIGN KEY (ID_ASEGURADORA) REFERENCES ASEGURADORA (ID_ASEGURADORA) ON DELETE CASCADE
;

ALTER TABLE CAJA ADD CONSTRAINT FK_FUNCIONARIO_CAJA 
	FOREIGN KEY (ID_FUNCIONARIO) REFERENCES FUNCIONARIO (ID_FUNCIONARIO) ON DELETE CASCADE
;

ALTER TABLE CUEN_BANCARIA ADD CONSTRAINT FK_CUEN_BANCARIA_TIPO_C_BANCA 
	FOREIGN KEY (ID_TIPO_C_BANCARIA) REFERENCES TIPO_C_BANCARIA (ID_TIPO_C_BANCARIA) ON DELETE CASCADE
;

ALTER TABLE CUEN_BANCARIA ADD CONSTRAINT FK_CUEN_BANCARIA_BANCO 
	FOREIGN KEY (ID_BANCO) REFERENCES BANCO (ID_BANCO) ON DELETE CASCADE
;

ALTER TABLE CUEN_BANCARIA ADD CONSTRAINT FK_CUEN_BANCARIA_PERS_MEDICO 
	FOREIGN KEY (ID_PERS_MEDICO) REFERENCES PERS_MEDICO (ID_PERSONAL_MEDICO) ON DELETE CASCADE
;

ALTER TABLE ENTRADA_FICHA ADD CONSTRAINT FK_ENTRADA_FICHA_FICHA 
	FOREIGN KEY (ID_FICHA) REFERENCES FICHA (ID_FICHA) ON DELETE CASCADE
;

ALTER TABLE EQUIPO_REQ ADD CONSTRAINT FK_EQUIPO_REQ_TIPO_EQUIPO 
	FOREIGN KEY (ID_TIPO_EQUIPO) REFERENCES TIPO_EQUIPO (ID_TIPO_EQUIPO) ON DELETE CASCADE
;

ALTER TABLE EQUIPO_REQ ADD CONSTRAINT FK_EQUIPO_REQ_PRESTACION 
	FOREIGN KEY (ID_PRESTACION) REFERENCES PRESTACION (ID_PRESTACION) ON DELETE CASCADE
;

ALTER TABLE FICHA ADD CONSTRAINT FK_PACIENTE_FICHA 
	FOREIGN KEY (ID_PACIENTE) REFERENCES PACIENTE (ID_PACIENTE) ON DELETE CASCADE
;

ALTER TABLE FUNCIONARIO ADD CONSTRAINT FK_CARGO_FUNCIONARIO 
	FOREIGN KEY (ID_CARGO_FUNCI) REFERENCES CARGO (ID_CARGO_FUNCI) ON DELETE CASCADE
;

ALTER TABLE FUNCIONARIO ADD CONSTRAINT FK_PERSONAL_FUNCIONARIO 
	FOREIGN KEY (ID_PERSONAL) REFERENCES PERSONAL (ID_PERSONAL) ON DELETE CASCADE
;

ALTER TABLE INVENTARIO ADD CONSTRAINT FK_TIPO_EQUIPO_INVENTARIO 
	FOREIGN KEY (ID_TIPO_EQUIPO) REFERENCES TIPO_EQUIPO (ID_TIPO_EQUIPO) ON DELETE CASCADE
;

ALTER TABLE PAGO ADD CONSTRAINT FK_BONO_PAGO 
	FOREIGN KEY (ID_BONO) REFERENCES BONO (ID_BONO) ON DELETE CASCADE
;

ALTER TABLE PAGO ADD CONSTRAINT FK_CAJA_PAGO 
	FOREIGN KEY (ID_CAJA) REFERENCES CAJA (ID_CAJA) ON DELETE CASCADE
;

ALTER TABLE PAGO ADD CONSTRAINT FK_DEVOLUCION_PAGO 
	FOREIGN KEY (ID_DEVOLUCION) REFERENCES DEVOLUCION (ID_DEVOLUCION) ON DELETE CASCADE
;

ALTER TABLE PERS_MEDICO ADD CONSTRAINT FK_PERS_MEDICO_ESPECIALIDAD 
	FOREIGN KEY (ID_ESPECIALIDAD) REFERENCES ESPECIALIDAD (ID_ESPECIALIDAD) ON DELETE CASCADE
;

ALTER TABLE PERS_MEDICO ADD CONSTRAINT FK_PERSONAL_PERS_MEDICO 
	FOREIGN KEY (ID_PERSONAL) REFERENCES PERSONAL (ID_PERSONAL) ON DELETE CASCADE
;

ALTER TABLE PERS_MEDICO ADD CONSTRAINT FK_TURNO_PERS_MEDICO 
	FOREIGN KEY (ID_TURNO) REFERENCES TURNO (ID_TURNO) ON DELETE CASCADE
;

ALTER TABLE PRESTACION ADD CONSTRAINT FK_ESPECIALIDAD_PRESTACION 
	FOREIGN KEY (ID_ESPECIALIDAD) REFERENCES ESPECIALIDAD (ID_ESPECIALIDAD) ON DELETE CASCADE
;

ALTER TABLE PRESTACION ADD CONSTRAINT FK_TIPO_PRES_PRESTACION 
	FOREIGN KEY (ID_TIPO_PRESTACION) REFERENCES TIPO_PRES (ID_TIPO_PRESTACION) ON DELETE CASCADE
;

ALTER TABLE RES_ATENCION ADD CONSTRAINT FK_ATENCION_AGEN_RES_ATENCION 
	FOREIGN KEY (ID_ATENCION_AGEN) REFERENCES ATENCION_AGEN (ID_ATENCION_AGEN) ON DELETE CASCADE
;

ALTER TABLE RES_ATENCION ADD CONSTRAINT FK_ORDEN_ANALISIS_RES_ATENCION 
	FOREIGN KEY (ID_ORDEN_ANALISIS) REFERENCES ORDEN_ANALISIS (ID_ORDEN_ANALISIS) ON DELETE CASCADE
;

ALTER TABLE RES_ATENCION ADD CONSTRAINT FK_EJECUTA_RES_ATENCION 
	FOREIGN KEY (ID_PERSONAL_MEDICO) REFERENCES PERS_MEDICO (ID_PERSONAL_MEDICO) ON DELETE CASCADE
;






CREATE SEQUENCE SEQ_ARCHIVO_ID_ARCHIVO 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_ARCHIVO_ID_ARCHIVO 
	BEFORE INSERT 
	ON ARCHIVO 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_ARCHIVO_ID_ARCHIVO.NEXTVAL 
		INTO :NEW.ID_ARCHIVO 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_ASEGURADORA_ID_ASEGURADORA 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_ASEGURADORA_ID_ASEGURADORA 
	BEFORE INSERT 
	ON ASEGURADORA 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_ASEGURADORA_ID_ASEGURADORA.NEXTVAL 
		INTO :NEW.ID_ASEGURADORA 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_ATENCION_AGEN_ID_ATENCION_ 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_ATENCION_AGEN_ID_ATENCION_ 
	BEFORE INSERT 
	ON ATENCION_AGEN 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_ATENCION_AGEN_ID_ATENCION_.NEXTVAL 
		INTO :NEW.ID_ATENCION_AGEN 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_BANCO_ID_BANCO 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_BANCO_ID_BANCO 
	BEFORE INSERT 
	ON BANCO 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_BANCO_ID_BANCO.NEXTVAL 
		INTO :NEW.ID_BANCO 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_BONO_ID_BONO 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_BONO_ID_BONO 
	BEFORE INSERT 
	ON BONO 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_BONO_ID_BONO.NEXTVAL 
		INTO :NEW.ID_BONO 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_CAJA_ID_CAJA 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_CAJA_ID_CAJA 
	BEFORE INSERT 
	ON CAJA 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_CAJA_ID_CAJA.NEXTVAL 
		INTO :NEW.ID_CAJA 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_CARGO_ID_CARGO_FUNCI 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_CARGO_ID_CARGO_FUNCI 
	BEFORE INSERT 
	ON CARGO 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_CARGO_ID_CARGO_FUNCI.NEXTVAL 
		INTO :NEW.ID_CARGO_FUNCI 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_CUEN_BANCARIA_ID_CUEN_BANC 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_CUEN_BANCARIA_ID_CUEN_BANC 
	BEFORE INSERT 
	ON CUEN_BANCARIA 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_CUEN_BANCARIA_ID_CUEN_BANC.NEXTVAL 
		INTO :NEW.ID_CUEN_BANCARIA 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_DEVOLUCION_ID_DEVOLUCION 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_DEVOLUCION_ID_DEVOLUCION 
	BEFORE INSERT 
	ON DEVOLUCION 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_DEVOLUCION_ID_DEVOLUCION.NEXTVAL 
		INTO :NEW.ID_DEVOLUCION 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_ENTRADA_FICHA_ID_ENTRADA_F 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_ENTRADA_FICHA_ID_ENTRADA_F 
	BEFORE INSERT 
	ON ENTRADA_FICHA 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_ENTRADA_FICHA_ID_ENTRADA_F.NEXTVAL 
		INTO :NEW.ID_ENTRADA_FICHA 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_EQUIPO_REQ_ID_EQUIPO_REQ 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_EQUIPO_REQ_ID_EQUIPO_REQ 
	BEFORE INSERT 
	ON EQUIPO_REQ 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_EQUIPO_REQ_ID_EQUIPO_REQ.NEXTVAL 
		INTO :NEW.ID_EQUIPO_REQ 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_ESPECIALIDAD_ID_ESPECIALID 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_ESPECIALIDAD_ID_ESPECIALID 
	BEFORE INSERT 
	ON ESPECIALIDAD 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_ESPECIALIDAD_ID_ESPECIALID.NEXTVAL 
		INTO :NEW.ID_ESPECIALIDAD 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_ESTADO_ATEN_ID_ESTADO_ATEN 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_ESTADO_ATEN_ID_ESTADO_ATEN 
	BEFORE INSERT 
	ON ESTADO_ATEN 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_ESTADO_ATEN_ID_ESTADO_ATEN.NEXTVAL 
		INTO :NEW.ID_ESTADO_ATEN 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_FICHA_ID_FICHA 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_FICHA_ID_FICHA 
	BEFORE INSERT 
	ON FICHA 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_FICHA_ID_FICHA.NEXTVAL 
		INTO :NEW.ID_FICHA 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_FUNCIONARIO_ID_FUNCIONARIO 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_FUNCIONARIO_ID_FUNCIONARIO 
	BEFORE INSERT 
	ON FUNCIONARIO 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_FUNCIONARIO_ID_FUNCIONARIO.NEXTVAL 
		INTO :NEW.ID_FUNCIONARIO 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_INVENTARIO_ID_INVENTARIO_E 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_INVENTARIO_ID_INVENTARIO_E 
	BEFORE INSERT 
	ON INVENTARIO 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_INVENTARIO_ID_INVENTARIO_E.NEXTVAL 
		INTO :NEW.ID_INVENTARIO_EQUIPO 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_ORDEN_ANALISI_ID_ORDEN_ANA 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_ORDEN_ANALISI_ID_ORDEN_ANA 
	BEFORE INSERT 
	ON ORDEN_ANALISIS 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_ORDEN_ANALISI_ID_ORDEN_ANA.NEXTVAL 
		INTO :NEW.ID_ORDEN_ANALISIS 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_PACIENTE_ID_PACIENTE 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_PACIENTE_ID_PACIENTE 
	BEFORE INSERT 
	ON PACIENTE 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_PACIENTE_ID_PACIENTE.NEXTVAL 
		INTO :NEW.ID_PACIENTE 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_PAGO_ID_PAGO 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_PAGO_ID_PAGO 
	BEFORE INSERT 
	ON PAGO 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_PAGO_ID_PAGO.NEXTVAL 
		INTO :NEW.ID_PAGO 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_PERS_MEDICO_ID_PERSONAL_ME 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_PERS_MEDICO_ID_PERSONAL_ME 
	BEFORE INSERT 
	ON PERS_MEDICO 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_PERS_MEDICO_ID_PERSONAL_ME.NEXTVAL 
		INTO :NEW.ID_PERSONAL_MEDICO 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_PERSONAL_ID_PERSONAL 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_PERSONAL_ID_PERSONAL 
	BEFORE INSERT 
	ON PERSONAL 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_PERSONAL_ID_PERSONAL.NEXTVAL 
		INTO :NEW.ID_PERSONAL 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_PRESTACION_ID_PRESTACION 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_PRESTACION_ID_PRESTACION 
	BEFORE INSERT 
	ON PRESTACION 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_PRESTACION_ID_PRESTACION.NEXTVAL 
		INTO :NEW.ID_PRESTACION 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_RES_ATENCION_ID_RESULTADO_ 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_RES_ATENCION_ID_RESULTADO_ 
	BEFORE INSERT 
	ON RES_ATENCION 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_RES_ATENCION_ID_RESULTADO_.NEXTVAL 
		INTO :NEW.ID_RESULTADO_ATENCION 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_TIPO_C_BANCAR_ID_TIPO_C_BA 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_TIPO_C_BANCAR_ID_TIPO_C_BA 
	BEFORE INSERT 
	ON TIPO_C_BANCARIA 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_TIPO_C_BANCAR_ID_TIPO_C_BA.NEXTVAL 
		INTO :NEW.ID_TIPO_C_BANCARIA 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_TIPO_EQUIPO_ID_TIPO_EQUIPO 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_TIPO_EQUIPO_ID_TIPO_EQUIPO 
	BEFORE INSERT 
	ON TIPO_EQUIPO 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_TIPO_EQUIPO_ID_TIPO_EQUIPO.NEXTVAL 
		INTO :NEW.ID_TIPO_EQUIPO 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_TIPO_PRES_ID_TIPO_PRESTACI 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_TIPO_PRES_ID_TIPO_PRESTACI 
	BEFORE INSERT 
	ON TIPO_PRES 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_TIPO_PRES_ID_TIPO_PRESTACI.NEXTVAL 
		INTO :NEW.ID_TIPO_PRESTACION 
		FROM DUAL; 
	END;
/
CREATE SEQUENCE SEQ_TURNO_ID_TURNO 
    INCREMENT BY 1 
    START WITH 1 
    NOMAXVALUE 
    MINVALUE 1 
	NOCYCLE 
	NOCACHE 
	NOORDER
;



CREATE OR REPLACE TRIGGER TRG_TURNO_ID_TURNO 
	BEFORE INSERT 
	ON TURNO 
	FOR EACH ROW 
	BEGIN 
		SELECT SEQ_TURNO_ID_TURNO.NEXTVAL 
		INTO :NEW.ID_TURNO 
		FROM DUAL; 
	END;
/
