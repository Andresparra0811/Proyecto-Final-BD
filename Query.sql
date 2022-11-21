  Create database Supermercado
  Go
  
  use Supermercado
  go
  
  CREATE TABLE Factura 
    (
     ID_Factura INTEGER identity NOT NULL , 
     Fecha_Generada_Factura DATE NOT NULL , 
     Productos VARCHAR (max) NOT NULL , 
	 primary key(ID_Factura),
	 FK_Id_Usuario Integer not null,
	 CONSTRAINT FK_ID_Usuario FOREIGN KEY (FK_Id_Usuario)
        REFERENCES Usuario (ID)
        ON DELETE CASCADE
        ON UPDATE CASCADE
    )
GO

CREATE TABLE Producto 
    (
     ID_Producto INTEGER identity NOT NULL , 
     Nombre VARCHAR (150) NOT NULL , 
     Cantidad TINYINT NOT NULL , 
	 Proveedor TINYINT not null,
	 primary key(ID_Producto),
	 
    )
GO

CREATE TABLE Usuario 
    (
     ID INTEGER identity NOT NULL , 
     Nombre_usuario VARCHAR (100) NOT NULL , 
     Contrasena VARCHAR (100) NOT NULL 
	 primary key(ID)
    )
GO


CREATE TABLE Fecha_InicioSesion 
    (
     ID_Fecha INTEGER identity NOT NULL , 
     Fecha smalldatetime NOT NULL , 
     Nombre_Usuario varchar (100) NOT NULL 
	 primary key(ID_Fecha)
    )
GO


create procedure spLogin
	 @usuario varchar (100),
	 @pass varchar (100)
 as
 begin
	select top 1 COUNT(*) from Usuario
	where usuario.Nombre_usuario = @usuario and Usuario.Contrasena = @pass

end
go

create procedure sp_FechaSesion
	 @usuario varchar (100),
	 @fecha smalldatetime
 as
 begin
	insert into Fecha_InicioSesion values (@fecha, @usuario)

end
go


create PROCEDURE pa_listar_productos 
as
begin
    select * from Producto
end

create proc pa_buscar_producto
@nombre varchar(40)
as select * from Producto
where Nombre like @nombre+'%'

go

CREATE procedure pa_CUD
 @ID_Producto int,
 @Nombre varchar (150),
 @Cantidad tinyint,
 @Proveedor varchar (150),
 @accion varchar (50) OUTPUT
as
if (@accion='1')
begin
    insert into Producto values (@Nombre, @Cantidad, @Proveedor)
    set @accion = 'Se inserto correctamente'
end
else if (@accion='2')
begin
    update Producto set Nombre = @Nombre, Cantidad = @Cantidad, Proveedor = @Proveedor
    where ID_Producto = @ID_Producto
    set @accion = 'Se actualizo correctamente'
end
else if (@accion='3')
begin
    delete from Producto where ID_Producto = @ID_Producto
    set @accion = 'Se elimino correctamente'
end
go




drop table Producto
drop table Factura
drop table Fecha_InicioSesion
drop table Usuario

select * from Fecha_InicioSesion
select * from Usuario
delete from Fecha_InicioSesion
insert into Usuario values ('Daniel', 'DAPQ')
insert into Usuario values ('Andres', 'ACPG')

 if object_id('pa_CUD') is not null
  drop procedure pa_CUD;

   if object_id('spLogin') is not null
  drop procedure spLogin;