sql.sql for answer number 2

how to run this project

1. open with vs code
2. create db and table open sql.sql
3. set your local database in appsettings.json
4. run dotnet run --urls=http://localhost:5001

## API Spec

### Warehouses API

#### Create Warehouse

Request :

- Method : POST
- Endpoint : `api/warehouses`
- Header :
  - Content-Type : application/json
  - Accept : application/json
- Body :

```json
{
  "name": "WarehouseX"
}
```

#### Get All Warehouses

Request :

- Method : GET
- Endpoint : `api/warehouses`
  - Header :
  - Accept : application/json

#### Get Warehouse By Id

Request :

- Method : GET
- Endpoint : `/api/warehouses/:id`
- Header :
  - Accept : application/json

Response :

- Status Code: 200 OK
- Body :

#### Update Warehouse

Request :

- Method : PUT
- Endpoint : `/api/warehouses/:id`
- Header :
  - Content-Type : application/json
  - Accept : application/json
- Body :

```json
{
  "name": "WarehouseX"
}
```

#### Delete Warehouse

Request :

- Method : DELETE
- Endpoint : `/api/warehouses/:id`
- Header :
  - Accept : application/json
- Body :

### Item API

#### Create Item

Request :

- Method : POST
- Endpoint : `/api/item`
- Header :
  - Content-Type : application/json
  - Accept : application/json
- Body :

```json
{
  "id": 1,
  "name": "Product A",
  "price": "10.00",
  "qty": 5,
  "exp_date": "2024-12-31",
  "id_warehouse": 1
}
```

#### Get All Item

Request :

- Method : GET
- Endpoint : `/api/item`
  - Header :
  - Accept : application/json

#### Get Item By Id

Request :

- Method : GET
- Endpoint : `/api/item/:id`
- Header :
  - Accept : application/json

Response :

- Status Code: 200 OK
- Body :

#### Update Item

Request :

- Method : PUT
- Endpoint : `/api/item/:id`
- Header :
  - Content-Type : application/json
  - Accept : application/json
- Body :

```json
{
  "id": 1,
  "name": "Product A",
  "price": "10.00",
  "qty": 5,
  "exp_date": "2024-12-31",
  "id_warehouse": 1
}
```

#### Delete Item

Request :

- Method : DELETE
- Endpoint : `/api/item/:id`
- Header :
  - Accept : application/json
- Body :
