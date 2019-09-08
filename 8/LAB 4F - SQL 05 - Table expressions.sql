use Northwind;

--1. List the number of orders by each customer who lives in the United States using a CTE. Sort from highest to lowest.

with CustomerOrders as
(
select CustomerID, count(OrderID) as NumOrders
	from Orders
	where ShipCountry = 'USA'
	group by CustomerID
)
select * from CustomerOrders
	order by NumOrders;

--2. List the product name and the number of each product from a German supplier 
--sold to a customer in Germany using a CTE. Sort from highest to lowest.

with GermanySuppliers as 
(
select SupplierID from Suppliers
	where Country = 'Germany'
), GermanyProducts as
(
select ProductID, ProductName
	from Products as P
	join GermanySuppliers as S
	on P.SupplierID = S.SupplierID
), OrdersWithGermanProducts as
(
select distinct OD.OrderID, GP.ProductName, OD.Quantity
	from [Order Details] as OD
	join GermanyProducts as GP
	on OD.ProductID = GP.ProductID
), GermanCustomers as
(
select CustomerID from Customers
	where Country = 'Germany'
), OrdersbyGermanCusomters as
(
 select OrderID from Orders
	where CustomerID in (select CustomerID from GermanCustomers)
), GermanOrdersofGermanProducts as
(
select * from OrdersWithGermanProducts
	where OrderID in (select OrderID from OrdersbyGermanCusomters)
)
select ProductName, sum(Quantity) as TotalQty
	from OrdersWithGermanProducts
	group by ProductName
	order by TotalQty asc;

--or

with GermanCustomers as
(
select CustomerID from Customers
	where Country = 'Germany'
), GermanSuppliers as
(
select SupplierID from Suppliers
	where Country = 'Germany'
), [Orders by Germany Customers] as
(
select OrderID
	from Orders
	where CustomerID in (select CustomerID from GermanCustomers)
), [Products by German Suppliers] as
(
select ProductID, ProductName
	from Products 
	where SupplierID in (select SupplierID from GermanSuppliers)
), [German Order Details] as
(
select ProductName, Quantity
	from [Order Details] as OD
	join [Products by German Suppliers] as P
		on OD.ProductID = P.ProductID
	where OrderID     in (select OrderID from [Orders by Germany Customers])
)
select ProductName, sum(quantity) as TotalQTY
	from [German Order Details]
	group by ProductName
	order by TotalQTY desc;

--3. Prepare an employee report showing the name of each employee, the number of employees they supervise, 
--   and the name of their supervisor using a CTE. Sort by the number of employees supervised.



use TSQLV4;

--1.

Select orderid, orderdate, custid, empid,
DATEFROMPARTS(Year(orderdate), 12, 31) As endofyear
From Sales.Orders
Where orderdate <> DATEFROMPARTS(Year(orderdate), 12, 31);

--2.

select empid as ID, Max(orderdate) as [Max Order Date] 
from Sales.Orders
group by empid;

--or
select empid as ID, orderdate as [Max Order Date]
from Sales.Orders
group by empid, orderdate;


-- 2-2

select ID, custid, OID.[Max Order Date] from (select empid as ID, Max(orderdate) as [Max Order Date]
from Sales.Orders
group by empid) as OID
join Sales.Orders as O
on OID.[Max Order Date] = O.orderdate
and O.empid = OID.ID;

-- fun.
select top(5) OD.orderid, sum(OD.unitprice) as Maximum, SO.empid
from Sales.OrderDetails as OD
join Sales.Orders as SO
on SO.orderid = OD.orderid
    join Hr.Employees as E
    on E.empid = SO.empid
group by OD.orderid, SO.empid
order by Maximum desc;


-- Exercise 3

select orderid, orderdate, custid, empid, ROW_NUMBER() over(order by orderid, orderdate) as RowNum 
from Sales.Orders;

-- 3-2
with TableName as
(select orderid, orderdate, custid, empid, ROW_NUMBER() over(order by orderid, orderdate) as RowNum 
from Sales.Orders)
select * from TableName
where ROWNum >= 11
and ROWNum <= 20;
