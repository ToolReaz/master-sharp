/*------------------------------------------------------------
*        Script SQLSERVER 
------------------------------------------------------------*/


/*------------------------------------------------------------
-- Table: Stocks
------------------------------------------------------------*/
CREATE TABLE Stocks(
	ID INT IDENTITY (1,1) NOT NULL ,
	CONSTRAINT prk_constraint_Stocks PRIMARY KEY NONCLUSTERED (ID)
);


/*------------------------------------------------------------
-- Table: Foods
------------------------------------------------------------*/
CREATE TABLE Foods(
	ID            INT IDENTITY (1,1) NOT NULL ,
	Name          VARCHAR (255) NOT NULL ,
	ID_Food_Types INT  NOT NULL ,
	CONSTRAINT prk_constraint_Foods PRIMARY KEY NONCLUSTERED (ID)
);


/*------------------------------------------------------------
-- Table: Food_Types
------------------------------------------------------------*/
CREATE TABLE Food_Types(
	ID   INT IDENTITY (1,1) NOT NULL ,
	Name VARCHAR (255) NOT NULL ,
	CONSTRAINT prk_constraint_Food_Types PRIMARY KEY NONCLUSTERED (ID)
);


/*------------------------------------------------------------
-- Table: Recipes
------------------------------------------------------------*/
CREATE TABLE Recipes(
	ID                   INT IDENTITY (1,1) NOT NULL ,
	Name                 VARCHAR (255) NOT NULL ,
	Preparation          TIME (2)  ,
	Cook                 TIME (2)  ,
	Rest                 TIME (2)  ,
	Description          VARCHAR (5000)  ,
	Side                 VARCHAR (255)  ,
	Number_Persons       INT  NOT NULL ,
	ID_Recipe_Categories INT  NOT NULL ,
	CONSTRAINT prk_constraint_Recipes PRIMARY KEY NONCLUSTERED (ID)
);


/*------------------------------------------------------------
-- Table: Utensils
------------------------------------------------------------*/
CREATE TABLE Utensils(
	ID      INT IDENTITY (1,1) NOT NULL ,
	Name    VARCHAR (255) NOT NULL ,
	ID_Size INT  NOT NULL ,
	CONSTRAINT prk_constraint_Utensils PRIMARY KEY NONCLUSTERED (ID)
);


/*------------------------------------------------------------
-- Table: Recipe_Categories
------------------------------------------------------------*/
CREATE TABLE Recipe_Categories(
	ID   INT IDENTITY (1,1) NOT NULL ,
	Name VARCHAR (255) NOT NULL ,
	CONSTRAINT prk_constraint_Recipe_Categories PRIMARY KEY NONCLUSTERED (ID)
);


/*------------------------------------------------------------
-- Table: Actions
------------------------------------------------------------*/
CREATE TABLE Actions(
	ID   INT IDENTITY (1,1) NOT NULL ,
	Name VARCHAR (255) NOT NULL ,
	CONSTRAINT prk_constraint_Actions PRIMARY KEY NONCLUSTERED (ID)
);


/*------------------------------------------------------------
-- Table: Size
------------------------------------------------------------*/
CREATE TABLE Size(
	ID   INT IDENTITY (1,1) NOT NULL ,
	Name VARCHAR (255) NOT NULL ,
	CONSTRAINT prk_constraint_Size PRIMARY KEY NONCLUSTERED (ID)
);


/*------------------------------------------------------------
-- Table: Dishes
------------------------------------------------------------*/
CREATE TABLE Dishes(
	ID   INT IDENTITY (1,1) NOT NULL ,
	Name VARCHAR (255) NOT NULL ,
	CONSTRAINT prk_constraint_Dishes PRIMARY KEY NONCLUSTERED (ID)
);


/*------------------------------------------------------------
-- Table: Textils
------------------------------------------------------------*/
CREATE TABLE Textils(
	ID   INT IDENTITY (1,1) NOT NULL ,
	Name VARCHAR (255) NOT NULL ,
	CONSTRAINT prk_constraint_Textils PRIMARY KEY NONCLUSTERED (ID)
);


/*------------------------------------------------------------
-- Table: Food_Stock
------------------------------------------------------------*/
CREATE TABLE Food_Stock(
	Quantity    INT  NOT NULL ,
	Expiry_Date DATETIME NOT NULL ,
	ID_Foods    INT  NOT NULL ,
	ID_Stocks   INT  NOT NULL ,
	CONSTRAINT prk_constraint_Food_Stock PRIMARY KEY NONCLUSTERED (ID_Foods,ID_Stocks)
);


/*------------------------------------------------------------
-- Table: Recipe_Step
------------------------------------------------------------*/
CREATE TABLE Recipe_Step(
	Food_Quantity INT  NOT NULL ,
	Number_Step   INT  NOT NULL ,
	ID_Foods      INT  NOT NULL ,
	ID_Recipes    INT  NOT NULL ,
	ID_Actions    INT  NOT NULL ,
	CONSTRAINT prk_constraint_Recipe_Step PRIMARY KEY NONCLUSTERED (ID_Foods,ID_Recipes,ID_Actions)
);


/*------------------------------------------------------------
-- Table: Utensil_Action
------------------------------------------------------------*/
CREATE TABLE Utensil_Action(
	ID_Actions  INT  NOT NULL ,
	ID_Utensils INT  NOT NULL ,
	CONSTRAINT prk_constraint_Utensil_Action PRIMARY KEY NONCLUSTERED (ID_Actions,ID_Utensils)
);


