--- Start
Go
IF EXISTS ( SELECT * from Sys.procedures Where name = 'uspGetCompanies')
BEGIN
	DROP PROC uspGetCompanies
END
Go
--- End
--- Start
Create proc uspGetCompanies
	@CompanyId int = NULL
as
IF (@CompanyId IS NOT NULL)
	BEGIN
		SELECT CompanyId, CompanyName from Companies where CompanyId = @CompanyId
	END
ELSE 
	BEGIN
		SELECT CompanyId, CompanyName from Companies
	END
--- End
--- Start
Go
IF EXISTS ( SELECT * from Sys.procedures Where name = 'uspInsertCompany')
BEGIN
	DROP PROC uspInsertCompany
END
Go
--- End
--- Start
Create proc uspInsertCompany
	@CompanyName varchar(255),
	@CompanyId int output
as

BEGIN
	Insert into Companies(
		CompanyName
	) Values (
		@CompanyName
	)
	SET @CompanyId = SCOPE_IDENTITY()
END
--- End
--- Start
Go
IF EXISTS ( SELECT * from Sys.procedures Where name = 'uspUpdateCompany')
BEGIN
	DROP PROC uspUpdateCompany
END
Go
--- End
--- Start
Create proc uspUpdateCompany
	@CompanyName varchar(255),
	@CompanyId int

as

BEGIN
	Update Companies
	SET CompanyName = @CompanyName
	Where CompanyId = @CompanyId
END
--- End
--- Start
Go
IF EXISTS ( SELECT * from Sys.procedures Where name = 'uspDeleteCompany')
BEGIN
	DROP PROC uspDeleteCompany
END
Go
--- End
--- Start

Create proc uspDeleteCompany
	@CompanyId int
as
BEGIN
	Delete from Companies
	Where CompanyId = @CompanyId
END
--- End