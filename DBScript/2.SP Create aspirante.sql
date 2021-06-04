CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AspiranteCreate`(
	in _identificacion INT(10),
	in _nombre VARCHAR(20),
    in _apellido VARCHAR(20),
    in _edad INT(2),
    in _nombreCasa VARCHAR(100)
)
BEGIN
	insert into aspirante (
		identificacion, 
        nombre, 
        apellido, 
        edad,
        nombre_casa,
        fecha_creacion,
        fecha_modificacion
    ) 
    values (
		_identificacion,
		_nombre,
        _apellido,
        _edad,
        _nombreCasa,
        CURDATE(), -- fecha de creacion
        CURDATE() -- se coloca la misma fecha la primera vez de registro
    );

END