use master
go

if exists(select * from Sysdatabases where name = 'ObligatorioFarmacia2')
begin
	drop database ObligatorioFarmacia2
end
go

create database ObligatorioFarmacia2
go

use ObligatorioFarmacia2
go

------------------------------TABLAS----------------------------------------------

create table Empleado
(
	Usuario varchar (30) not null primary key,
	Contraseña varchar (30) not null,
	NombreEmp varchar (30) not null
)
go

create table Clientes
(
		Ci int not null primary key check(ci between 1000000 AND 999999999),
		NumTelefonico varchar (9) not null check (numTelefonico NOT LIKE '%[^0-9]%'),
		NumTarjeta varchar (20) not null check (numTarjeta NOT LIKE '%[^0-9 ]%'),
		NombreCli varchar (30) not null
)
go


create table Categorias
(
		CodigoC varchar (6) not null primary key check(len(CodigoC) = 6 and CodigoC not like '%[^a-zA-Z0-9]%'),
		NombreCat varchar (30) not null									  
)
go

create table Articulos
(
	Codigo varchar (10) not null primary key check(len(Codigo) = 10 and Codigo not like '%[^a-zA-Z0-9]%'),
	NombreArt varchar (15) not null,
	Precio int not null check (Precio >= 0),
	TipoPresentacion varchar (7) not null check (TipoPresentacion in ('Unidad', 'Blister', 'Sobre', 'Frasco')),
	Tamaño int not null,
	CodigoC varchar (6) not null,
	foreign key (CodigoC) references Categorias(CodigoC)	
)
go

create table Ventas
(
	NumVenta int not null primary key identity (1,1),
	FechaRealizada datetime not null default getdate(),
	Estado varchar (10) not null check (estado in ('Armado', 'Envío', 'Entregado', 'Devuelto')),
	Direccion varchar (50) not null,
	Cantidad int not null,
	Codigo varchar (10) not null check(len(Codigo) = 10 and Codigo not like '%[^a-zA-Z0-9]%'),
	Usuario varchar (30) not null,
	Ci int not null check(ci between 1000000 AND 999999999),
	foreign key (Codigo) references Articulos(Codigo),
	foreign key (Usuario) references Empleado(Usuario),
	foreign key (Ci) references Clientes(Ci)
)
go


----------------------------- DATOS DE PRUEBA -----------------------------------------

 insert into Empleado (Usuario, Contraseña, NombreEmp) values ('Juancito', 'Montevideo2025', 'Juan'),
														      ('Rodriguez', 'Canelones2021', 'Rodrigo'),
															  ('Fernandez', 'Durazno2019', 'Fernando'),
															  ('Ramirez', 'SanJose2015', 'Ramiro'),
															  ('Santos', 'Rivera2020', 'Luis'),
															  ('Zalayeta', 'Rocha2012', 'Agustin'),
															  ('Layston', 'RioNegro2001', 'Mario'), 
															  ('Roston', 'Soriano2019', 'Marcos'),
															  ('Falcon', 'Tacuarembo2010', 'Franco'),
															  ('Sotel', 'Florida2005', 'Alvaro')


insert into Clientes (Ci, NumTelefonico, NumTarjeta, NombreCli) values (42349832, '094853413', '4539148803436467', 'German'),
																	   (52249845, '096289314', '4539148846895745', 'Ana'),
																	   (32347345, '096594819', '4539148821350987', 'Carlos'),
																	   (45449812, '098838917', '4539148887544567', 'Maria'),
																       (53434421, '095234711', '4539148813675674', 'Andrea'),
																	   (42349809, '096645312', '4539148895362452', 'Ian'),
																	   (52899845, '099643217', '4539148874135234', 'Francisco'),
																	   (22459609, '096579049', '4539148895629045', 'Jose'),
																	   (42365498, '096349875', '4539148846317886', 'Julian'),
																	   (42369875, '097543265', '4539148845674532', 'Rodrigo'),
																       (54123547, '095324576', '4539148868524567', 'Ricardo')	

insert into Categorias (CodigoC, NombreCat) values ('aca209', 'Analgesico muscular'),
												   ('bca309', 'Antibiótico'),
												   ('cca409', 'Antialergico'),
												   ('dca509', 'Antiinflamatorio'),
												   ('eca609', 'Anestesico'),
												   ('fca709', 'Ginecologia'),
												   ('gca809', 'Analgesicos'),
												   ('hca909', 'Antigripales'),
												   ('ica109', 'Antivirales'),
												   ('jca009', 'Endocrinologia')


