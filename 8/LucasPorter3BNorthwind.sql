use Northwind;

--1. What is the order number and date of each order sold by each employee?

select * from Orders;

select OrderId, OrderDate, O.EmployeeID
from Orders as O;

select * from Employees;

select EmployeeId, E.FirstName + ' ' + E.LastName as Name
from Employees as E;


select OrderId, OrderDate, --O.EmployeeID, 
/*E.EmployeeID,*/ E.FirstName + ' ' + E.LastName as Name
    from Orders as O
	  join Employees as E
	  on O.EmployeeID = E.EmployeeID;


--2. List each territory by region

select *
    from Territories as T
	  join Region as R
	  on T.RegionID = R.RegionID;

select TerritoryDescription, R.RegionDescription
    from Territories as T
	  join Region as R
	  on T.RegionID = R.RegionID;


select T.TerritoryDescription + 'is in the ' + R.RegionDescription + 'region.'
    from Territories as T
	  join Region as R
	  on T.RegionID = R.RegionID
    order by T.TerritoryDescription asc;

select T.TerritoryDescription, R.RegionDescription
    from Territories as T
	  join Region as R
	  on T.RegionID = R.RegionID
    order by T.TerritoryDescription asc;

--3. What is the supplier name for each product aplpha by supplier

select * from Products;
select * from Suppliers;

select S.CompanyName, P.ProductName
    from Products as P
	  join Suppliers as S
	  on P.SupplierID = S.SupplierID
order by S.CompanyName asc;

--4. For every order on May 5, 1998, how many of each item was ordered, 
-- and what was the price?

select * from Orders;

select *
    from Orders
    where OrderDate = '1998-05-05';

select *
    from Orders as O
	  join [Order Details] as OD
	  on O.OrderId = OD.OrderID
	  where OrderDate = '1998-05-05';

select ProductID
    from Orders as O
	  join [Order Details] as OD
	  on O.OrderId = OD.OrderID
    where OrderDate = '1998-05-05'
    group by OD.ProductID;


-- invalid
select ProductID, OD.UnitPrice
    from Orders as O
	  join [Order Details] as OD
	  on O.OrderId = OD.OrderID
    where OrderDate = '1998-05-05'
    group by OD.ProductID;


select OD.ProductID, OD.UnitPrice
    from Orders as O
	  join [Order Details] as OD
	  on O.OrderId = OD.OrderID
    where OrderDate = '1998-05-05'
    group by OD.ProductID, OD.UnitPrice;


-- group by goes first before distinct so distinct will always return 1

select OD.ProductID, OD.UnitPrice, count(ProductID)
    from Orders as O
	  join [Order Details] as OD
	  on O.OrderId = OD.OrderID
    where OrderDate = '1998-05-05'
    group by OD.ProductID, OD.UnitPrice
    order by ProductID;


--5. For each order on May 5, 1998, how many of each item was ordered, giving the name of the item
-- and the price.

select P.ProductName, OD.ProductID, OD.UnitPrice, count(OD.ProductID) as NumOrdered
    from Orders as O
	  join [Order Details] as OD
	  on O.OrderId = OD.OrderID
		join Products as P
		on OD.ProductID = P.ProductID
    where OrderDate = '1998-05-05'
    group by P.ProductName, OD.ProductID, OD.UnitPrice
    order by OD.ProductID;


--6. For every order in May, 1998, what was the customer's name and the shipper's name

select * from Orders;

select *
    from Orders as O
    where month(O.OrderDate) = 5 and year(O.OrderDate) = 1998;

select O.OrderID, C.CompanyName, S.CompanyName
    from Orders as O
	  join Shippers as S
	  on O.ShipVia = S.ShipperID
	  join Customers as C
	  on O.CustomerID = C.CustomerID
    where month(O.OrderDate) = 5 and year(O.OrderDate) = 1998
    order by O.OrderID;

--7. What is the customer's name and the employee's name for every order shipped to France

select * from Orders;

select *
    from Orders as O
    where O.ShipCountry = 'France';


select O.OrderID
    from Orders as O
    where O.ShipCountry = 'France'
    order by O.OrderID;

select O.OrderID, C.CompanyName, 
E.FirstName + ' ' +  E.LastName as EmployeeName
    from Orders as O
	  join Customers as C
	  on O.CustomerID = C.CustomerID
	  join Employees as E
	  on O.EmployeeID = E.EmployeeID
    where O.ShipCountry = 'France'
    order by O.OrderID;

--8. List the products by name that were shipped to Germany

select O.OrderID
    from Orders as O
    where O.ShipCountry = 'Germany'
    order by O.OrderID;


select distinct P.ProductName
    from Orders as O
	  join [Order Details] as OD
	  on O.OrderID = OD.OrderID
		join Products as P
		on P.ProductID = OD.ProductID
    where O.ShipCountry = 'Germany'
    order by P.ProductName;

    