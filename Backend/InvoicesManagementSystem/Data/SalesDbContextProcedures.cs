﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using InvoicesManagementSystem.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace InvoicesManagementSystem.Data
{
    public partial class SalesDbContext
    {
        private ISalesDbContextProcedures _procedures;

        public virtual ISalesDbContextProcedures Procedures
        {
            get
            {
                if (_procedures is null) _procedures = new SalesDbContextProcedures(this);
                return _procedures;
            }
            set
            {
                _procedures = value;
            }
        }

        public ISalesDbContextProcedures GetProcedures()
        {
            return Procedures;
        }

        protected void OnModelCreatingGeneratedProcedures(ModelBuilder modelBuilder)
        {
        }
    }

    public partial class SalesDbContextProcedures : ISalesDbContextProcedures
    {
        private readonly SalesDbContext _context;

        public SalesDbContextProcedures(SalesDbContext context)
        {
            _context = context;
        }

        public virtual async Task<int> CalculateTotalPriceAsync(int? id, OutputParameter<int> returnValue = null, CancellationToken cancellationToken = default)
        {
            var parameterreturnValue = new SqlParameter
            {
                ParameterName = "returnValue",
                Direction = System.Data.ParameterDirection.Output,
                SqlDbType = System.Data.SqlDbType.Int,
            };

            var sqlParameters = new []
            {
                new SqlParameter
                {
                    ParameterName = "id",
                    Value = id ?? Convert.DBNull,
                    SqlDbType = System.Data.SqlDbType.Int,
                },
                parameterreturnValue,
            };
            var _ = await _context.Database.ExecuteSqlRawAsync("EXEC @returnValue = [dbo].[CalculateTotalPrice] @id", sqlParameters, cancellationToken);

            returnValue?.SetValue(parameterreturnValue.Value);

            return _;
        }
    }
}
