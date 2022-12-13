create database DBIntercitiPrueba;
go 
use DBIntercitiPrueba;
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
create table tblRecorridoMensaje(
idRecorridoMensaje int identity (1,1) primary key,
idRecorrido int,
idMensaje int
);
go

create table tblModeloVehiculo(
idModelo int identity (1,1) primary key,
idMarca int,
modelo varchar(50)
);
go

create table tblAñoVehiculo(
idAño int identity (1,1) primary key,
año varchar(50)
);
go

create table tblMarcaVehiculo(
idMarca int identity (1,1) primary key,
marca varchar(20)
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
picture image
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
picture image
);
go

create table tblConductor(
idConductor int identity (1,1) primary key,
cedula varchar(10),
nombre varchar(30),
apellido varchar(30),
correo varchar(30),
telefono varchar(30),
fechaNacimiento datetime,
idVehiculo int,
pass varchar(65),
estadoConductor bit, 
tokenExternalLogin varchar(80),
picture image
);
go

create table tblVehiculo(
idVehiculo int identity (1,1) primary key,
idModelo int,
idAño int,
idTipo int,
idMarca int,
placa varchar(10),
picture image
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
idConductor int,
idCliente int,
idEstadoRecorrido int,
calificacion int,
comentario varchar(100),

);
go
create table tblEstadoRecorrido(
idEstadoRecorrido int identity (1,1) primary key,
estado varchar(15));
go

create table tblUbicaciones(
idUbicacion int identity (1,1) primary key,
idCreador int,
latitud DECIMAL(10,5),
longitud DECIMAL(10,5),
direccion varchar(100));
go
select * from tblAdmin

/*

--------------------------------------------------------datos de tabla
---admin
insert into tblAdmin values('1','Admin1',  'Garcia', 'patricio.garcia@du.ec','0960400373',  GETDATE() ,'abc123',1,'','')
insert into tblAdmin values('2','Admin2',  'Garcia', 'patrico.garcia@edu.ec','0960400373',  GETDATE() ,'abc123',1,'','')
insert into tblAdmin values('3','Admin3',  'Garcia', 'patricio.garcia@epn.ec','0960400373',  GETDATE() ,'abc123',1,'','')

--cliente
insert into tblCliente values('8','Cliente1',  'Garcia', 'patricio.garcia@edu.ec','0960400373',  GETDATE() ,'abc123','','')
insert into tblCliente values('9','Cliente2',  'Coronel', 'patricio.garcia@ec','0960400373',  GETDATE() ,'abc123','','')
insert into tblCliente values('10','Cliente3',  'Leon', 'patricio.garcia@epn.edu.ec','0960400373',  GETDATE() ,'abc123','','')
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
insert into tblAñoVehiculo values('1999');
insert into tblAñoVehiculo values('2000');
insert into tblAñoVehiculo values('2001');
insert into tblAñoVehiculo values('2002');
insert into tblAñoVehiculo values('2003');
insert into tblAñoVehiculo values('2004');
insert into tblAñoVehiculo values('2005');
insert into tblAñoVehiculo values('2006');
insert into tblAñoVehiculo values('2007');
insert into tblAñoVehiculo values('2008');
insert into tblAñoVehiculo values('2009');
insert into tblAñoVehiculo values('2010');
insert into tblAñoVehiculo values('2011');
insert into tblAñoVehiculo values('2012');
insert into tblAñoVehiculo values('2013');
insert into tblAñoVehiculo values('2014');
insert into tblAñoVehiculo values('2015');
insert into tblAñoVehiculo values('2016');
insert into tblAñoVehiculo values('2017');
insert into tblAñoVehiculo values('2018');
insert into tblAñoVehiculo values('2019');
insert into tblAñoVehiculo values('2020');
insert into tblAñoVehiculo values('2021');
insert into tblAñoVehiculo values('2022');
insert into tblAñoVehiculo values('2023');
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
insert into tblVehiculo values(1,1,1,1,'ASD-123');
insert into tblVehiculo values(2,1,1,1,'BGV-223');
insert into tblVehiculo values(4,1,1,2,'JHF-323');
insert into tblVehiculo values(5,1,1,2,'TGB-423');
insert into tblVehiculo values(5,1,1,2,'UJH-523');
insert into tblVehiculo values(6,1,1,3,'OLK-623');
insert into tblVehiculo values(7,1,1,3,'PLKJ-723');
---estado conductor


---Conductor
insert into tblConductor values('17','Conductor1',  'Garcia', 'garcia@du.ec','0960400373',  GETDATE(),1 ,'abc123',1,'','')
insert into tblConductor values('18','Conductor2',  'Garcia', 'g@du.ec','0960400373',  GETDATE(),2 ,'abc123',1,'','')
insert into tblConductor values('19','Conductor3',  'Garcia', 'patricio@du.ec','0960400373',  GETDATE(),3 ,'abc123',1,'','')

---estado recorrido
insert into tblEstadoRecorrido values('Reservado')
insert into tblEstadoRecorrido values('Espera')
insert into tblEstadoRecorrido values('Cancelado')
insert into tblEstadoRecorrido values('Realizado')
-----ubicaciones
insert into tblUbicaciones values(8,0,0,'')
insert into tblUbicaciones values(9,0,0,'')
insert into tblUbicaciones values(10,0,0,'')

-----recorrido

insert into tblRecorrido values(0.0,0.0,10.0,10.0,GETDATE(),2.5,2,3,2,4,'Buen servicio')
insert into tblRecorrido values(0.0,0.0,10.0,10.0,GETDATE(),5.5,19,9,5,5,'Los mejores')
insert into tblRecorrido values(0.0,0.0,10.0,10.0,GETDATE(),3.5,17,10,4,5,'Excelente servioio')

select * from tblRecorrido
select * from tblTipoVehiculo
select * from tblMarcaVehiculo
select * from tblModeloVehiculo
*/

delete from tblRecorrido where idConductor=19 or idConductor=17