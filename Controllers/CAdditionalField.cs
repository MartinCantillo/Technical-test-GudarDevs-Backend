using ControllersContactController.ContactController;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsAdditionalField.AdditionalField;
using RepositoriesIAdditionalField.IAdditionalField;



namespace ControllersCAdditionalField.CAdditionalField
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CAdditionalFieldController : ControllerBase
    {
        private readonly IAdditionalField _IAdditionalField;

        public CAdditionalFieldController(IAdditionalField _IAdditionalField)
        {
            this._IAdditionalField = _IAdditionalField;
        }

        [HttpPost("/SaveAdditionalFiedl")]
        public IActionResult SaveAdditionalFiedl(AdditionalField additionalField)
        {
            if (additionalField.FieldName == "" || additionalField.FieldType == "")
            {
                return BadRequest("Please check the values ");
            }
            else
            {
                try
                {
                    this._IAdditionalField.Save(additionalField);
                    return Ok();
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }
        }

        [HttpGet("GetAllAdditionalFiedl")]
        public ActionResult<AdditionalField> GetAllAdditionalFiedl()
        {
            return Ok(this._IAdditionalField.GetAll());
        }


        [HttpGet("GetbyIdAdditionalField")]
        public async Task<ActionResult<AdditionalField>> GetbyId(int id)
        {
            if (id == 0)
            {
                return BadRequest("Please check the id");
            }
            else
            {
                try
                {
                    var found = this._IAdditionalField.GetById(id);
                    if (found == null)
                    {
                        return NotFound("Contact Not Found");
                    }
                    else
                    {
                        return found;
                    }
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }
        [HttpPut("/UpdateAdditionalField/{id}")]
        public IActionResult Update(int id, AdditionalField additionalField)
        {
            if (id == 0 || additionalField.FieldName == "" || additionalField.FieldType == "")
            {
                return BadRequest("Please check the the values");
            }
            else
            {
                var found = this._IAdditionalField.GetById(id);
                Console.WriteLine(found);
                try
                {
                    if (found == null)
                    {
                        return NotFound();
                    }
                    else
                    {

                        this._IAdditionalField.Update(id, additionalField);
                        return Ok("AdditionalField was updated satisfactorily");
                    }
                }
                catch (System.Exception)
                {

                    return BadRequest("server error ");
                }
            }
        }
        [HttpDelete("DeleteAdditionalField")]
        public IActionResult Delete(int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest("Please check");
            }
            else
            {
                try
                {
                    this._IAdditionalField.Delete(id);
                    return Ok("It was deleted satisfactorily");
                }
                catch (Exception e)
                {

                    return BadRequest(e.Message);
                }
            }


        }


    }

}