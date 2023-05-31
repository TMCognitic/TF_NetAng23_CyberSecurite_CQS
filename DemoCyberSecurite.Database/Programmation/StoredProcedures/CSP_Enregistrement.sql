CREATE PROCEDURE [dbo].[CSP_Enregistrement]
	@Nom NVARCHAR(50), 
    @Prenom NVARCHAR(50), 
    @Email NVARCHAR(384), 
    @Passwd NVARCHAR(20)
AS
BEGIN
    IF LEN(TRIM(@Nom)) < 1
    BEGIN
        RAISERROR ('Nom invalide', 16, 1);
        RETURN 1;
    END

    IF LEN(TRIM(@Prenom)) < 1
    BEGIN
        RAISERROR ('Prenom invalide', 16, 1);
        RETURN 2;
    END

    IF LEN(TRIM(@Email)) < 1 AND @Email NOT LIKE '%@%.%'
    BEGIN
        RAISERROR ('Email invalide', 16, 1);
        RETURN 3;
    END

	INSERT INTO Utilisateur (Nom, Prenom, Email, Passwd)
    VALUES (@Nom, @Prenom, @Email, HASHBYTES('SHA2_512', CONCAT(dbo.CSF_PreSalt(), @Passwd, dbo.CSF_PostSalt())));

    RETURN 0;
END
