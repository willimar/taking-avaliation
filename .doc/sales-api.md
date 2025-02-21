[Back to README](../README.md)

### Sales

#### GET /sales
- Description: Retrieve a list of all sales
- Query Parameters:
  - `_page` (optional): Page number for pagination (default: 1)
  - `_size` (optional): Number of items per page (default: 10)
  - `_order` (optional): Ordering of results (e.g., "price desc, title asc")
- Response: 
  ```json
  {
    "data": [
      {
	"id": "integer",
	"number": "integer",
	"date": "date",
	"customerName": "string",
	"cpfCnpjCustomer": "string",
	"totalValue": "number",
	"companyName": "string",
	"userName": "string",
	"status": "integer"
	"products": [{
		"name": "string",
        	"count": "integer",
		"unityValue": "number",
		"discount": "number",
		"totalUnityValue": "number"
		"canceled": "boolean"
        }]
      }
    ],
    "totalItems": "integer",
    "currentPage": "integer",
    "totalPages": "integer"
  }
  ```

#### POST /sales
- Description: Add a new sale
- Request Body:
  ```json
  {
	"customerName": "string",
	"cpfCnpjCustomer": "string",
	"companyName": "string",
	"userName": "string",
	"products": [{
		"name": "string",
		"count": "integer",
		"unityValue": "number",
		"canceled": "boolean"
	}]
  }
  ```
- Response: 
  ```json
  {
	"id": "integer",
	"number": "integer",
	"date": "date",
	"customerName": "string",
	"cpfCnpjCustomer": "string",
	"totalValue": "number",
	"companyName": "string",
	"userName": "string",
	"status": "integer"
	"products": [{
		"name": "string",
		"count": "integer",
		"unityValue": "number",
		"discount": "number",
		"totalUnityValue": "number"
		"canceled": "boolean"
	}]
  }
  ```

#### GET /sales/{id}
- Description: Retrieve a specific sale by ID
- Path Parameters:
  - `id`: Sale ID
- Response: 
  ```json
  {
	"id": "integer",
	"number": "integer",
	"date": "date",
	"customerName": "string",
	"cpfCnpjCustomer": "string",
	"totalValue": "number",
	"companyName": "string",
	"userName": "string",
	"status": "integer"
	"products": [{
		"name": "string",
		"count": "integer",
		"unityValue": "number",
		"discount": "number",
		"totalUnityValue": "number"
		"canceled": "boolean"
	}]
  }
  ```

#### DELETE /sales/{id}
- Description: Delete a specific sale
- Path Parameters:
  - `id`: Sale ID
- Response: 
  ```json
  {
    "message": "string"
  }
  ```

#### GET /sales/categories
- Description: Retrieve all sale categories
- Response: 
  ```json
  [
    "string"
  ]
  ```

<br>
<div style="display: flex; justify-content: space-between;">
  <a href="./general-api.md">Previous: General API</a>
  <a href="./carts-api.md">Next: Carts API</a>
</div>
