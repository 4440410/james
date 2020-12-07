USE [xzc]
GO
/****** Object:  StoredProcedure [dbo].[proc_SelectEInfo]    Script Date: 2020/3/25 14:02:57 ******/
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER OFF
GO
create proc proc_SelectEInfo
(
@id varchar (20),
@name varchar (30)

)
as
if(@id='' and @name='' )
 select * from d_base
else
begin
if(@id<>'')
  select * from d_base where NumbID=@id
else if(@name<>'')
   select * from d_base where UserName like @name

end