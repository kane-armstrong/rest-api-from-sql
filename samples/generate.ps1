# This assumes the executable is in the same folder as this script

.\apigen.exe -c "Server=<server>;Initial Catalog=AdventureWorks2016CTP3;Persist Security Info=False;User ID=<user>;Password=<password>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=True;Connection Timeout=30;" -s "AdventureWorksApi" -o "c:\temp\generated code\AdventureWorksApi2" -p "AdventureWorksApi