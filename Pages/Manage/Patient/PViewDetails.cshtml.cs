using Capstonep2.Infrastructure.Domain;
using Capstonep2.Infrastructure.Domain.Models;
using Capstonep2.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Capstonep2.Pages.Manage.Patient
{
    [Authorize(Roles = "patient")]
    public class PViewDetailsModel : PageModel
    {

        private ILogger<System.Index> _logger;
        private DefaultDBContext _context;

        [BindProperty]
        public ViewModel View { get; set; }

        public PViewDetailsModel(DefaultDBContext context, ILogger<System.Index> logger)
        {
            _logger = logger;
            _context = context;
            View = View ?? new ViewModel();
        }
        public void OnGet(Guid? ID = null)
        {
        
        }

        public void OnPost()
        {

        }

        [HttpGet("purposeedit")]
        public JsonResult? OnGetPurposeedit(int pageIndex = 1, string? keyword = "", int pageSize = 10)
        {
            return new JsonResult(_context.Purposes!.Select(a => new LookupDto.Result()
            {
                Id = a.Id.ToString(),
                Text = a.Name ?? ""
            })
            .AsQueryable()
            .GetLookupPaged(pageIndex, pageSize));
        }

        [HttpGet("symptomedit")]
        public JsonResult? OnGetSymptomedit(int pageIndex = 1, string? keyword = "", int pageSize = 10)
        {
            return new JsonResult(_context.Symptoms!.Select(a => new LookupDto.Result()
            {
                Id = a.Id.ToString(),
                Text = a.Name ?? ""
            })
            .AsQueryable()
            .GetLookupPaged(pageIndex, pageSize));
        }

        public class ViewModel : CRViewModel
        {
            public List<Symptom>? Symptoms { get; set; }
            public List <Infrastructure.Domain.Models.Patient>? Patient { get; set; }
            public List<Purpose>? Purposes { get; set; }
            public List<Appointment>? Appointments { get; set; }
            public string? AppointmentId { get; set; }
            public List<Finding>? Findings { get; set; }
            public List<Prescription>? Prescriptions { get; set; }
            public List<ConsultationRecord>? ConsultationRecords { get; set; }
            
        }
    }
}
