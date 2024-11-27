using ClientApplication.DAL.DTOs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.DAL.Repositories
{
    public class ContactRepository
    {
        private readonly string _connectionString;
        public ContactRepository()
        {
            _connectionString = Helper.ConnectionHelper.GetConnectionString();
        }
        public List<ContactDto> GetAllContacts(int companyId)
        {
            var contacts = new List<ContactDto>();

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("GetContactList", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@CompanyID", companyId);

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var contact = new ContactDto
                                {
                                    ContactID = reader.GetInt32(reader.GetOrdinal("ContactID")),
                                    FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                                    LastName = reader.GetString(reader.GetOrdinal("LastName")),
                                    PhoneNumber = reader.GetString(reader.GetOrdinal("PhoneNumber")),
                                    EmailID = reader.GetString(reader.GetOrdinal("EmailID")),
                                    CompanyID = reader.GetInt32(reader.GetOrdinal("CompanyID")),
                                    CompanyName = reader.GetString(reader.GetOrdinal("CompanyName")),
                                };
                                contacts.Add(contact);
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while fetching the contact list.", ex);
                }
            }

            return contacts;
        }
        public int InsertUpdateContact(ContactDto contactDto)
        {
            int contactId;

            using (var connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();

                    using (var command = new SqlCommand("InsertUpdateContact", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Input parameters
                        command.Parameters.AddWithValue("@FirstName", contactDto.FirstName);
                        command.Parameters.AddWithValue("@LastName", contactDto.LastName);
                        command.Parameters.AddWithValue("@PhoneNumber", contactDto.PhoneNumber ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@EmailID", contactDto.EmailID ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CompanyID", contactDto.CompanyID);

                        // Output parameter
                        var outputParam = new SqlParameter
                        {
                            ParameterName = "@ContactID",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.InputOutput,
                            Value = contactDto.ContactID > 0 ? contactDto.ContactID : (object)DBNull.Value
                        };
                        command.Parameters.Add(outputParam);

                        // Execute the command
                        command.ExecuteNonQuery();

                        // Retrieve the ContactID
                        contactId = (int)outputParam.Value;
                    }
                }
                catch (SqlException ex)
                {
                    throw new Exception("An error occurred while inserting/updating the contact.", ex);
                }
            }

            return contactId;
        }

    }
}
