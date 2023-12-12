using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB_API_1.Models
{
    public sealed class Alunno
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public int ClassroomId { get; set; }

        public Alunno(int id, string name, string surname, int classroomId)
        {
            Id = id;
            Name = name;
            Surname = surname;
            ClassroomId = classroomId;
        }
    }
}