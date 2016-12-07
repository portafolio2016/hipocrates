1. Título
  - Buenos días, somos el grupo 1 correspondiente al caso 1. Nuestro caso es del Centro Médico Hipócrates.
  - Los integrantes del grupo son...
1. Agenda
  - En nuestra presentación, veremos los siguientes temas
    - Presentaremos al cliente y sus actividades
    - Veremos la problemática identificada
    - Y la solución requerida
    - Luego presentaremos las especificaciones de alto nivel de la solución
    - Veremos la organización del proyecto
    - y finalizaremos con una demostración de la solución.
1. Cliente
  - Nuestro cliente es el Centro Médico Hipócrates.
  - Esta institución ofrece servicios de:
    - Consultas médicas
    - Exámenes de imagenología
    - Exámenes de laboratorio
  - Además, para apoyar estos servicios, tienen procesos internos:
    - Agendamiento de horas
    - Entrega de exámenes
    - Mantención de fichas médicas de pacientes.
  - Además cuenta con procesos administrativos:
    - Pago de honorarios a médicos
    - Generación de reportes de cajas
    - Gestión de información de bonos
1. Problematica
  - Con el cliente, descubrimos que la principal problemática es que los actuales procesos del centro médico son insuficientes para cumplir las necesidades del personal.
  - Esta problemática se puede desglosar en los siguientes factores:
    - El volumen de pacientes que están recibiendo aumentó, y el personal no está preparado para la nueva carga de trabajo.
    - Toda la información está siendo manejada en papel.
1. Consecuencias problematica
  - Los tiempos de espera del paciente son largos.
  - Inconsistencia en los datos entregados al paciente.
  - Los procesos financieros tienen una tasa de error considerada inaceptable por la gerencia del centro.
1. Solución propuesta
  - El cliente nos solicitó estandarizar sus procesos internos y administativos.
  - También nos solicitó una solución de software que permita la ejecución de los nuevos procesos implementados.
1. Objetivos generales
 - Mejorar los resultados de los procesos administrativos del centro médico Hipócrates mediante una solución integrada de software.
1. Objetivos especificos
  - Reducir el tiempo empleado en el pago de honorarios en al menos un 50% del tiempo de ejecución.
  - Reducir la incertidumbre de pacientes frente a sus atenciones y sus resultados al menos a un 2%.
  - Asegurar la confiabilidad de la información de las cajas de pago en al menos un 99%.
  - Incrementar información de detalle de procedimientos de médicos, enfermeros y/o tecnólogos en al menos un 99% de las ocasiones.
1. Restricciones:
  - Después de entregado el producto, no se le hará mantención.
  - Después de haber sido entregado el producto, el CMH se hace responsable de la digitación y mantención de los datos manejados por el sistema.
1. Requerimientos principales del negocio: funcionales
  - Los principales requerimientos funcionales a nivel negocio son:
    - Administrar horas agendadas
    - Pagar honorarios de médicos periódicamente
    - Mantener fichas médicas de todos los pacientes
    - Mejorar el acceso a la información al personal médico
    - Mantener las cajas
    - Entregar resultados de exámenes a pacientes
    - Consultar estado de los seguros de los pacientes
1. requerimientos principales del negocio: no funcionales.
  - Los principales requerimientos no funcionales son:
    - El sistema debe estar implementado con una arquitectura en capas
    - El sistema debe utilizar Java y .NET y Oracle como tecnologías principales.
1. Modelo de datos relacional
  - Nuestro modelo de datos está en forma normal 3, por requerimiento del cliente.
  - Las principales tablas son Paciente y atención agendada.
  - La tabla paciente relaciona y organiza los datos personales de cada uno de los pacientes del centro, sirviendo como nodo que relaciona con otras tablas importantes para el negocio, como las fichas médicas, las credenciales para la página web.
  - La tabla atención agendada relaciona los paciente con las prestaciones, el personal médico tratante, contiene el factor tiempo y el resultado de las atenciones, lo que es particularmente importante cuando son exámenes.
1. Diagrama de despliegue
  -
1. Tecnologías y versiones
  - Para control de versiones utilizamos Git y GitHub.
  - Para los componentes en .NET utilizamos:
    - Visual Studio 2013 como IDE.
    - La versión de framework es 4.5
    - Entity framework 6.
  - Para los componentes Java utilizamos:
    - NetBeans 8.1 como IDE.
    - JDK 1.8
    - Servidor web Glassfish.
  - Oracle 11g R2 como motor de base de datos.
  - SQL Developer como IDE SQL.
  - Bootstrap y jQuery para el frontend web.
  - Enterprise Architect 11 para diagramas UML
  - Bizagi Modeler 3.0
1. Roles del equipo
  - Tomás Muñiz: Ingeniero de testing y desarrollo en Java.
  - Elías Baeza: Ingeniero en testing y encargado de la documentación
  - Gonzalo López: desarrollador en el área .NET y Oracle
  - Fabián Jaque: jefe de proyecto y encargado de los bocetos.
  - Pablo de la Sotta: encargado de la arquitectura y modelamiento de procesos.
