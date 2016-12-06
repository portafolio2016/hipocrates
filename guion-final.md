1. Título
1. Agenda
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
  -
1. Roles del equipo
  -
1. Calendarización
  - Nuestro trabajo lo dividimos en 3 iteraciones.
  - En la primera iteración desarrolló todo lo relacionado con la planificación del proyecto. Se ejecutó entre el 29 de agosto y 25 de septiembre del presente. El principal entregable fue el documento del plan de proyecto y los bpmn propuestos.
  - En la segunda iteración diseñamos la solución, desarrollamos la capa DAL y la capa de negocios, modelamos e implementamos las bases de datos y se realizaron los tests unitarios para la capa de negocios. Los entregables de esta iteración fueron: los scripts de base de datos, las librerías de WebApp y terminal, los módulos de webservice de aseguradora y el servicio de pagos.
  - En la tercera iteración se diseñaron e implementaron las interfaces gráficas de usuario de webapp y terminal, se ejecutaron las pruebas de integración y de humo. El entregable de esta iteración fueron los ejecutables finales del sistema terminado.
1. Plan de pruebas
  -
1. Metodologías
  -
1. Desglose de costos y flujo de caja
  -
1. Demo
  -


---
# Reserva
1. Tabla de objetivos smart
1. Requerimientos de usuario
1. Requerimientos de sistema
1. RFC
1. Diccionario de datos
1. 3 capas del software.
1. Riesgos
