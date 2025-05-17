using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NIC_PRACTICAL.Data;
using NIC_PRACTICAL.Models;

using System.Diagnostics;

namespace NIC_PRACTICAL.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly ApplicationDBContext _ctx;
		//private readonly IRepository<StudentDetail> _repo1;
		//private readonly IRepository<DeptTable> _repo2;

		public HomeController(ILogger<HomeController> logger, ApplicationDBContext ctx)// , IRepository<StudentDetail> sd, IRepository<DeptTable> dt)
		{
			_logger = logger;
			_ctx = ctx;	
			//_repo1 = sd;
			//_repo2 = dt;
		}

		public IActionResult Index()
	{
			ViewBag.Dept = new SelectList(_ctx.DeptTables, "DeptCode", "DeptName").ToList();

			//List<StudentDetail> list=new List<StudentDetail>();
			//list = _ctx.StudentDetails.ToList();
			//return View(list);
			int i = 0;
			
			List<StudentModel>  tblUsers = new List<StudentModel>();
			//var ls = _repo1.GetAll();
			//var ld = _repo2.GetAll();
			//var list = (from a in ls
			//			join d in ld on a.DeptCode equals d.DeptCode
			//			select new
			//			{
			//				a.Id,
			//				a.StudentName,
			//				a.StudentRoll,
			//				a.TotalMarks,
			//				d.DeptName,
			//				a.Dob
			//			}).ToList();

			//foreach( var ss in list.Select(s=> new { s.Id, s.StudentName, s.StudentRoll, s.TotalMarks, s.DeptName, s.Dob }))
			//{
			//	tblUsers.Add(new StudentModel() {
			//		Id=ss.Id,StudentRoll=ss.StudentRoll,
			//		StudentName=ss.StudentName,
			//		TotalMarks=ss.TotalMarks
			//		,DeptName=ss.DeptName,
			//		Dob=ss.Dob});
			//}


			var li = _ctx.StudentDetails.ToList();
			var list = (from a in _ctx.StudentDetails
						join s in _ctx.DeptTables on a.DeptCode equals s.DeptCode

						select new { a.Id, a.StudentRoll, a.StudentName, a.TotalMarks, s.DeptName, a.Dob }).ToList();
			foreach (var ss in list.Select(s => new { s.Id, s.StudentRoll, s.StudentName, s.TotalMarks, s.DeptName, s.Dob }))
			{
				tblUsers.Add(new StudentModel()
				{
					Id = ss.Id,
					StudentRoll = ss.StudentRoll,
					StudentName = ss.StudentName,
					TotalMarks = ss.TotalMarks,
					DeptName = ss.DeptName,
					Dob = ss.Dob
				});
			}

			////var result = tblUsers.Where(s => s.IsActive == true).ToList();
			return View(tblUsers.AsEnumerable());
			
		}

		public IActionResult Edit(int Id)
		{
			var users = _ctx.StudentDetails.Where(s => s.Id == Id).FirstOrDefault();
			ViewBag.Dept = new SelectList(_ctx.DeptTables, "DeptCode", "DeptName").ToList();


			return View(users);
		}

		[HttpPost]
		[ValidateAntiForgeryToken]
		public IActionResult Edit(StudentDetail tblUser)
		{
			_ctx.StudentDetails.Update(tblUser);
			_ctx.SaveChanges();
			return RedirectToAction("Index", "Home");
		}

		public IActionResult GetDetails(int id)
		{
			//var students = _ctx.StudentDetails.Where(s => s.Id == id).ToList();
			List<StudentModel> tblUsers = new List<StudentModel>();
			if (id == 0)
			{

				
				var li = _ctx.StudentDetails.ToList();
				var list = (from a in _ctx.StudentDetails
							join s in _ctx.DeptTables on a.DeptCode equals s.DeptCode

							select new { a.Id, a.StudentRoll, a.StudentName, a.TotalMarks, s.DeptName, a.Dob }).ToList();
				foreach (var ss in list.Select(s => new { s.Id, s.StudentRoll, s.StudentName, s.TotalMarks, s.DeptName, s.Dob }))
				{
					tblUsers.Add(new StudentModel()
					{
						Id = ss.Id,
						StudentRoll = ss.StudentRoll,
						StudentName = ss.StudentName,
						TotalMarks = ss.TotalMarks,
						DeptName = ss.DeptName,
						Dob = ss.Dob
					});
				}
			}
			else {

				var li = _ctx.StudentDetails.ToList();
				var list = (from a in _ctx.StudentDetails
							join s in _ctx.DeptTables on a.DeptCode equals s.DeptCode
							where a.DeptCode == id

							select new { a.Id, a.StudentRoll, a.StudentName, a.TotalMarks, s.DeptName, a.Dob }).ToList();
				foreach (var ss in list.Select(s => new { s.Id, s.StudentRoll, s.StudentName, s.TotalMarks, s.DeptName, s.Dob }))
				{
					tblUsers.Add(new StudentModel()
					{
						Id = ss.Id,
						StudentRoll = ss.StudentRoll,
						StudentName = ss.StudentName,
						TotalMarks = ss.TotalMarks,
						DeptName = ss.DeptName,
						Dob = ss.Dob
					});
				}
			}


			return PartialView("_PartialView", tblUsers);
		}
	}
}
