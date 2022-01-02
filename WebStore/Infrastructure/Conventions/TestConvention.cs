using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace WebStore.Infrastructure.Conventions
{
    // наследник IControllerModelConvention
    public class TestConvention : IControllerModelConvention
    {
        // вызывается для каждого контроллера
        public void Apply(ControllerModel controller)
        {
            Debug.WriteLine(controller.Actions.FirstOrDefault().DisplayName);
        }
    }
}
