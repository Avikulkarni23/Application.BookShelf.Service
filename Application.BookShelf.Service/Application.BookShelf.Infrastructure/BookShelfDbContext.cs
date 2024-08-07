﻿using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.BookShelf.Infrastructure
{
    public class BookShelfDbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public BookShelfDbContext(IConfiguration configuration) 
        {
            _configuration = configuration;
            _connectionString = configuration.GetConnectionString("BookShelfDbConn");
        }

        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
       
    }
}
