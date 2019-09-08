Use TSQLV4;

--Luke Porter T-SQL Book Questions 2-9 20190815
--2. When using aliases, you have to refer to the aliases and not the original reference.
-- Change as to Customers and as to Orders or remove as Customers and make it From Sales.Customers

--3. Find all us customers
select * from Sales.Customers;

select Customers.custid as USAC
from Sales.Customers
    where country = 'USA';

select USAC.custid, COUNT(DISTINCT O.orderid) As numorders, SUM(OD.qty) AS totalqty
from Sales.Customers as USAC
inner join Sales.Orders as O
on USAC.custid = O.custid
inner join Sales.OrderDetails as OD
on O.orderid = OD.orderid
where country = 'USA'
group by USAC.custid;

--4. 

select C.custid, C.companyname, O.orderid, O.orderdate
from Sales.Customers as C
left join Sales.Orders as O
on O.custid = C.custid;


--5. 

select C.custid, C.companyname
from Sales.Customers as C
left join Sales.Orders as O
on C.custid = O.custid
where O.orderid IS NULL;


--6.
select C.custid, C.companyname, O.orderid, O.orderdate
from Sales.Customers as C
join Sales.Orders as O
on C.custid = O.custid
where O.orderdate = '2016-02-12';

--7.
select  C.custid, C.companyname, O.orderdate as HasOrderOn20160212
from Sales.Customers as C
left join Sales.Orders as O
on C.custid = O.custid
and O.orderdate = '20160212';

9.
select distinct c.companyname, case when 0.orderin is not null