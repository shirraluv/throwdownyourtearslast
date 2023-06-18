-- 
-- Set character set the client will use to send SQL statements to the server
--
SET NAMES 'utf8';

--
-- Set default database
--
USE throwdownyourtears;

--
-- Create table `user`
--
CREATE TABLE user (
  id int NOT NULL AUTO_INCREMENT,
  Name varchar(50) NOT NULL DEFAULT '',
  Lastname varchar(255) NOT NULL DEFAULT '',
  Login varchar(255) NOT NULL DEFAULT '',
  Password varchar(255) NOT NULL DEFAULT '',
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 16,
AVG_ROW_LENGTH = 5461,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create table `shop`
--
CREATE TABLE shop (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(50) NOT NULL DEFAULT '',
  iduser int NOT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 20,
AVG_ROW_LENGTH = 2340,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create foreign key
--
ALTER TABLE shop
ADD CONSTRAINT FK_shop_user_id FOREIGN KEY (iduser)
REFERENCES user (id);

--
-- Create table `stats`
--
CREATE TABLE stats (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(50) DEFAULT NULL,
  quantity int DEFAULT NULL,
  gain int DEFAULT NULL,
  shopid int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 12,
AVG_ROW_LENGTH = 5461,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create foreign key
--
ALTER TABLE stats
ADD CONSTRAINT FK_stats_shop_id FOREIGN KEY (shopid)
REFERENCES shop (id);

--
-- Create table `products`
--
CREATE TABLE products (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(50) NOT NULL DEFAULT '',
  price int NOT NULL,
  quantity int NOT NULL,
  PurchasePrice int DEFAULT 0,
  productsales int DEFAULT 0,
  productgain int DEFAULT 0,
  minimum varchar(255) NOT NULL DEFAULT '',
  productbuys int DEFAULT 0,
  productgain2 int DEFAULT 0,
  shopid int NOT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 49,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create foreign key
--
ALTER TABLE products
ADD CONSTRAINT FK_products_shop_id FOREIGN KEY (shopid)
REFERENCES shop (id);

--
-- Create table `provider`
--
CREATE TABLE provider (
  id int NOT NULL AUTO_INCREMENT,
  name varchar(50) DEFAULT NULL,
  telegram varchar(255) DEFAULT NULL,
  productid int NOT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create foreign key
--
ALTER TABLE provider
ADD CONSTRAINT FK_provider_products_id FOREIGN KEY (productid)
REFERENCES products (id);

--
-- Create table `historysale`
--
CREATE TABLE historysale (
  id int NOT NULL AUTO_INCREMENT,
  productname varchar(255) DEFAULT NULL,
  productquantity int DEFAULT NULL,
  gain int DEFAULT NULL,
  shopid int DEFAULT NULL,
  Date datetime DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 34,
AVG_ROW_LENGTH = 2340,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create foreign key
--
ALTER TABLE historysale
ADD CONSTRAINT FK_historysale_shop_id FOREIGN KEY (shopid)
REFERENCES shop (id);

--
-- Create table `historybuy`
--
CREATE TABLE historybuy (
  id int NOT NULL AUTO_INCREMENT,
  productname varchar(255) DEFAULT NULL,
  productquantity int DEFAULT NULL,
  buys int DEFAULT NULL,
  shopid int DEFAULT NULL,
  Date datetime DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
AUTO_INCREMENT = 15,
AVG_ROW_LENGTH = 4096,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create foreign key
--
ALTER TABLE historybuy
ADD CONSTRAINT FK_historybuy_shop_id FOREIGN KEY (shopid)
REFERENCES shop (id);

--
-- Create table `generalsales`
--
CREATE TABLE generalsales (
  id int NOT NULL AUTO_INCREMENT,
  generalgain int DEFAULT NULL,
  generalgain2 int DEFAULT NULL,
  generalbuys int DEFAULT NULL,
  generalquantity int DEFAULT NULL,
  shopid int DEFAULT NULL,
  PRIMARY KEY (id)
)
ENGINE = INNODB,
CHARACTER SET utf8mb4,
COLLATE utf8mb4_0900_ai_ci;

--
-- Create foreign key
--
ALTER TABLE generalsales
ADD CONSTRAINT FK_generalsales_shop_id FOREIGN KEY (shopid)
REFERENCES shop (id);