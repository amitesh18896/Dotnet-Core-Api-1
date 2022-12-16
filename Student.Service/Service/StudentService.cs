using Student.DAL.UnitOfWork;
using Student.Domin.Models;
using Student.PresentationLayer.Mapper;
using Student.PresentationLayer.ViewModel;
using Student.Service.Iservice;
using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Student.Service.Service
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork uow;
        public StudentService(IUnitOfWork _uow)
        {
            uow = _uow;
        }
        public IEnumerable<StudentViewModel> GetAll()
        {
            var students = this.uow.GenericRepository<StudentUser>().Get().ToList();
            var productViewModel = students.ConvertToStudentViewModelList();

            return productViewModel;
        }
        public StudentViewModel GetById(object id)
        {


            var student = uow.GenericRepository<StudentUser>().GetByID(id);

            var StudentViewModel = student.ConvertToStudentViewModel();



            return StudentViewModel;
        }





        public void AddStudent(StudentViewModel model)
        {
            var objProduct = new StudentUser
            {
                Id = model.Id,
                Name = model.Name,
                ModifiedOn = model.ModifiedOn,
                Rate = model.Rate,
                Description = model.Description,
                Barcode = model.Barcode,
                AddedOn = DateTime.UtcNow,
                IsDelete = false

            };
            if (objProduct != null)
            {
                uow.GenericRepository<StudentUser>().Insert(objProduct);
                uow.Save();
            }
        }

        public void UpdateStudent(StudentViewModel model)
        {
            if (model.Id > 0)
            {
                var existingProduct = this.uow.GenericRepository<StudentUser>().GetByID(model.Id);
                existingProduct.Id = model.Id;
                existingProduct.Name = model.Name;
                existingProduct.ModifiedOn = model.ModifiedOn;
                existingProduct.Rate = model.Rate;
                existingProduct.Description = model.Description;
                existingProduct.Barcode = model.Barcode;

                uow.Save();
            }

        }

        public void DeleteStudentByID(int Id)
        {
            var students = uow.GenericRepository<StudentUser>().GetByID(Id);

            students.IsDelete = true;
            uow.Save();
        }
    }
}

