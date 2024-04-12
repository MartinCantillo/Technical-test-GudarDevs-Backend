using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelsContacts.Contacs;
using RepositoriesIContact.IContact;

namespace ControllersContactController.ContactController
{
    // [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CContactController : ControllerBase
    {
        public readonly IContact _IContact;

        public CContactController(IContact _IContact)
        {
            this._IContact = _IContact;
        }
        [HttpPost("/SaveContact")]
        public IActionResult SaveContact(Contact contact)
        {
            if (contact.ContactType == 0 || contact.Comments == "" || contact.AdditionalField1 == ""
            || contact.Name == "" || contact.AdditionalField2 == "" || contact.PhoneNumber == "")
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
                    var found = this._IContact.GetById(id);
                    if (found == null)
                    {
                        return NotFound();
                    }
                    else
                    {

                        this._IContact.Delete(id);
                        return Ok("Contact was deleted satisfactorily");
                    }
                }
                catch (System.Exception e)
                {

                    throw new Exception(e.Message);
                }
            }
        }
        [HttpGet("GetAllContact")]
        public ActionResult<Contact> GetAllContact()
        {
            Console.WriteLine("entro");
            return Ok(this._IContact.GetAll());
        }

        [HttpGet("GetbyIdContact")]
        public ActionResult<Contact> GetbyIdContact(int id)
        {
            if (id == 0)
            {
                return BadRequest("Please check the id");
            }
            else
            {
                try
                {
                    var found = this._IContact.GetById(id);
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
        [HttpPut("/UpdateContact/{id}")]
public IActionResult UpdateContact(int id, Contact contact)
{
    if (id == 0 || contact.ContactType == 0 || contact.Comments == "" || contact.AdditionalField1 == "" || contact.AdditionalField2 == "" || contact.Name == "")
    {
        return BadRequest("Please check the values");
    }
    else
    {
        try
        {
            var found = this._IContact.GetById(id);
            if (found == null)
            {
                return NotFound();
            }
            else
            {
                this._IContact.Update(id, contact);
                return Ok("Contact was updated satisfactorily");
            }
        }
        catch (System.Exception)
        {
            return BadRequest("Server error");
        }
    }
}



    }
}