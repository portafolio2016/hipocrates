# Lista de videos para el demo
- La idea de esta lista es no ser exhaustiva, porque en 7 minutos no caben todas las funciones del software. Son las funcionalidades visibles que más fácilmente pueden demostrarse.
- Decidí contar la historias de usuarios individuales para no ir de un lado a otro, me parece que es mucho menos confuso al explicarle el sistema a alguien que no lo ha visto nunca.

## Notas para la grabación:
1. No usar una pantalla con resolución demasiado grande: se tiene que ver bien en el proyector
1. No usar datos lulz
1. No mostrar nada que no sea la aplicación: croppear el resto del OS.


##  1. Paciente
> Los pacientes son los clientes o potenciales clientes del centro médico.

1. Paciente revisa horas libres
> En vez de llamar por teléfono, el paciente puede ingresar a la página web de la página y revisar las horas libres para la prestación que está buscando.

1. Paciente toma hora (no mostrar el login)
> Una vez hecho el login, el paciente puede tomar la hora directamente en la página web.

1. Paciente revisa resultados
> Cada vez que el paciente se haga un examen, recibirá una notificación en su correo. En esta página podrá descargar los


## 2. Operador
> Los operadores son funcionarios del centro médico cuyas responsabilidades son ingresar a los pacientes, recibir pagos, registrar pacientes y agendar horas.

1. Operador abre caja
> Al principio de cada día, el operador debe abrir su caja e ingresar el dinero inicial en dicha caja.

1. Operador ingresa paciente/pago
> Cuando un paciente se presenta para una atención y llega su hora, el operador procede a cobrarle e ingresarlo.

1. Operador agenda hora
> En el caso de que un operador reciba una llamada telefónica o una solicitud en persona, puede agendar una hora para un paciente. Si el paciente no existe, el operador puede crearle un perfil.

1. Cierra caja
> Al final del día, el operador debe cerrar la caja con la cantidad de dinero que contiene. Si la cantidad de dinero no calza con las ventas hechas durante el día, el sistema le envía un correo al jefe de operadores.


## 3. Médico
> Un médico es parte del personal médico del Centro. Se encargan de efectuar atenciones médicas y derivar a pacientes que lo necesiten

1. Revisar agenda
> El médico puede ver todas las atenciones que le corresponden durante el presente día.

1. Cerrar atención
> Una vez realizada la atención, puede cerrarla y actualizar la ficha médica del paciente.

1. Actualizar ficha médica
> El médico puede actualizar las fichas médicas de los pacientes

1. Derivar (agendar para un paciente)
> En el caso de que el paciente necesite una derivación a otro especialista o un examen en particular, esta ventana permite al médico agendar esta atención en el momento.

1. Modificar datos bancarios
> Como el pago de los médicos es automático, tienen la posibilidad de cambiar su información bancaria para recibir sus honorarios donde más le convenga.

## 4. Enfermero
> Un enfermero es un miembro del personal médico del Centro, encargado de tomar muestras para los exámenes de laboratorio, solicitar orden de análisis y subir los resultados de esta orden.

1. Revisar agenda
> Al igual que el médico, el enfermero puede revisar su agenda diaria.

1. Abrir orden de análisis
> Los enfermeros se encargan de tomar las muestras de los exámenes de laboratorio. Una vez tomada la muestra, el enfermero puede abrir la orden de análisis sobre la muestra.

1. Cerrar orden de análisis
> Una vez que recibe los resultados del análisis, el enfermero debe cerrar la orden de análisis correspondiente y subir un archivo. Al subir este archivo, el paciente recibe una notificación por mail que le indica que los resultados de su examen están listos. Si un médico fue el que solicitó el examen, dicho médico también recibirá una notificación en su mail.


## 5. Jefe de operadores
> Los jefes de operadores son funcionarios del centro cuyas responsabilidades son: funciones de mantención en el sistema, monitorear los reportes de cajas diarias, monitorear el pago de los honorarios médicos y administrar los usuarios.

1. Reporte de caja
> Los jefes de operadores pueden revisar el detalle de cada caja diaria cerrada por un operador en esta ventana.


1. Log pago de honorarios a médicos
> Los pagos de honorarios históricos pueden ser revisados en esta ventana.

1. Mantenedor de personal
> En el caso de una nueva contratación o el olvido de una contraseña, el jefe de operadores puede editar la información de cualquier miembro del personal del Centro.

1. Mantenedor de prestaciones
> En el caso de que el centro médico modifique las prestaciones que ofrece, es posible modificarlas en esta ventana.
