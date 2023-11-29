API Hospital - Documentación
Esta API proporciona endpoints para la gestión de médicos, pacientes y reservas en un sistema hospitalario. Es esencial tener en cuenta el diseño de la base de datos al ingresar datos de reservas y pacientes para garantizar su integridad y coherencia.

Uso de la API
Endpoints Disponibles
/api/Medico
/api/Paciente
/api/Reserva
Operaciones admitidas
Médicos
GET /api/Medico: Obtiene una lista de todos los médicos.
GET /api/Medico/{id}: Obtiene los detalles de un médico por su ID.
POST /api/Medico: Ingresa un nuevo médico.
PUT /api/Medico/{id}: Actualiza los detalles de un médico existente por su ID.
DELETE /api/Medico/{id}: Elimina un médico por su ID.
Pacientes
GET /api/Paciente: Obtiene una lista de todos los pacientes.
GET /api/Paciente/{id}: Obtiene los detalles de un paciente por su ID.
POST /api/Paciente: Ingresa un nuevo paciente.
PUT /api/Paciente/{id}: Actualiza los detalles de un paciente existente por su ID.
DELETE /api/Paciente/{id}: Elimina un paciente por su ID.
Reservas
GET /api/Reserva: Obtiene una lista de todas las reservas.
GET /api/Reserva/{id}: Obtiene los detalles de una reserva por su ID.
POST /api/Reserva: Ingresa una nueva reserva.
PUT /api/Reserva/{id}: Actualiza los detalles de una reserva existente por su ID.
DELETE /api/Reserva/{id}: Elimina una reserva por su ID.
Consideraciones sobre el diseño de la base de datos
Es crucial seguir un diseño de base de datos coherente al interactuar con los endpoints de la API para médicos, pacientes y reservas. La API está estructurada para trabajar con las siguientes entidades:

Medico: Representa a los médicos del hospital.
Paciente: Representa a los pacientes atendidos en el hospital.
Reserva: Representa las reservas realizadas por los pacientes.
Relaciones
Los médicos pueden estar asociados con varias reservas.
Los pacientes pueden tener múltiples reservas.
Las reservas se relacionan con médicos y pacientes.
Recomendaciones
Al ingresar datos de médicos, pacientes o reservas, asegúrate de mantener la coherencia en las relaciones establecidas entre estas entidades para evitar inconsistencias en la base de datos.

Este README proporciona una descripción general del uso de la API Hospital y destaca la importancia del diseño de la base de datos al interactuar con la misma. Asegúrate de adaptarlo a tus necesidades específicas y agregar más detalles si es necesario.