using SmlSmartLocker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace SmlSmartLocker.Controllers
{
    public class ManageStorageController : Controller
    {

        #region Manage Locker
        //View Locker List
        public ActionResult ManageLocker()
        {
            return View();
        }

        //Get locker list
        public ActionResult GetLockerList(string CAB, string RACK) //listing have filter
        {
            var context = new SmlSystemAEntities();
            var lockerList = context.TD_FDP1115;
            if (CAB != "" && RACK != "")
            {
                lockerList = (DbSet<TD_FDP1115>)lockerList.Where(a => a.CAB == CAB && a.RACK == RACK);
            }
            else if(CAB != "" && RACK == "")
            {
                lockerList = (DbSet<TD_FDP1115>)lockerList.Where(a => a.CAB == CAB);
            }
            var filterLocker = lockerList.ToList();

            var result = new { filterLocker = filterLocker };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //get locker by id
        public JsonResult GetLockerId(string CAB, string RACK, string PLACE)
        {
            var context = new SmlSystemAEntities();
            var thisLocker = context.TD_FDP1115.Where(a => a.CAB == CAB && a.RACK == RACK && a.PLACE == PLACE).FirstOrDefault();

            var result = new { thisLocker = thisLocker };
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //update action
        public ActionResult UpdateLockerDetail(string CAB, string RACK, string PLACE, string NMODEL, string TYPE, int LIMIT, int TQTY)
        {
            var context = new SmlSystemAEntities();
            var Ok = false;
            var thisLocker = context.TD_FDP1115.Where(a => a.CAB == CAB && a.RACK == RACK && a.PLACE == PLACE).FirstOrDefault();
            thisLocker.NMODEL = NMODEL;
            thisLocker.TYPE = TYPE;
            thisLocker.LIMIT = LIMIT;
            thisLocker.TQTY = TQTY;
            context.Entry(thisLocker).State = EntityState.Modified;
            context.SaveChanges();
            Ok = true;

            var result = new { Ok = Ok };
            return Json(result, JsonRequestBehavior.AllowGet);

        }
        #endregion

        #region Manage Transaction


        #endregion
    }
}