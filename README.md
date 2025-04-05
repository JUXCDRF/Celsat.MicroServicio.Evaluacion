# Celsat.MicroServicio.Evaluacion

## PROCEDIMIENTOS
CREATE DATABASE Empleados
GO
USE Empleados
GO

-- Crear la tabla Empleados
CREATE TABLE Empleados (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100),
    Cargo NVARCHAR(100),
    FechaIngreso DATE,
    Email NVARCHAR(100)
);


DECLARE @i INT = 1;
WHILE @i <= 50
BEGIN
    INSERT INTO Empleados (Nombre, Cargo, FechaIngreso, Email)
    VALUES (
        'Empleado ' + CAST(@i AS NVARCHAR(3)),
        CASE 
            WHEN @i % 3 = 0 THEN 'Desarrollador'
            WHEN @i % 3 = 1 THEN 'Administrador'
            ELSE 'Analista'
        END,
        DATEADD(DAY, (ABS(CHECKSUM(NEWID())) % (DATEDIFF(DAY, '2021-01-01', '2024-12-31') + 1)), '2021-01-01'),       
        'empleado' + CAST(@i AS NVARCHAR(3)) + '@empresa.com'
    );
    SET @i = @i + 1;
END;
--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
CREATE PROCEDURE SP_ListarEmpleados
AS
BEGIN 
SELECT * FROM Empleados
END

EXEC SP_ListarEmpleados

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--CREAR UN EMPLEADO NUEVO, QUE A LA VES DEBE DE ACTUALIZAR REGISTRO SI EL ID SE ENCUENTRA
CREATE PROCEDURE CreatedEmpleado
@Id INT=NULL,
@Nombre NVARCHAR(100),
@Cargo NVARCHAR(100),
@FechaIngreso DATE,
@Email NVARCHAR(100)
AS
BEGIN
	IF(@Id IS NOT NULL)
		BEGIN
			UPDATE Empleados SET Nombre=@Nombre,Cargo=@Cargo,FechaIngreso=@FechaIngreso,Email=@Email WHERE Id=@Id;
		END
	ELSE
		BEGIN
			INSERT INTO Empleados(Nombre,Cargo,FechaIngreso,Email)VALUES(@Nombre,@Cargo,@FechaIngreso,@Email); 
		END	
END

--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

--LISTAR EMPLEADOS POR AÑO DE INGRESO (si pones el año de ingreso te muestra ese empleado, si no muestra todo el listado de empleados) 
CREATE PROCEDURE ListEmpleadoByYear
@FechaIngreso DATE=NULL
AS
BEGIN
	SELECT *FROM Empleados WHERE (@FechaIngreso IS NULL OR FechaIngreso=@FechaIngreso)
END

EXEC ListEmpleadoByYear '2022-04-12'
EXEC ListEmpleadoByYear 
