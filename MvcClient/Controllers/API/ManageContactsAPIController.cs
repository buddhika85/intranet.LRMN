using MvcClient.Logger;
using Persistance;
using Persistance.Dtos;
using Persistance.ViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Http;

namespace MvcClient.Controllers.API
{
    [Authorize(Roles = "Admin")]
    public class ManageContactsAPIController : ApiController
    {
        UnitOfWork _uow;
        MvcLogger _mvcLogger;

        public ManageContactsAPIController()
        {
            _uow = new UnitOfWork();
            _mvcLogger = new MvcLogger(log4net.LogManager.GetLogger(typeof(ManageContactsAPIController)));
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var result = _uow.ApplicationUserRepository.SQLQuery<ApplicationUserViewModel>(
                    sql: "usp_GetApplicationUsers", parameters: null);
                IList<ApplicationUserViewModel> contacts = result.ToList();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                _mvcLogger.LogException(ex, ControllerContext, nameof(Get), User.Identity.Name);
                throw;
            }
        }


        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var result = _uow.ApplicationUserRepository.SQLQuery<ApplicationUserViewModel>(
                    sql: "usp_GetApplicationUsers", parameters: null);
                var contact = result.Single(u => u.UserIdGenerated == id);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                _mvcLogger.LogException(ex, ControllerContext, nameof(Get), User.Identity.Name);
                throw;
            }
        }


        //var result = _uow.ApplicationUserRepository.SQLQuery<ApplicationUserViewModel>(
        //                "usp_SearchApplicationUsers @FirstName, @LastName, @Email, @IsApproved, @IsLocked, @IsActivated, @ContactTypeId, @VolunteerInerests",
        //                new SqlParameter("FirstName", SqlDbType.VarChar) { Value = contactsSearchDto.FirstName ?? SqlString.Null },
        //                new SqlParameter("LastName", SqlDbType.VarChar) { Value = contactsSearchDto.LastName ?? SqlString.Null },
        //                new SqlParameter("Email", SqlDbType.VarChar) { Value = contactsSearchDto.Email ?? SqlString.Null },
        //                new SqlParameter("IsApproved", SqlDbType.Bit) { Value = contactsSearchDto.IsApproved == "-1" ? SqlString.Null : contactsSearchDto.IsApproved },
        //                new SqlParameter("IsLocked", SqlDbType.Bit) { Value = contactsSearchDto.IsLocked == "-1" ? SqlString.Null : contactsSearchDto.IsLocked },
        //                new SqlParameter("IsActivated", SqlDbType.Bit) { Value = contactsSearchDto.IsActivated == "-1" ? SqlString.Null : contactsSearchDto.IsActivated },
        //                new SqlParameter("ContactTypeId", SqlDbType.Int) { Value = contactsSearchDto.ContactTypeId == -1 ? (object) DBNull.Value : contactsSearchDto.ContactTypeId },
        //                new SqlParameter("VolunteerInerests", SqlDbType.VarChar) { Value = contactsSearchDto.VolunteerInerests ?? SqlString.Null });
        //var searchResult = result.ToList();
        [HttpPost] // For search
        public IHttpActionResult Post(ContactsSearchDto contactsSearchDto)
        {
            try
            {
                IEnumerable<ApplicationUserViewModel> contacts = _uow.ApplicationUserRepository.SQLQuery<ApplicationUserViewModel>(
                    sql: "usp_GetApplicationUsers", parameters: null);

                if (contactsSearchDto.FirstName != null)
                    contacts = from u in contacts where u.FirstName.Contains(contactsSearchDto.FirstName) select u;

                if (contactsSearchDto.LastName != null)
                    contacts = from u in contacts where u.LastName.Contains(contactsSearchDto.LastName) select u;

                if (contactsSearchDto.Email != null)
                    contacts = from u in contacts where u.FirstName.Contains(contactsSearchDto.Email) select u;

                if (contactsSearchDto.IsApproved != "-1" && contactsSearchDto.IsApproved != "0")
                    contacts = from u in contacts where (u.IsAdminApproved == false) select u;
                if (contactsSearchDto.IsApproved != "-1" && contactsSearchDto.IsApproved != "1")
                    contacts = from u in contacts where (u.IsAdminApproved == true) select u;

                if (contactsSearchDto.IsLocked != "-1" && contactsSearchDto.IsLocked != "0")
                    contacts = from u in contacts where (u.UserLocked == false) select u;
                if (contactsSearchDto.IsLocked != "-1" && contactsSearchDto.IsLocked != "1")
                    contacts = from u in contacts where (u.UserLocked == true) select u;

                if (contactsSearchDto.IsActivated != "-1" && contactsSearchDto.IsActivated != "0")
                    contacts = from u in contacts where (u.UserActive == false) select u;
                if (contactsSearchDto.IsActivated != "-1" && contactsSearchDto.IsActivated != "1")
                    contacts = from u in contacts where (u.UserActive == true) select u;

                if (contactsSearchDto.ContactTypeId != -1)
                    contacts = from u in contacts where u.ContactTypeId == contactsSearchDto.ContactTypeId select u;

                if (contactsSearchDto.VolunteerInerests != null)
                    contacts = from u in contacts where u.VolunteerInterests.Contains(contactsSearchDto.VolunteerInerests) select u;


                contacts = contacts.ToList();
                return Ok(contacts);
            }
            catch (Exception ex)
            {
                _mvcLogger.LogException(ex, ControllerContext, nameof(Get), User.Identity.Name);
                throw;
            }
        }
    }
}
