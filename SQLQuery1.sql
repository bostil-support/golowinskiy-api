Use Car_Prc2
go

Exec sp_SearchPicture @Cust_ID = 19139, @SearchDescr = 'Штаны'
go
Exec sp_SearchAvitoPictureAll @Cust_ID_Main = '19139'
go