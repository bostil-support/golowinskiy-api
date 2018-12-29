Use Car_Prc2
go

Exec sp_SearchPicture @Cust_ID = 19139, @SearchDescr = 'Штаны'
go
Exec sp_SearchAvitoPictureAll @Cust_ID_Main = '19139'
go

Exec sp_SearchCreateAvito @Catalog = '19139',@Id = '500663',@Ctlg_Name = 'Ветровка',@TArticle = 'null',@TName = 'product1',@TDescription = 'null',@TCost='null',@TImageprev='3.jpeg',@Appcode='19139',@TypeProd= 'null',@PrcNt = 'null',@TransformMech='null',@video='https://www.youtube.com/watch?v=b-D9ErP-eoA',@CID= 41609

go
Exec sp_SearchPictureInfo @Prc_ID = 18146,@Cust_ID = 19139,@AppCode = '19139'
Go

Exec sp_SearchCreateAvito @Catalog= '19139',@Id='500663',@Ctlg_Name= 'Вет', @TArticle= 'null',@TName= 'product1',@TDescription='null',@TCost= 'null',@TImageprev='3.jpeg',@Appcode='19139',@TypeProd= 'null',@PrcNt='null',@TransformMech= 'null',@video= 'https://www.youtube.com/watch?v=b-D9ErP-eoA',@CID = 41609
go
  
Exec sp_SearchUpdateAvito  @Catalog= '19139',@Id='500663',@Ctlg_Name= 'Вет', @TArticle= 'null',@TName= 'product1',@TDescription='null',@TCost= 'null',@TImageprev='3.jpeg',@Appcode='19139',@TypeProd= 'null',@PrcNt='null',@TransformMech= 'null',@video= 'https://www.youtube.com/watch?v=b_aF8enlwVE',@CID = 41609
go  
  
  
  
  
  
  
  
  
  