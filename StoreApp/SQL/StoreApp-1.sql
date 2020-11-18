--DROP TABLE Customer
--DROP TABLE location
--DROP TABLE order_items
--DROP TABLE orders
--DROP TABLE products
--DROP TABLE store
--DROP TABLE store_periods
--DROP TABLE inventory

CREATE TABLE [customer] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [first_name] nvarchar(20) NOT NULL,
  [last_name] nvarchar(20) NOT NULL,
  [created_at] timestamp
)
GO

CREATE TABLE [location] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(20) NOT NULL
)
GO

CREATE TABLE [order_items] (
  [order_id] int,
  [product_id] int,
  [quantity] int 
)
GO

CREATE TABLE [orders] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [customer_id] int UNIQUE NOT NULL,
  [status] nvarchar(255),
  [created_at] timestamp
)
GO

CREATE TABLE [products] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [name] nvarchar(20) NOT NULL,
  [store_id] int NOT NULL,
  [price] decimal,
  [status] nvarchar(255) NOT NULL CHECK ([status] IN ('out_of_stock', 'in_stock', 'running_low')),
  [created_at] datetime DEFAULT (getdate())
)
GO

CREATE TABLE [store] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [location_id] int,
  [store_name] nvarchar(20) NOT NULL,
  [created at] timestamp
)
GO

CREATE TABLE [Inventory] (
  [id] int PRIMARY KEY IDENTITY(1, 1),
  [store_id] int,
  [product_id] int,
  [stock] int NOT NULL CHECK (stock >= 0)
)
GO


ALTER TABLE [store] ADD FOREIGN KEY ([location_id]) REFERENCES [location] ([id])
GO

ALTER TABLE [order_items] ADD FOREIGN KEY ([order_id]) REFERENCES [orders] ([id])
GO

ALTER TABLE [order_items] ADD FOREIGN KEY ([product_id]) REFERENCES [products] ([id])
GO

ALTER TABLE [orders] ADD FOREIGN KEY ([customer_id]) REFERENCES [customer] ([id])
GO

ALTER TABLE [Inventory] ADD FOREIGN KEY ([store_id]) REFERENCES [store] ([id])
GO

ALTER TABLE [Inventory] ADD FOREIGN KEY ([product_id]) REFERENCES [products] ([id])
GO

ALTER TABLE [products] ADD FOREIGN KEY ([store_id]) REFERENCES [store] ([id])
GO

CREATE INDEX [product_status] ON [products] ("store_id", "status")
GO

CREATE UNIQUE INDEX [products_index_1] ON [products] ("id")
GO

CREATE INDEX [store_index_2] ON [store] ("id", "location_id")
GO

EXEC sp_addextendedproperty
@name = N'Column_Description',
@value = 'When order created',
@level0type = N'Schema', @level0name = 'dbo',
@level1type = N'Table',  @level1name = 'orders',
@level2type = N'Column', @level2name = 'created_at';
GO


INSERT INTO Customer (
    first_name,
    last_name
)
VALUES
    (
        'Paul',
        'Cortez'

    );

INSERT INTO Customer (
    first_name,
    last_name
)
VALUES
    (
        'Grace',
        'See'

    );

INSERT INTO Customer (
    first_name,
    last_name
)
VALUES
    (
        'Rosel',
        'Pardillo'

    );

INSERT INTO Customer (
    first_name,
    last_name
)
VALUES
    (
        'Don',
        'Tai''Chi'

    );


SELECT * FROM Customer;


INSERT INTO store (
    
    location_id,
    store_name
)
VALUES
    (
      1,
      'Gaisano'
    );

INSERT INTO store (
    location_id,
    store_name
    
)
VALUES
    (
      2,
      'SM'
      
    );

INSERT INTO store (
    location_id,
    store_name
    
)
VALUES
    (
      3,
      'Mercury Drug'
      
    );

INSERT INTO store (
    location_id,
    store_name
    
)
VALUES
    (
      4,
      'Krogers'
      
    );

INSERT INTO store (
    location_id,
    store_name
   
)
VALUES
    (
      5,
      'Dollar Tree'
      
    );





SELECT * FROM Store;

INSERT INTO location (
    
    name
)
VALUES
    (
      
      'Texas'
    );

INSERT INTO location (
    
    name
)
VALUES
    (
      
      'Berlin'
    );

INSERT INTO location (
    
    name
)
VALUES
    (
      
      'Oslo'
    );

INSERT INTO location (
    
    name
)
VALUES
    (
      
      'Tokyo'
    );

INSERT INTO location (
    
    name
)
VALUES
    (
      
      'Nairubi'
    );

SELECT * from LOCATION;

INSERT INTO products (
    
    name,
    store_id,
    price,
    status
    
    
)
VALUES
    (
      
      'Vaseline',
      8,
      4,
      'in_stock'
      
      
    );

INSERT INTO products (
    
    name,
    store_id,
    price,
    status
)
VALUES
    (
      
      'Cola',
      9,
      5,
      'in_stock'
    );

INSERT INTO products (
    
    name,
    store_id,
    price,
    status
)
VALUES
    (
      
      'Choco',
      10,
      4,
      'in_stock'
    );

INSERT INTO products (
    
    name,
    store_id,
    price,
    status
)
VALUES
    (
      
      'Mango',
      11,
      1,
      'in_stock'
    );

INSERT INTO products (
    
    name,
    store_id,
    price,
    status
)
VALUES
    (
      
      'Grapes',
      12,
      2,
      'in_stock'
    );

INSERT INTO products (
    
    name,
    store_id,
    price,
    status
)
VALUES
    (
      
      'Strawberries',
      10,
      3,
      'in_stock'
    );

SELECT * from products

INSERT INTO Inventory (
    
    
    store_id,
    product_id,
    stock
)
VALUES
    (
      
      8,
      9,
      30
    );

INSERT INTO Inventory (
    
    
    store_id,
    product_id,
    stock
)
VALUES
    (
      
      9,
      10,
      40
    );

INSERT INTO Inventory (
    
    
    store_id,
    product_id,
    stock
)
VALUES
    (
      
      10,
      11,
      30
    );

INSERT INTO Inventory (
    
    
    store_id,
    product_id,
    stock
)
VALUES
    (
      
      11,
      12,
      40
    );

INSERT INTO Inventory (
    
    
    store_id,
    product_id,
    stock
)
VALUES
    (
      
      12,
      13,
      35
    );

SELECT * FROM Inventory;