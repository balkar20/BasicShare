-- Create categories table
CREATE TABLE categories (
  category_id SERIAL PRIMARY KEY,
  category_name VARCHAR(255),
  description TEXT
);

-- Create customers table
CREATE TABLE customers (
  customer_id SERIAL PRIMARY KEY,
  customer_name VARCHAR(255),
  contact_name VARCHAR(255),
  address VARCHAR(255),
  city VARCHAR(255),
  postal_code VARCHAR(255),
  country VARCHAR(255)
);

-- Create products table
CREATE TABLE products (
  product_id SERIAL PRIMARY KEY,
  product_name VARCHAR(255),
  category_id INT REFERENCES categories(category_id),
  unit VARCHAR(255),
  price DECIMAL(10, 2)
);

-- Create orders table
CREATE TABLE orders (
  order_id SERIAL PRIMARY KEY,
  customer_id INT REFERENCES customers(customer_id),
  order_date DATE
);

-- Create order_details table
CREATE TABLE order_details (
  order_detail_id SERIAL PRIMARY KEY,
  order_id INT REFERENCES orders(order_id),
  product_id INT REFERENCES products(product_id),
  quantity INT
);

-- Create testproducts table
CREATE TABLE testproducts (
  testproduct_id SERIAL PRIMARY KEY,
  product_name VARCHAR(255),
  category_id INT REFERENCES categories(category_id)
);

-- Insert default data into categories table
INSERT INTO categories (category_name, description)
VALUES ('Category 1', 'Description 1'),
       ('Category 2', 'Description 2'),
       ('Category 3', 'Description 3');

-- Insert default data into customers table
INSERT INTO customers (customer_name, contact_name, address, city, postal_code, country)
VALUES ('Customer 1', 'Contact 1', 'Address 1', 'City 1', '12345', 'Country 1'),
       ('Customer 2', 'Contact 2', 'Address 2', 'City 2', '23456', 'Country 2'),
       ('Customer 3', 'Contact 3', 'Address 3', 'City 3', '34567', 'Country 3');

-- Insert default data into products table
INSERT INTO products (product_name, category_id, unit, price)
VALUES ('Product 1', 1, 'Unit 1', 10.99),
       ('Product 2', 2, 'Unit 2', 20.99),
       ('Product 3', 3, 'Unit 3', 30.99);

-- Insert default data into orders table
INSERT INTO orders (customer_id, order_date)
VALUES (1, '2021-01-01'),
       (2, '2021-02-01'),
       (3, '2021-03-01');

-- Insert default data into order_details table
INSERT INTO order_details (order_id, product_id, quantity)
VALUES (1, 1, 5),
       (1, 2, 10),
       (2, 2, 3),
       (3, 3, 8);

-- Insert default data into testproducts table
INSERT INTO testproducts (product_name, category_id)
VALUES ('Test Product 1', 1),
       ('Test Product 2', 2),
       ('Test Product 3', 3);