1. Calendarización
  - Nuestro trabajo lo dividimos en 3 iteraciones.
  - En la primera iteración desarrolló todo lo relacionado con la planificación del proyecto. El principal entregable fue el documento del plan de proyecto y los bpmn propuestos.
  - En la segunda iteración diseñamos la solución, desarrollamos la capa DAL y la capa de negocios, modelamos e implementamos las bases de datos y se realizaron los tests unitarios para la capa de negocios. Los entregables de esta iteración fueron: los scripts de base de datos, las librerías de WebApp y terminal, los módulos de webservice de aseguradora y el servicio de pagos.
  - En la tercera iteración se diseñaron e implementaron las interfaces gráficas de usuario de webapp y terminal, se ejecutaron las pruebas de integración y de humo. El entregable de esta iteración fueron los ejecutables finales del sistema terminado.
1. Pruebas
  - El sistema tiene 72 casos de pruebas unitarias, con un 100% de aprobación.
  - Desarrollamos un plan de pruebas de humo/aceptación con 71 casos. Este plan de pruebas fue ejecutado por miembros del CITT.
1. Metodologías
  -
1. Desglose de costos y flujo de caja
  -
1. Demo
  - Paciente: Los pacientes son los clientes o potenciales clientes del centro médico.

    - Paciente revisa horas libres: En vez de llamar por teléfono, el paciente puede ingresar a la página web de la página y revisar las horas libres para la prestación que está buscando.

    - Paciente toma hora: Una vez hecho el login, el paciente puede tomar la hora directamente en la página web.

    - Paciente revisa resultados: Cada vez que el paciente se haga un examen, recibirá una notificación en su correo. En esta página podrán descargar los resultados de los exámenes.
  - Operador: Los operadores son funcionarios del centro médico cuyas responsabilidades son ingresar a los pacientes, recibir pagos, registrar pacientes y agendar horas.

    - Operador abre caja: Al principio de cada día, el operador debe abrir su caja e ingresar el dinero inicial en dicha caja.

    - Crear paciente: Cuando un paciente no existe en el sistema, el operador tiene la capacidad de crear un nuevo paciente.

    - Operador ingresa paciente/pago: Cuando un paciente se presenta para una atención y llega su hora, el operador procede a cobrarle e ingresarlo.

    - Operador agenda hora: En el caso de que un operador reciba una llamada telefónica o una solicitud en persona, puede agendar una hora para un paciente. Si el paciente no existe, el operador puede crearle un perfil.

    - Cierra caja: Al final del día, el operador debe cerrar la caja con la cantidad de dinero que contiene. Si la cantidad de dinero no calza con las ventas hechas durante el día, el sistema le envía un correo al jefe de operadores.

  - Médico: Un médico es parte del personal médico del Centro. Se encargan de efectuar atenciones médicas y derivar a pacientes que lo necesiten

    - Revisar agenda: El médico puede ver todas las atenciones que le corresponden durante el presente día.

    - Cerrar atención: Una vez realizada la atención, puede cerrarla y actualizar la ficha médica del paciente.

    - Derivar (agendar para un paciente): En el caso de que el paciente necesite una derivación a otro especialista o un examen en particular, esta ventana permite al médico agendar esta atención en el momento.

    - Modificar datos bancarios: Como el pago de los médicos es automático, tienen la posibilidad de cambiar su información bancaria para recibir sus honorarios donde más le convenga.

  - Enfermero: Un enfermero es un miembro del personal médico del Centro, encargado de tomar muestras para los exámenes de laboratorio, solicitar orden de análisis y subir los resultados de esta orden.
    - Revisar agenda: Al igual que el médico, el enfermero puede revisar su agenda diaria.

    - Abrir orden de análisis: Los enfermeros se encargan de tomar las muestras de los exámenes de laboratorio. Una vez tomada la muestra, el enfermero puede abrir la orden de análisis sobre la muestra.

    - Cerrar orden de análisis: Una vez que recibe los resultados del análisis, el enfermero debe cerrar la orden de análisis correspondiente y subir un archivo. Al subir este archivo, el paciente recibe una notificación por mail que le indica que los resultados de su examen están listos. Si un médico fue el que solicitó el examen, dicho médico también recibirá una notificación en su mail.

  - Jefe de operadores: Los jefes de operadores son funcionarios del centro cuyas responsabilidades son: funciones de mantención en el sistema, monitorear los reportes de cajas diarias, monitorear el pago de los honorarios médicos y administrar los usuarios.

    - Reporte de caja: Los jefes de operadores pueden revisar el detalle de cada caja diaria cerrada por un operador en esta ventana.

    - Log pago de honorarios a médicos: Los pagos de honorarios históricos pueden ser revisados en esta ventana.

    - Mantenedor de personal: En el caso de una nueva contratación o el olvido de una contraseña, el jefe de operadores puede editar la información de cualquier miembro del personal del Centro.

    - Mantenedor de prestaciones: En el caso de que el centro médico modifique las prestaciones que ofrece, es posible modificarlas en esta ventana.
1. Conclusiones
  - En conclusión:
    - Hemos presentado un proyecto que cumple con los requerimientos de nuestro cliente.
    - Y es viable económicamente.
    - Ambos puntos justificado debidamente con herramientas adecuadas para este propósito.
    - Gracias por su atención, abrimos el espacio para preguntas.
