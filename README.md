<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Smart Inventory Management System API - README</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            margin: 0 auto;
            padding: 20px;
            max-width: 900px;
            background-color: #f8f9fa;
        }
        h1, h2 {
            color: #007bff;
        }
        pre {
            background: #eee;
            padding: 10px;
            border-radius: 5px;
        }
        code {
            color: #d63384;
        }
        table {
            width: 100%;
            border-collapse: collapse;
            margin: 20px 0;
            background: #fff;
        }
        table, th, td {
            border: 1px solid #ddd;
        }
        th, td {
            padding: 10px;
            text-align: left;
        }
        th {
            background: #007bff;
            color: white;
        }
        .container {
            background: white;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
    </style>
</head>
<body>

<div class="container">
    <h1>📦 Smart Inventory Management System (SIMS) - API</h1>
    <p><strong>A powerful inventory management system built with ASP.NET Core 8 Web API</strong></p>

    <h2>🚀 Overview</h2>
    <p>Smart Inventory Management System (SIMS) is an API-driven solution designed for efficient stock tracking, order management, and user authentication. This project follows best practices such as the Repository Pattern, DTOs, AutoMapper, and JWT authentication.</p>

    <h2>🛠️ Features</h2>
    <ul>
        <li>✅ <strong>JWT Authentication & Authorization</strong> (Role-based access)</li>
        <li>✅ <strong>CRUD Operations</strong> for Products, Orders, and Users</li>
        <li>✅ <strong>Stock Management</strong> (Quantity deduction upon ordering)</li>
        <li>✅ <strong>Search, Filtering, and Pagination</strong></li>
        <li>✅ <strong>AutoMapper for Model Mapping</strong></li>
        <li>✅ <strong>Repository Pattern & Services Layer</strong> for better code structure</li>
    </ul>

    <h2>⚙️ Technologies Used</h2>
    <ul>
        <li><strong>ASP.NET Core 8 Web API</strong></li>
        <li><strong>Entity Framework Core</strong> (Code-First Approach)</li>
        <li><strong>SQL Server</strong> (Database)</li>
        <li><strong>JWT Authentication</strong></li>
        <li><strong>AutoMapper</strong> (For DTO mapping)</li>
    </ul>

    <h2>🏗️ Project Structure</h2>
    <pre>
/Smart-Inventory-Management-System-API
│── /Server             # Backend (ASP.NET Core 8 Web API)
│── /Client (Optional)  # Frontend (Future React/Angular implementation)
│── /Models             # Entity Models
│── /DTOs               # Data Transfer Objects
│── /Repositories       # Repository Pattern
│── /Services           # Business Logic Layer
│── /Controllers        # API Controllers
│── /Migrations         # Entity Framework Migrations
│── appsettings.json    # Configuration settings
│── Program.cs          # Entry point
│── README.md           # Project Documentation
    </pre>

    <h2>🛠️ Setup & Installation</h2>

    <h3>1️⃣ Prerequisites</h3>
    <ul>
        <li>✅ <strong>Visual Studio 2022</strong> (or VS Code)</li>
        <li>✅ <strong>.NET 8 SDK</strong></li>
        <li>✅ <strong>SQL Server</strong> (or any supported database)</li>
        <li>✅ <strong>Postman</strong> (for API testing, optional)</li>
    </ul>

    <h3>2️⃣ Clone the Repository</h3>
    <pre>
git clone https://github.com/JAnMors13/Smart-Inventory-Management-System-API.git
cd Smart-Inventory-Management-System-API
    </pre>

    <h3>3️⃣ Configure the Database</h3>
    <p>Update <code>appsettings.json</code> with your SQL Server connection string.</p>

    <h3>4️⃣ Apply Migrations & Seed Data</h3>
    <pre>
dotnet ef database update
    </pre>

    <h3>5️⃣ Run the API</h3>
    <pre>
dotnet run
    </pre>

    <h2>6️⃣ API Endpoints</h2>
    <table>
        <tr>
            <th>Endpoint</th>
            <th>Method</th>
            <th>Description</th>
        </tr>
        <tr>
            <td>/api/auth/login</td>
            <td>POST</td>
            <td>User login (JWT Token)</td>
        </tr>
        <tr>
            <td>/api/auth/register</td>
            <td>POST</td>
            <td>Register a new user</td>
        </tr>
        <tr>
            <td>/api/products</td>
            <td>GET</td>
            <td>Get all products</td>
        </tr>
        <tr>
            <td>/api/products/{id}</td>
            <td>GET</td>
            <td>Get product by ID</td>
        </tr>
        <tr>
            <td>/api/orders</td>
            <td>GET</td>
            <td>Get all orders</td>
        </tr>
        <tr>
            <td>/api/orders</td>
            <td>POST</td>
            <td>Create a new order</td>
        </tr>
    </table>

    <h2>🔒 Authentication</h2>
    <p>Users need a <strong>JWT token</strong> for protected endpoints.</p>
    <p>Tokens are generated on login (<code>/api/auth/login</code>).</p>
    <p>Add the token in the <strong>Authorization Header</strong> as:</p>
    <pre>
Authorization: Bearer &lt;your-token&gt;
    </pre>

    <h2>🛠️ Contributing</h2>
    <p>Feel free to fork this project and submit a pull request!</p>

    <h2>📜 License</h2>
    <p>This project is licensed under the <strong>MIT License</strong>.</p>
</div>

</body>
</html>
