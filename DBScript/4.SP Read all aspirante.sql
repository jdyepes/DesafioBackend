CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_AspiranteReadAll`(	
)
BEGIN
	select * from aspirante;
END