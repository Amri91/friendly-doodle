--- Start
Go
IF EXISTS ( SELECT * from Sys.procedures Where name = 'uspGetCars')
BEGIN
	DROP PROC uspGetCars
END
Go
--- End
--- Start
Create proc uspGetCars
	@CarId int = NULL
as
IF (@CarId IS NOT NULL)
	BEGIN
		SELECT CarId, CarName, CompanyId from Cars where CarId = @CarId
	END
ELSE 
	BEGIN
		SELECT CarId, CarName, CompanyId from Cars
	END
--- End
--- Start
Go
IF EXISTS ( SELECT * from Sys.procedures Where name = 'uspInsertCar')
BEGIN
	DROP PROC uspInsertCar
END
Go
--- End
--- Start
Create proc uspInsertCar
	@CarName varchar(255),
	@CompanyId int,
	@CarId int output
as

BEGIN
	Insert into Cars(
		CarName,
		CompanyId
	) Values (
		@CarName,
		@CompanyId
	)
	SET @CarId = SCOPE_IDENTITY()
END
--- End
--- Start
Go
IF EXISTS ( SELECT * from Sys.procedures Where name = 'uspUpdateCar')
BEGIN
	DROP PROC uspUpdateCar
END
Go
--- End
--- Start
Create proc uspUpdateCar
	@CarName varchar(255) = null,
	@CompanyId int = null,
	@CarId int
as
BEGIN
IF ((@CarName is null or @CarName =  '') and @CompanyId IS NOT NULL)
	BEGIN
		Update Cars
		SET CarName = @CarName, CompanyId = @CompanyId
		Where CarId = @CarId
	END
ELSE
	BEGIN
		IF(@CompanyId IS NOT NULL)
			BEGIN
				Update Cars
				SET CompanyId = @CompanyId
				Where CarId = @CarId
			END
		ELSE
			BEGIN
				Update Cars
				SET CarName = @CarName
				Where CarId = @CarId
			END
	END
END
--- End
--- Start
Go
IF EXISTS ( SELECT * from Sys.procedures Where name = 'uspDeleteCar')
BEGIN
	DROP PROC uspDeleteCar
END
Go
--- End
--- Start
Create proc uspDeleteCar
	@CarId int
as
BEGIN
	Delete from Cars
	Where CarId = @CarId
END
--- End