### Objetivos SMART

Para llegar a los objetivos específicos se usó una tabla SMART, en la cual se
identificó el proceso afectado de la situación actual del centro médico
Hipócrates.

Para comprobar el proceso afectado se usó una métrica para medir el nivel de la
situación actual.

Para saber si el objetivo se cumplió, se definió un criterio de éxito medible.

Los 4 objetivos específicos fueron calificados como exitosos.

### Requerimiento de sistema

Hay una totalidad de 33 requerimientos funcionales y 18 requerimientos no
funcionales, de los cuales se nombran los principales:

1.  Los pacientes pueden agendar atenciones por la página web del centro médico

2.  Los médicos pueden revisar su carga de trabajo diaria

3.  Durante el proceso de pago, el sistema debe verificar la cobertura de
    seguros asociados al paciente ingresado e informar el porcentaje que cubre
    el plan del paciente

4.  Los profesionales médicos (médicos, enfermeros o tecnólogos) pueden
    actualizar fichas médicas existentes del centro médico

5.  El operador puede generar reportes de su caja

### RFC

Al principio de la segunda iteración, se generó un documento RFC (Request for
change) para la restructuración del diseño de la arquitectura.

Se hizo una prueba de concepto con una arquitectura que incluía un módulo
adicional pero no seguimos con este diseño porque resultaba muy costoso.

Esto no afectó en la planificación de tiempos ya que la prueba de concepto fue
previa al desarrollo de la arquitectura.

### Diccionario de datos

El diccionario de datos es un documento que describe cada una de las tablas de
los modelos de datos tanto como la del Centro médico Hipócrates y
CMHAseguradora.

Aquí tenemos la tabla de paciente con sus campos respectivos como por ejemplo:
nombre y usuario; el tipo de datos, su tamaño y una breve descripción del campo.

### 3 capas de servidor

Nuestro sistema está dividido en 3 capas siguiendo el modelo de MVC

-   Modelo (DAL - Data Access Layer)

-   Controlador (BL - Business Layer)

-   Vista (View)

(Insertar imágenes de las capas en terminal y web)

Nombrar las capas en el código del sistema
