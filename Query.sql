  Create database Supermercado
  Go
  
  use Supermercado
  go
  
  CREATE TABLE Factura 
    (
     ID_Factura INTEGER identity NOT NULL , 
     Fecha_Generada_Factura DATE NOT NULL , 
     Productos VARCHAR (max) NOT NULL , 
	 Nombre_Cliente varchar (100) not null,
	 cedula int not null,
	 primary key(ID_Factura),
	 )
	 
GO

CREATE TABLE Producto 
    (
     ID_Producto INTEGER identity NOT NULL , 
     Nombre VARCHAR (150) NOT NULL , 
     Cantidad TINYINT NOT NULL , 
	 Proveedor varchar (100) not null,
	 Precio Int not null,
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
 @Precio int,
 @accion varchar (50) OUTPUT
as
if (@accion='1')
begin
    insert into Producto values (@Nombre, @Cantidad, @Proveedor,@Precio)
    set @accion = 'Se inserto correctamente'
end
else if (@accion='2')
begin
    update Producto set Nombre = @Nombre, Cantidad = @Cantidad, Proveedor = @Proveedor, Precio = @Precio
    where ID_Producto = @ID_Producto
    set @accion = 'Se actualizo correctamente'
end
else if (@accion='3')
begin
    delete from Producto where ID_Producto = @ID_Producto
    set @accion = 'Se elimino correctamente'
end
go

create procedure spRegistroEnFactura
     @Fecha_Generada_Factura DATE, 
     @Productos VARCHAR (max), 
	 @Nombre_Cliente varchar (100),
	 @cedula int
 as
 begin
	insert into Factura values (@Fecha_Generada_Factura, @Productos,@Nombre_Cliente, @cedula)
		
end
go

create PROCEDURE pa_listar_productosFactura 
	@nombre_cliente varchar (100)
as
begin
    select cedula, Fecha_Generada_Factura, Productos from Factura
	where @nombre_cliente = Nombre_Cliente
end


drop table Producto
drop table Factura
drop table Fecha_InicioSesion
drop table Usuario

select * from Fecha_InicioSesion
select * from Usuario
select * from Producto
select * from Factura

delete from Fecha_InicioSesion
insert into Usuario values ('Daniel', 'DAPQ')
insert into Usuario values ('Andres', 'ACPG')

insert into Producto values ('chocorramo', 5, 'ramo', 5000)

 if object_id('pa_CUD') is not null
  drop procedure pa_CUD;

   if object_id('spLogin') is not null
  drop procedure spLogin;

if object_id('spRegistroEnFactura') is not null
  drop procedure spRegistroEnFactura;

insert into Producto values ('Arroz', 10, 'Arroz S.A',9000)
insert into Producto values ('Frijol', 10, 'Frijol S.A',6000)
insert into Producto values ('Papa', 10, 'Papa S.A',4500)
insert into Producto values ('Leche', 10, 'Leche S.A',5000)
insert into Producto values ('Huevos', 10, 'Huevos S.A',18000)
insert into Producto values ('Cafe', 10, 'Cafe S.A',10000)
insert into Producto values ('Azucar', 10, 'Azucar S.A',6000)
insert into Producto values ('Sal', 10, 'Sal S.A',3000)
insert into Producto values ('Aceite', 10, 'Aceite S.A',12000)
insert into Producto values ('Carne', 10, 'Carne S.A',24000)
insert into Producto values ('Pollo', 10, 'Pollo S.A',22000)
insert into Producto values ('Pescado', 10, 'Pescado S.A',16000)
insert into Producto values ('Pan', 10, 'Pan S.A',8000)
insert into Producto values ('Galletas', 10, 'Galletas S.A',6000)
insert into Producto values ('Jamon', 10, 'Jamon S.A',9700)
insert into Producto values ('Queso', 10, 'Queso S.A',7200)
insert into Producto values ('Cerveza', 10, 'Cerveza S.A',3700)
insert into Producto values ('Vino', 10, 'Vino S.A',58000)
insert into Producto values ('Cigarrillos', 10, 'Cigarrillos S.A',10000)


