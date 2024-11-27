using ClientApplication.DAL.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClientApplication.DAL
{
    public class CompanyRepository
    {
        private readonly string _connectionString;

        public CompanyRepository()
        {
            _connectionString = Helper.ConnectionHelper.GetConnectionString();
        }

        public List<CompanyDto> GetAllCompanies()
        {
            var companies = new List<CompanyDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("GetCompanyList", connection))
                    {

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                companies.Add(new CompanyDto
                                {
                                    CompanyID = reader.GetInt32(reader.GetOrdinal("CompanyID")),
                                    CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                                    Address1 = reader.GetString(reader.GetOrdinal("Address1")),
                                    Address2 = reader.IsDBNull(reader.GetOrdinal("Address2")) ? string.Empty : reader.GetString(reader.GetOrdinal("Address2")),
                                    ZipCode = reader.GetString(reader.GetOrdinal("ZipCode")),
                                    PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber"))


                                });
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while fetching the company list.", ex);

                }
     
            }

            return companies;
        }

        public int InsertUpdateCompany(CompanyDto companyDto)
        {
            int companyID = 0;

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("InsertUpdateCompany", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command
                       // command.Parameters.AddWithValue("@CompanyID", companyDto.CompanyID > 0 ? companyDto.CompanyID : (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CompanyName", companyDto.CompanyName);
                        command.Parameters.AddWithValue("@Address1", companyDto.Address1 ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Address2", companyDto.Address2 ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@ZipCode", companyDto.ZipCode ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PhoneNumber", companyDto.PhoneNumber ?? (object)DBNull.Value);

                        // Add output parameter for CompanyID
                        SqlParameter outputIdParam = new SqlParameter
                        {
                            ParameterName = "@CompanyID",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.InputOutput,
                            Value = companyDto.CompanyID > 0 ? companyDto.CompanyID : (object)DBNull.Value
                        };
                        command.Parameters.Add(outputIdParam);

                        // Execute the command
                        command.ExecuteNonQuery();

                        // Retrieve the CompanyID (updated or newly inserted)
                        companyID = (outputIdParam.Value != DBNull.Value) ? Convert.ToInt32(outputIdParam.Value) : 0;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while inserting or updating the company.", ex);
                }
            }

            return companyID;
        }
        public bool IsCompanyExists(int? companyId, string companyName)
        {
            bool isExist = false;

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("IsCompanyExist", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add parameters to the command
                        command.Parameters.AddWithValue("@CompanyID", companyId ?? 0);
                        command.Parameters.AddWithValue("@CompanyName", companyName);
                        
                        // Add output parameter for CompanyID
                        SqlParameter outputParam = new SqlParameter
                        {
                            ParameterName = "@IsExist",
                            SqlDbType = SqlDbType.Bit,
                            Direction = ParameterDirection.Output,
                        };
                        command.Parameters.Add(outputParam);

                        // Execute the command
                        command.ExecuteNonQuery();

                        // Retrieve the CompanyID (updated or newly inserted)
                        isExist = (outputParam.Value != DBNull.Value) ? Convert.ToBoolean(outputParam.Value) : false;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while inserting or updating the company.", ex);
                }
            }

            return isExist;
        }
    }
}
