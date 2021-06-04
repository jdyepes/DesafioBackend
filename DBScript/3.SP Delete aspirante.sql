CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AspiranteDelete`(
	in _identificacion INT(10) -- documento de identificacion
)
BEGIN
	delete from aspirante 	
    where identificacion = _identificacion ;

END