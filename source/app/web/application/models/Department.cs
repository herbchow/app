using System;

namespace app.web.application
{
    public class Department
    {
        public string name { get; set; }
        public bool has_sub_departments { get; set; }
        public Guid departmentId { get; set; }
    }
}