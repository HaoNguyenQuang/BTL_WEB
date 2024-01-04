using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BTL_ConGa.Models;
using Microsoft.EntityFrameworkCore;

namespace BTL_ConGa.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackAPIController : ControllerBase
    {
        BtlWebContext db = new BtlWebContext();

        [HttpGet]
        public IEnumerable<Feedback> GetAllFeedBack()
        {
            var feedback = db.Feedbacks.ToList();
            return feedback;
        }
        [HttpGet("{mafeedback}")]
        public IEnumerable<Feedback> GetFeedBackTheoMa(string mafeedback)
        {
            var feedback = db.Feedbacks.Where(x => x.Mafeedback == mafeedback).ToList();
            return feedback;
        }

        [HttpDelete]
        public bool DeleteFeedBack(string mafeedback)
        {

            try
            {
                var feedback = db.Feedbacks.Find(mafeedback);
                if (feedback == null) { return false; }
                db.Feedbacks.Remove(feedback);
                db.SaveChanges();
                return true;
            }
            catch { return false; }

        }
    }
}
