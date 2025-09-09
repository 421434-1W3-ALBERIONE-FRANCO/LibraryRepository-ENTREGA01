 CREATE PROCEDURE SP_INSERTAR_DETALLE

@factura int,
@libro int ,
@articulo int,
@cantidad int,
@precio decimal (10,2)


AS
BEGIN
     INSERT INTO detalle_facturas ( nro_factura,cod_libros, pre_unitario, cantidad) VALUES (@factura,@libro,@precio, @cantidad);
     
	-- SELECT @@IDENTITY -- DEVUELVE EL ULTIMO ID GENERADO POR EL ULTIMO USUARIO DENTRO DE ESTA TABLA
            
    END
GO
