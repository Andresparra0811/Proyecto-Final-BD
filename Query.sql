  CREATE TABLE Factura 
    (
     ID_Factura INTEGER identity NOT NULL , 
     Fecha_Generada_Factura DATE NOT NULL , 
     Productos VARCHAR (max) NOT NULL , 
     Usuario_ID INTEGER NOT NULL 
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
     Factura_ID_Factura INTEGER 
	 primary key(ID_Producto),
	 FK_ID_Factura integer not null,
	 CONSTRAINT FK_ID_Factura FOREIGN KEY (FK_ID_Factura)
        REFERENCES Factura (ID_Factura)
        ON DELETE CASCADE
        ON UPDATE CASCADE
    )
GO

CREATE TABLE Usuario 
    (
     ID INTEGER identity NOT NULL , 
     Nombre_usuario VARCHAR (100) NOT NULL , 
     Contraseña VARCHAR (100) NOT NULL 
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
	where usuario.Nombre_usuario = @usuario and Usuario.Contraseña = @pass

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


drop table Producto
drop table Factura
drop table Fecha_InicioSesion
drop table Usuario

select * from Fecha_InicioSesion
delete from Fecha_InicioSesion
insert into Usuario values ('Daniel', 'DAPQ')
insert into Usuario values ('Andres', 'ACPG')