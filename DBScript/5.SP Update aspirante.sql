CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AspiranteUpdate`(
	in _identificacion INT(10), -- documento de identificacion
	in _nombre VARCHAR(20),
    in _apellido VARCHAR(20),
    in _edad INT(2),
    in _nombreCasa VARCHAR(100)
)
BEGIN
	update aspirante 
		set 
        nombre = _nombre, 
        apellido = _apellido, 
        edad =  _edad,
        nombre_casa = _nombreCasa,     
        fecha_modificacion = CURDATE()
    where identificacion = _identificacion ;

END