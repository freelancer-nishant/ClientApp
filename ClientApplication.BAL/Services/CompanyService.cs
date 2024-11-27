using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientApplication.BAL.Models;
using ClientApplication.DAL;
using ClientApplication.DAL.DTOs;
using ClientApplication.DAL.Repositories;

namespace ClientApplication.BAL
{
    public class CompanyService
    {
        private readonly CompanyRepository _repository;


        public CompanyService()
        {
            _repository = new CompanyRepository();
        }

        public List<CompanyModel> GetAllCompanies()
        {
            var companyDtos = _repository.GetAllCompanies();

            // Map DTOs to domain models
            return companyDtos.Select(dto => new CompanyModel
            {
                CompanyID = dto.CompanyID,
                CompanyName = dto.CompanyName,
                Address1 = dto.Address1,
                Address2 = dto.Address2,
                ZipCode = dto.ZipCode,
                PhoneNumber = dto.PhoneNumber,

            }).ToList();
        }

        public int InsertUpdateCompany(CompanyModel companyModel)
        {
            int companyID = 0;
            var companyDto = new CompanyDto
            {
                CompanyID= companyModel.CompanyID,
                CompanyName = companyModel.CompanyName,
                Address1 = companyModel.Address1,
                Address2 = companyModel.Address2,
                ZipCode = companyModel.ZipCode,
                PhoneNumber =companyModel.PhoneNumber
            };

            companyID = _repository.InsertUpdateCompany(companyDto);
            return companyID;
        }
        public bool IsCompanyExists(int? companyId, string companyName)
        {
            bool IsExist = false;
            IsExist = _repository.IsCompanyExists(companyId, companyName);
            return IsExist;
        }
    }
}
