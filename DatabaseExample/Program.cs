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

var i = 0;

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


    Personal addedPersonal = new Personal
    {
        UserId = addedUser.Id,
        Salary = personalUsers[i].Salary,
        SSN = personalUsers[i].SSN,
    };
    db.Personals.Add(addedPersonal);

    Student addedStudent = new Student
    {
        UserId = addedUser.Id,
        Number = studentUsers[i].Number,
        Absenteeism = studentUsers[i].Absenteeism,
        Marks = studentUsers[i].Marks
    };

    Jobber addedJobber = new Jobber
    {
        UserId = addedUser.Id,
        Plate = jobberUsers[i].Plate,
        WorkArea = jobberUsers[i].WorkArea
    };

    i++;
    
});


db.SaveChanges();

