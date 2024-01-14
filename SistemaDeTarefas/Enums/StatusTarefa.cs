using System.ComponentModel;

namespace SistemaDeTarefas.Enums
{
    public enum StatusTarefa
    {
        [Description("To do")]
        ToDo = 1,
        [Description("On going")]
        OnGoing = 2,
        [Description("Completed")]
        Completed
    }
}
