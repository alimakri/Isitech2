select 1 col1, 'ABC' col2, getdate() col3, newid() col4
-- GUID Global unique identifier

select * into #t1 from
(
select 'A1' lettre, 1 lien
UNION ALL
select 'B1', 2 
UNION ALL
select 'C1', 3 
UNION ALL
select 'D1', 4 
) t

select * into #t2 from
(
select 'A2' lettre
UNION ALL
select 'B2'
UNION ALL
select 'C2'
UNION ALL
select 'D2'
) t

select * from #t1
select * from #t2


