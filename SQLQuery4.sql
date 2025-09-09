CREATE PROCEDURE  INSERTAR_MAESTRO
-- se evita poner fecha dado que va con la actual a la hora de ejecutar
 
@cliente varchar(50),
@vendedor varchar(50),
 
@id int output -- parametro de salida , como lo busco?

AS
BEGIN
     INSERT INTO facturas (fecha, cod_cliente,cod_vendedor) VALUES (GETDATE(),@cliente,@vendedor);
	 
	 -- VARIABLES DEL MOTOR
	 SET @id = SCOPE_IDENTITY();
	-- SELECT @@IDENTITY -- DEVUELVE EL ULTIMO ID GENERADO POR EL ULTIMO USUARIO DENTRO DE ESTA TABLA
	 
	 END
GO