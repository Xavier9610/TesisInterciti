create database DBInterciti;
go 
use DBInterciti;
go

create table tblTipoVehiculo(
idTipoVehiculo int identity (1,1) primary key,
tipo varchar(20)
);
go
create table tblMensaje(
idMensaje int identity (1,1) primary key,
mensaje varchar(100)
);
go

create table tblMarcaVehiculo(
idMarca int identity (1,1) primary key,
marca varchar(20)
);
go
create table tblModeloVehiculo(
idModelo int identity (1,1) primary key,
idMarca int foreign key (idMarca) references tblMarcaVehiculo (idMarca) ,
modelo varchar(50)
);
go

create table tblA�oVehiculo(
idA�o int identity (1,1) primary key,
a�o varchar(50)
);
go

create table tblVehiculo(
idVehiculo int identity (0,1) primary key,
idModelo int foreign key (idModelo) references tblModeloVehiculo (idModelo),
idA�o int foreign key (idA�o) references tblA�oVehiculo (idA�o),
idTipo int foreign key (idTipo) references tblTipoVehiculo (idTipoVehiculo),
placa varchar(10),
picture varbinary(max)
);
go

create table tblCliente(
idCliente int identity (1,1) primary key,
cedula varchar(10),
nombre varchar(30),
apellido varchar(30),
correo varchar(30),
telefono varchar(30),
fechaNacimiento datetime,
pass varchar(65),
tokenExternalLogin varchar(80),
picture varbinary(max)
);
go



create table tblAdmin(
idAdmin int identity (1,1) primary key,
cedula varchar(10),
nombre varchar(30),
apellido varchar(30),
correo varchar(30),
telefono varchar(30),
fechaNacimiento datetime,
pass varchar(65),
estado bit, 
tokenExternalLogin varchar(80),
picture varbinary(max)
);
go
create table tblEstadoRecorrido(
idEstadoRecorrido int identity (-1,1) primary key,
estado varchar(15));
go
create table tblConductor(
idConductor int identity (1,1) primary key,
cedula varchar(10),
nombre varchar(30),
apellido varchar(30),
correo varchar(30),
telefono varchar(30),
fechaNacimiento datetime,
idVehiculo int foreign key (idVehiculo) references tblVehiculo (idVehiculo),
pass varchar(65),
estadoConductor BIT , 
tokenExternalLogin varchar(80),
picture varbinary(max)
);
go



create table tblRecorrido(
idRecorrido int identity (1,1) primary key,
latitudOrigen DECIMAL(10,5) ,
longitudOrigen DECIMAL(10,5) ,
longitudDestino DECIMAL(10,5) ,
latitudDestino DECIMAL(10,5) ,
fechaRecorrido datetime,
valorRecorrido DECIMAL(5,2) ,
idConductor int foreign key (idConductor) references tblConductor (idConductor),
idCliente int foreign key (idCliente) references tblCliente (idCliente),
idEstadoRecorrido int foreign key (idEstadoRecorrido) references tblEstadoRecorrido (idEstadoRecorrido) ,
calificacion int,
comentario varchar(100),

);
go


create table tblUbicaciones(
idUbicacion int identity (1,1) primary key,
idCreador int foreign key (idCreador) references tblCliente (idCliente),
latitud DECIMAL(10,5),
longitud DECIMAL(10,5),
direccion varchar(100));
go

select * from tblAdmin


--tipo vehiculo
insert into tblTipoVehiculo values('Camioneta');
insert into tblTipoVehiculo values('Camion');
insert into tblTipoVehiculo values('Buseta');
insert into tblTipoVehiculo values('Furgon refrigerante');
--marca vehiciulo
insert into tblMarcaVehiculo values('KIA');
insert into tblMarcaVehiculo values('Toyota');
insert into tblMarcaVehiculo values('Hyundai');
insert into tblMarcaVehiculo values('ChangGan');
insert into tblMarcaVehiculo values('JAC');
insert into tblMarcaVehiculo values('Skoda');
insert into tblMarcaVehiculo values('MACK');
insert into tblMarcaVehiculo values('HINO');

--anio vehiculo
insert into tblA�oVehiculo values('1999');
insert into tblA�oVehiculo values('2000');
insert into tblA�oVehiculo values('2001');
insert into tblA�oVehiculo values('2002');
insert into tblA�oVehiculo values('2003');
insert into tblA�oVehiculo values('2004');
insert into tblA�oVehiculo values('2005');
insert into tblA�oVehiculo values('2006');
insert into tblA�oVehiculo values('2007');
insert into tblA�oVehiculo values('2008');
insert into tblA�oVehiculo values('2009');
insert into tblA�oVehiculo values('2010');
insert into tblA�oVehiculo values('2011');
insert into tblA�oVehiculo values('2012');
insert into tblA�oVehiculo values('2013');
insert into tblA�oVehiculo values('2014');
insert into tblA�oVehiculo values('2015');
insert into tblA�oVehiculo values('2016');
insert into tblA�oVehiculo values('2017');
insert into tblA�oVehiculo values('2018');
insert into tblA�oVehiculo values('2019');
insert into tblA�oVehiculo values('2020');
insert into tblA�oVehiculo values('2021');
insert into tblA�oVehiculo values('2022');
insert into tblA�oVehiculo values('2023');
---MODELO
insert into tblModeloVehiculo values(1,'SPORTAGE');
insert into tblModeloVehiculo values(1,'PICANTO');
insert into tblModeloVehiculo values(1,'STONIC');
insert into tblModeloVehiculo values(2,'LUV DMAX');
insert into tblModeloVehiculo values(2,'FORTUNER');
insert into tblModeloVehiculo values(3,'TUCSON');
insert into tblModeloVehiculo values(3,'IONIC');
insert into tblModeloVehiculo values(4,'V3');
insert into tblModeloVehiculo values(4,'CS15');
insert into tblModeloVehiculo values(5,'S2');
insert into tblModeloVehiculo values(5,'S3');
insert into tblModeloVehiculo values(6,'ENYAQ');
insert into tblModeloVehiculo values(6,'KODIAQ');
insert into tblModeloVehiculo values(7,'Granite');
insert into tblModeloVehiculo values(7,'B95');
insert into tblModeloVehiculo values(8,'NQR 915 EIII');
insert into tblModeloVehiculo values(8,'NLR 511 EIV');
select * from tblVehiculo
--VEHICULOS
insert into tblVehiculo values(1,1,1,'ASD-123',null);
insert into tblVehiculo values(2,1,1,'BGV-223',null);
insert into tblVehiculo values(4,1,2,'JHF-323',null);
insert into tblVehiculo values(5,1,2,'TGB-423',null);
insert into tblVehiculo values(5,1,2,'UJH-523',null);
insert into tblVehiculo values(6,1,3,'OLK-623',null);
insert into tblVehiculo values(7,1,3,'PLKJ-723',null);