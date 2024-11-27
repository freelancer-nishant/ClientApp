using ClientApplication.BAL.Models;
using ClientApplication.DAL;
using ClientApplication.DAL.DTOs;
using ClientApplication.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientApplication.BAL.Services
{
    public class ContactService
    {
        private readonly ContactRepository _repository;
        public ContactService()
        {
            _repository = new ContactRepository();
        }

        public List<ContactModel> GetAllContacts(int companyID)
        {
            var contactDtos = _repository.GetAllContacts(companyID);

            var contacts = contactDtos.Select(dto => new ContactModel
            {
                ContactID = dto.ContactID,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                PhoneNumber = dto.PhoneNumber,
                EmailID = dto.EmailID,
                CompanyID = dto.CompanyID,
                CompanyName=dto.CompanyName
            }).ToList();
            return contacts;
        }
        public int InsertUpdateContact(ContactModel contactModel)
        {
            if (contactModel == null)
            {
                throw new ArgumentNullException(nameof(contactModel), "ContactModel cannot be null.");
            }

          

            // Map ContactModel to ContactDto
            var contactDto = new ContactDto
            {
                ContactID = contactModel.ContactID,
                FirstName = contactModel.FirstName,
                LastName = contactModel.LastName,
                PhoneNumber = contactModel.PhoneNumber,
                EmailID = contactModel.EmailID,
                CompanyID = contactModel.CompanyID
            };

            try
            {
                // Call the repository
                return _repository.InsertUpdateContact(contactDto);
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while processing the contact.", ex);
            }
        }

    }
}
