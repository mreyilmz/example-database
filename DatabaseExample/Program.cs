// See https://aka.ms/new-console-template for more information
using DatabaseExample.Datas;
using DatabaseExample.Entities;
using DatabaseExample.Repositories;
using Newtonsoft.Json;
using System.Collections;

var users = JsonConvert.DeserializeObject<IList<User>>(UserDatas.UserJson);
var personalUsers = JsonConvert.DeserializeObject<IList<Personal>>(PersonalDatas.PersonalJson);
var studentUsers = JsonConvert.DeserializeObject<IList<Student>>(StudentDatas.StudentJson);
var jobberUsers = JsonConvert.DeserializeObject<IList<Jobber>>(JobberDatas.JobberJson);

ExampleDbContext db = new();

users.ToList().ForEach(user =>
{
    User addedUser = new User
    {
        UserName = user.UserName,
        FirstName = user.FirstName,
        LastName = user.LastName,
        Password = user.Password,
        IdentificationNumber = user.IdentificationNumber,
        IsActive = user.IsActive
    };
    db.Users.Add(addedUser);

    personalUsers.ToList().ForEach(personal =>
    {
        Personal addedPersonal = new Personal
        {
            UserId = addedUser.Id,
            Salary = personal.Salary,
            SSN = personal.SSN,
        };
        db.Personals.Add(addedPersonal);
    });

    studentUsers.ToList().ForEach(student =>
    {
        Student addedStudent = new Student
        {
            UserId = addedUser.Id,
            Number = student.Number,
            Absenteeism = student.Absenteeism,
            Marks = student.Marks
        };
    });

    jobberUsers.ToList().ForEach(jobber =>
    {
        Jobber addedJobber = new Jobber
        {
            UserId = addedUser.Id,
            Plate = jobber.Plate,
            WorkArea = jobber.WorkArea
        };
    });
});





db.SaveChanges();

