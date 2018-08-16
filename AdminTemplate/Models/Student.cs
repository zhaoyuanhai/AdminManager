using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AdminTemplate.Models
{
    public class Student
    {
        public Student(string name, int age, bool isBoy, string url)
        {
            this.Name = name;
            this.Age = age;
            this.Gender = isBoy;
            this.Url = url;
        }

        [UIHint("HiddenInput")]
        public int Id { get; set; }

        [DisplayName("姓名")]
        public string Name { get; set; }

        [DisplayName("年龄")]
        public int Age { get; set; }

        [DisplayName("性别")]
        public bool Gender { get; set; }

        [UIHint("Url")]
        public string Url { get; set; }
    }
}