using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsContactType.ContactTyp;
using RepositoriesIContactType.IContactType;

namespace ControllersCContactType.CContactType
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CContactTypeController : ControllerBase
    {
        public readonly IContactType _IContactType;

        public CContactTypeController(IContactType _IContactType)
        {
            this._IContactType = _IContactType;
        }
        [HttpPost("/SaveContactType")]
        public IActionResult Save(ContactType contactType)
        {
            if (contactType.TypeName == "")
            {
                return BadRequest("Please check the value");

            }
            else
            {
                try
                {
                    this._IContactType.Save(contactType);
                    return Ok();
                }
                catch (System.Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
        }
        [HttpDelete("DeleteContactType")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest("Please check the  id");
            }
            else
            {
                try
                {
                    var found = this._IContactType.GetById(id);
                    if (found == null)
                    {
                        return NotFound();
                    }
                    else
                    {

                        this._IContactType.Delete(id);
                        return Ok("It was deleted satisfactorily");
                    }
                }
                catch (System.Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
        }
        [HttpGet("GetAllContactType")]
        public ActionResult<ContactType> GetAll()
        {
            return Ok(this._IContactType.GetAll());
        }

        [HttpGet("GetbyIdContactType")]
        public async Task<ActionResult<ContactType>> GetbyId(int id)
        {
            if (id == 0)
            {
                return BadRequest("Please check the id");
            }
            else
            {
                try
                {
                    var found = this._IContactType.GetById(id);
                    if (found == null)
                    {
                        return NotFound("Contact Not Found");
                    }
                    else
                    {
                        return found;
                    }
                }
                catch (System.Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
        }

        [HttpPut("/UpdateContactType/{id}")]
        public IActionResult Update(int id, ContactType contactType)
        {
            if (id == 0 || contactType.TypeName == "")
            {
                return BadRequest("Please check  the values");
            }
            else
            {
                try
                {
                    var found = this._IContactType.GetById(id);
                    if (found == null)
                    {
                        return NotFound();
                    }
                    else
                    {
                        this._IContactType.Update(id, contactType);
                        return Ok("It was updated satisfactorily");
                    }
                }
                catch (System.Exception e)
                {

                    return BadRequest(e.Message);
                }
            }
        }


    }
}