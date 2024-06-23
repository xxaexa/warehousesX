-- 1 
CREATE DATABASE inventory_db;

CREATE TABLE warehouses (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL
);

CREATE TABLE items (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    price DECIMAL(10, 2) NOT NULL,
    qty INT NOT NULL,
    exp_date VARCHAR(255) NOT NULL,
    id_warehouse INT,
    FOREIGN KEY (id_warehouse) REFERENCES warehouses(id)
);

CREATE INDEX idx_code_warehouses ON items(id_warehouse);

--2
DELIMITER //

CREATE PROCEDURE GetWarehouseItems (
    IN pageNumber INT,
    IN pageSize INT
)
BEGIN
    DECLARE offset INT;
    SET offset = (pageNumber - 1) * pageSize;
    
    SET @sql = CONCAT(
        'SELECT w.id AS warehouse_code, w.name AS warehouse_name, ',
        'i.id AS item_code, i.name AS item_name, i.price AS item_price, ',
        'i.count AS item_count, i.exp_date AS item_exp_date ',
        'FROM warehouses w ',
        'JOIN items i ON w.id = i.id_warehouse ',
        'LIMIT ', offset, ', ', pageSize
    );

    PREPARE stmt FROM @sql;
    EXECUTE stmt;
    DEALLOCATE PREPARE stmt;
END //

DELIMITER ;


--3
DELIMITER //

CREATE PROCEDURE ListMonitoring (
    IN warehouseName VARCHAR(255),
    IN expirationDate DATE
)
BEGIN
    SET @sql = CONCAT(
        'SELECT w.id AS warehouse_code, w.name AS warehouse_name, ',
        'i.id AS item_code, i.name AS item_name, i.price AS item_price, ',
        'i.count AS item_count, i.exp_date AS item_exp_date ',
        'FROM warehouses w ',
        'JOIN items i ON w.id = i.id_warehouse ',
        'WHERE 1=1 '
    );

    IF warehouseName IS NOT NULL AND warehouseName != '' THEN
        SET @sql = CONCAT(@sql, ' AND w.name = ?');
    END IF;

    IF expirationDate IS NOT NULL THEN
        SET @sql = CONCAT(@sql, ' AND i.exp_date = ?');
    END IF;

    PREPARE stmt FROM @sql;
    
    IF warehouseName IS NOT NULL AND warehouseName != '' AND expirationDate IS NOT NULL THEN
        EXECUTE stmt USING warehouseName, expirationDate;
    ELSEIF warehouseName IS NOT NULL AND warehouseName != '' THEN
        EXECUTE stmt USING warehouseName;
    ELSEIF expirationDate IS NOT NULL THEN
        EXECUTE stmt USING expirationDate;
    ELSE
        EXECUTE stmt;
    END IF;

    DEALLOCATE PREPARE stmt;
END //

DELIMITER ;
