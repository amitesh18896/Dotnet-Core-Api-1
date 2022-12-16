using Student.Domin.Models;
using Student.PresentationLayer.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Student.PresentationLayer.Mapper
{
  public static  class StudentMapper
    {

        public static StudentViewModel ConvertToStudentViewModel(this StudentUser model) // Extension method
        {
            var output = new StudentViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                Barcode = model.Barcode,
                Rate = model.Rate
            };

            return output;
        }

        public static List<StudentViewModel> ConvertToStudentViewModelList
            (this List<StudentUser> model)
        {
            List<StudentViewModel> output = model.ConvertAll(ConvertToStudentViewModel);

            return output;
        }

    }
}