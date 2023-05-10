if not exists (select 1 from dbo.Item)
begin
	insert into dbo.[Item] (Description,[Count],Price)
	values ('Pencil',50,1),
	('Hat',25,15),
	('Chair',10,25)
end