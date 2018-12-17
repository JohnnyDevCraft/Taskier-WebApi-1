using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Taskier.Domain.ViewModel.Request.TaskController;

namespace Taskier.Domain.Tests.ValidationTests
{
    [TestClass]
    public class CreateTaskRequestValidatorTests
    {
        CreateTaskRequestValidator GetValidator()
        {
            return new CreateTaskRequestValidator();
        }

        [TestMethod]
        public void ValidatorShouldHaveErrors_WhenSubjectIsEmpty()
        {
            var result = GetValidator().Validate(new CreateTaskRequest()
            {
                Subject = "",
                Description = "This is desc",
                AssignedTo = "",
                EndDate = DateTime.Now.AddDays(5),
                StartDate = DateTime.Today.AddDays(1)
            });
            
            Assert.AreEqual(true, result.Errors.Any());
            Assert.AreEqual(true, result.Errors.Any(v=>v.ErrorMessage == "'Subject' must not be empty."));
        }
    }
}