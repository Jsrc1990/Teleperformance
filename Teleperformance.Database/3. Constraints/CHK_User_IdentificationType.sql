ALTER TABLE [User]
ADD CONSTRAINT CHK_User_IdentificationType CHECK
(
--CÉDULA
--El nombre de la compañia NO debe ser digitado, y el primer nombre y primer apellido deben ser digitados
(
IdentificationTypeId = '32722B70-940C-4A9E-BFAF-5BA391432040'
AND CompanyName = '' AND TRIM(FirstName) <> '' AND TRIM(FirstLastName) <> ''
)
--NIT
--El nombre de la compañia debe ser digitado, y el primer nombre, segundo nombre, primer apellido, segundo apellido NO deben ser digitados
OR
(
(
IdentificationTypeId = '8D048425-B821-4CA2-AEA9-9B64B036E09B' OR IdentificationTypeId = '9B2D9580-F56F-4AA7-8FEE-0BFB986E6B9B')
AND TRIM(CompanyName) <> '' AND FirstName = '' AND SecondName = '' AND FirstLastName = '' AND SecondLastName = ''
)
)