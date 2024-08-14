	CREATE DATABASE sales_db;
	USE sales_db;
	
	CREATE TABLE salesman (
	    SALESMAN_ID NUMERIC(5) PRIMARY KEY,
	    NAME VARCHAR(30),
	    CITY VARCHAR(15),
	    COMMISSION DECIMAL(5, 2)
	);
	
	CREATE TABLE customer (
	    CUSTOMER_ID NUMERIC(5) PRIMARY KEY,
	    CUST_NAME VARCHAR(30),
	    CITY VARCHAR(15),
	    GRADE NUMERIC(3),
	    SALESMAN_ID NUMERIC(5),
	    FOREIGN KEY (SALESMAN_ID) REFERENCES salesman(SALESMAN_ID)
	);
	
	CREATE TABLE orders (
	    ORD_NO NUMERIC(5) PRIMARY KEY,
	    PURCH_AMT DECIMAL(8, 2),
	    ORD_DATE DATE,
	    CUSTOMER_ID NUMERIC(5),
	    SALESMAN_ID NUMERIC(5),
	    FOREIGN KEY (CUSTOMER_ID) REFERENCES customer(CUSTOMER_ID),
	    FOREIGN KEY (SALESMAN_ID) REFERENCES salesman(SALESMAN_ID)
	);