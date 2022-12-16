using Student.PresentationLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.Service.Iservice
{
    public interface IStudentService
    {
        IEnumerable<StudentViewModel> GetAll();
        StudentViewModel GetById(object id);
        void AddStudent(StudentViewModel model);
        void UpdateStudent(StudentViewModel model);
        void DeleteStudentByID(int Id);
    }
}
