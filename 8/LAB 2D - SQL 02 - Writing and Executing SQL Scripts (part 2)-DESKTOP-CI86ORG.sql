--1. Who are our customers in North America?
use Northwind;

select * from Customers


select * 
from Customers
where Country = 'USA' or Country ='Mexico' or Country = 'Canada';

--is method is completing the same task as the one above 
select * 
from Customers
where Country in('USA','Mexico','Canada');

--2. What orders were placed in April, 1998?

select * from Orders;

select * 
from Orders
where OrderDate >= '1998-04-01' and OrderDate <'1998-05-01';


--this does the same function as the method above
select * 
from Orders
where year (OrderDate) = 1998 and month (OrderDate) = 4;




--3. What sauces do we sell?
select * from Categories

select * from Products
where CategoryID = 2;

select * from Products
where CategoryID= 2 and (ProductName like '%Sauce%' or 
ProductName like '%Soße%' or --German sauce
ProductName like '%Shouyu%');--Japanense sauce 


--4. You sell some kind of dried fruit that I liked very much. What is its name?
select * from Products

select *
from Products
Where ProductName like '%dri%';

select *
from [Order Details]
where ProductID in (7, 51)
order by Quantity;


--5. What employees ship products to Germany in December?


Select * from Orders;
select EmployeeID
from Orders where ShipCountry = 'Germany'

select *
from Employees
where EmployeeID in (select EmployeeID
from Orders
where ShipCountry = 'Germany' and
month(OrderDate)=12);

select LastName + ', ' + FirstName as Name 
from Employees
where EmployeeID in (select EmployeeID
from Orders
where ShipCountry = 'Germany' and
month(OrderDate)=12)
order by LastName;


--6. We have an issue with product 19. I need to know the total amount and the net amount of all orders for product 19 where the customer took a discount.
select * 
from Products
where ProductID = 19;

select OrderID, UnitPrice * Quantity as Total,
UnitPrice * Quantity * (1 - Discount) as Net
from [Order Details]
where ProductID = 19 and Discount > 0;

--7. I need a list of employees by title, first name, and last name, 
--with the employee’s position under their names, and a line separating each employee.
select * from Employees;

select TitleOfCourtesy + ' ' + FirstName + ' ' + LastName + char(10)
+ Title + char(10) + '-----------------------------------'
from Employees;





--8. I need a list of our customers and the first name only of the customer representative.
select * from Customers;

select CompanyName,  
substring(ContactName, 0, charindex(' ', ContactName)) as FirstName 
from Customers;

--9. Give me a list of our customer contacts alphabetically by last name.
select ContactName,
substring(ContactName, 1 + charindex(' ', ContactName), len(ContactName)) as LastName
from Customers
order by LastName;


select ContactName, 
-- '' as LastName,
reverse (ContactName),
'" '+ reverse (substring (reverse(ContactName), 0, charindex (' ', reverse(ContactName)))) + '"' as LastName
from Customers
order by LastName;


--10. How many days old are you today?
  
  select datediff_big (d, '1992-09-22', getdate());
  
  select getdate();