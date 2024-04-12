using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsContacts.Contacs;
using RepositoriesIContact.IContact;

namespace ControllersContactController.ContactController
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {
        public readonly IContact _IContact;

        public ContactController(IContact _IContact)
        {
            this._IContact = _IContact;
        }
        [HttpPost("/SaveContact")]
        public IActionResult SaveContact(Contact contact)
        {
            if (contact.ContactType == 0 || contact.Comments == "" || contact.AdditionalField == 0
            || contact.Name == "")
            {
                return BadRequest("Please check the values ");
            }
            else
            {
                try
                {
                    this._IContact.Save(contact);
                    return Ok();
                }
                catch (System.Exception)
                {

                    return BadRequest("Server error");
                }
            }
        }

        [HttpDelete("DeleteContact")]
        public IActionResult DeleteContact(int id)
        {
            if (id == 0)
            {
                return BadRequest("Please check the  id");
            }
            else
            {
                try
                {
                    this._IContact.Delete(id);
                    return Ok("Contact was deleted satisfactorily");
                }
                catch (System.Exception)
                {

                    throw;
                }
            }
        }
        [HttpGet("GetAllContact")]
        public ActionResult<Contact> GetAllContact()
        {
            return Ok(this._IContact.GetAll());
        }

        [HttpGet("GetbyIdContact")]
        public async Task<ActionResult<Contact>> GetbyIdContact(int id)
        {
            if (id == 0)
            {
                return BadRequest("Please check the id");
            }
            else
            {
                try
                {
                    var found = await this._IContact.GetById(id);
                    if (found == null)
                    {
                        return NotFound("Contact Not Found");
                    }
                    else
                    {
                        return found;
                    }
                }
                catch (System.Exception)
                {
                    throw;
                }
            }
        }
        [HttpPut("/UpdateContact/{id}")]
        public IActionResult UpdateContact(int id, Contact contact)
        {
            if (id == 0 || contact.ContactType == 0 || contact.Comments == "" || contact.AdditionalField == 0 || contact.Name == "")
            {
                return BadRequest("Please check the id and the values");
            }
            else
            {
                try
                {
                    this._IContact.Update(id, contact);
                    return Ok("Contact was updated satisfactorily");
                }
                catch (System.Exception)
                {

                    return BadRequest("Server error");
                }
            }
        }


    }
}