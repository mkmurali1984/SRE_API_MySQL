using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SRE_API.Models;
using SRE_API.Services;

namespace SRE_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Filters.APIKeyAuth]
    public class PropertiesController : ControllerBase
    {
        private readonly PropertiesServices propertiesServices;
        private readonly IWebHostEnvironment env;
        public PropertiesController(PropertiesServices propertiesServices, IWebHostEnvironment env)
        {
            this.propertiesServices = propertiesServices;
            this.env = env;
        }

        [HttpGet]
        public async Task<List<PropertiesModel>> Get()
        {
            return await propertiesServices.GettheProperties();
        }

        [HttpPost]
        public async Task<OkObjectResult> Insert([FromBody] PropertiesModel propertiesModel)
        {
            await propertiesServices.InsertPropertiesDetails(propertiesModel);
            return Ok(propertiesModel);
        }

        [Route("SaveFile")]
        [HttpPost]
        public JsonResult SaveFile()
        {
            try
            {
                var httpRequest = Request.Form;
                var postedFile = httpRequest.Files[0];
                string filename = postedFile.FileName;
                var physicalPath = env.ContentRootPath + "/Photos/" + filename;

                using (var stream = new FileStream(physicalPath, FileMode.Create))
                {
                    postedFile.CopyTo(stream);
                }

                return new JsonResult(filename);
            }
            catch (Exception)
            {

                return new JsonResult("anonymous.png");
            }
        }

        [HttpPut]
        public void UpdateProperties(string id, PropertiesModel propertiesModel)
        {
            var isPropertiesFound = propertiesServices.GetPropertyById(id);

            if (isPropertiesFound != null)
            {
                propertiesModel.PId = isPropertiesFound.PId;
                propertiesServices.updateProperties(id, propertiesModel);
            }
        }

        [HttpGet]
        [Route("GetByID")]
        public  PropertiesModel GetById(string id)
        {
            return propertiesServices.GetPropertyById(id);

        }
    }
}
