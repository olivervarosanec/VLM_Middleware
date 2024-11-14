# 📊 VLM Middleware - SQL Server Data API

Welcome to the **VLM Middleware** project! This web API allows you to serve data from SQL Server through simple API calls, enabling seamless data integration for your applications. Let's dive in! 🚀

## 📝 Overview
This project is built using **ASP.NET Core** and provides an easy way to access your SQL Server data over HTTP. The API fetches data from the SQL Server using a query string and returns it as JSON, making it incredibly useful for building data-driven applications and services.

## ✨ Features
- 🚀 **Serve SQL Server Data**: Easily serve data from SQL Server with simple GET requests.
- 🔒 **Configurable Connection**: Accept connection strings dynamically via request headers.
- 📊 **Flexible Queries**: Run custom SQL queries and receive the data in JSON format.
- ⚙️ **ASP.NET Core**: Leverage the power and security of ASP.NET Core for your API.

## 🚀 Getting Started
Follow these steps to get started with VLM Middleware:

### 📦 Prerequisites
- .NET SDK (6.0 or later)
- SQL Server instance

### 📥 Installation
1. Clone the repository:
   ```sh
   git clone https://github.com/your-username/vlm-middleware.git
   cd vlm-middleware
   ```
2. Restore the dependencies and build the project:
   ```sh
   dotnet restore
   dotnet build
   ```

### ⚙️ Configuration
The connection string is obtained from the request headers. Make sure to include it when making requests. If no connection string is provided, a default connection string will be used:

- **Header Example**:
  ```http
  ConnectionString: Data Source=SERVER_NAME;Initial Catalog=DATABASE_NAME;Integrated Security=True;
  ```

### ▶️ Running the API
Start the application by running:
```sh
dotnet run
```
The API will be available at `http://localhost:5000/VLM`.

## 📊 Usage
### 🧪 Example API Call
To fetch data from the SQL Server, you need to provide the SQL query as a query parameter.

- **GET /VLM?query=SELECT * FROM TableName**

**Curl Example**:
```sh
curl -X GET "http://localhost:5000/VLM?query=SELECT%20*%20FROM%20TableName" -H "ConnectionString: Data Source=SERVER_NAME;Initial Catalog=DATABASE_NAME;Integrated Security=True;"
```
- Returns a JSON response with the data from the table.

## 🛠️ Project Structure
- `Controllers/VLMController.cs`: Contains the main API logic for executing SQL queries and returning JSON responses.
- `Program.cs`: The entry point for configuring and starting the application.

## 🚨 Error Handling
If an error occurs during execution, the API will return a 500 status code with an appropriate message. The logs provide more context for troubleshooting.

## 🔒 Security Considerations
- Use a secure connection string to avoid exposing sensitive credentials.
- Validate all user inputs to prevent SQL injection attacks.

## 🤝 Contributing
We welcome contributions! Feel free to submit issues or pull requests.

1. Fork the repository
2. Create your feature branch (`git checkout -b feature/YourFeature`)
3. Commit your changes (`git commit -m 'Add your feature'`)
4. Push to the branch (`git push origin feature/YourFeature`)
5. Open a pull request

---

### 🚀 Let's Connect!
If you have any questions or suggestions, feel free to open an issue or contribute to the project.

