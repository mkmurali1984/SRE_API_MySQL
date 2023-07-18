using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SRE_API.Models;
using System.ComponentModel;
using System.Net.Sockets;

namespace SRE_API.Services
{
    public class PropertiesServices
    {

        SreDatasContext _dbContext;
        public PropertiesServices(SreDatasContext dbContext)
        {
            _dbContext = dbContext;
        }

       
        public async Task<List<PropertiesModel>> GettheProperties()
        {
            var lst= await _dbContext.PropertyInfos.AsNoTracking().ToListAsync();
            List<PropertiesModel> properties = new List<PropertiesModel>();
           foreach(var prop in lst)
            {
                properties.Add(new PropertiesModel()
                {
                    PId =Convert.ToString( prop.Pid),
                    ContactNumber = prop.ContactNumber,
                    dimensions = prop.Dimension,
                    EmailAddress = prop.EmailAddress,
                    ImageFileName = prop.ImageFileName,
                    IsActive = prop.IsActive,
                    IsApproved = prop.IsApproved,
                    MapURL = prop.MapUrl,
                    Location = prop.Location,
                    OwnershipType = prop.OwnershipType,
                    PersonAddress = prop.PersonAddress,
                    PersonName = prop.PersonName,
                    Price = prop.Price,
                    PropertyDescription = prop.PropertyDescription,
                    PropertySubtype = prop.PropertySubtype,
                    PropertyType = prop.PropertyType,
                    Purpose = prop.Purpose,

                });
            }
            return properties;
        }

        public async Task InsertPropertiesDetails(PropertiesModel propertiesModel)
        {
            //await propertiesCollection.InsertOneAsync(propertiesModel);
            PropertyInfo propertyInfo = new PropertyInfo()
            {
                ContactNumber = propertiesModel.ContactNumber,
                Dimension = propertiesModel.dimensions,
                EmailAddress = propertiesModel.EmailAddress,
                ImageFileName = propertiesModel.ImageFileName,
                IsActive = propertiesModel.IsActive,
                IsApproved = propertiesModel.IsApproved,
                MapUrl = propertiesModel.MapURL,
                OwnershipType = propertiesModel.OwnershipType,
                PersonAddress = propertiesModel.PersonAddress,
                PersonName = propertiesModel.PersonName,
                Location = propertiesModel.Location,
                Price = propertiesModel.Price,
                PropertyDescription = propertiesModel.PropertyDescription,
                PropertySubtype = propertiesModel.PropertySubtype,
                PropertyType = propertiesModel.PropertyType,
                Purpose = propertiesModel.Purpose,

            };
             _dbContext.PropertyInfos.Add(propertyInfo);
            await _dbContext.SaveChangesAsync();
        }

        public PropertiesModel GetPropertyById(string id)
        {
            var prop = _dbContext.PropertyInfos.AsNoTracking().Where(i => i.Pid == Convert.ToInt32(id)).FirstOrDefault();

            if (prop != null)
            {
                PropertiesModel properties = new PropertiesModel()
                {

                    PId = Convert.ToString(prop.Pid),
                    ContactNumber = prop.ContactNumber,
                    dimensions = prop.Dimension,
                    EmailAddress = prop.EmailAddress,
                    ImageFileName = prop.ImageFileName,
                    IsActive = prop.IsActive,
                    IsApproved = prop.IsApproved,
                    MapURL = prop.MapUrl,
                    Location = prop.Location,
                    OwnershipType = prop.OwnershipType,
                    PersonAddress = prop.PersonAddress,
                    PersonName = prop.PersonName,
                    Price = prop.Price,
                    PropertyDescription = prop.PropertyDescription,
                    PropertySubtype = prop.PropertySubtype,
                    PropertyType = prop.PropertyType,
                    Purpose = prop.Purpose,
                };
                return properties;
            }
            else
            {
                return new PropertiesModel();
            }
        }

        public async void updateProperties(string id, PropertiesModel propertiesModel)
        {
            PropertyInfo propertyInfo = new PropertyInfo()
            {
                ContactNumber = propertiesModel.ContactNumber,
                Dimension = propertiesModel.dimensions,
                EmailAddress = propertiesModel.EmailAddress,
                ImageFileName = propertiesModel.ImageFileName,
                IsActive = propertiesModel.IsActive,
                IsApproved = propertiesModel.IsApproved,
                MapUrl = propertiesModel.MapURL,
                Location = propertiesModel.Location,
                OwnershipType = propertiesModel.OwnershipType,
                PersonAddress = propertiesModel.PersonAddress,
                PersonName = propertiesModel.PersonName,
                Pid =Convert.ToInt32(id),
                Price = propertiesModel.Price,
                PropertyDescription = propertiesModel.PropertyDescription,
                PropertySubtype = propertiesModel.PropertySubtype,
                PropertyType = propertiesModel.PropertyType,
                Purpose = propertiesModel.Purpose,

            };
            _dbContext.PropertyInfos.Update(propertyInfo);
            await _dbContext.SaveChangesAsync();
        }
    }
}
