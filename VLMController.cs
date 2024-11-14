using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;

namespace VLM_Middleware.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VLMController : ControllerBase
    {
        private readonly string _connectionString;
        private readonly ILogger<VLMController> _logger;

        public VLMController(IHttpContextAccessor httpContextAccessor, ILogger<VLMController> logger)
        {
            _logger = logger;

            var context = httpContextAccessor.HttpContext;
            if (context != null && context.Request.Headers.ContainsKey("ConnectionString"))
            {
                _connectionString = context.Request.Headers["ConnectionString"].ToString();
            }
            else if (true)
            {
                _connectionString = "Data Source=WIN-KHQFLH3GIF0;Initial Catalog=DMO_USCFPL;Integrated Security=True;TrustServerCertificate=True;";
            }
            else
            {
                throw new InvalidOperationException("Connection string not provided in the request headers.");
            }
        }

        [HttpGet]
        public IActionResult GetData([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return BadRequest("Query is required.");
            }

            try
            {
                var dataTable = ExecuteQuery(query);
                var result = ConvertDataTableToJson(dataTable);
                return Ok(result); // The result will be serialized to JSON
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while executing the query.");
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request.");
            }
        }

        private DataTable ExecuteQuery(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            using (var command = new SqlCommand(query, connection))
            using (var adapter = new SqlDataAdapter(command))
            {
                var dataTable = new DataTable();
                command.CommandTimeout = 300;

                connection.Open();
                adapter.Fill(dataTable);
                return dataTable;
            }
        }

        private List<Dictionary<string, object>> ConvertDataTableToJson(DataTable table)
        {
            var rows = new List<Dictionary<string, object>>();
            foreach (DataRow dr in table.Rows)
            {
                var row = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    row[col.ColumnName] = dr[col];
                }
                rows.Add(row);
            }
            return rows;
        }
    }
}
