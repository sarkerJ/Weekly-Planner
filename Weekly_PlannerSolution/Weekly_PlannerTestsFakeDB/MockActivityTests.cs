using NUnit.Framework;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Weekly_PlannerDataLayer;
using System;
using NUnit.Framework.Constraints;
using Weekly_PlannerDataLayer.Services;
using System.Collections.Generic;
using Weekly_Planner_BusinessLayer;
using Moq;


namespace Weekly_PlannetTests
{
    class MockActivityTest
    {
        private Mock<IActivityService> _mockActivityService;
        private Mock<IDayService> _mockDayService;
        private Mock<CRUDManagerActivity> _crudActivity;

        private CRUDManagerActivity _crudActivity1;

        [SetUp]
        public void SetUp()
        {
            _crudActivity = new Mock<CRUDManagerActivity>();

            _mockActivityService = new Mock<IActivityService>();
            _mockDayService = new Mock<IDayService>();
            _crudActivity1 = new CRUDManagerActivity(_mockActivityService.Object, _mockDayService.Object);
        }


        [Test]
        [Category("Mock CrudmanagerActivity Test")]
        public void Given3Strings_CreateActivity_CallsAddActivity_AndUpdate_ExactlyOnce()
        {
            var getDay = new WeekDay() { Day = "Tuesday" };
            var Activity1 = new Activity() { Name = "Actvity1", Content = "Content1", WeekDays = getDay };

            _mockDayService.Setup(s => s.GetDayByString("Tuesday")).Returns(getDay);
            _crudActivity1.CreateActivity("Activity1", "Content1", "Tuesday");
            
            _mockActivityService.Verify(x => x.AddActivity(It.IsAny<Activity>()), Times.AtLeastOnce); //spy
            _mockActivityService.Verify(x => x.UpdateActivity(), Times.Once);  //spy

        }

        [Test]
        [Category("Mock CrudmanagerActivity Test")]
        public void AddingDuplicate_Activity_ThrowsException()
        {
            _mockDayService.Setup(s => s.GetDayByString("Tuesday")).Returns(new WeekDay() { WeekDayId = 1, Day = "Tuesday" });
            _mockActivityService.Setup(s => s.GetActivityByName("Activity1")).Throws<ArgumentNullException>();

            //  Assert.Throws<ArgumentNullException>(() => _crudActivity1.CreateActivity("Activity1", "Content1", "Tuesday); //classic assert
            Assert.That(() => _crudActivity1.CreateActivity("Activity1", "Content1", "Tuesday"), Throws.TypeOf<ArgumentNullException>()); //constraint assert
        }

        [Test]
        [Category("Mock CrudmanagerActivity Test")]
        public void GivenAString_SetCurrentDayCorrectly()
        {
            _mockDayService.Setup(s => s.GetDayByString("Tuesday")).Returns(new WeekDay() { WeekDayId = 1, Day = "Tuesday" });
            _crudActivity1.SetSelectedDay("Tuesday");
            var getDay = _crudActivity1.CurrentDay;
            Assert.That(getDay.Day, Is.EqualTo("Tuesday"));
        }

        [Test]
        [Category("Mock CrudmanagerActivity Test")]
        public void GivenAnId_ToEditActivity_UpdateActivity_IsCalledOnce()
        {
            _mockActivityService.Setup(s => s.GetActivityById(1)).Returns(new Activity() { ActivityId = 1, Name = "Actvity1", Content = "Content", WeekDayId = 2 });
            _mockDayService.Setup(s => s.GetDayByString("Wednesday")).Returns(new WeekDay() { WeekDayId = 1, Day = "Wednesday" });

            _crudActivity1.EditActivity(1,"Activity1", "Content1","Wednesday");
            _mockActivityService.Verify(x => x.UpdateActivity(), Times.Once);  //spy
            _mockActivityService.Verify(x => x.UpdateActivity(), Times.AtMostOnce);  //spy

        }


        [Test]
        [Category("Mock CrudmanagerActivity Test")]
        public void GivenAnId_ToDeleteFunction_DeleteActivity_IsCalledOnce()
        {
            Activity activity = new Activity() { ActivityId = 1, Name = "Actvity1", Content = "Content", WeekDayId = 2 };
            _mockActivityService.Setup(s => s.GetActivityById(1)).Returns(activity);
            _crudActivity1.DeleteActivity(1);

            _mockActivityService.Verify(x => x.DeleteActivity(activity), Times.Once); //spy
            _mockActivityService.Verify(x => x.DeleteActivity(activity), Times.AtMostOnce); //spy

        }
    }
}
