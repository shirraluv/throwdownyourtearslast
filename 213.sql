-- 
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE throwdownyourtears;

--
-- Create table `provider`
--
CREATE TABLE provider (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(50) DEFAULT '',
  telegramid varchar(255) DEFAULT '',
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 126,
AVG_ROW_LENGTH = 5461,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create table `shop`
--
CREATE TABLE shop (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(50) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 2,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create table `products`
--
CREATE TABLE products (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(50) DEFAULT NULL,
  price varchar(255) DEFAULT NULL,
  quantity int DEFAULT NULL,
  PurchasePrice varchar(255) DEFAULT NULL,
  productsales int DEFAULT 0,
  productgain int DEFAULT 0,
  minimum varchar(255) DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 15,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create table `productsprovider`
--
CREATE TABLE productsprovider (
  id int NOT NULL AUTO_INCREMENT,
  products_id int DEFAULT NULL,
  provider_id int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 5,
AVG_ROW_LENGTH = 16384,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create foreign key
--
ALTER TABLE productsprovider
ADD CONSTRAINT FK_productsprovider_products_id FOREIGN KEY (products_id)
REFERENCES products (id);

--
-- Create foreign key
--
ALTER TABLE productsprovider
ADD CONSTRAINT FK_productsprovider_provider_id FOREIGN KEY (provider_id)
REFERENCES provider (id);

--
-- Create table `productshop`
--
CREATE TABLE productshop (
  id int NOT NULL AUTO_INCREMENT,
  productid int DEFAULT NULL,
  shopid int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 5,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create foreign key
--
ALTER TABLE productshop
ADD CONSTRAINT FK_productshop_products_id FOREIGN KEY (productid)
REFERENCES products (id);

--
-- Create foreign key
--
ALTER TABLE productshop
ADD CONSTRAINT FK_productshop_shop_id FOREIGN KEY (shopid)
REFERENCES shop (id);

--
-- Create table `generalsales`
--
CREATE TABLE generalsales (
  id int NOT NULL AUTO_INCREMENT,
  generalgain int DEFAULT NULL,
  generalquantity int DEFAULT NULL,
  productsid int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 40,
AVG_ROW_LENGTH = 420,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create foreign key
--
ALTER TABLE generalsales
ADD CONSTRAINT FK_generalsales_products_id FOREIGN KEY (productsid)
REFERENCES products (id);