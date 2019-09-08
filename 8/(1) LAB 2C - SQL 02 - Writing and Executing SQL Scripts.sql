use Northwind;

--Comments 
--1. what are the region?
select * from Region;
select RegionID, RegionDescription from Region
select count (1) from Region;
select count (*) from Region;

--2. What are the cities?
select * from Territories;
select TerritoryDescription
from Territories;

select TerritoryDescription as Cities
from Territories;

select TerritoryDescription as Cities
from Territories
order by Cities;

--3.what are the cities in the southern region?

select * from Region; 

select RegionID
from Region
where RegionDescription = 'Southern';


select * from Territories;

select *
from Territories
where RegionID = 4;




--4.How do you run this query with the fully qualified column name?
select *
from Territories
join Region
on Territories.RegionID = Region.RegionID
-- fully qualified column name always use these.
where RegionDescription = 'Southern';


--5.How do you run this query with a table alias?
select t.TerritoryDescription as Cities
from Territories as T 
join Region as R
on T.RegionID = R.RegionID -- can reference both values in select with join on
where RegionDescription = 'Southern'
order by T.TerritoryDescription asc;





--using subquery
select T.TerritoryDescription as Cities 
from Territories as T
where RegionID = (select RegionID
from Region
where RegionDescription = 'Southern')
order by Cities asc;

--6. what is the contact name city and phone number for each customer
select * from Customers;

select ContactName, Phone, City
from Customers;

--7. what products are out of stock
select * from Products order by UnitsInStock;

select * -- answer
from Products
where UnitsInStock= 0;

select *
from Products
where UnitsInStock != 0;

select *
from Products
where not UnitsInStock = 0;

select *
from Products
where not UnitsInStock > 0;

--8. what are the 10 products currently stock with the least ammount on hand

select top (10) *
from Products
where UnitsInStock > 0
order by UnitsInStock asc;

--this to look at specific items 
select top (10) ProductName, UnitsInStock
from Products
where UnitsInStock > 0
order by UnitsInStock asc;

--9. What are the five most expensive products in stock

select top(5) *
from Products
where UnitsInStock > 0
order by UnitPrice desc;

--10.How many products does Northwind have? How many customers? How many suppliers?

select count (*) as Products# from Products;
select count (*) as Customers# from Customers;
select count (*) as Supplieers# from Suppliers;




