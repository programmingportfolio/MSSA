use Northwind;

-- 1. List the number of orders by each customers who lives in the United States using a CTE, sorting
-- from highest to lowest.

select * from Orders;


with CustomerOrders as 
(
select CustomerID, count(OrderID) as NumOrders
    from Orders
    where ShipCountry = 'USA'
    group by CustomerID
    )
    select * 
    from CustomerOrders
    order by NumOrders;

-- 2. List the product name and the number of each product from a german supplier sold
-- to a customer in germany using CTE. Sort from highest to lowest

select * from Suppliers where Suppliers.Country = 'Germany';

select * from Products where Products.SupplierID = ;


with GermanSuppliers as
(
select *
from Suppliers
where Country = 'Germany'
), GermanProducts as
(
select ProductID, P.SupplierID
from Products as P
join GermanSuppliers as S
on P.SupplierID = S.SupplierID
), OrdersWithGermanProducts as
(
select OD.OrderID, GB.ProductID
from [Order Details] as OD
join GermanProducts as GB
on OD.ProductID = GB.ProductID

)
select * from OrdersWithGermanProducts;






with GermanSuppliers as
(
select *
from Suppliers
where Country = 'Germany'
), GermanProducts as
(
select ProductID, P.SupplierID
from Products as P
join GermanSuppliers as S
on P.SupplierID = S.SupplierID
), OrdersWithGermanProducts as
(
select distinct OD.OrderID
from [Order Details] as OD
join GermanProducts as GB
on OD.ProductID = GB.ProductID

)
select * from OrdersWithGermanProducts;












with GermanSuppliers as
(
select *
from Suppliers
where Country = 'Germany'
), GermanProducts as
(
select ProductID, P.SupplierID
from Products as P
join GermanSuppliers as S
on P.SupplierID = S.SupplierID
), OrdersWithGermanProducts as
(
select distinct OD.OrderID
from [Order Details] as OD
join GermanProducts as GB
on OD.ProductID = GB.ProductID
), GermanCustomers as
(
select CustomerID
from Customers
where Country = 'Germany'
), OrdersByGermanCustomers as
(
select OrderID
from Orders
where CustomerID in (select CustomerID from GermanCustomers)
)
select * from GermanCustomers;


















with GermanSuppliers as
(
select *
from Suppliers
where Country = 'Germany'
), GermanProducts as
(
select ProductID, ProductName
from Products as P
join GermanSuppliers as S
on P.SupplierID = S.SupplierID
), OrdersWithGermanProducts as
(
select OD.OrderID, GB.ProductName, OD.Quantity
from [Order Details] as OD
join GermanProducts as GB
on OD.ProductID = GB.ProductID
), GermanCustomers as
(
select CustomerID
from Customers
where Country = 'Germany'
), OrdersByGermanCustomers as
(
select OrderID
from Orders
where CustomerID in (select CustomerID from GermanCustomers)
), GermanOrdersOfGermanProducts as
(
select *
from OrdersWithGermanProducts
where OrderID in (select OrderID from OrdersByGermanCustomers)
)

select ProductName, sum(Quantity) as TotalQty
from GermanOrdersOfGermanProducts
group by ProductName
order by TotalQty desc;

--Better method

-- Get product name and # from every german supplier to every german customer
-- highest to lowest sort.

select * from Customers
where Country = 'Germany';

select * from Suppliers
where Country = 'Germany';





with GermanCustomers as
(
select CustomerID from Customers
where Country = 'Germany'
), GermanSuppliers as
(
select SupplierID from Suppliers
where Country = 'Germany'
), [Orders by German Customers] as
(
select *
    from Orders
    where CustomerID in (select CustomerID from GermanCustomers)
), [Products by German Suppliers] as
(
select ProductID, ProductName
    from Products
    where SupplierID in (select SupplierID from GermanSuppliers)
), something as
(
select *
    from [Order Details]
    where Product in (select OrderID from [Orders by German Customers])
    where 
)
select 1;
