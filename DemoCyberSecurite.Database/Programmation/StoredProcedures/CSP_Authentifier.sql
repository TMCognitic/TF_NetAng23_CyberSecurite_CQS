CREATE PROCEDURE [dbo].[CSP_Authentifier]
	@Email NVARCHAR(384), 
    @Passwd NVARCHAR(20)
AS
BEGIN
	SELECT Id, Nom, Prenom, @Email AS Email FROM Utilisateur
	WHERE Email = @Email AND Passwd = HASHBYTES('SHA2_512', CONCAT(dbo.CSF_PreSalt(), @Passwd, dbo.CSF_PostSalt()));
	RETURN 0
END
