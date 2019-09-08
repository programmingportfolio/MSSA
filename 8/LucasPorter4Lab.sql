Use Northwind;



--1. Create a reporte that shows this produce name and supplier d for all productssupplied exotic liquids grandma kelly's homstead
-- and tokyo traders

--Easier to read same as join or subquery no processing difference, may be easier to read, maybe


select * from Suppliers;

select * from Suppliers where CompanyName ='Tokyo Traders';
select * from Suppliers where CompanyName ='Exotic Liquids';
select * from Suppliers where CompanyName ='Grandma Kelly''s Homestead';


select SupplierID
from Suppliers
where CompanyName in ('Tokyo Traders'
								, 'Exotic Liquids'
								, 'Grandma Kelly''s Homestead');

select ProductName
from Products
where SupplierID in (select SupplierID
				from Suppliers
				where CompanyName in ('Tokyo Traders'
								, 'Exotic Liquids'
								, 'Grandma Kelly''s Homestead'));


-- 2. create a report that shows all products by name that are in the seafood category.

select * from Categories;
select * 
    from Categories
    where CategoryName = 'Seafood';


select ProductName
from Products
where CategoryID = (select CategoryID
			from Categories
			where CategoryName = 'Seafood');

select P.ProductName
from Products as P
join Categories as C
on P.CategoryID = C.CategoryID
where C.CategoryName = 'Seafood';


-- 3. Create a report that shows all companies by name that sell products in category ID 8 
-- 4. Create a report that shows all companies by name that sell products in Seafood Category 

select distinct SupplierID
from Products
where CategoryID = (select CategoryID
			from Categories
			where CategoryName = 'Seafood');

-- fast way to just find more information directly related with the other queries put parens around and call it.

select CompanyName
from Suppliers
where SupplierID in (
			  select distinct SupplierID
				from Products
				where CategoryID = (select CategoryID
				from Categories
				where CategoryName = 'Seafood'));


select CompanyName
from Suppliers
where SupplierID in (
			  select SupplierID
				from Products
				where CategoryID = (select CategoryID
				from Categories
				where CategoryName = 'Seafood'));

-- 5. Create a reportthat lists the ten most expensive products

select * from Products
select top(10) ProductName, UnitPrice
    from Products
    order by UnitPrice desc;



 -- 6. Create a report that show the date of the last order by all employees

 select * from Orders order by EmployeeID, OrderDate;

 select EmployeeID, max(OrderDate) -- greatest and needs that single value and the group by makes it so that they both have only 1 row of data. Max makes sense
 from Orders
 group by EmployeeID
 order by EmployeeID;


 select EmployeeID, max(OrderDate) 
 from Orders
 group by EmployeeID
 order by EmployeeID;



 select E.FirstName, E.LastName, L.LastOrder
 from Employees as E
 join ( select EmployeeID, max(OrderDate) as LastOrder
 from Orders
 group by EmployeeID) as L
 on E.EmployeeID = L.EmployeeID
 order by E.EmployeeID;