/*------------------------------------------------------------
-- Table: Textil_Stock
------------------------------------------------------------*/
CREATE TABLE Textil_Stock(
	Quantity   INT  NOT NULL ,
	Clean      bit  NOT NULL ,
	ID_Textils INT  NOT NULL ,
	ID_Stocks  INT  NOT NULL ,
	CONSTRAINT prk_constraint_Textil_Stock PRIMARY KEY NONCLUSTERED (ID_Textils,ID_Stocks)
);


/*------------------------------------------------------------
-- Table: Recipe_Dish
------------------------------------------------------------*/
CREATE TABLE Recipe_Dish(
	Quantity   INT  NOT NULL ,
	ID_Dishes  INT  NOT NULL ,
	ID_Recipes INT  NOT NULL ,
	CONSTRAINT prk_constraint_Recipe_Dish PRIMARY KEY NONCLUSTERED (ID_Dishes,ID_Recipes)
);


/*------------------------------------------------------------
-- Table: Dish_Stock
------------------------------------------------------------*/
CREATE TABLE Dish_Stock(
	Quantity  INT  NOT NULL ,
	Clean     bit  NOT NULL ,
	ID_Stocks INT  NOT NULL ,
	ID_Dishes INT  NOT NULL ,
	CONSTRAINT prk_constraint_Dish_Stock PRIMARY KEY NONCLUSTERED (ID_Stocks,ID_Dishes)
);


/*------------------------------------------------------------
-- Table: Utensil_Stock
------------------------------------------------------------*/
CREATE TABLE Utensil_Stock(
	Quantity    INT  NOT NULL ,
	Clean       bit  NOT NULL ,
	ID_Utensils INT  NOT NULL ,
	ID_Stocks   INT  NOT NULL ,
	CONSTRAINT prk_constraint_Utensil_Stock PRIMARY KEY NONCLUSTERED (ID_Utensils,ID_Stocks)
);



ALTER TABLE Foods ADD CONSTRAINT FK_Foods_ID_Food_Types FOREIGN KEY (ID_Food_Types) REFERENCES Food_Types(ID);
ALTER TABLE Recipes ADD CONSTRAINT FK_Recipes_ID_Recipe_Categories FOREIGN KEY (ID_Recipe_Categories) REFERENCES Recipe_Categories(ID);
ALTER TABLE Utensils ADD CONSTRAINT FK_Utensils_ID_Size FOREIGN KEY (ID_Size) REFERENCES Size(ID);
ALTER TABLE Food_Stock ADD CONSTRAINT FK_Food_Stock_ID_Foods FOREIGN KEY (ID_Foods) REFERENCES Foods(ID);
ALTER TABLE Food_Stock ADD CONSTRAINT FK_Food_Stock_ID_Stocks FOREIGN KEY (ID_Stocks) REFERENCES Stocks(ID);
ALTER TABLE Recipe_Step ADD CONSTRAINT FK_Recipe_Step_ID_Foods FOREIGN KEY (ID_Foods) REFERENCES Foods(ID);
ALTER TABLE Recipe_Step ADD CONSTRAINT FK_Recipe_Step_ID_Recipes FOREIGN KEY (ID_Recipes) REFERENCES Recipes(ID);
ALTER TABLE Recipe_Step ADD CONSTRAINT FK_Recipe_Step_ID_Actions FOREIGN KEY (ID_Actions) REFERENCES Actions(ID);
ALTER TABLE Utensil_Action ADD CONSTRAINT FK_Utensil_Action_ID_Actions FOREIGN KEY (ID_Actions) REFERENCES Actions(ID);
ALTER TABLE Utensil_Action ADD CONSTRAINT FK_Utensil_Action_ID_Utensils FOREIGN KEY (ID_Utensils) REFERENCES Utensils(ID);
ALTER TABLE Textil_Stock ADD CONSTRAINT FK_Textil_Stock_ID_Textils FOREIGN KEY (ID_Textils) REFERENCES Textils(ID);
ALTER TABLE Textil_Stock ADD CONSTRAINT FK_Textil_Stock_ID_Stocks FOREIGN KEY (ID_Stocks) REFERENCES Stocks(ID);
ALTER TABLE Recipe_Dish ADD CONSTRAINT FK_Recipe_Dish_ID_Dishes FOREIGN KEY (ID_Dishes) REFERENCES Dishes(ID);
ALTER TABLE Recipe_Dish ADD CONSTRAINT FK_Recipe_Dish_ID_Recipes FOREIGN KEY (ID_Recipes) REFERENCES Recipes(ID);
ALTER TABLE Dish_Stock ADD CONSTRAINT FK_Dish_Stock_ID_Stocks FOREIGN KEY (ID_Stocks) REFERENCES Stocks(ID);
ALTER TABLE Dish_Stock ADD CONSTRAINT FK_Dish_Stock_ID_Dishes FOREIGN KEY (ID_Dishes) REFERENCES Dishes(ID);
ALTER TABLE Utensil_Stock ADD CONSTRAINT FK_Utensil_Stock_ID_Utensils FOREIGN KEY (ID_Utensils) REFERENCES Utensils(ID);
ALTER TABLE Utensil_Stock ADD CONSTRAINT FK_Utensil_Stock_ID_Stocks FOREIGN KEY (ID_Stocks) REFERENCES Stocks(ID);