insert into Articulos (Codigo, NombreArt, Precio, TipoPresentacion, Tamaño, CodigoC) values ('AZURA45637', 'Ibuprofeno', 300, 'Blister', 9, 'aca209'),
																						    ('AZIBU45621', 'Paracetamol', 250, 'Blister', 9, 'aca209'),
																						    ('AZASP45682', 'Aspirina', 150, 'Blister', 6, 'aca209'),

                                                                                            ('AZMOX45422', 'Moxifar', 800, 'Blister', 10, 'bca309'),
																						    ('AZAMM45682', 'Amoxidal', 1000, 'Sobre', 250, 'bca309'),
																						    ('AZAMO45689', 'Amoxicilina', 400, 'Frasco', 90, 'bca309'),

																						    ('AZBER46465', 'Berodual', 1000, 'Unidad', 1, 'cca409'),
																						    ('AZDOL76552', 'Dolosedol', 100, 'Sobre', 10, 'cca409'),
																						    ('AZAMM45432', 'Kalitron', 400, 'Frasco', 120, 'cca409'),

																						    ('AZKEF43465', 'Kefentech', 1500, 'Unidad', 20, 'dca509'),
																				            ('AZPRE46732', 'Prednicort', 400, 'Blister', 20, 'dca509'),
																						    ('AZDOL46543', 'Dolcox', 300, 'Blister', 10, 'dca509'),

																						    ('AZDIC48876', 'Diclofenac', 450, 'Sobre', 50, 'eca609'),
																						    ('AZXEF47352', 'Xylo-Efa', 350, 'Frasco', 250, 'eca609'),
																						    ('AZBEF86745', 'Bupy-Efa', 800, 'Frasco', 20, 'eca609')


insert into Ventas (FechaRealizada, Estado, Direccion, Cantidad, Codigo, Usuario, Ci) values 
																				(getdate(), 'Entregado', 'Gonzalo Ramirez 8762', 1, 'AZPRE46732', 'Juancito', 42349832),
																				(getdate(), 'Envío', '18 de Julio 9843', 1, 'AZIBU45621', 'Rodriguez', 52249845),
																				(getdate(), 'Entregado', 'Bulevar Artigas 9823', 1, 'AZIBU45621', 'Fernandez', 32347345),
																				(getdate(), 'Devuelto', 'Bulevar España 238', 1, 'AZIBU45621', 'Ramirez', 45449812),
																				(getdate(), 'Devuelto', 'Defensa 762', 1, 'AZKEF43465', 'Santos', 53434421),
																				(getdate(), 'Armado', 'Justicia 920', 1, 'AZKEF43465', 'Zalayeta', 42349809),
																				(getdate(), 'Armado', 'Galicia 271', 1, 'AZDOL76552', 'Layston', 52899845),
																				(getdate(), 'Entregado', 'Cuareim 980', 1, 'AZDOL76552', 'Roston', 22459609),
																				(getdate(), 'Entregado', 'Benito Blanco 2872', 1, 'AZDIC48876', 'Falcon', 42365498),
																				(getdate(), 'Entregado', '21 de Setiembre 9812', 1, 'AZBEF86745', 'Sotel', 42369875),
																				(getdate(), 'Envío', 'Carlos Quijano 4782', 1, 'AZURA45637', 'Juancito', 42349832),
																				(getdate(), 'Envío', 'Wilson Ferreira Aldunate 298', 1, 'AZURA45637', 'Rodriguez', 52249845),
																				(getdate(), 'Armado', 'Colonia 762', 1, 'AZBEF86745', 'Fernandez', 32347345),
																				(getdate(), 'Envío', 'Mercedes 8729', 1, 'AZDOL46543', 'Ramirez', 45449812),
																				(getdate(), 'Entregado', 'Uruguay 980', 1, 'AZAMO45689', 'Santos', 53434421),
																				(getdate(), 'Devuelto', 'Joaquin de Salterain 9820', 1, 'AZAMO45689', 'Zalayeta', 42349809),
																				(getdate(), 'Armado', 'Justicia 920', 1, 'AZKEF43465', 'Layston', 52899845)


------------------------------------------ PROCEDIMIENTOS ALMACENADOS ----------------------------------------------

