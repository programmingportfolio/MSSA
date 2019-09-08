Use TSQLV4;

--1.

select O.orderid, O.orderdate, O.custid, O.empid
from Sales.Orders as O
where orderdate =
(Select Max(O.orderdate) from Sales.Orders as O);

--2.
select top(1) O.custid, count(O.orderid) as ordercount
from Sales.Orders as O
group by custid
order by ordercount desc;

select top(1)custid, count(custid) as OrderCount
from Sales.Orders
group by custid
order by Ordercount desc;

select *
from Sales.Orders
where custid in (select top(1) with ties custid
from Sales.Orders
group by custid
order by count(custid) desc);

--3.
select empid
from HR.Employees
where empid not in (select empid
from Sales.Orders
where orderdate >= '2016-05-01'
group by empid)
order by empid asc;

--4.

select distinct country, custid
from Sales.Customers
where country not in (
select country
from Hr.Employees)
order by country;

--5.

select max(orderdate)
from Sales.Orders
where custid = 34;

select custid, orderid, orderdate, empid
from Sales.Orders as O
where orderdate = (select max(orderdate)
from Sales.Orders
where custid = O.custid)
order by custid desc;

--6.
select companyname, custid
from Sales.Customers AS C
where Exists (Select *
from Sales.Orders As O
where O.custid = C.custid
and O.orderdate >= '20150101'
and O.orderdate < '20160101')
and not exists
(select *
from Sales.Orders as O
where O.custid = C.custid
and O.orderdate >= '20160101'
and O.orderdate < '20170101');


use TSQLV5;
select companyname, custid
from Sales.Customers AS C
where Exists (Select *
from Sales.Orders As O
where O.custid = C.custid
and year(orderdate) = 2017)
and not exists
(select *
from Sales.Orders as O
where O.custid = C.custid
and year(orderdate) = 2018);

select custid, orderdate
from Sales.Orders as O
where orderdate = '2015';

select custid, orderdate
from Sales.Orders as O2
where orderdate = '2016';