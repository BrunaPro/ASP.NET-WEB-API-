using System.ComponentModel;

namespace Task_System.Enums
{
    public enum TaskStatus
    {
        [Description("To do ")]
        ToDo =1,
        [Description("Doing ")]
        Doing =2,
        [Description("Done")]
        Done =3 

    }
}