--- Formulario : Default

create proc FormularioNoEnDev
as
begin
	select * from Ventas where Estado not in ('Entregado', 'Devuelto') 
end
go

--exec FormularioNoEnDev

create proc BuscarEmp
@usuario varchar(30)
as
begin
	select * from Empleado where Usuario = @usuario
end
go

--- Formulario : Logueo Empleado

create proc LogueoEmpleado
@usuario varchar(30),
@contraseña varchar(30),
@resultado int output,
@nombre varchar(30) output
as
begin
	

	if exists (select 1 from Empleado where usuario = @usuario and contraseña = @contraseña)
		begin
			set @resultado = 1

			   set @nombre = (select NombreEmp from Empleado where usuario = @usuario)
		end
	else
		begin
			set @resultado = 0
			set @nombre = null
		end
end
go

--declare @resultado int
--exec LogueoEmpleado @usuario = 'Santos', @contraseña = 'Rivera2020', @resultado = @resultado output
--select @resultado

--- Formulario : ABM de Categorías

create proc BuscarCat
@codigoC varchar(6)
as
begin
	select * from Categorias where CodigoC = @codigoC
end
go

--exec BuscarCat 'dca509'

create proc AltaCategorias
@codigoC varchar(6),
@nombre varchar(30)
as
begin
	if exists (select CodigoC from Categorias where CodigoC = @codigoC)
		return -1
	declare @Error int

	insert Categorias(CodigoC, NombreCat) values(@codigoC, @nombre)
		set @Error = @@ERROR

		if(@Error = 0)
			return 1
		else
			return -2
end
go

create proc ModificarCategorias
@codigoC varchar(6),
@nombre varchar(30)
as
begin
	declare @Error int
	
	if not exists (select 1 from Categorias where CodigoC = @codigoC)
		return -1

	update Categorias
	set NombreCat = @nombre
	where CodigoC = @codigoC and NombreCat != @nombre

	set @Error = @@ERROR

	if(@Error = 0)
		return 1
	else
		return -2
end
go


create proc EliminarCategorias
@codigoC varchar(6)
as
begin
	if not exists (select * from Categorias where CodigoC = @codigoC)
		return -1

	if exists (select @codigoC from Articulos where CodigoC = @CodigoC)
		return -2

	delete from Categorias where CodigoC = @codigoC

end
go


--- Formulario : ABM Artículos

create proc BuscarArt
@codigo varchar(10)
as
begin
	select * from Articulos where codigo = @codigo
end
go

create proc AltaArticulos
@codigo varchar(10),
@nombre varchar (30),
@precio int,
@tipoPresentacion varchar (7),
@tamaño int,
@codigoC varchar (6)

as
begin
	if exists (select codigo from Articulos where codigo = @codigo)
		return -1

	declare @Error int

	insert Articulos(Codigo, NombreArt, Precio, TipoPresentacion, Tamaño, CodigoC) 
	values(@codigo, @nombre, @precio, @tipoPresentacion, @tamaño, @codigoC)
		set @Error = @@ERROR

	if(@Error = 0)
		return 1
	else
		return -2
	
end
go

create proc ModificarArticulos
@codigo varchar(10),
@nombre varchar (30),
@precio int,
@tipoPresentacion varchar (7),
@tamaño int,
@codigoC varchar (6)

as
begin
	if not exists (select Codigo from Articulos where Codigo = @codigo)
		return -1

	declare @Error int

	update Articulos
	set NombreArt = @nombre, Precio = @precio, tipoPresentacion = @tipoPresentacion, tamaño = @tamaño, codigoC = @codigoC
	where codigo = @codigo 
	set @Error = @@ERROR

	if (@Error = 0)
		return 1
	else
		return -2
		
end
go

create proc eliminarArticulos
@codigo varchar(10)

as
begin

	if not exists (select * from Articulos where codigo = @codigo)
		return -1
		
	if exists (select @codigo from Ventas where codigo = @codigo)
		return -2
		
	delete from Articulos where codigo = @codigo
		return 1

end
go


------ Formulario : ABM de Clientes

create proc BuscarClie
@ci int
as
begin
	select * from Clientes where Ci = @ci
end
go

create proc AltaClientes
@ci int,
@numTarjeta varchar (20),
@numTelefonico varchar (9),
@nombre varchar (30)

as
begin
	if exists (select Ci from Clientes where Ci = @ci)
		return -1

	declare @Error int

	insert Clientes(Ci, NumTarjeta, NumTelefonico, NombreCli) values(@ci, @numTarjeta, @numTelefonico, @nombre)
		set @Error = @@ERROR

	if(@Error = 0)
		return 1
	else
		return -2
	
end
go

create proc ModificarClientes
@ci int,
@numTarjeta varchar (20),
@numTelefonico varchar (9),
@nombre varchar (30)

as
begin
	if not exists (select Ci from Clientes where Ci = @ci)
		return -1

	declare @Error int

	update Clientes
	set NumTarjeta = @numTarjeta, NumTelefonico = @numTelefonico, NombreCli = @nombre
	where Ci = @ci
	set @Error = @@ERROR

	if (@Error = 0)
		return 1											  
	else
		return -2
		
end
go

create proc EliminarClientes
@ci int

as
begin

	if not exists (select * from Clientes where Ci = @ci)
			return -1
	
	if exists (select * from Ventas where Ci = @ci)
			return -2
		
		delete from Clientes where Ci = @ci 
			return 1

end
go

----- Formulario : Alta Venta

create proc AltaVenta
@codigo varchar (10),
@ci int,
@direccion varchar (50),
@cantidad int,
@usuario varchar (30)

as
begin

	declare @Error int

	if not exists (select *  from Articulos where Codigo = @codigo)
		return -1
	
	if not exists (select * from Clientes where Ci = @ci)
		return -2

	insert into Ventas (FechaRealizada, Estado, Direccion, Cantidad, Codigo, Ci, Usuario)
			values(getdate(), 'Armado', @direccion, @cantidad, @codigo, @ci, @usuario)

		set @Error = @@ERROR

	if(@Error = 0)
		return 1
	else
		return -3
end
go


----- Formulario : Seguimiento de Venta

create proc EstadoActual
 @numVenta int
	  
as
begin
	select * from Ventas where NumVenta = @numVenta
end
go	

create proc SeguimientoVenta
@numVenta int
as
begin
	declare @estadoActual varchar (15)
	declare @nuevoEstado varchar (15)
	declare @Error int

	select @estadoActual = Estado from Ventas where numVenta = @numVenta
		if @estadoActual is null
			return -1
		if @estadoActual = 'Devuelto'
			return -2
		set @nuevoEstado = case WHEN @estadoActual = 'Armado' THEN 'Envío'    
								WHEN @estadoActual = 'Envío' THEN 'Entregado' 
								WHEN @estadoActual = 'Entregado' THEN 'Devuelto'  
						   END 
	if @nuevoEstado is not null
		update Ventas
		set Estado = @nuevoEstado
		where NumVenta = @numVenta
		set @Error = @@ERROR

	if (@Error = 0)
		return 1											  
	else
		return -3
end
go


---- Formulario : Listado Interactivo Artículos

create proc ListaCategorias
as
begin
	select * from Categorias
end 
go

create proc ListaArticulosXCategorias
@codigoC varchar(6)
as
begin
	select * from Articulos where CodigoC = @codigoC
end
go

create proc DatosArticulo
@codigo varchar (10)
as
begin
	select * from Articulos where Codigo = @codigo
end
go

create proc ListarVentasXArticulo
@codigo varchar(10)
as
begin
	select * from Ventas where Codigo = @codigo
	order by FechaRealizada desc
end
go

create proc VentaCompleta
@numVenta int
as
begin
	select * from Ventas where NumVenta = @numVenta
end
go

--- Formulario : Listado Interactivo Clientes

create proc ListarClientes
as
begin
	select * from Clientes
end
go

create proc ListaVentasXCliente
@ci int
as
begin
	select * from Ventas where ci = @ci
	order by fechaRealizada desc
end
go

create proc ListaArtxClie
@ci int
as
begin
    select distinct a.codigo, a.nombreArt, a.precio, a.tipoPresentacion, a.tamaño, a.codigoC
    from Articulos a
    INNER JOIN Ventas v on a.codigo = v.codigo
    where v.ci = @ci
    order by a.nombreArt asc
end
go

create proc MontoTotal
@ci int
as
begin
    select SUM(a.precio * v.cantidad) as MontoTotal
    from Articulos a
    inner join Ventas v on a.codigo = v.codigo
    where v.ci = @ci
end
go





																



























